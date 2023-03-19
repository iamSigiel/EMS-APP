using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EMS_APP.Models
{
    public class employeeModel
    {
        //Default Constructor
        public employeeModel()
        {
        }

        //Variables
        [DisplayName("ID")]
        public int id { get; set; }

        [DisplayName("Name")]
        public string? empName { get; set; }

        [DisplayName("Date of Birth")]
        public DateTime empDOB { get; set; }

        [DisplayName("Email Address")]
        [EmailAddress]
        public string empEmail { get; set; }

        [DisplayName("Phone Number")]
        public string empPhone { get; set; }

        [DisplayName("Admin")]
        public bool isAdmin { get; set; }


        //Relationship
        [DisplayName("Department")]
        public departmentModel? department { get; set; }
        public int deptID { get; set; }



        //Parameterized Constructor
        public employeeModel(int id, string empName, DateTime empDOB, string empEmail, string empPhone, bool isAdmin, int deptID)
        {
            this.id = id;
            this.empName = empName;
            this.empDOB = empDOB;
            this.empEmail = empEmail;
            this.empPhone = empPhone;
            this.isAdmin = isAdmin;
            this.deptID = deptID;
        }


    }
}
