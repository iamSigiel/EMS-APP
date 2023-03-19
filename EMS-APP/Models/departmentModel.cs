using System.ComponentModel;

namespace EMS_APP.Models
{
    public class departmentModel
    {
        //Default Constructor
        public departmentModel()
        {
        }

        //Variables
        [DisplayName("ID")]
        public int deptID { get; set; }

        [DisplayName("Department Name")]
        public string deptName { get; set;}

        //Relationship
        public ICollection<employeeModel>? employees { get; set; }

        //Parameterized Constructor
        public departmentModel(int deptID, string deptName)
        {
            this.deptID = deptID;
            this.deptName = deptName;
        }
    }
}
