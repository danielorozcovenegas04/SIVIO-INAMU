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
    
    public partial class TBL_INTERVENCION_TESTIMONIO_EXPERTO
    {
        public System.Guid PK_TESTIMONIOEXPERTO { get; set; }
        public System.Guid FK_INTERVENCION { get; set; }
        public string VC_TIPO { get; set; }
        public string VC_LUGARPROCESO { get; set; }
        public string VC_OBSERVACIONES { get; set; }
    
        public virtual TBL_INTERVENCION TBL_INTERVENCION { get; set; }
    }
}
