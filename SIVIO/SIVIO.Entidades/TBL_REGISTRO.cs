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
    
    public partial class TBL_REGISTRO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_REGISTRO()
        {
            this.TBL_ARCHIVO = new HashSet<TBL_ARCHIVO>();
            this.TBL_ATENCION = new HashSet<TBL_ATENCION>();
            this.TBL_CONSULTA = new HashSet<TBL_CONSULTA>();
            this.TBL_REGISTRO_CEAAM = new HashSet<TBL_REGISTRO_CEAAM>();
            this.TBL_REGISTRO_COORDINACION = new HashSet<TBL_REGISTRO_COORDINACION>();
            this.TBL_REGISTRO_TIPIFICACION_VIOLENCIA = new HashSet<TBL_REGISTRO_TIPIFICACION_VIOLENCIA>();
        }
    
        public System.Guid PK_REGISTRO { get; set; }
        public int FK_PERSONA { get; set; }
        public int FK_USUARIOREGISTRA { get; set; }
        public System.DateTime DT_FECHAINICIO { get; set; }
        public System.DateTime DT_FECHAFIN { get; set; }
        public int FK_TIPOSERVICIO { get; set; }
        public int FK_TIPOREGISTRO { get; set; }
        public string VC_OBSERVACIONES { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_ARCHIVO> TBL_ARCHIVO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_ATENCION> TBL_ATENCION { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_CONSULTA> TBL_CONSULTA { get; set; }
        public virtual TBL_PERSONA TBL_PERSONA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_REGISTRO_CEAAM> TBL_REGISTRO_CEAAM { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_REGISTRO_COORDINACION> TBL_REGISTRO_COORDINACION { get; set; }
        public virtual TBL_USUARIO TBL_USUARIO { get; set; }
        public virtual TBL_VALOR_CATALOGO TBL_VALOR_CATALOGO { get; set; }
        public virtual TBL_VALOR_CATALOGO TBL_VALOR_CATALOGO1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_REGISTRO_TIPIFICACION_VIOLENCIA> TBL_REGISTRO_TIPIFICACION_VIOLENCIA { get; set; }
    }
}
