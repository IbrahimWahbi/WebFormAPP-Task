using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormAPP.Services;

namespace WebFormAPP.EmployeesContainer
{
    public partial class EmployeeList : System.Web.UI.Page
    {
        EmployeesService empService;
        protected void Page_Load(object sender, EventArgs e)
        {
            empService = new EmployeesService();
            var delete = Request.QueryString["delete"];
            if (delete == "1")
            {
                if (!User.IsInRole("Admin"))
                {
                    Response.StatusCode = 401;
                    Response.End();
                }
                empService.Delete_Employee(long.Parse(Request.QueryString["EmployeeId"]));
            }
            StringBuilder htmlTableString = new StringBuilder();
            htmlTableString.AppendLine("<table id='myTable' class='table table-hover table-responsive table-border table-sm'>");
            htmlTableString.AppendLine("<thead>");
            htmlTableString.AppendLine("<tr>");
            htmlTableString.AppendLine("<th>Employee ID</th>");
            htmlTableString.AppendLine("<th>First Name</th>");
            htmlTableString.AppendLine("<th>Last Name</th>");
            htmlTableString.AppendLine("<th>Position </th>");
            htmlTableString.AppendLine("<th>Salary </th>");
            htmlTableString.AppendLine("<th>DateOfBirth </th>");
            htmlTableString.AppendLine("<th> </th>");
            htmlTableString.AppendLine("</tr>");
            htmlTableString.AppendLine("</thead>");
            htmlTableString.AppendLine("<tbody>");
            empService.GetAllEmployeess().ForEach(emp =>
            {
                htmlTableString.AppendLine("<tr>");
                htmlTableString.AppendLine($"<td>{emp.EmployeeID}</td>");
                htmlTableString.AppendLine($"<td>{emp.FirstName}</td>");
                htmlTableString.AppendLine($"<td>{emp.LastName}</td>");
                htmlTableString.AppendLine($"<td>{emp.Position}</td>");
                htmlTableString.AppendLine($"<td>{emp.Salary}</td>");
                htmlTableString.AppendLine($"<td>{emp.DateOfBirth}</td>");
                htmlTableString.AppendLine($"<td> <a class='btn btn-small btn-warning' href = 'EditEmployee.aspx?EmployeeId={emp.EmployeeID}'>Edit</a> " +
                    $" <a class='btn btn-small btn-danger' href = 'EmployeeList.aspx?EmployeeId={emp.EmployeeID}&delete=1'>Delete</a></td>");
                htmlTableString.AppendLine("</tr>");
            });
            htmlTableString.AppendLine("</tbody>");
            htmlTableString.AppendLine("</table>");
            litTable.Text = htmlTableString.ToString();
        }

        

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click1(object sender, EventArgs e)
        {
            
        }
    }
}