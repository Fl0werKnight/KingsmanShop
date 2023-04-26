//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KingsmanShop.Databases
{
    using System;
    using System.Collections.Generic;
    
    public partial class Service
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Service()
        {
            this.MaterialService = new HashSet<MaterialService>();
            this.ServiceOrder = new HashSet<ServiceOrder>();
        }
    
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Cost { get; set; }
        public Nullable<int> IdCategory { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
    
        public virtual CategoryService CategoryService { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaterialService> MaterialService { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceOrder> ServiceOrder { get; set; }
    }
}
