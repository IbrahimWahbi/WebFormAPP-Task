using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormAPP.Dtos;
using WebFormAPP.Services;

namespace WebFormAPP.EmployeesContainer
{
    public partial class EditEmployee : System.Web.UI.Page
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

                EmployeesDto Employee_data;

                DepartmentsService departmentsService = new DepartmentsService();
                var departs = departmentsService.GetAllDepartments();


                var DepartmentsEmployess = new List<DepartmentsEmployess>();



                EmployeesService employeesService = new EmployeesService();
                var employeesService_ = employeesService.Get_Employee_ById(long.Parse(Request.QueryString["EmployeeId"]));

                FirstName.Text = employeesService_.FirstName;
                LastName.Text = employeesService_.LastName;
                Salary.Text = employeesService_.Salary.ToString();
                DateOfBirth.Text = employeesService_.DateOfBirth.ToString();
                Position.Text = employeesService_.Position.ToString();
                HiddenField_EmployeeID.Value = employeesService_.EmployeeID.ToString();
                foreach (var dep in departs)
                {
                    Departments.Items.Add(new ListItem(dep.DepartmentName, dep.DepartmentID + ""));
                    if (employeesService_.DepartmentsEmployess.Where(m => m.DepartmentID == dep.DepartmentID).Any())
                    {
                        Departments.Items[Departments.Items.Count - 1].Selected = true;
                    }
                }
            }

            
        }

        protected void EditEmployee_btn(object sender, EventArgs e)
        {
            EmployeesService employeesService = new EmployeesService();
            DepartmentsService departmentsService = new DepartmentsService();


            var DepartmentsEmployess = new List<DepartmentsEmployessDto>();
            foreach (ListItem deps in Departments.Items)
            {
                if (deps.Selected)
                {
                    DepartmentsEmployess.Add(new DepartmentsEmployessDto() { DepartmentID = long.Parse(deps.Value) });
                }
            }
          
            EmployeesDto employee = new EmployeesDto()
            {
                FirstName = FirstName.Text,
                LastName = LastName.Text,
                Salary = decimal.Parse(Salary.Text),
                DateOfBirth = DateTime.Parse(DateOfBirth.Text),
                Position = Position.Text,
                EmployeeID = long.Parse(HiddenField_EmployeeID.Value),
                DepartmentsEmployess = DepartmentsEmployess

            };
            
            employeesService.EditEmployee(employee);
            Response.Redirect("EmployeeList.aspx");
        }
    }
}