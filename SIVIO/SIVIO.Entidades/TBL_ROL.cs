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
    
    public partial class TBL_ROL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_ROL()
        {
            this.TBL_ROL_ACCION = new HashSet<TBL_ROL_ACCION>();
            this.TBL_ROL_USUARIO = new HashSet<TBL_ROL_USUARIO>();
            this.TBL_ROL_TIPO_ATENCION = new HashSet<TBL_ROL_TIPO_ATENCION>();
        }
    
        public int PK_ROL { get; set; }
        public string VC_NOMBRE { get; set; }
        public string VC_DESCRIPCION { get; set; }
        public int FK_TIPOSERVICIO { get; set; }
    
        public virtual TBL_VALOR_CATALOGO TBL_VALOR_CATALOGO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_ROL_ACCION> TBL_ROL_ACCION { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_ROL_USUARIO> TBL_ROL_USUARIO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_ROL_TIPO_ATENCION> TBL_ROL_TIPO_ATENCION { get; set; }
    }
}
