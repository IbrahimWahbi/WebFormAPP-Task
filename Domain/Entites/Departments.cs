using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class Departments
    {
        public long DepartmentID { get; set; }
        public string DepartmentName {  get; set; } 
        public virtual ICollection<DepartmentsEmployess> DepartmentsEmployess { get; set; }
    }
}
