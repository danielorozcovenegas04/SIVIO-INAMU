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
    
    public partial class TBL_INTERVENCION_CRITERIO_EXPERTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_INTERVENCION_CRITERIO_EXPERTO()
        {
            this.TBL_INTERVENCION_CRITERIO_EXPERTO_DETALLE = new HashSet<TBL_INTERVENCION_CRITERIO_EXPERTO_DETALLE>();
        }
    
        public System.Guid PK_INTERVENCIONCRITERIOEXPERTO { get; set; }
        public int FK_INSTITUCIONREMITE { get; set; }
        public string VC_PERSONAINFORME { get; set; }
        public System.DateTime DT_FECHAINFORME { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_INTERVENCION_CRITERIO_EXPERTO_DETALLE> TBL_INTERVENCION_CRITERIO_EXPERTO_DETALLE { get; set; }
        public virtual TBL_VALOR_CATALOGO TBL_VALOR_CATALOGO { get; set; }
    }
}