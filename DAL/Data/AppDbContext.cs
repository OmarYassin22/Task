using DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Applicant> Applicants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Applicant>().Property(a => a.Name).HasColumnType("nvarchar(50)").IsRequired();
            modelBuilder.Entity<Applicant>().Property(a => a.FamilyName).HasColumnType("nvarchar(50)").IsRequired();
            modelBuilder.Entity<Applicant>().Property(a => a.Address).HasColumnType("nvarchar(50)").IsRequired();
        }

    }

}
