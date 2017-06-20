using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using WcfService.User_Defined_Table_Types;

namespace WcfService.Contracts
{
    [DataContract]
    public class ReservationContract
    {
        [JsonProperty]
        [DataMember]
        public string first_name { get; set; }

        [JsonProperty]
        [DataMember]
        public string last_name { get; set; }

        [JsonProperty]
        [DataMember]
        public string email { get; set; }

        [JsonProperty]
        [DataMember]
        public string phone_number { get; set; }

        [JsonProperty]
        [DataMember]
        public System.DateTime start_date { get; set; }

        [JsonProperty]
        [DataMember]
        public System.DateTime end_date { get; set; }

        [JsonProperty]
        [DataMember]
        public int reservation_number { get; set; }

        [JsonProperty]
        [DataMember]
        public int guest_id { get; set; }

        [JsonProperty]
        [DataMember]
        public List<RoomToReserve> reserveRooms { get; set; }

        [JsonProperty]
        [DataMember]
        public List<BookedRoom> rooms { get; set; }

        [JsonProperty]
        [DataMember]
        public bool checked_in { get; set; }

        [JsonProperty]
        [DataMember]
        public bool checked_out { get; set; }
    }
}