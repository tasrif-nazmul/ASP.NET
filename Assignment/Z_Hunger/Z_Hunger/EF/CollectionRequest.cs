//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Z_Hunger.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class CollectionRequest
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CollectionRequest()
        {
            this.Collecteds = new HashSet<Collected>();
        }
    
        public int CollectionRequestID { get; set; }
        public string IteamName { get; set; }
        public System.DateTime CreationTime { get; set; }
        public System.DateTime ExpiredTime { get; set; }
        public int RestaurantID { get; set; }
        public string Status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Collected> Collecteds { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}