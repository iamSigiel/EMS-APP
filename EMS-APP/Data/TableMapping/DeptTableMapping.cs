using EMS_APP.Models;
using Microsoft.EntityFrameworkCore;

namespace EMS_APP.Data.TableMapping
{
    public static class DeptTableMapping
    {
        public static void DepartmentTableMapping( this ModelBuilder modelBuilder)
        {
            //TABLE PROPERTIES
            modelBuilder.Entity<departmentModel>()
                .ToTable("DEPARTMENTS LIST")
                .HasKey(pk => pk.deptID);

            //COLUMN PROPERTIES
            modelBuilder.Entity<departmentModel>()
                .Property(p => p.deptID)
                .HasColumnName("ID");

            modelBuilder.Entity<departmentModel>()
                .Property(p => p.deptName)
                .IsRequired()
                .HasColumnName("Department Name");
                
        }

    }
}
