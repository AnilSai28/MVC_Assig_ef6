using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
namespace mvc_ef6_example.Models
{
    public class mydbcontext:DbContext
    {
        public mydbcontext():base("constr")
        {

        }
        public DbSet<customermodel> customers { get; set; }
        public DbSet<ordermodel> orders { get; set; }
        public DbSet<employeemodel> employees { get; set; }
        public DbSet<productmodel> products { get; set; }
     
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<customermodel>().MapToStoredProcedures();
            modelBuilder.Entity<ordermodel>().MapToStoredProcedures();
            modelBuilder.Entity<employeemodel>().MapToStoredProcedures();

            modelBuilder.Entity<productmodel>().ToTable("tbl_products");
            modelBuilder.Entity<productmodel>().HasKey(p => p.productid);

            modelBuilder.Entity<productmodel>().Property(p => p.productid).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<productmodel>().Property(p => p.productname).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<productmodel>().Property(p => p.productprice).IsRequired();

            modelBuilder.Entity<productmodel>().Property(p => p.productaddeddate).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            modelBuilder.Entity<productmodel>().MapToStoredProcedures();
        }
    }
}