using EMS_APP.Data.SeedData;
using EMS_APP.Data.TableMapping;
using EMS_APP.Models;
using Microsoft.EntityFrameworkCore;

namespace EMS_APP.Data
{
    public class EMS_DBContext : DbContext 
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conn = @"Server=(localdb)\MSSQLLocalDB;Database=EMS_DB;Integrated Security=True;";
            optionsBuilder.UseSqlServer(conn)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.DefautDept();
            modelBuilder.DefaultAdmin();
            modelBuilder.DepartmentTableMapping();
            modelBuilder.EmployeeTableMapping();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<employeeModel> EMPLOYEES { get; set; }
        public DbSet<departmentModel> DEPARTMENTS { get; set; }
     
    }
}
