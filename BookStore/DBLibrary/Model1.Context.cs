﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace DBLibrary
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class mvcStudyEntities : DbContext
    {
        public mvcStudyEntities()
            : base("name=mvcStudyEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<BookTypes> BookTypes { get; set; }
        public virtual DbSet<Custom> Custom { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Purchases> Purchases { get; set; }
        public virtual DbSet<Detail> Detail { get; set; }
    }
}
