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
    
    public partial class TBL_ATENCION_PSICOLOGICA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_ATENCION_PSICOLOGICA()
        {
            this.TBL_ATENCION_PSICOLOGICA_DETALLE = new HashSet<TBL_ATENCION_PSICOLOGICA_DETALLE>();
        }
    
        public System.Guid PK_ATENCIONPSICOLOGICA { get; set; }
        public System.Guid FK_ATENCION { get; set; }
        public bool B_DESEARECIBIRATENCION { get; set; }
        public System.DateTime DT_FECHASESION { get; set; }
        public string VC_OBJETIVOSESION { get; set; }
        public string VC_PLANINTERVENCION { get; set; }
        public string VC_RESUMENSESION { get; set; }
        public string VC_PLANSEGURIDAD { get; set; }
        public Nullable<System.DateTime> DT_FECHAASIGNACIONKITEMERGENCIA { get; set; }
        public string VC_PERSONARESPONSABLEKITEMERGENCIA { get; set; }
        public string VC_SEGUIMIENTOKITEMERGENCIA { get; set; }
        public bool B_KITEMERGENCIA { get; set; }
    
        public virtual TBL_ATENCION TBL_ATENCION { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_ATENCION_PSICOLOGICA_DETALLE> TBL_ATENCION_PSICOLOGICA_DETALLE { get; set; }
    }
}
