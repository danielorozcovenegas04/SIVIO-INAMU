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
    
    public partial class TBL_REFERENCIA_DETALLE
    {
        public System.Guid PK_REFERENCIADETALLE { get; set; }
        public System.Guid FK_REFERENCIA { get; set; }
        public string VC_FUNCIONARIO { get; set; }
        public string VC_CORREO { get; set; }
        public string VC_TELEFONO { get; set; }
        public int FK_INSTITUCION { get; set; }
        public int FK_UNIDAD { get; set; }
    
        public virtual TBL_REFERENCIA TBL_REFERENCIA { get; set; }
        public virtual TBL_UNIDAD TBL_UNIDAD { get; set; }
        public virtual TBL_VALOR_CATALOGO TBL_VALOR_CATALOGO { get; set; }
    }
}