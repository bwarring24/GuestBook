using System.Net;
using System.ServiceModel.Web;
using Newtonsoft.Json;
using WcfService.Repositories;
using WcfService.Contracts;
using System.Collections.Generic;
using System;

namespace WcfService
{

    public class RestServiceImpl : IRestServiceImpl
    {
        TokenRepository tokenRepo = new TokenRepository(new GuestBookEntities());
        RoomRepository roomRepo = new RoomRepository(new GuestBookEntities());
        EmployeeRepository employeeRepo = new EmployeeRepository(new GuestBookEntities());
        FavoriteRepository favoriteRepo = new FavoriteRepository(new GuestBookEntities());
        ReservationRepository reservationRepo = new ReservationRepository(new GuestBookEntities());
        SoftwareRepository softwareRepo = new SoftwareRepository();
        LogRepository logRepo = new LogRepository(new GuestBookEntities());
        TicketRepository ticketRepo = new TicketRepository(new GuestBookEntities());

        public void GetStatus()
        {
            // Make DB checks here eventually too?
            throw new WebFaultException(HttpStatusCode.OK);
        }


        #region Room Routes

        /// <summary>
        /// Returns JSON string of a single room and it's information
        /// </summary>
        /// <param name="roomNumber"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public RoomContract GetRoom(string roomNumber, string token)
        {
            tokenRepo.Authenticate(token);

            return roomRepo.GetRoom(roomNumber);
        }

        /// <summary>
        /// Returns JSON string of all rooms and their information
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public List<RoomContract> GetRooms(string token)
        {
            tokenRepo.Authenticate(token);

            return roomRepo.GetRooms();
        }

        public List<RoomContract> GetAvailableRooms(ReservationContract reservation, string token)
        {
            tokenRepo.Authenticate(token);

            return roomRepo.GetAvaiableRooms(reservation);
        }

        #endregion

        #region Employee Routes

        public List<EmployeeContract> GetEmployees(string token)
        {
            tokenRepo.Authenticate(token);

            return employeeRepo.GetAll();
        }

        public EmployeeContract GetEmployee(string username, string token)
        {
            tokenRepo.Authenticate(token);

            return employeeRepo.Get(username);
        }

        public void RemoveEmployee(string id, string token)
        {
            tokenRepo.Authenticate(token);

            employeeRepo.Remove(id);
        }

        public List<JobTitleContract> GetJobTitles(string token)
        {
            tokenRepo.Authenticate(token);

            return employeeRepo.GetJobTitles();
        }

        public EmployeeContract AuthenticateEmployee(AuthenticateContract auth, string token)
        {
            tokenRepo.Authenticate(token);

            return employeeRepo.Authenticate(auth);
        }

        public void CreateEmployee(EmployeeContract employee, string token)
        {
            tokenRepo.Authenticate(token);

            employeeRepo.Create(employee);
        }

        public void CreatePermissions(List<Permission> permissions, string id, string token)
        {
            tokenRepo.Authenticate(token);

            employeeRepo.CreatePermissions(permissions, id);
        }

        public void RemovePermissions(List<Permission> permissions, string id, string token)
        {
            tokenRepo.Authenticate(token);

            employeeRepo.RemovePermissions(permissions, id);
        }

        public void CheckUserName(EmployeeContract employee, string token)
        {
            tokenRepo.Authenticate(token);

            employeeRepo.CheckUsername(employee);
        }

        public void CheckEmail(EmployeeContract employee, string token)
        {
            tokenRepo.Authenticate(token);

            employeeRepo.CheckEmail(employee);
        }

        public AuthenticateContract GetEmployeeSalt(EmployeeContract employee, string token)
        {
            tokenRepo.Authenticate(token);

            return employeeRepo.GetSalt(employee);
        }

        public void UpdatePassword(EmployeeContract employee, string token)
        {
            tokenRepo.Authenticate(token);

            employeeRepo.UpdatePassword(employee);
        }

        public void CreateResetKey(EmployeeContract employee, string token)
        {
            tokenRepo.Authenticate(token);

            employeeRepo.CreateResetKey(employee);
        }


        #endregion

        #region Token Routes

        public string CreateTemporaryToken()
        {
            return JsonConvert.SerializeObject(tokenRepo.CreateTemporaryToken());
        }

        public string CreateToken(string id, string tokenTemp)
        {
            Token token = tokenRepo.CreateToken(id, tokenTemp);

            if (token == null)
            {
                throw new WebFaultException((HttpStatusCode.Unauthorized));
            }

            return JsonConvert.SerializeObject(token);
        }

        #endregion

        #region Favorite Routes

        public List<Permission> GetFavorites(string token)
        {
            tokenRepo.Authenticate(token);

            return favoriteRepo.GetFavorites();
        }

        public List<EmployeeHasPermission> GetEmployeeFavorites(string id, string token)
        {
            tokenRepo.Authenticate(token);

            return favoriteRepo.GetEmployeeFavorites(id);
        }

        public bool UpdateEmployeeFavorite(FavoriteContract favorite, string id, string token)
        {
            tokenRepo.Authenticate(token);

            return favoriteRepo.Update(favorite, id);
        }

        public bool CreateEmployeeFavorite(FavoriteContract favorite, string id, string token)
        {
            tokenRepo.Authenticate(token);

            return favoriteRepo.Create(favorite, id);
        }

        public string DeleteEmployeeFavorite(FavoriteContract favorite, string id, string token)
        {
            tokenRepo.Authenticate(token);

            return JsonConvert.SerializeObject(favoriteRepo.Delete(favorite, id));
        }

        #endregion

        #region Booking Routes
        
        public void CreateReservation(ReservationContract reservation, string token)
        {
            tokenRepo.Authenticate(token);

            reservationRepo.Create(reservation);
        }

        public ReservationContract GetReservation(ReservationContract reservation, string token)
        {
            tokenRepo.Authenticate(token);

            return reservationRepo.GetReservation(reservation, token);
        }

        public List<ReservationContract> GetReservationsSpan(ReservationContract reservation, string token)
        {
            tokenRepo.Authenticate(token);

            return reservationRepo.GetReservationsSpan(reservation.start_date, reservation.end_date);
        }

        public List<ReservationContract> GetCheckIn(ReservationContract reservation, string token)
        {
            tokenRepo.Authenticate(token);

            return reservationRepo.GetCheckIn(reservation.start_date);
        }

        public List<ReservationContract> GetCheckOut(ReservationContract reservation, string token)
        {
            tokenRepo.Authenticate(token);

            return reservationRepo.GetCheckOut(reservation.end_date);
        }

        public void CancelReservation(string id, string token)
        {
            tokenRepo.Authenticate(token);

            reservationRepo.Delete(id);
        }

        public void CheckIn(string id, string token)
        {
            tokenRepo.Authenticate(token);

            reservationRepo.CheckIn(id);
        }

        public void CheckOut(string id, string token)
        {
            tokenRepo.Authenticate(token);

            reservationRepo.CheckOut(id);
        }


        #endregion

        #region Software Routes

        /// <summary>
        /// Returns JSON string of a single room and it's information
        /// </summary>
        /// <param name="roomNumber"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public VersionContract GetLatestVersion(string token)
        {
            tokenRepo.Authenticate(token);

            return softwareRepo.GetLatestVersion();
        }

        #endregion

        #region Logs Routes

        public List<LogContract> GetErrorLogs(string token)
        {
            tokenRepo.Authenticate(token);

            return logRepo.GetErrorLog();
        }

        public List<LogContract> GetActionLogs(string token)
        {
            tokenRepo.Authenticate(token);

            return logRepo.GetActionLog();
        }

        public void CreateErrorLog(LogContract log, string token)
        {
            tokenRepo.Authenticate(token);

            logRepo.CreateError(log);
        }

        public void CreateActionLog(LogContract log, string token)
        {
            tokenRepo.Authenticate(token);

            logRepo.CreateAction(log);
        }

        #endregion

        #region Ticket Routes

        public List<TicketContract> GetAllHousekeepingTickets(string token)
        {
            tokenRepo.Authenticate(token);

            return ticketRepo.GetAllHousekeeping();
        }

        public List<TicketContract> GetAllMaintenanceTickets(string token)
        {
            tokenRepo.Authenticate(token);

            return ticketRepo.GetAllMaintenance();
        }

        public List<TicketContract> GetUserHousekeepingTickets(string id, string token)
        {
            tokenRepo.Authenticate(token);

            return ticketRepo.GetUserHousekeeping(id);
        }

        public List<TicketContract> GetUserMaintenanceTickets(string id, string token)
        {
            tokenRepo.Authenticate(token);

            return ticketRepo.GetUserMaintenance(id);
        }

        public void CreateTicket(TicketContract ticket, string token)
        {
            tokenRepo.Authenticate(token);

            ticketRepo.Create(ticket);
        }


        public void Delete(string ticketNumber, string token)
        {
            tokenRepo.Authenticate(token);

            ticketRepo.Delete(ticketNumber);
        }

        #endregion

    }
}