using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class DepartmentsEmployees
    {
        public long DepartmentID { get; set; }
        public Departments department { get; set; }
        public long EmployeeID { get; set; }
        public Employees employee { get; set; }
    }
}
