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
    
        public DbSet<PARAM_BLOCK> PARAM_BLOCK { get; set; }
        public DbSet<PARAM_CITY> PARAM_CITY { get; set; }
        public DbSet<PARAM_COUNTRY> PARAM_COUNTRY { get; set; }
        public DbSet<PARAM_CUSTOMER> PARAM_CUSTOMER { get; set; }
        public DbSet<PARAM_FINANCIAL> PARAM_FINANCIAL { get; set; }
        public DbSet<PARAM_PAYMENTS> PARAM_PAYMENTS { get; set; }
        public DbSet<PARAM_PROJECT> PARAM_PROJECT { get; set; }
        public DbSet<PARAM_PROPERTY> PARAM_PROPERTY { get; set; }
        public DbSet<PARAM_REQUEST_STATUS> PARAM_REQUEST_STATUS { get; set; }
        public DbSet<SEC_FORM> SEC_FORM { get; set; }
        public DbSet<SEC_FORMS_ROLE> SEC_FORMS_ROLE { get; set; }
        public DbSet<SEC_ROLE> SEC_ROLE { get; set; }
        public DbSet<SEC_SESSION> SEC_SESSION { get; set; }
        public DbSet<SEC_USER> SEC_USER { get; set; }
        public DbSet<SEC_USER_ROLE> SEC_USER_ROLE { get; set; }
        public DbSet<PARAM_REQUEST> PARAM_REQUEST { get; set; }
    }
}
