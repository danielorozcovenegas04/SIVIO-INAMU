﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SIVIO.Entidades
{
    using Entidades;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class SIVIOEntities : DbContext
    {
        public SIVIOEntities()
            : base("name=SIVIOEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TBL_ACCION> TBL_ACCION { get; set; }
        public virtual DbSet<TBL_BITACORA> TBL_BITACORA { get; set; }
        public virtual DbSet<TBL_CATALOGO> TBL_CATALOGO { get; set; }
        public virtual DbSet<TBL_DIRECCION> TBL_DIRECCION { get; set; }
        public virtual DbSet<TBL_LABORAL> TBL_LABORAL { get; set; }
        public virtual DbSet<TBL_PERSONA> TBL_PERSONA { get; set; }
        public virtual DbSet<TBL_ROL> TBL_ROL { get; set; }
        public virtual DbSet<TBL_TELEFONO> TBL_TELEFONO { get; set; }
        public virtual DbSet<TBL_USUARIO> TBL_USUARIO { get; set; }
        public virtual DbSet<TBL_VALORCATALOGO> TBL_VALORCATALOGO { get; set; }
    }
}
