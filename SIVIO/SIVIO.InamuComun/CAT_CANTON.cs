//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SIVIO.InamuComun
{
    using System;
    using System.Collections.Generic;
    
    public partial class CAT_CANTON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CAT_CANTON()
        {
            this.CAT_DISTRITO = new HashSet<CAT_DISTRITO>();
        }
    
        public int I_IDCANTON { get; set; }
        public int I_IDPROVINCIA { get; set; }
        public string VC_DESCRIPCION { get; set; }
    
        public virtual CAT_PROVINCIA CAT_PROVINCIA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CAT_DISTRITO> CAT_DISTRITO { get; set; }
    }
}