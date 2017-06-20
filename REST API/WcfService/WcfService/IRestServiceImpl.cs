using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using WcfService.Contracts;

namespace WcfService
{
    [ServiceContract]
    public interface IRestServiceImpl
    {
        // Service
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/status")]
        void GetStatus();


        // Rooms
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "/rooms?token={token}")]
        List<RoomContract> GetRooms(string token);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/rooms/{id}?token={token}")]
        RoomContract GetRoom(string id, string token);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "/rooms/avaiable?token={token}")]
        List<RoomContract> GetAvailableRooms(ReservationContract reservation, string token);


        // Booking
        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "/reservations/book?token={token}")]
        void CreateReservation(ReservationContract reservation, string token);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "/reservations?token={token}")]
        ReservationContract GetReservation(ReservationContract reservation, string token);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "/reservations/checkin?token={token}")]
        List<ReservationContract> GetCheckIn(ReservationContract reservation, string token);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "/reservations/checkout?token={token}")]
        List<ReservationContract> GetCheckOut(ReservationContract reservation, string token);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "/reservations/span?token={token}")]
        List<ReservationContract> GetReservationsSpan(ReservationContract reservation, string token);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "/reservations/{id}/checkin?token={token}")]
        void CheckIn(string id, string token);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "/reservations/{id}/checkout?token={token}")]
        void CheckOut(string id, string token);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/reservations/cancel/{id}?token={token}")]
        void CancelReservation(string id, string token);



        // Employees
        [OperationContract]
        [WebInvoke(Method = "GET",
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "/employees?token={token}")]
        List<EmployeeContract> GetEmployees(string token);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/employees/{username}?token={token}")]
        EmployeeContract GetEmployee(string username, string token);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/employees/{id}/remove?token={token}")]
        void RemoveEmployee(string id, string token);

        [OperationContract]
        [WebInvoke(Method = "GET",
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "/employees/titles?token={token}")]
        List<JobTitleContract> GetJobTitles(string token);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "/employees/authenticate?token={token}")]
        EmployeeContract AuthenticateEmployee(AuthenticateContract auth, string token);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "/employees/create?token={token}")]
        void CreateEmployee(EmployeeContract auth, string token);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "employees/{id}/permissions/add?token={token}")]
        void CreatePermissions(List<Permission> permissions, string id, string token);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "employees/{id}/permissions/remove?token={token}")]
        void RemovePermissions(List<Permission> permissions, string id, string token);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "/employees/check/username?token={token}")]
        void CheckUserName(EmployeeContract auth, string token);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "/employees/check/email?token={token}")]
        void CheckEmail(EmployeeContract auth, string token);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "/employees/create/resetkey?token={token}")]
        void CreateResetKey(EmployeeContract auth, string token);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "/employees/salt?token={token}")]
        AuthenticateContract GetEmployeeSalt(EmployeeContract employee, string token);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "/employees/update/password?token={token}")]
        void UpdatePassword(EmployeeContract employee, string token);



        // Favorites
        [OperationContract]
        [WebInvoke(Method = "GET",
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "/favorites?token={token}")]
        List<Permission> GetFavorites(string token);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedResponse,
            UriTemplate = "/favorites/{id}?token={token}")]
        List<EmployeeHasPermission> GetEmployeeFavorites(string id, string token);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "/favorites/update/{id}?token={token}")]
        bool UpdateEmployeeFavorite(FavoriteContract favorite, string id, string token);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "/favorites/create/{id}?token={token}")]
        bool CreateEmployeeFavorite(FavoriteContract favorite, string id, string token);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "/favorites/delete/{id}?token={token}")]
        string DeleteEmployeeFavorite(FavoriteContract favorite, string id, string token);


        // Tickets
        [OperationContract]
        [WebInvoke(Method = "GET",
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "/tickets/housekeeping?token={token}")]
        List<TicketContract> GetAllHousekeepingTickets(string token);

        [OperationContract]
        [WebInvoke(Method = "GET",
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "/tickets/maintenance?token={token}")]
        List<TicketContract> GetAllMaintenanceTickets(string token);

        [OperationContract]
        [WebInvoke(Method = "GET",
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "/tickets/housekeeping/{id}?token={token}")]
        List<TicketContract> GetUserHousekeepingTickets(string id, string token);

        [OperationContract]
        [WebInvoke(Method = "GET",
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "/tickets/maintenance/{id}?token={token}")]
        List<TicketContract> GetUserMaintenanceTickets(string id, string token);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "/tickets/create?token={token}")]
        void CreateTicket(TicketContract ticket, string token);

        [OperationContract]
        [WebInvoke(Method = "GET",
          ResponseFormat = WebMessageFormat.Json,
          UriTemplate = "/tickets/{id}/remove?token={token}")]
        void Delete(string id, string token);


        // Reservations
        


        //// /invoices
        //[OperationContract]
        //[WebInvoke(Method = "GET",
        //    ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.Wrapped,
        //    UriTemplate = "/invoices?token={token}")]
        //Stream GetInvoices(string token);

        //[OperationContract]
        //[WebInvoke(Method = "GET",
        //   ResponseFormat = WebMessageFormat.Json,
        //   BodyStyle = WebMessageBodyStyle.Wrapped,
        //   UriTemplate = "/invoices/{id}?token={token}")]
        //Stream GetInvoice(string id, string token);

        //[OperationContract]
        //[WebInvoke(Method = "POST",
        //    RequestFormat = WebMessageFormat.Json,
        //    ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.Bare,
        //    UriTemplate = "/invoices?token={token}")]
        //bool CreateInvoice(InvoiceContract invoice, string token);


        //// /guests
        //[OperationContract]
        //[WebInvoke(Method = "GET",
        //    ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.Wrapped,
        //    UriTemplate = "/guests?token={token}")]
        //Stream GetGuests(string token);

        //[OperationContract]
        //[WebInvoke(Method = "GET",
        //    ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.Wrapped,
        //    UriTemplate = "/guests/{id}?token={token}")]
        //Stream GetGuest(string id, string token);

        //[OperationContract]
        //[WebInvoke(Method = "POST",
        //    RequestFormat = WebMessageFormat.Json,
        //    ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.Bare,
        //    UriTemplate = "/guests?token={token}")]
        //bool CreateGuest(GuestContract guest, string token);


        // Token Routes
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/tokens/temporary")]
        string CreateTemporaryToken();

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/tokens/{id}/create?token={token}")]
        string CreateToken(string id, string token);


        // Software
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/software/latest?token={token}")]
        VersionContract GetLatestVersion(string token);


        // Logs
        [OperationContract]
        [WebInvoke(Method = "GET",
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "/logs/error?token={token}")]
        List<LogContract> GetErrorLogs(string token);

        [OperationContract]
        [WebInvoke(Method = "GET",
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "/logs/action?token={token}")]
        List<LogContract> GetActionLogs(string token);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "/logs/error/create?token={token}")]
        void CreateErrorLog(LogContract log, string token);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "/logs/action/create?token={token}")]
        void CreateActionLog(LogContract log, string token);
    }
}
