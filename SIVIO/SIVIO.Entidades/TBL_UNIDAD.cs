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
    
    public partial class TBL_UNIDAD
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_UNIDAD()
        {
            this.TBL_REFERENCIA_DETALLE = new HashSet<TBL_REFERENCIA_DETALLE>();
        }
    
        public int PK_UNIDAD { get; set; }
        public string VC_CODIGO { get; set; }
        public string VC_DESCRIPCION { get; set; }
        public string VC_PREFIJO { get; set; }
        public Nullable<int> I_NUMERO { get; set; }
        public Nullable<int> I_ANNO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_REFERENCIA_DETALLE> TBL_REFERENCIA_DETALLE { get; set; }
    }
}
