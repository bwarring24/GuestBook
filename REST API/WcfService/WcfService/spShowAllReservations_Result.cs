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
    
    public partial class spShowAllReservations_Result
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
        public int reservation_number { get; set; }
        public System.DateTime start_date { get; set; }
        public System.DateTime end_date { get; set; }
        public bool checked_in { get; set; }
        public bool checked_out { get; set; }
        public string room_number { get; set; }
        public decimal cost_for_stay { get; set; }
    }
}
