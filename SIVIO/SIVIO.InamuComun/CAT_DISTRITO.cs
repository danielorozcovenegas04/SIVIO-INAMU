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
    
    public partial class CAT_DISTRITO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CAT_DISTRITO()
        {
            this.CAT_COMUNIDAD = new HashSet<CAT_COMUNIDAD>();
        }
    
        public int I_IDDISTRITO { get; set; }
        public int I_IDCANTON { get; set; }
        public int I_IDPROVINCIA { get; set; }
        public Nullable<int> I_IDREGION { get; set; }
        public string VC_DESCRIPCION { get; set; }
    
        public virtual CAT_CANTON CAT_CANTON { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CAT_COMUNIDAD> CAT_COMUNIDAD { get; set; }
        public virtual CAT_REGION CAT_REGION { get; set; }
    }
}
