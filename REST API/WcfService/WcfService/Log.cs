//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WcfService
{
    using System;
    using System.Collections.Generic;
    
    public partial class Log
    {
        public int log_id { get; set; }
        public string log_type { get; set; }
        public System.DateTime occured_at { get; set; }
        public Nullable<int> employee_id { get; set; }
        public string message { get; set; }
        public string workstation { get; set; }
        public string @event { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual LogType LogType { get; set; }
    }
}
