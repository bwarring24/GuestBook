using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace WcfService.Contracts
{
    public class JobTitleContract
    {
        [JsonProperty]
        [DataMember]
        public byte access_level { get; set; }

        [JsonProperty]
        [DataMember]
        public string title { get; set; }

        [JsonProperty]
        [DataMember]
        public string description { get; set; }
    }
}