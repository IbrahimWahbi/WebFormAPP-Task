using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFormAPP.Dtos
{
    public class DepartmentsEmployessDto
    {
        public long DepartmentsEmployessID { get; set; }
        public long DepartmentID { get; set; }
        public long EmployeeID { get; set; }
        public string DepartmentName { get; set; }
    }
}