using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormAPP.Services;

namespace WebFormAPP.EmployeesContainer
{
    public partial class AddEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.IsInRole("Admin"))
            {
                Response.StatusCode = 401;
                Response.End();
            }
            if (!IsPostBack)
            {

                DepartmentsService departmentsService = new DepartmentsService();
                var departs = departmentsService.GetAllDepartments();
                foreach (var dep in departs)
                {
                    Departments.Items.Add(new ListItem(dep.DepartmentName, dep.DepartmentID + ""));
                }
            }
            
        }

        protected void AddNewEmployee(object sender, EventArgs e)
        {
            EmployeesService employeesService = new EmployeesService();
            DepartmentsService departmentsService = new DepartmentsService();

            var DepartmentsEmployess = new List<DepartmentsEmployess>();
            foreach (ListItem deps in Departments.Items)
            {
                if (deps.Selected)
                {
                    DepartmentsEmployess.Add(new DepartmentsEmployess() { DepartmentID = long.Parse(deps.Value) });
                }
            }
            Employees employee = new Employees()
            {
                FirstName = FirstName.Text,
                LastName = LastName.Text,
                Salary = int.Parse(Salary.Text),
                DateOfBirth = DateTime.Parse(DateOfBirth.Text),
                Position = Position.Text,
                DepartmentsEmployess = DepartmentsEmployess

            };
            //employee.DepartmentsEmployess = new List<DepartmentsEmployess>();
           
            employeesService.AddEmployee(employee, DepartmentsEmployess);
            Response.Redirect("EmployeeList.aspx");
        }
    }
}