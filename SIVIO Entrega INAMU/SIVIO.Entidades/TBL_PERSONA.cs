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
    
    public partial class TBL_PERSONA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_PERSONA()
        {
            this.TBL_DIRECCION = new HashSet<TBL_DIRECCION>();
            this.TBL_TELEFONO = new HashSet<TBL_TELEFONO>();
            this.TBL_VALORCATALOGO = new HashSet<TBL_VALORCATALOGO>();
        }
    
        public int PK_PERSONA { get; set; }
        public string VC_IDENTIFICACION { get; set; }
        public int FK_TIPOIDENTIFICACION { get; set; }
        public int FK_NACIONALIDAD { get; set; }
        public string VC_NOMBRE { get; set; }
        public string VC_APELLIDO1 { get; set; }
        public string VC_APELLIDO2 { get; set; }
        public System.DateTime DT_FECHANACIMIENTO { get; set; }
        public int FK_ESTADOCIVIL { get; set; }
        public int FK_ESCOLARIDAD { get; set; }
        public int FK_GENERO { get; set; }
        public int FK_OCUPACION { get; set; }
        public int FK_CONDICIONMIGRATORIA { get; set; }
        public int FK_CONDICIONLABORAL { get; set; }
        public int FK_CONDICIONASEGURAMIENTO { get; set; }
        public int FK_TIPOVIVIENDA { get; set; }
        public int FK_TIPOFAMILIA { get; set; }
        public int FK_ESTADOEMBARAZO { get; set; }
        public int FK_CONDICIONSALUD { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_DIRECCION> TBL_DIRECCION { get; set; }
        public virtual TBL_LABORAL TBL_LABORAL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_TELEFONO> TBL_TELEFONO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_VALORCATALOGO> TBL_VALORCATALOGO { get; set; }
    }
}
