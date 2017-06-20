using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfService.Contracts
{
    [DataContract]
    public class AuthenticateContract
    {
        [DataMember]
        public string username { get; set; }

        [DataMember]
        public string hash { get; set; }

        [DataMember]
        public string salt { get; set; }
    }
}