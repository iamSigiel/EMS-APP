using EMS_APP.Models;
using Microsoft.EntityFrameworkCore;

namespace EMS_APP.Data.SeedData
{
    public static class DefaultSeedData
    {
        //DEFAULT ADMIN DATA
        //int empId, string empName, DateTime? empDOB, string empEmail, int empPhone, int deptID)
        public static void DefaultAdmin(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<employeeModel>().HasData
                (
                    new employeeModel(1, "Admin", DateTime.Now.AddYears(-22), "admin@ems.com", "09987654321", true, 1)
                );
        }

        //DEFAULT ROLES
        public static void DefautDept(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<departmentModel>().HasData
                (
                    new departmentModel(1, "Admin")
                );
        }
    }
}
