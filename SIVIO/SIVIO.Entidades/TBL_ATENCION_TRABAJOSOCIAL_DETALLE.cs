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
    
    public partial class TBL_ATENCION_TRABAJOSOCIAL_DETALLE
    {
        public System.Guid PK_ATENCIONTRABAJOSOCIALDETALLE { get; set; }
        public System.Guid FK_ATENCIONTRABAJOSOCIAL { get; set; }
        public int FK_DETALLEATENCION { get; set; }
    
        public virtual TBL_ATENCION_TRABAJOSOCIAL TBL_ATENCION_TRABAJOSOCIAL { get; set; }
        public virtual TBL_VALOR_CATALOGO TBL_VALOR_CATALOGO { get; set; }
    }
}