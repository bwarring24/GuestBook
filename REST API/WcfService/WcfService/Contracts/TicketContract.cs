using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WcfService.Contracts
{
    [DataContract]
    public class TicketContract
    {
        [JsonProperty]
        [DataMember]
        public int ticket_number { get; set; }

        [JsonProperty]
        [DataMember]
        public string ticket_type { get; set; }

        [JsonProperty]
        [DataMember]
        public List<Room> room_number { get; set; }

        [JsonProperty]
        [DataMember]
        public Nullable<int> opened_by { get; set; }

        [JsonProperty]
        [DataMember]
        public Nullable<int> assigned_to { get; set; }

        [JsonProperty]
        [DataMember]
        public Nullable<int> closed_by { get; set; }

        [JsonProperty]
        [DataMember]
        public string title { get; set; }

        [JsonProperty]
        [DataMember]
        public string description { get; set; }

        [JsonProperty]
        [DataMember]
        public System.DateTime date_opened { get; set; }

        [JsonProperty]
        [DataMember]
        public Nullable<System.DateTime> date_closed { get; set; }

        [JsonProperty]
        [DataMember]
        public string priority { get; set; }

        [JsonProperty]
        [DataMember]
        public bool completed { get; set; }
    }
}