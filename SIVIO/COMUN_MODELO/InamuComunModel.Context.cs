﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace COMUN_MODELO
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class INAMU_COMUNEntities1 : DbContext
    {
        public INAMU_COMUNEntities1()
            : base("name=INAMU_COMUNEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CAT_CANTON> CAT_CANTON { get; set; }
        public virtual DbSet<CAT_COMUNIDAD> CAT_COMUNIDAD { get; set; }
        public virtual DbSet<CAT_DISTRITO> CAT_DISTRITO { get; set; }
        public virtual DbSet<CAT_PROVINCIA> CAT_PROVINCIA { get; set; }
        public virtual DbSet<CAT_REGION> CAT_REGION { get; set; }
        public virtual DbSet<CAT_PAIS> CAT_PAIS { get; set; }
    }
}
