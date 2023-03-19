using EMS_APP.Models;

namespace EMS_APP.Repository.Interfaces
{
    public interface IEmployeeRepo
    {
        List<employeeModel> GetAllEmployees();

        employeeModel GetEmployeeById(int Id);
        employeeModel AddEmployee(employeeModel newEmployee);
        employeeModel UpdateEmployee(int empId, employeeModel newEmployee);
        employeeModel DeleteEmployee(int empId);
    }
}
