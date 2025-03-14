using _07_EF_Data_annotation___fluent_api.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_EF_Data_annotation___fluent_api
{
    public class Company_db : DbContext
    {
        public Company_db()
        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source = (localdb)\ProjectModels;
                                        Initial Catalog = Company_PV_421;
                                        Integrated Security = True;
                                        Connect Timeout = 2;
                                        Encrypt = False;
                                        Trust Server Certificate = False;
                                        Application Intent = ReadWrite;
                                        Multi Subnet Failover = False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Fluent api configuration

            modelBuilder.Entity<Department>().ToTable("Positions");
            modelBuilder.Entity<Department>()
                .Property(c => c.Name)
                .IsRequired() // not null
                .HasMaxLength(50) // nvarchar(50)
                .IsUnicode(true);
            modelBuilder.Entity<Department>()
                .Property(c => c.Phone)
                .IsRequired(false) //  null
                .HasMaxLength(50) // nvarchar(50)
                .IsFixedLength() // varchar
                .IsUnicode(false); // char

            modelBuilder.Entity<Worker>().HasKey(c => c.Number);
            modelBuilder.Entity<Worker>()
                .Property(w => w.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("FirstName");

            // 1 ..... *
            modelBuilder.Entity<Worker>()
                .HasOne(c => c.Country)
                .WithMany(w => w.Workers)
                .HasForeignKey(c => c.CountryId);

            // 1 ..... *
            modelBuilder.Entity<Worker>()
                .HasOne(c => c.Department)
                .WithMany(w => w.Workers)
                .HasForeignKey(c => c.DepartmentId);

            // * ....... *
            modelBuilder.Entity<Project>()
                .HasMany(p => p.Workers)
                .WithMany(w => w.Projects);


            modelBuilder.SeedCountries();
            modelBuilder.SeedDepartments();
            modelBuilder.SeedProjects();
            modelBuilder.SeedWorkers();

        }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}

