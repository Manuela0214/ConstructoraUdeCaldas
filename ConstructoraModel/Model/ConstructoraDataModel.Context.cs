﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConstructoraModel.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ConstructoraDBEntities : DbContext
    {
        public ConstructoraDBEntities()
            : base("name=ConstructoraDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<SEC_ROLE> SEC_ROLE { get; set; }
        public DbSet<SEC_SESSION> SEC_SESSION { get; set; }
        public DbSet<SEC_USER> SEC_USER { get; set; }
        public DbSet<SEC_USER_ROLE> SEC_USER_ROLE { get; set; }
    }
}
