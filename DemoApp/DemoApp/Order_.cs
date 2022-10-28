//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DemoApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order_
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order_()
        {
            this.IssuedDocuments = new HashSet<IssuedDocuments>();
        }
    
        public string OrderName { get; set; }
        public System.DateTime CurrentDate { get; set; }
        public string Role { get; set; }
        public string Content_ { get; set; }
        public string EventResponsible { get; set; }
        public System.DateTime PerformanceDate { get; set; }
        public string Correspondent { get; set; }
        public int EventNumber { get; set; }
    
        public virtual CommonEmployee CommonEmployee { get; set; }
        public virtual Event_ Event_ { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IssuedDocuments> IssuedDocuments { get; set; }
        public virtual OutgoingCorrespondent OutgoingCorrespondent { get; set; }
    }
}