using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFormAPP.Dtos
{
    public class EmployeesDto
    {
        public long EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<DepartmentsEmployessDto> DepartmentsEmployess { get; set; }
    }
}