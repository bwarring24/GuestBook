using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.ServiceModel.Web;
using System.Web;
using WcfService.Contracts;

namespace WcfService.Repositories
{
    public class FavoriteRepository
    {
        private readonly GuestBookEntities _guestBookEntities;

        public FavoriteRepository(GuestBookEntities guestBookEntities)
        {
            _guestBookEntities = guestBookEntities;
        }

        public List<Permission> GetFavorites()
        {
            return _guestBookEntities.Set<Permission>().ToList();
        }

        public List<EmployeeHasPermission> GetEmployeeFavorites(string idStr)
        {
            int id;
            int.TryParse(idStr, out id);

            return _guestBookEntities.EmployeeHasPermissions.Where(x => x.employee_id == id).ToList();
        }

        public bool Update(FavoriteContract favorite, string idStr)
        {
            int id;
            byte priority;

            int.TryParse(idStr, out id);
            byte.TryParse(favorite.priority, out priority);

            _guestBookEntities.spChangePermissionPriorityForEmployee(id, favorite.permission_name, priority);

            return true;
        }

        public bool Create(FavoriteContract favorite, string idStr)
        {
            int id;
            byte priority;

            int.TryParse(idStr, out id);
            byte.TryParse(favorite.priority, out priority);

            _guestBookEntities.spChangePermissionPriorityForEmployee(id, favorite.permission_name, priority);

            return true;
        }

        public bool Delete(FavoriteContract favorite, string idStr)
        {
            int id;
            int.TryParse(idStr, out id);
            _guestBookEntities.spChangePermissionPriorityForEmployee(id, favorite.permission_name, null);

            return true;
        }
    }
}