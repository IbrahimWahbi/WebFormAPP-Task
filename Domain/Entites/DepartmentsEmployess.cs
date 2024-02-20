using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class DepartmentsEmployess
    {
        [Key]
        public long DepartmentsEmployessID { get; set; }
        public long DepartmentID { get; set; }
        public long EmployeeID { get; set; }
        public virtual Departments Departments { get; set; }
        public virtual Employees Employees { get; set; }
    }
}
