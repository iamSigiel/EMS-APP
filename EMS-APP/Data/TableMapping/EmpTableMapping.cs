using EMS_APP.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;


namespace EMS_APP.Data.TableMapping
{
    public static class EmpTableMapping
    {
        public static void EmployeeTableMapping(this ModelBuilder modelBuilder)
        {
            //TABLE PROPERTIES
            modelBuilder.Entity<employeeModel>()
                .ToTable("EMPLOYEES LIST")
                .HasKey(pk => pk.id);

            modelBuilder.Entity<employeeModel>()
                .HasOne<departmentModel>(e => e.department)
                .WithMany(d => d.employees)
                .HasForeignKey(e => e.deptID)
                .HasConstraintName("FK_DeptID");

            //COLUMN PROPERTIES
            //int empId, string empName, DateTime? empDOB, string empEmail, string empPhone, bool isAdmin, int deptID
            modelBuilder.Entity<employeeModel>()
              .Property(e => e.id)
              .HasColumnName("ID");

            modelBuilder.Entity<employeeModel>()
              .Property(e => e.empName)
              .IsRequired()
              .HasColumnName("Name");

            modelBuilder.Entity<employeeModel>()
              .Property(e => e.empDOB)
              .IsRequired()
              .HasColumnName("DOB");

            modelBuilder.Entity<employeeModel>()
              .Property(e => e.empEmail)
              .IsRequired()
              .HasColumnName("Email Address");

            modelBuilder.Entity<employeeModel>()
              .Property(e => e.isAdmin)
              .IsRequired()
              .HasColumnName("ADMIN")
              .HasDefaultValue(false);

            modelBuilder.Entity<employeeModel>()
              .Property(e => e.deptID)
              .IsRequired()
              .HasColumnName("Dapartment ID");

            modelBuilder.Entity<employeeModel>()
              .Property(e => e.empPhone)
              .IsRequired()
              .HasColumnName("Phone Number")
              .HasMaxLength(11);
        }
    }
}
