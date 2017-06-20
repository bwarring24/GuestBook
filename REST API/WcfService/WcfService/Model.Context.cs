﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WcfService
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class GuestBookEntities : DbContext
    {
        public GuestBookEntities()
            : base("name=GuestBookEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Charge> Charges { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeHasPermission> EmployeeHasPermissions { get; set; }
        public virtual DbSet<Guest> Guests { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<JobTitle> JobTitles { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<LogType> LogTypes { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<RoomForReservation> RoomForReservations { get; set; }
        public virtual DbSet<RoomType> RoomTypes { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<TicketType> TicketTypes { get; set; }
        public virtual DbSet<Token> Tokens { get; set; }
        public virtual DbSet<BookedRoom> BookedRooms { get; set; }
        public virtual DbSet<CheckInList> CheckInLists { get; set; }
        public virtual DbSet<CheckOutList> CheckOutLists { get; set; }
        public virtual DbSet<HousekeepingTicketList> HousekeepingTicketLists { get; set; }
        public virtual DbSet<MaintenanceTicketList> MaintenanceTicketLists { get; set; }
        public virtual DbSet<OutstandingInvoice> OutstandingInvoices { get; set; }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual int spAddEmployee(string first_name, string last_name, string email, string phone_number, string password_hash, string salt, Nullable<byte> access_level)
        {
            var first_nameParameter = first_name != null ?
                new ObjectParameter("first_name", first_name) :
                new ObjectParameter("first_name", typeof(string));
    
            var last_nameParameter = last_name != null ?
                new ObjectParameter("last_name", last_name) :
                new ObjectParameter("last_name", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var phone_numberParameter = phone_number != null ?
                new ObjectParameter("phone_number", phone_number) :
                new ObjectParameter("phone_number", typeof(string));
    
            var password_hashParameter = password_hash != null ?
                new ObjectParameter("password_hash", password_hash) :
                new ObjectParameter("password_hash", typeof(string));
    
            var saltParameter = salt != null ?
                new ObjectParameter("salt", salt) :
                new ObjectParameter("salt", typeof(string));
    
            var access_levelParameter = access_level.HasValue ?
                new ObjectParameter("access_level", access_level) :
                new ObjectParameter("access_level", typeof(byte));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spAddEmployee", first_nameParameter, last_nameParameter, emailParameter, phone_numberParameter, password_hashParameter, saltParameter, access_levelParameter);
        }
    
        public virtual int spAddPermissionForEmployee(Nullable<int> employee_id, string permission_name, Nullable<byte> priority)
        {
            var employee_idParameter = employee_id.HasValue ?
                new ObjectParameter("employee_id", employee_id) :
                new ObjectParameter("employee_id", typeof(int));
    
            var permission_nameParameter = permission_name != null ?
                new ObjectParameter("permission_name", permission_name) :
                new ObjectParameter("permission_name", typeof(string));
    
            var priorityParameter = priority.HasValue ?
                new ObjectParameter("priority", priority) :
                new ObjectParameter("priority", typeof(byte));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spAddPermissionForEmployee", employee_idParameter, permission_nameParameter, priorityParameter);
        }
    
        public virtual int spAddRoomToReservation(Nullable<int> reservation_number, string room_type)
        {
            var reservation_numberParameter = reservation_number.HasValue ?
                new ObjectParameter("reservation_number", reservation_number) :
                new ObjectParameter("reservation_number", typeof(int));
    
            var room_typeParameter = room_type != null ?
                new ObjectParameter("room_type", room_type) :
                new ObjectParameter("room_type", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spAddRoomToReservation", reservation_numberParameter, room_typeParameter);
        }
    
        public virtual int spCancelReservation(Nullable<int> reservation_number)
        {
            var reservation_numberParameter = reservation_number.HasValue ?
                new ObjectParameter("reservation_number", reservation_number) :
                new ObjectParameter("reservation_number", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spCancelReservation", reservation_numberParameter);
        }
    
        public virtual int spChangePermissionPriorityForEmployee(Nullable<int> employee_id, string permission_name, Nullable<byte> new_priority)
        {
            var employee_idParameter = employee_id.HasValue ?
                new ObjectParameter("employee_id", employee_id) :
                new ObjectParameter("employee_id", typeof(int));
    
            var permission_nameParameter = permission_name != null ?
                new ObjectParameter("permission_name", permission_name) :
                new ObjectParameter("permission_name", typeof(string));
    
            var new_priorityParameter = new_priority.HasValue ?
                new ObjectParameter("new_priority", new_priority) :
                new ObjectParameter("new_priority", typeof(byte));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spChangePermissionPriorityForEmployee", employee_idParameter, permission_nameParameter, new_priorityParameter);
        }
    
        public virtual int spCreateInvoice(Nullable<int> reservation_number)
        {
            var reservation_numberParameter = reservation_number.HasValue ?
                new ObjectParameter("reservation_number", reservation_number) :
                new ObjectParameter("reservation_number", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spCreateInvoice", reservation_numberParameter);
        }
    
        public virtual int spCreateReservation(Nullable<int> guest_id, Nullable<System.DateTime> start_date, Nullable<System.DateTime> end_date)
        {
            var guest_idParameter = guest_id.HasValue ?
                new ObjectParameter("guest_id", guest_id) :
                new ObjectParameter("guest_id", typeof(int));
    
            var start_dateParameter = start_date.HasValue ?
                new ObjectParameter("start_date", start_date) :
                new ObjectParameter("start_date", typeof(System.DateTime));
    
            var end_dateParameter = end_date.HasValue ?
                new ObjectParameter("end_date", end_date) :
                new ObjectParameter("end_date", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spCreateReservation", guest_idParameter, start_dateParameter, end_dateParameter);
        }
    
        public virtual int spRemovePermissionForEmployee(Nullable<int> employee_id, string permission_name)
        {
            var employee_idParameter = employee_id.HasValue ?
                new ObjectParameter("employee_id", employee_id) :
                new ObjectParameter("employee_id", typeof(int));
    
            var permission_nameParameter = permission_name != null ?
                new ObjectParameter("permission_name", permission_name) :
                new ObjectParameter("permission_name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spRemovePermissionForEmployee", employee_idParameter, permission_nameParameter);
        }
    
        public virtual int spRemoveRoomFromReservation(Nullable<int> reservation_number, string room_type)
        {
            var reservation_numberParameter = reservation_number.HasValue ?
                new ObjectParameter("reservation_number", reservation_number) :
                new ObjectParameter("reservation_number", typeof(int));
    
            var room_typeParameter = room_type != null ?
                new ObjectParameter("room_type", room_type) :
                new ObjectParameter("room_type", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spRemoveRoomFromReservation", reservation_numberParameter, room_typeParameter);
        }
    
        public virtual ObjectResult<spShowAllReservations_Result> spShowAllReservations(Nullable<System.DateTime> start_date, Nullable<System.DateTime> end_date)
        {
            var start_dateParameter = start_date.HasValue ?
                new ObjectParameter("start_date", start_date) :
                new ObjectParameter("start_date", typeof(System.DateTime));
    
            var end_dateParameter = end_date.HasValue ?
                new ObjectParameter("end_date", end_date) :
                new ObjectParameter("end_date", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spShowAllReservations_Result>("spShowAllReservations", start_dateParameter, end_dateParameter);
        }
    
        public virtual ObjectResult<spShowAvailableRooms_Result> spShowAvailableRooms(Nullable<System.DateTime> start_date, Nullable<System.DateTime> end_date)
        {
            var start_dateParameter = start_date.HasValue ?
                new ObjectParameter("start_date", start_date) :
                new ObjectParameter("start_date", typeof(System.DateTime));
    
            var end_dateParameter = end_date.HasValue ?
                new ObjectParameter("end_date", end_date) :
                new ObjectParameter("end_date", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spShowAvailableRooms_Result>("spShowAvailableRooms", start_dateParameter, end_dateParameter);
        }
    
        public virtual ObjectResult<spShowEmployeePermissions_Result> spShowEmployeePermissions(Nullable<int> employee_id)
        {
            var employee_idParameter = employee_id.HasValue ?
                new ObjectParameter("employee_id", employee_id) :
                new ObjectParameter("employee_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spShowEmployeePermissions_Result>("spShowEmployeePermissions", employee_idParameter);
        }
    
        public virtual ObjectResult<spShowRoomsWithReservation_Result> spShowRoomsWithReservation(Nullable<int> reservation_number)
        {
            var reservation_numberParameter = reservation_number.HasValue ?
                new ObjectParameter("reservation_number", reservation_number) :
                new ObjectParameter("reservation_number", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spShowRoomsWithReservation_Result>("spShowRoomsWithReservation", reservation_numberParameter);
        }
    
        public virtual int spUpdateEmployee(Nullable<int> employee_id, string username, string first_name, string last_name, string email, string phone_number, string password_hash, string salt, Nullable<byte> access_level, string reset_key)
        {
            var employee_idParameter = employee_id.HasValue ?
                new ObjectParameter("employee_id", employee_id) :
                new ObjectParameter("employee_id", typeof(int));
    
            var usernameParameter = username != null ?
                new ObjectParameter("username", username) :
                new ObjectParameter("username", typeof(string));
    
            var first_nameParameter = first_name != null ?
                new ObjectParameter("first_name", first_name) :
                new ObjectParameter("first_name", typeof(string));
    
            var last_nameParameter = last_name != null ?
                new ObjectParameter("last_name", last_name) :
                new ObjectParameter("last_name", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var phone_numberParameter = phone_number != null ?
                new ObjectParameter("phone_number", phone_number) :
                new ObjectParameter("phone_number", typeof(string));
    
            var password_hashParameter = password_hash != null ?
                new ObjectParameter("password_hash", password_hash) :
                new ObjectParameter("password_hash", typeof(string));
    
            var saltParameter = salt != null ?
                new ObjectParameter("salt", salt) :
                new ObjectParameter("salt", typeof(string));
    
            var access_levelParameter = access_level.HasValue ?
                new ObjectParameter("access_level", access_level) :
                new ObjectParameter("access_level", typeof(byte));
    
            var reset_keyParameter = reset_key != null ?
                new ObjectParameter("reset_key", reset_key) :
                new ObjectParameter("reset_key", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spUpdateEmployee", employee_idParameter, usernameParameter, first_nameParameter, last_nameParameter, emailParameter, phone_numberParameter, password_hashParameter, saltParameter, access_levelParameter, reset_keyParameter);
        }
    
        public virtual int spCreateHousekeepingTicketFromReservation(Nullable<int> reservation_number)
        {
            var reservation_numberParameter = reservation_number.HasValue ?
                new ObjectParameter("reservation_number", reservation_number) :
                new ObjectParameter("reservation_number", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spCreateHousekeepingTicketFromReservation", reservation_numberParameter);
        }
    }
}