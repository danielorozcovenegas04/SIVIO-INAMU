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
    
    public partial class TBL_AGRESOR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_AGRESOR()
        {
            this.TBL_AGRESION = new HashSet<TBL_AGRESION>();
            this.TBL_AGRESOR_MOTIVO_REGRESO = new HashSet<TBL_AGRESOR_MOTIVO_REGRESO>();
            this.TBL_AGRESOR_ADICCIONES = new HashSet<TBL_AGRESOR_ADICCIONES>();
        }
    
        public int PK_AGRESOR { get; set; }
        public int FK_PERSONA { get; set; }
        public string VC_IDENTIFICACION { get; set; }
        public string VC_NOMBRE { get; set; }
        public string VC_APELLIDO1 { get; set; }
        public string VC_APELLIDO2 { get; set; }
        public int FK_TIPORELACION { get; set; }
        public System.DateTime DT_COMIENZORELACION { get; set; }
        public int FK_GENERO { get; set; }
        public System.DateTime DT_FECHANACIMIENTO { get; set; }
        public int FK_OCUPACION { get; set; }
        public int FK_NIVELEDUCATIVO { get; set; }
        public bool B_DENUNCIAPENAL { get; set; }
        public Nullable<bool> B_MEDIDASPROTECCION { get; set; }
        public Nullable<System.DateTime> DT_FECHAVENCIMIENTOPROTECCION { get; set; }
        public string VC_LUGARTRABAJO { get; set; }
        public int I_SEPARACIONES { get; set; }
        public Nullable<bool> B_ANTECEDENTESLEGALES { get; set; }
        public string VC_OBSERVACIONANTECEDESTESLEGALES { get; set; }
        public Nullable<bool> B_ANTECEDENTESPSIQUIATRICOS { get; set; }
        public string VC_OBSERVACIONANTPSIQUIATRICOS { get; set; }
        public int FK_NACIONALIDAD { get; set; }
        public string VC_NUMEXPEDIENTEMP { get; set; }
        public string VC_NUMEXPEDIENTEDENUNCIA { get; set; }
        public string VC_SEDEJUDICIALDENUNCIA { get; set; }
        public Nullable<int> FK_CASOCLAIS { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_AGRESION> TBL_AGRESION { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_AGRESOR_MOTIVO_REGRESO> TBL_AGRESOR_MOTIVO_REGRESO { get; set; }
        public virtual TBL_PERSONA TBL_PERSONA { get; set; }
        public virtual TBL_VALOR_CATALOGO TBL_VALOR_CATALOGO { get; set; }
        public virtual TBL_VALOR_CATALOGO TBL_VALOR_CATALOGO1 { get; set; }
        public virtual TBL_VALOR_CATALOGO TBL_VALOR_CATALOGO2 { get; set; }
        public virtual TBL_VALOR_CATALOGO TBL_VALOR_CATALOGO3 { get; set; }
        public virtual TBL_VALOR_CATALOGO TBL_VALOR_CATALOGO4 { get; set; }
        public virtual TBL_VALOR_CATALOGO TBL_VALOR_CATALOGO5 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_AGRESOR_ADICCIONES> TBL_AGRESOR_ADICCIONES { get; set; }
    }
}
