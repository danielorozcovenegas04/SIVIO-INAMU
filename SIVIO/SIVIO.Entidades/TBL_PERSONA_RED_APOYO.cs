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
    
    public partial class TBL_PERSONA_RED_APOYO
    {
        public System.Guid PK_RED_APOYO { get; set; }
        public int FK_PERSONA { get; set; }
        public string VC_NOMBRE { get; set; }
        public string VC_OBSERVACIONES { get; set; }
        public int FK_TIPOREDAPOYO { get; set; }
    
        public virtual TBL_PERSONA TBL_PERSONA { get; set; }
        public virtual TBL_VALOR_CATALOGO TBL_VALOR_CATALOGO { get; set; }
    }
}
