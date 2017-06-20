using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfService.Contracts
{
    [DataContract]
    public class EmployeeContract
    {

        [JsonProperty]
        [DataMember]
        public int employee_id { get; set; }

        [JsonProperty]
        [DataMember]
        public string username { get; set; }

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
        public string salt { get; set; }

        [JsonProperty]
        [DataMember]
        public string password_hash { get; set; }

        [JsonProperty]
        [DataMember]
        public int access_level { get; set; }

        [JsonProperty]
        [DataMember]
        public string title { get; set; }

        [JsonProperty]
        [DataMember]
        public string token { get; set; }

        [JsonProperty]
        [DataMember]
        public List<spShowEmployeePermissions_Result> permissions { get; set; }

        [JsonProperty]
        [DataMember]
        public string reset_key { get; set; }
    }
}