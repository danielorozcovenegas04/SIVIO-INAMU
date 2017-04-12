﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class INAMU_COMUNEntities : DbContext
    {
        public INAMU_COMUNEntities()
            : base("name=INAMU_COMUNEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<CAT_CANTON> CAT_CANTON { get; set; }
        public DbSet<CAT_COMUNIDAD> CAT_COMUNIDAD { get; set; }
        public DbSet<CAT_DISTRITO> CAT_DISTRITO { get; set; }
        public DbSet<CAT_PAIS> CAT_PAIS { get; set; }
        public DbSet<CAT_PROVINCIA> CAT_PROVINCIA { get; set; }
        public DbSet<CAT_REGION> CAT_REGION { get; set; }
    
        public virtual ObjectResult<spConsultarPadron_Result> spConsultarPadron(string cedula)
        {
            var cedulaParameter = cedula != null ?
                new ObjectParameter("Cedula", cedula) :
                new ObjectParameter("Cedula", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spConsultarPadron_Result>("spConsultarPadron", cedulaParameter);
        }
    }
}
