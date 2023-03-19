using EMS_APP.Models;
using EMS_APP.Repository.Interfaces;

namespace EMS_APP.Repository.Repo.InMemory
{
    public class InMemDepartment : IDepartmentRepo
    {
        //STATIC DATA
        static List<departmentModel> departmentList = new List<departmentModel>();

        public InMemDepartment() 
        {
            departmentList.Add(new departmentModel(1, "Admin"));
            departmentList.Add(new departmentModel(2, "Finance"));
            departmentList.Add(new departmentModel(3, "IT"));
            departmentList.Add(new departmentModel(4, "Human Resource"));
        }


        //METHODS
        //READ ALL
        public List<departmentModel> GetAllDepartments()
        {
            return departmentList;
        }

        //READ ONLY ONE
        public departmentModel GetDepartmentById(int Id)
        {
            return departmentList.FirstOrDefault(x => x.deptID == Id);
        }


        //CREATE
        public departmentModel AddDepartment(departmentModel newDepartment)
        {
            newDepartment.deptID = departmentList.Max(x => x.deptID)+1;
            departmentList.Add(newDepartment);
            return newDepartment;
        }

        //UPDATE
        public departmentModel UpdateDepartment(int deptId, departmentModel newDepartment)
        {
            var department = departmentList.Find(x => x.deptID == deptId);
            if (department != null) 
            { 
                departmentList.Remove(department);
                departmentList.Add(newDepartment);
            }
            return newDepartment;
        }

        //DELETE
        public departmentModel DeleteDepartment(int deptId)
        {
            var department = departmentList.Find(x => x.deptID == deptId);
            if (department != null)
            {
                departmentList.Remove(department);
            }
            
            return department;
        }



       
    }
}
