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
    
    public partial class TBL_VALOR_CATALOGO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_VALOR_CATALOGO()
        {
            this.TBL_ADICCIONES = new HashSet<TBL_ADICCIONES>();
            this.TBL_AGRESION_ATENCION_MEDICA = new HashSet<TBL_AGRESION_ATENCION_MEDICA>();
            this.TBL_AGRESION_DETALLE_VIOLENCIA = new HashSet<TBL_AGRESION_DETALLE_VIOLENCIA>();
            this.TBL_AGRESION_VIOLENCIA = new HashSet<TBL_AGRESION_VIOLENCIA>();
            this.TBL_AGRESOR = new HashSet<TBL_AGRESOR>();
            this.TBL_AGRESOR1 = new HashSet<TBL_AGRESOR>();
            this.TBL_AGRESOR2 = new HashSet<TBL_AGRESOR>();
            this.TBL_AGRESOR3 = new HashSet<TBL_AGRESOR>();
            this.TBL_AGRESOR4 = new HashSet<TBL_AGRESOR>();
            this.TBL_AGRESOR_MOTIVO_REGRESO = new HashSet<TBL_AGRESOR_MOTIVO_REGRESO>();
            this.TBL_ATENCIONASESORIA = new HashSet<TBL_ATENCIONASESORIA>();
            this.TBL_BITACORA = new HashSet<TBL_BITACORA>();
            this.TBL_DIRECCION = new HashSet<TBL_DIRECCION>();
            this.TBL_FAMILIAR_ACADEMICO = new HashSet<TBL_FAMILIAR_ACADEMICO>();
            this.TBL_FAMILIAR_SALUD = new HashSet<TBL_FAMILIAR_SALUD>();
            this.TBL_LABORAL = new HashSet<TBL_LABORAL>();
            this.TBL_PERSONA = new HashSet<TBL_PERSONA>();
            this.TBL_PERSONA_APOYO = new HashSet<TBL_PERSONA_APOYO>();
            this.TBL_PERSONA_CONDICIONESPECIAL = new HashSet<TBL_PERSONA_CONDICIONESPECIAL>();
            this.TBL_PERSONA_RED_APOYO = new HashSet<TBL_PERSONA_RED_APOYO>();
            this.TBL_PERSONA_SALUD = new HashSet<TBL_PERSONA_SALUD>();
            this.TBL_REFERENCIA = new HashSet<TBL_REFERENCIA>();
            this.TBL_REFERENCIA1 = new HashSet<TBL_REFERENCIA>();
            this.TBL_REFERENCIA_DETALLE = new HashSet<TBL_REFERENCIA_DETALLE>();
            this.TBL_REGISTRO = new HashSet<TBL_REGISTRO>();
            this.TBL_REGISTRO1 = new HashSet<TBL_REGISTRO>();
            this.TBL_REGISTRO_CEAAM = new HashSet<TBL_REGISTRO_CEAAM>();
            this.TBL_REGISTRO_CEAAM1 = new HashSet<TBL_REGISTRO_CEAAM>();
            this.TBL_REGISTRO_CEAAM2 = new HashSet<TBL_REGISTRO_CEAAM>();
            this.TBL_REGISTRO_COORDINACION = new HashSet<TBL_REGISTRO_COORDINACION>();
            this.TBL_TELEFONO = new HashSet<TBL_TELEFONO>();
            this.TBL_ROL = new HashSet<TBL_ROL>();
        }
    
        public int PK_VALORCATALOGO { get; set; }
        public int FK_CATALOGO { get; set; }
        public string VC_VALOR1 { get; set; }
        public string VC_VALOR2 { get; set; }
        public bool B_EDITABLE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_ADICCIONES> TBL_ADICCIONES { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_AGRESION_ATENCION_MEDICA> TBL_AGRESION_ATENCION_MEDICA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_AGRESION_DETALLE_VIOLENCIA> TBL_AGRESION_DETALLE_VIOLENCIA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_AGRESION_VIOLENCIA> TBL_AGRESION_VIOLENCIA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_AGRESOR> TBL_AGRESOR { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_AGRESOR> TBL_AGRESOR1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_AGRESOR> TBL_AGRESOR2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_AGRESOR> TBL_AGRESOR3 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_AGRESOR> TBL_AGRESOR4 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_AGRESOR_MOTIVO_REGRESO> TBL_AGRESOR_MOTIVO_REGRESO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_ATENCIONASESORIA> TBL_ATENCIONASESORIA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_BITACORA> TBL_BITACORA { get; set; }
        public virtual TBL_CATALOGO TBL_CATALOGO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_DIRECCION> TBL_DIRECCION { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_FAMILIAR_ACADEMICO> TBL_FAMILIAR_ACADEMICO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_FAMILIAR_SALUD> TBL_FAMILIAR_SALUD { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_LABORAL> TBL_LABORAL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_PERSONA> TBL_PERSONA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_PERSONA_APOYO> TBL_PERSONA_APOYO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_PERSONA_CONDICIONESPECIAL> TBL_PERSONA_CONDICIONESPECIAL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_PERSONA_RED_APOYO> TBL_PERSONA_RED_APOYO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_PERSONA_SALUD> TBL_PERSONA_SALUD { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_REFERENCIA> TBL_REFERENCIA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_REFERENCIA> TBL_REFERENCIA1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_REFERENCIA_DETALLE> TBL_REFERENCIA_DETALLE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_REGISTRO> TBL_REGISTRO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_REGISTRO> TBL_REGISTRO1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_REGISTRO_CEAAM> TBL_REGISTRO_CEAAM { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_REGISTRO_CEAAM> TBL_REGISTRO_CEAAM1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_REGISTRO_CEAAM> TBL_REGISTRO_CEAAM2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_REGISTRO_COORDINACION> TBL_REGISTRO_COORDINACION { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_TELEFONO> TBL_TELEFONO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_ROL> TBL_ROL { get; set; }
    }
}
