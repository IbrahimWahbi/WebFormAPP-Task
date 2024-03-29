﻿using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class Employees 
    {
        public long EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }    
        public decimal Salary { get; set; }
        public DateTime DateOfBirth { get; set; }
        public virtual ICollection<DepartmentsEmployess> DepartmentsEmployess { get; set; }
    }
}
