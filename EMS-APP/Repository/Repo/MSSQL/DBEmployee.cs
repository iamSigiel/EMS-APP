using EMS_APP.Data;
using EMS_APP.Models;
using EMS_APP.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EMS_APP.Repository.Repo.MSSQL
{
    public class DBEmployee : IEmployeeRepo
    {
        //CONNECT TO THE DATABASE THRU THE DBCONTEXT
        EMS_DBContext _dbContext;

        public DBEmployee(EMS_DBContext dbContext)
        {
            _dbContext = dbContext;
        }


        //METHODS
        //READ-ALL
        public List<employeeModel> GetAllEmployees()
        {
            return _dbContext.EMPLOYEES.Include(e => e.department).AsNoTracking().ToList();
        }

        //READ-ONLY ONE
        public employeeModel GetEmployeeById(int Id)
        {
            return _dbContext.EMPLOYEES.Include(e =>e.department).AsNoTracking().ToList().FirstOrDefault(m => m.id == Id);
        }


        //CREATE
        public employeeModel AddEmployee(employeeModel newEmployee)
        {
            _dbContext.EMPLOYEES.Add(newEmployee);
            _dbContext.SaveChangesAsync(); 
            return newEmployee;
        }


        //UPDATE
        public employeeModel UpdateEmployee(int empId, employeeModel newEmployee)
        {
            _dbContext.EMPLOYEES.Update(newEmployee);
            _dbContext.SaveChangesAsync();
            return newEmployee;
        }


        //DELETE
        public employeeModel DeleteEmployee(int empId)
        {
            var emp = GetEmployeeById(empId);
            if (emp != null)
            {
                _dbContext.EMPLOYEES.Remove(emp);
                _dbContext.SaveChangesAsync();
            }
            return emp;
        }
    }
}
