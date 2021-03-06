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
            this.TBL_ADICCIONES = new HashSet<TBL_ADICCIONES>();
            this.TBL_AGRESOR = new HashSet<TBL_AGRESOR>();
            this.TBL_DIRECCION = new HashSet<TBL_DIRECCION>();
            this.TBL_INTERVENCION = new HashSet<TBL_INTERVENCION>();
            this.TBL_PERSONA_RED_APOYO = new HashSet<TBL_PERSONA_RED_APOYO>();
            this.TBL_PERSONA_SALUD = new HashSet<TBL_PERSONA_SALUD>();
            this.TBL_PERSONA_APOYO = new HashSet<TBL_PERSONA_APOYO>();
            this.TBL_PERSONA_CONDICIONESPECIAL = new HashSet<TBL_PERSONA_CONDICIONESPECIAL>();
            this.TBL_REGISTRO = new HashSet<TBL_REGISTRO>();
            this.TBL_TELEFONO = new HashSet<TBL_TELEFONO>();
        }
    
        public int PK_PERSONA { get; set; }
        public string VC_IDENTIFICACION { get; set; }
        public int FK_TIPOIDENTIFICACION { get; set; }
        public int FK_NACIONALIDAD { get; set; }
        public string VC_NOMBRE { get; set; }
        public string VC_APELLIDO1 { get; set; }
        public string VC_APELLIDO2 { get; set; }
        public Nullable<System.DateTime> DT_FECHANACIMIENTO { get; set; }
        public int FK_ESTADOCIVIL { get; set; }
        public int FK_ESCOLARIDAD { get; set; }
        public int FK_GENERO { get; set; }
        public int FK_OCUPACION { get; set; }
        public int FK_CONDICIONMIGRATORIA { get; set; }
        public int FK_CONDICIONASEGURAMIENTO { get; set; }
        public int FK_TIPOVIVIENDA { get; set; }
        public int FK_TIPOFAMILIA { get; set; }
        public int FK_ESTADOEMBARAZO { get; set; }
        public int FK_CONDICIONSALUD { get; set; }
        public int FK_ORIENTACIONSEXUAL { get; set; }
        public int I_HIJOS { get; set; }
        public int I_HIJOSCEEAM { get; set; }
        public int I_HIJOSMAYORESDOCE { get; set; }
        public int FK_PROVINCIAPROCEDENCIA { get; set; }
        public int FK_CANTONPROCEDENCIA { get; set; }
        public int FK_DISTRITOPROCEDENCIA { get; set; }
        public string VC_CORREO { get; set; }
        public Nullable<int> FK_ETNIA { get; set; }
        public Nullable<int> FK_NACIONALIDAD2 { get; set; }
        public Nullable<int> I_EDAD { get; set; }
        public Nullable<bool> B_CONOCEFECHANACIMIENTO { get; set; }
        public Nullable<int> FK_PUEBLOINDIGENA { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_ADICCIONES> TBL_ADICCIONES { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_AGRESOR> TBL_AGRESOR { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_DIRECCION> TBL_DIRECCION { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_INTERVENCION> TBL_INTERVENCION { get; set; }
        public virtual TBL_LABORAL TBL_LABORAL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_PERSONA_RED_APOYO> TBL_PERSONA_RED_APOYO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_PERSONA_SALUD> TBL_PERSONA_SALUD { get; set; }
        public virtual TBL_VALOR_CATALOGO TBL_VALOR_CATALOGO { get; set; }
        public virtual TBL_VALOR_CATALOGO TBL_VALOR_CATALOGO1 { get; set; }
        public virtual TBL_VALOR_CATALOGO TBL_VALOR_CATALOGO2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_PERSONA_APOYO> TBL_PERSONA_APOYO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_PERSONA_CONDICIONESPECIAL> TBL_PERSONA_CONDICIONESPECIAL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_REGISTRO> TBL_REGISTRO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_TELEFONO> TBL_TELEFONO { get; set; }
        public virtual TBL_VALOR_CATALOGO TBL_VALOR_CATALOGO21 { get; set; }
    }
}
