using EMS_APP.Data;
using EMS_APP.Models;
using EMS_APP.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EMS_APP.Repository.Repo.MSSQL
{
    public class DBDepartment : IDepartmentRepo
    {
        //CONNECT TO THE DATABASE THRU THE DBCONTEXT

        EMS_DBContext _dbContext;

        public DBDepartment(EMS_DBContext dbContext)
        {
            _dbContext = dbContext;
        }


        //METHODS
        //READ-ALL
        public List<departmentModel> GetAllDepartments()
        {
            return _dbContext.DEPARTMENTS.AsNoTracking().ToList();
        }


        //READ-ONLY ONE
        public  departmentModel GetDepartmentById(int Id)
        {
            return  _dbContext.DEPARTMENTS.AsNoTracking().ToList().FirstOrDefault(m => m.deptID == Id);
        }


        //CREATE
        public departmentModel AddDepartment(departmentModel newDepartment)
        {
            _dbContext.DEPARTMENTS.Add(newDepartment);
            _dbContext.SaveChangesAsync();
            return newDepartment;
        }

        //UPDATE
        public departmentModel UpdateDepartment(int id,departmentModel newDepartment)
        {
            _dbContext.DEPARTMENTS.Update(newDepartment);
            _dbContext.SaveChangesAsync();
            return newDepartment;
        }

        //DELETE
        public departmentModel DeleteDepartment(int deptId)
        {
            var dept = GetDepartmentById(deptId);
            if (dept != null)
            {
                _dbContext.DEPARTMENTS.Remove(dept);
                _dbContext.SaveChangesAsync();
            }
            return dept;
        }
    }
}
