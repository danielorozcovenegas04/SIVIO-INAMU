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
    
    public partial class TBL_INTERVENCION_COADYUVANCIA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_INTERVENCION_COADYUVANCIA()
        {
            this.TBL_INTERVENCION_COADYUVANCIA_DETALLE = new HashSet<TBL_INTERVENCION_COADYUVANCIA_DETALLE>();
        }
    
        public System.Guid PK_INTERVENCIONCOADYUVANCIA { get; set; }
        public Nullable<int> FK_TIPOSEDE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_INTERVENCION_COADYUVANCIA_DETALLE> TBL_INTERVENCION_COADYUVANCIA_DETALLE { get; set; }
    }
}
