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
    
    public partial class CAT_PROVINCIA
    {
        public CAT_PROVINCIA()
        {
            this.CAT_CANTON = new HashSet<CAT_CANTON>();
        }
    
        public int I_IDPROVINCIA { get; set; }
        public string VC_DESCRIPCION { get; set; }
    
        public virtual ICollection<CAT_CANTON> CAT_CANTON { get; set; }
    }
}