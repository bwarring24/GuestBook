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
    
    public partial class Reservation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Reservation()
        {
            this.Invoices = new HashSet<Invoice>();
            this.RoomForReservations = new HashSet<RoomForReservation>();
        }
    
        public int reservation_number { get; set; }
        public int guest_id { get; set; }
        public System.DateTime start_date { get; set; }
        public System.DateTime end_date { get; set; }
        public bool checked_in { get; set; }
        public bool checked_out { get; set; }
    
        public virtual Guest Guest { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invoice> Invoices { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RoomForReservation> RoomForReservations { get; set; }
    }
}
