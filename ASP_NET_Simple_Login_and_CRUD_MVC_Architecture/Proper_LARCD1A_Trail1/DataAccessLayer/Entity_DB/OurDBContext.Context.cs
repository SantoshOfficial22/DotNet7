﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer.Entity_DB
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PracticeEntities : DbContext
    {
        public PracticeEntities()
            : base("name=PracticeEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Trail1CRUDLibrary> Trail1CRUDLibrary { get; set; }
        public virtual DbSet<Trail1LoginAndRegis> Trail1LoginAndRegis { get; set; }
    }
}
