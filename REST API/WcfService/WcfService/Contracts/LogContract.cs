using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace WcfService.Contracts
{
    [DataContract]
    public class LogContract
    {
        
        [DataMember]
        public int log_id { get; set; }

        
        [DataMember]
        public string log_type { get; set; }

        
        public System.DateTime occured_at { get; set; }

        
        [DataMember]
        public Nullable<int> employee_id { get; set; }

        
        [DataMember]
        public string message { get; set; }

        
        [DataMember]
        public string workstation { get; set; }

        
        [DataMember]
        public string @event { get; set; }

    }
}