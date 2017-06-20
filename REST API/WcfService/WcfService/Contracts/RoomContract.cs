using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace WcfService.Contracts
{
    public class RoomContract
    {
        [JsonProperty]
        [DataMember]
        public string room_number { get; set; }

        [JsonProperty]
        [DataMember]
        public string room_type { get; set; }

        [JsonProperty]
        [DataMember]
        public short max_occupancy { get; set; }

        [JsonProperty]
        [DataMember]
        public decimal cost_per_day { get; set; }

        [JsonProperty]
        [DataMember]
        public Nullable<System.DateTime> last_cleaned { get; set; }
    }
}