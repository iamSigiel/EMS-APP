using EMS_APP.Models;
using EMS_APP.Repository.Interfaces;

namespace EMS_APP.Repository.Repo.InMemory
{
    public class InMemEmployee : IEmployeeRepo
    {
        //STATIC DATA
        static List<employeeModel> employeeList = new List<employeeModel>();

        static InMemEmployee()
        {
            employeeList.Add(new employeeModel(1, "admin", DateTime.Now.AddYears(-22), "admin@ems.com", "09987654321", true, 1));
            employeeList.Add(new employeeModel(2, "charl", DateTime.Now.AddYears(-26), "user1@ems.com", "09987653421", false, 3));
            employeeList.Add(new employeeModel(3, "anna", DateTime.Now.AddYears(-25), "user2@ems.com", "09987653412", false, 2));
            employeeList.Add(new employeeModel(4, "matthew", DateTime.Now.AddYears(-23), "user3@ems.com", "09986753421", false, 3));
            employeeList.Add(new employeeModel(5, "celine", DateTime.Now.AddYears(-20), "user4@ems.com", "09978653421", false, 4));
        }


        //METHODS
        //READ ALL
        public List<employeeModel> GetAllEmployees()
        {
            return employeeList;
        }

        //READ ONLY ONE
        public employeeModel GetEmployeeById(int Id)
        {
            return employeeList.FirstOrDefault(x => x.id == Id);
        }

        //CREATE
        public employeeModel AddEmployee(employeeModel newEmployee)
        {
            newEmployee.id = employeeList.Max(x => x.id) + 1;
            employeeList.Add(newEmployee);
            return newEmployee;
        }

        //DELETE
        public employeeModel DeleteEmployee(int id)
        {
            var emp = GetEmployeeById(id);
            if (emp != null)
            {
                employeeList.Remove(emp);
            }
            return emp;
        }

        //UPDATE
        public employeeModel UpdateEmployee(int id, employeeModel newEmployee)
        {
            var emp = employeeList.Find(x => x.id == id);
            if (emp != null)
            {
                employeeList.Remove(emp);
                employeeList.Add(newEmployee);
            }

            return newEmployee;
        }
    }
}
