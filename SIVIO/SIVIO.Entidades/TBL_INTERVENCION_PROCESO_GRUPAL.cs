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
    
    public partial class TBL_INTERVENCION_PROCESO_GRUPAL
    {
        public System.Guid PK_PROCESOGRUPAL { get; set; }
        public System.Guid FK_INTERVENCION { get; set; }
        public System.DateTime VC_FECHA { get; set; }
        public int FK_TIPOGRUPO { get; set; }
        public string VC_PERIODOPARTICIPACION { get; set; }
        public int I_SESIONESASISTIDAS { get; set; }
    
        public virtual TBL_INTERVENCION TBL_INTERVENCION { get; set; }
        public virtual TBL_VALOR_CATALOGO TBL_VALOR_CATALOGO { get; set; }
    }
}
