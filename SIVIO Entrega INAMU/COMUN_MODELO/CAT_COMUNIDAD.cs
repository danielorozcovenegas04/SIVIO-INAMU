//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace COMUN_MODELO
{
    using System;
    using System.Collections.Generic;
    
    public partial class CAT_COMUNIDAD
    {
        public int I_IDCOMUNIDAD { get; set; }
        public int I_IDDISTRITO { get; set; }
        public int I_IDCANTON { get; set; }
        public int I_IDPROVINCIA { get; set; }
        public string VC_DESCRIPCION { get; set; }
    
        public virtual CAT_DISTRITO CAT_DISTRITO { get; set; }
    }
}
