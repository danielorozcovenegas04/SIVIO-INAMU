//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SIVIO.Entidades
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_CATALOGO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_CATALOGO()
        {
            this.TBL_VALORCATALOGO = new HashSet<TBL_VALORCATALOGO>();
        }
    
        public int PK_CATALOGO { get; set; }
        public string VC_NOMBRECATALOGO { get; set; }
        public Nullable<int> FK_CATALOGOPADRE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_VALORCATALOGO> TBL_VALORCATALOGO { get; set; }
    }
}
