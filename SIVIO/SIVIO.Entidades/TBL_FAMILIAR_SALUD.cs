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
    
    public partial class TBL_FAMILIAR_SALUD
    {
        public System.Guid FK_FAMILIAR { get; set; }
        public int FK_CONDICIONSALUD { get; set; }
        public System.Guid PK_FAMILIARSALUD { get; set; }
    
        public virtual TBL_PERSONA_FAMILIAR TBL_PERSONA_FAMILIAR { get; set; }
        public virtual TBL_VALOR_CATALOGO TBL_VALOR_CATALOGO { get; set; }
    }
}
