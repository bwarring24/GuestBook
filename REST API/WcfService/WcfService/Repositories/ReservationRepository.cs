using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.ServiceModel.Web;
using WcfService.Contracts;
using WcfService.User_Defined_Table_Types;

namespace WcfService.Repositories
{
    public class ReservationRepository
    {
        private readonly GuestBookEntities _guestBookEntities;

        public ReservationRepository(GuestBookEntities guestBookEntities)
        {
            _guestBookEntities = guestBookEntities;
        }


        /// <summary>
        /// Gets all check ins with the specified date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<ReservationContract> GetCheckIn(DateTime date)
        {
            List<ReservationContract> reservations = new List<ReservationContract>();

            foreach (CheckInList checkIn in _guestBookEntities.Set<CheckInList>().Where(x => x.start_date.Year == date.Year && x.start_date.Month == date.Month && x.start_date.Day == date.Day).ToList())
            {
                ReservationContract reservationContract = new ReservationContract()
                {
                    first_name = checkIn.first_name,
                    last_name = checkIn.last_name,
                    email = checkIn.email,
                    phone_number = checkIn.phone_number,
                    start_date = checkIn.start_date,
                    end_date = checkIn.end_date,
                    reservation_number = checkIn.reservation_number,
                    guest_id = checkIn.guest_id,
                };

                reservations.Add(reservationContract);
            }

            return reservations;
        }


        /// <summary>
        /// Gets all check outs for the specified date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<ReservationContract> GetCheckOut(DateTime date)
        {
            List<ReservationContract> reservations = new List<ReservationContract>();

            foreach (CheckOutList checkOut in _guestBookEntities.Set<CheckOutList>().Where(x => x.end_date.Year == date.Year && x.end_date.Month == date.Month && x.end_date.Day == date.Day).ToList())
            {
                ReservationContract reservationContract = new ReservationContract()
                {
                    first_name = checkOut.first_name,
                    last_name = checkOut.last_name,
                    email = checkOut.email,
                    phone_number = checkOut.phone_number,
                    start_date = checkOut.start_date,
                    end_date = checkOut.end_date,
                    reservation_number = checkOut.reservation_number,
                    guest_id = checkOut.guest_id,
                };

                reservations.Add(reservationContract);
            }

            return reservations;
        }


        /// <summary>
        /// Create a new reservation for a guest
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns></returns>
        public void Create(ReservationContract reservation)
        {
            Guest guest = _guestBookEntities.Guests.FirstOrDefault(x => x.first_name == reservation.first_name && x.last_name == reservation.last_name);

            if(guest == null)
            {
                var perm = _guestBookEntities.Guests.Create();

                perm.first_name = reservation.first_name;
                perm.last_name = reservation.last_name;
                perm.phone_number = reservation.phone_number;
                perm.email = reservation.email;

                _guestBookEntities.Entry(perm).State = EntityState.Added;
                _guestBookEntities.SaveChanges();
            }

            guest = _guestBookEntities.Guests.FirstOrDefault(x => x.first_name == reservation.first_name && x.last_name == reservation.last_name);


            var roomsDT = new DataTable();
            
            roomsDT.Columns.Add("room_type", typeof(string));
            roomsDT.Columns.Add("number_of_rooms", typeof(int));
            foreach (RoomToReserve room in reservation.reserveRooms)
            {
                DataRow row = roomsDT.NewRow();
                row["room_type"] = room.room_type;
                row["number_of_rooms"] = room.number_of_rooms;
                roomsDT.Rows.Add(row);
                
            }
            

            var parameters = new[] {
                new SqlParameter("@rooms", SqlDbType.Structured)
                {
                    Value = roomsDT,
                    TypeName = "dbo.RoomToReserve"
                },
                new SqlParameter("@guest_id", guest.guest_id),
                new SqlParameter("@start_date", reservation.start_date),
                new SqlParameter("@end_date", reservation.end_date)
            };

            _guestBookEntities.Database.ExecuteSqlCommand("exec dbo.spCreateReservation @rooms, @guest_id, @start_date, @end_date", parameters);

            throw new WebFaultException(HttpStatusCode.Created);
        }


        /// <summary>
        /// Cancel an existing reservation for a guest
        /// </summary>
        /// <param name="favorite"></param>
        /// <param name="idStr"></param>
        /// <returns></returns>
        public void Delete(string idStr)
        {
            int id;

            int.TryParse(idStr, out id);

            // TODO: Implement delete.... Stored Procedure?
        }

        public ReservationContract GetReservation(ReservationContract currentReservation, string id)
        {
            Guest guest = _guestBookEntities.Guests.FirstOrDefault(x => x.first_name == currentReservation.first_name && x.last_name == currentReservation.last_name);

            if(guest != null)
            {
                Reservation reservation = _guestBookEntities.Reservations.FirstOrDefault(x => x.guest_id == guest.guest_id && x.start_date.Year == currentReservation.start_date.Year && x.start_date.Month == currentReservation.start_date.Month && x.start_date.Day == currentReservation.start_date.Day && x.checked_in != true);

                if(reservation != null)
                {
                    List<BookedRoom> rooms = _guestBookEntities.Set<BookedRoom>().Where(x => x.reservation_number == reservation.reservation_number).ToList();

                    if(rooms != null)
                    {
                        ReservationContract reservationContract = new ReservationContract()
                        {
                            first_name = guest.first_name,
                            last_name = guest.last_name,
                            email = guest.email,
                            phone_number = guest.phone_number,
                            start_date = reservation.start_date,
                            end_date = reservation.end_date,
                            reservation_number = reservation.reservation_number,
                            rooms = rooms,
                            guest_id = reservation.guest_id,
                        };


                        return reservationContract;
                    }
                }
            }

            throw new WebFaultException(HttpStatusCode.NoContent);
        }


        public List<ReservationContract> GetReservationsSpan(DateTime startDate, DateTime endDate)
        {
            List<ReservationContract> reservations = new List<ReservationContract>();

            foreach (CheckInList checkIn in _guestBookEntities.Set<CheckInList>().Where(x => x.start_date.Date >= startDate.Date && x.start_date.Date <= endDate.Date).ToList())
            {
                ReservationContract reservationContract = new ReservationContract()
                {
                    first_name = checkIn.first_name,
                    last_name = checkIn.last_name,
                    email = checkIn.email,
                    phone_number = checkIn.phone_number,
                    start_date = checkIn.start_date,
                    end_date = checkIn.end_date,
                    reservation_number = checkIn.reservation_number,
                    guest_id = checkIn.guest_id,
                };

                reservations.Add(reservationContract);
            }

            return reservations;
        }

        public void CheckIn(string idStr)
        {
            int id = int.Parse(idStr);

            _guestBookEntities.spCreateInvoice(id);

            Reservation reservation = _guestBookEntities.Reservations.FirstOrDefault(x => x.reservation_number == id);

            reservation.checked_in = true;

            _guestBookEntities.Entry(reservation).State = EntityState.Modified;
            _guestBookEntities.SaveChanges();

            throw new WebFaultException(HttpStatusCode.OK);
        }

        public void CheckOut(string idStr)
        {
            int id = int.Parse(idStr);

            _guestBookEntities.spCreateHousekeepingTicketFromReservation(id);

            Reservation reservation = _guestBookEntities.Reservations.FirstOrDefault(x => x.reservation_number == id);

            reservation.checked_out = true;

            _guestBookEntities.Entry(reservation).State = EntityState.Modified;
            _guestBookEntities.SaveChanges();

            throw new WebFaultException(HttpStatusCode.OK);
        }
    }
}