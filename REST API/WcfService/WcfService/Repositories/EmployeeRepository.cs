using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.ServiceModel.Web;
using WcfService.Contracts;

namespace WcfService.Repositories
{
    public class EmployeeRepository
    {
        private readonly GuestBookEntities _guestBookEntities;
        
        public EmployeeRepository(GuestBookEntities guestbookEntities)
        {
            _guestBookEntities = guestbookEntities;
        }

        public List<EmployeeContract> GetAll()
        {
            List<EmployeeContract> employees = new List<EmployeeContract>();

            foreach(Employee employee in _guestBookEntities.Set<Employee>().ToList())
            {
                EmployeeContract employeeContract = new EmployeeContract()
                {
                    employee_id = employee.employee_id,
                    username = employee.username,
                    first_name = employee.first_name,
                    last_name = employee.last_name,
                    email = employee.email,
                    phone_number = employee.phone_number,
                    access_level = employee.access_level,
                    title = employee.JobTitle.title,
                    token = GetToken(employee.employee_id),
                    permissions = GetPermissions(employee.employee_id)
                };

                employees.Add(employeeContract);
            }

            return employees;
        }

        public EmployeeContract Get(string username)
        {
            Employee employee = _guestBookEntities.Employees.FirstOrDefault(x => x.username == username);

            return new EmployeeContract()
            {
                employee_id = employee.employee_id,
                username = employee.username,
                first_name = employee.first_name,
                last_name = employee.last_name,
                email = employee.email,
                phone_number = employee.phone_number,
                access_level = employee.access_level
            };
        }

        public EmployeeContract Authenticate(AuthenticateContract auth)
        {
            Employee employee = _guestBookEntities.Employees.FirstOrDefault(x => x.username == auth.username);
            
            if (employee != null && employee.password_hash == auth.hash)
            {
                return new EmployeeContract
                {
                    employee_id = employee.employee_id,
                    username = employee.username,
                    first_name = employee.first_name,
                    last_name = employee.last_name,
                    email = employee.email,
                    phone_number = employee.phone_number,
                    access_level = employee.access_level,
                    title = employee.JobTitle.title,
                    token = GetToken(employee.employee_id),
                    permissions = GetPermissions(employee.employee_id)
                };
            }

            throw new WebFaultException(HttpStatusCode.NoContent);
        }

        public void Remove(string id)
        {
            
            var employee = _guestBookEntities.Employees.FirstOrDefault(x => x.employee_id == int.Parse(id));

            _guestBookEntities.Entry(employee).State = EntityState.Deleted;
            _guestBookEntities.SaveChanges();

            throw new WebFaultException(HttpStatusCode.Accepted);

        }

        public void CreatePermissions(List<Permission> permissions, string id)
        {
            foreach(Permission permission in permissions)
            {
                var perm = _guestBookEntities.EmployeeHasPermissions.Create();

                perm.employee_id = int.Parse(id);
                perm.permission_name = permission.permission_name;
                perm.priority = null;

                _guestBookEntities.Entry(perm).State = EntityState.Added;
                _guestBookEntities.SaveChanges();
            }
        }

        public void RemovePermissions(List<Permission> permissions, string id)
        {
            foreach (Permission permission in permissions)
            {
                var perm = _guestBookEntities.EmployeeHasPermissions.FirstOrDefault(x => x.permission_name == permission.permission_name);

                _guestBookEntities.Entry(perm).State = EntityState.Deleted;
                _guestBookEntities.SaveChanges();
            }
        }


        public void Create(EmployeeContract newEmployee)
        {
            Employee employee = _guestBookEntities.Employees.FirstOrDefault(x => x.username == newEmployee.username);

            if(employee != null && employee.username == newEmployee.username){
                throw new WebFaultException(HttpStatusCode.Conflict);
            }

            var emp = _guestBookEntities.Employees.Create();

            emp.access_level = Byte.Parse(newEmployee.access_level.ToString());
            emp.email = newEmployee.email;
            emp.first_name = newEmployee.first_name;
            emp.last_name = newEmployee.last_name;
            emp.password_hash = newEmployee.password_hash;
            emp.salt = newEmployee.salt;
            emp.username = newEmployee.username;
            emp.phone_number = newEmployee.phone_number;

            _guestBookEntities.Entry(emp).State = EntityState.Added;
            _guestBookEntities.SaveChanges();

            throw new WebFaultException(HttpStatusCode.Created);
        }

        public void CheckUsername(EmployeeContract newEmployee)
        {
            Employee employee = _guestBookEntities.Employees.FirstOrDefault(x => x.username == newEmployee.username);

            if(employee != null)
            {
                throw new WebFaultException(HttpStatusCode.Conflict);
            }

            throw new WebFaultException(HttpStatusCode.NoContent);
        }

        public List<JobTitleContract> GetJobTitles()
        {
            List<JobTitleContract> jobTitles = new List<JobTitleContract>();

            foreach (JobTitle title in _guestBookEntities.Set<JobTitle>().ToList())
            {
                JobTitleContract contract = new JobTitleContract
                {
                    access_level = title.access_level,
                    title = title.title,
                    description = title.description
                };

                jobTitles.Add(contract);
            }

            return jobTitles;
        }

        public void CheckEmail(EmployeeContract newEmployee)
        {
            Employee employee = _guestBookEntities.Employees.FirstOrDefault(x => x.email == newEmployee.email);

            if(employee != null)
            {
                throw new WebFaultException(HttpStatusCode.Conflict);
            }

            throw new WebFaultException(HttpStatusCode.NoContent);
        }

        public AuthenticateContract GetSalt(EmployeeContract loginEmployee)
        {
            Employee employee = _guestBookEntities.Employees.FirstOrDefault(x => x.username == loginEmployee.username);

            if(employee == null)
            {
                // User doesn't exist!
                throw new WebFaultException(HttpStatusCode.NoContent);
            }

            return new AuthenticateContract
            {
                salt = employee.salt
            };
        }

        public void UpdatePassword(EmployeeContract curEmployee)
        {
            Employee employee = _guestBookEntities.Employees.FirstOrDefault(x => x.email == curEmployee.email);

            if(employee.reset_key == curEmployee.reset_key)
            {
                employee.reset_key = "";
                employee.password_hash = curEmployee.password_hash;

                _guestBookEntities.SaveChanges();

                throw new WebFaultException(HttpStatusCode.OK);
            }

            throw new WebFaultException(HttpStatusCode.NoContent);
        }

        public void CreateResetKey(EmployeeContract curEmployee)
        {
            Employee employee = _guestBookEntities.Employees.FirstOrDefault(x => x.email == curEmployee.email);

            if (employee != null)
            {
                
                employee.reset_key = curEmployee.reset_key;
                _guestBookEntities.Entry(employee).State = EntityState.Modified;
                _guestBookEntities.SaveChanges();

                throw new WebFaultException(HttpStatusCode.OK);
            }

            throw new WebFaultException(HttpStatusCode.NoContent);
        }

        public string GetToken(int id)
        {
            return _guestBookEntities.Tokens.FirstOrDefault(x => x.employee_id == id).token1;
        }

        public List<spShowEmployeePermissions_Result> GetPermissions(int id)
        {
            return _guestBookEntities.spShowEmployeePermissions(id).ToList<spShowEmployeePermissions_Result>();
        }
    }
}