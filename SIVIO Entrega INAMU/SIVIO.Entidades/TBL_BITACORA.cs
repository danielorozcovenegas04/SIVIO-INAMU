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
    
    public partial class TBL_BITACORA
    {
        public int PK_BITACORA { get; set; }
        public System.DateTime DT_FECHAEVENTO { get; set; }
        public int FK_TIPOEVENTO { get; set; }
        public int FK_USUARIO { get; set; }
        public string VC_DETALLE { get; set; }
        public string VC_DIRECCIONIP { get; set; }
    }
}
