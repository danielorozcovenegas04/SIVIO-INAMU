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
    
    public partial class TBL_TELEFONO
    {
        public int PK_TELEFONO { get; set; }
        public int FK_PERSONA { get; set; }
        public string VC_NUMERO { get; set; }
        public int FK_TIPOTELEFONO { get; set; }
    
        public virtual TBL_PERSONA TBL_PERSONA { get; set; }
        public virtual TBL_VALOR_CATALOGO TBL_VALOR_CATALOGO { get; set; }
    }
}
