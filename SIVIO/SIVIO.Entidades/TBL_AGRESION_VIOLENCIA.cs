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
    
    public partial class TBL_AGRESION_VIOLENCIA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_AGRESION_VIOLENCIA()
        {
            this.TBL_AGRESION_DETALLE_VIOLENCIA = new HashSet<TBL_AGRESION_DETALLE_VIOLENCIA>();
        }
    
        public System.Guid PK_AGRESION_VIOLENCIA { get; set; }
        public System.Guid FK_AGRESION { get; set; }
        public int FK_TIPOVIOLENCIA { get; set; }
        public string VC_OBSERVACIONES { get; set; }
    
        public virtual TBL_AGRESION TBL_AGRESION { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_AGRESION_DETALLE_VIOLENCIA> TBL_AGRESION_DETALLE_VIOLENCIA { get; set; }
        public virtual TBL_VALOR_CATALOGO TBL_VALOR_CATALOGO { get; set; }
    }
}
