using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WcfService.Contracts;

namespace WcfService.Repositories
{
    public class RoomRepository
    {
        private readonly GuestBookEntities _guestBookEntities;

        public RoomRepository(GuestBookEntities guestBookEntities)
        {
            _guestBookEntities = guestBookEntities;
        }

        public void CreateRoom(Room room)
        {
            _guestBookEntities.Rooms.Add(room);
        }

        public List<RoomContract> GetRooms()
        {
            List<RoomContract> rooms = new List<RoomContract>();

            foreach(Room room in _guestBookEntities.Set<Room>().ToList()){
                RoomContract roomContract = new RoomContract
                {
                    room_number = room.room_number,
                    room_type = room.room_type,
                    max_occupancy = room.max_occupancy,
                    last_cleaned = room.last_cleaned
                };

                rooms.Add(roomContract);
            }

            return rooms;
        }

        public RoomContract GetRoom(string roomNumberStr)
        {
            Room room = _guestBookEntities.Rooms.FirstOrDefault((x) => x.room_number == roomNumberStr);

            RoomContract roomContract = new RoomContract
            {
                room_number = room.room_number,
                room_type = room.room_type,
                max_occupancy = room.max_occupancy,
                last_cleaned = room.last_cleaned
            };

            return roomContract;
        }

        public List<RoomContract> GetAvaiableRooms(ReservationContract reservation)
        {
            List<spShowAvailableRooms_Result> rooms = _guestBookEntities.spShowAvailableRooms(reservation.start_date, reservation.end_date).ToList();

            List<RoomContract> roomContracts = new List<RoomContract>();

            foreach(spShowAvailableRooms_Result result in rooms)
            {
                RoomContract room = new RoomContract()
                {
                    room_number = result.room_number,
                    cost_per_day = result.cost_per_day,
                    room_type = result.room_type
                };

                roomContracts.Add(room);
            }

            return roomContracts;
        }
    }
}