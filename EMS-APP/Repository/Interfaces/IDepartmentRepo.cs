using EMS_APP.Models;

namespace EMS_APP.Repository.Interfaces
{
    public interface IDepartmentRepo
    {
        List<departmentModel> GetAllDepartments();

        departmentModel GetDepartmentById(int Id);
        departmentModel AddDepartment(departmentModel newDepartment);
        departmentModel UpdateDepartment(int deptId, departmentModel newDepartment);
        departmentModel DeleteDepartment(int deptId);
    }
}
