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
    
    public partial class TBL_AGRESION_CATEGORIZACION_RIESGO
    {
        public System.Guid PK_AGRESIONCATEGORIZACIONRIESGO { get; set; }
        public System.Guid FK_AGRESION { get; set; }
        public System.DateTime DT_FECHA { get; set; }
        public int FK_CATEGORIARIESGO { get; set; }
        public string VC_PERSONAREPORTA { get; set; }
        public string VC_CORREOPERSONAREPORTA { get; set; }
    
        public virtual TBL_AGRESION TBL_AGRESION { get; set; }
        public virtual TBL_VALOR_CATALOGO TBL_VALOR_CATALOGO { get; set; }
    }
}
