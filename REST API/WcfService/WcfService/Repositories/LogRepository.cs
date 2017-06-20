using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.ServiceModel.Web;
using WcfService.Contracts;

namespace WcfService.Repositories
{
    public class LogRepository
    {
        private readonly GuestBookEntities _guestBookEntities;

        public LogRepository(GuestBookEntities guestbookEntities)
        {
            _guestBookEntities = guestbookEntities;
        }


        public void CreateError(LogContract errorLog)
        {
            var log = _guestBookEntities.Logs.Create();

            log.employee_id = errorLog.employee_id;
            log.occured_at = DateTime.Now;
            log.message = errorLog.message;
            log.log_type = "ErrorLog";
            

            _guestBookEntities.Entry(log).State = EntityState.Added;
            _guestBookEntities.SaveChanges();

            throw new WebFaultException(HttpStatusCode.Created);

        }

        public void CreateAction(LogContract actionLog)
        {
            var log = _guestBookEntities.Logs.Create();

            log.employee_id = actionLog.employee_id;
            log.workstation = actionLog.workstation;
            log.occured_at = DateTime.Now;
            log.@event = actionLog.@event;
            log.message = actionLog.message;
            log.log_type = "ActionLog";


            _guestBookEntities.Entry(log).State = EntityState.Added;
            _guestBookEntities.SaveChanges();

            throw new WebFaultException(HttpStatusCode.Created);
        }

        public List<LogContract> GetErrorLog()
        {
            List<LogContract> errorLogs = new List<LogContract>();

            foreach (Log log in _guestBookEntities.Set<Log>().Where(x => x.log_type == "ErrorLog").ToList())
            {
                LogContract logContract = new LogContract()
                {
                    employee_id = log.employee_id,
                    occured_at = log.occured_at,
                    message = log.message

                };

            errorLogs.Add(logContract);
            }

            return errorLogs;
        }

        public List<LogContract> GetActionLog()
        {
            List<LogContract> actionLogs = new List<LogContract>();

            foreach (Log log in _guestBookEntities.Set<Log>().Where(x => x.log_type == "ActionLog").ToList())
            {
                LogContract logContract = new LogContract()
                {
                    employee_id = log.employee_id,
                    occured_at = log.occured_at,
                    message = log.message

                };

                actionLogs.Add(logContract);
            }

            return actionLogs;
        }
    }
}