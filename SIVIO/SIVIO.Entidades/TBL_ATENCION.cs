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
    
    public partial class TBL_ATENCION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_ATENCION()
        {
            this.TBL_ATENCIONASESORIA = new HashSet<TBL_ATENCIONASESORIA>();
        }
    
        public System.Guid PK_ATENCION { get; set; }
        public System.Guid FK_REGISTRO { get; set; }
        public int FK_TIPOATENCION { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_ATENCIONASESORIA> TBL_ATENCIONASESORIA { get; set; }
        public virtual TBL_REGISTRO TBL_REGISTRO { get; set; }
    }
}