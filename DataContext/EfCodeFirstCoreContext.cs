using EfCodeFirstCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCodeFirstCore.DataContext
{
    public class EfCodeFirstCoreContext : DbContext
    {
        // Your context has been configured to use a 'EfCodeFirst' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'EfCodeFirst.EfCodeFirst' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'EfCodeFirst' 
        // connection string in the application configuration file.
        public EfCodeFirstCoreContext()
        {

        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Computer> computer { get; set; }
        public virtual DbSet<Department> department { get; set; }
        public virtual DbSet<Developer> developer { get; set; }
        public virtual DbSet<Manager> manager { get; set; }
        public virtual DbSet<Location> location { get; set; }
        public virtual DbSet<Employee> employee { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=MPP-P53;Initial Catalog=EfCodeFirstCore;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().UseTpcMappingStrategy();
            modelBuilder.Entity<Developer>().UseTpcMappingStrategy();
            modelBuilder.Entity<Manager>().UseTpcMappingStrategy();
        }
    }
}
