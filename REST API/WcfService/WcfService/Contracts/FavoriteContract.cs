using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace WcfService.Contracts
{
    [DataContract]
    public class FavoriteContract
    {
        [JsonProperty]
        [DataMember]
        public int favorite_id { get; set; }

        [JsonProperty]
        [DataMember]
        public string permission_name { get; set; }

        [JsonProperty]
        [DataMember]
        public string description { get; set; }

        [JsonProperty]
        [DataMember]
        public string priority { get; set; }

    }
}