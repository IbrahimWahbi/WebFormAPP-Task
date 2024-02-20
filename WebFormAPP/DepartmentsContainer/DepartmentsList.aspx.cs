using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unity;
using WebFormAPP.Services;

namespace WebFormAPP.DepartmentsContainer
{
    public partial class DepartmentsList : System.Web.UI.Page
    {
        
        

        protected  void Page_Load(object sender, EventArgs e)
        {
            DepartmentsService departmentsService = new DepartmentsService();
            
            StringBuilder htmlTableString = new StringBuilder();
            htmlTableString.AppendLine("<table class='table table-hover table-responsive table-border table-sm'>");
            htmlTableString.AppendLine("<thead>");
            htmlTableString.AppendLine("<tr>");
            htmlTableString.AppendLine("<th>Department ID</th>");
            htmlTableString.AppendLine("<th>Department Name</th>");
            //htmlTableString.AppendLine("<th>Employees</th>");
            htmlTableString.AppendLine("</tr>");
            htmlTableString.AppendLine("</thead>");
            htmlTableString.AppendLine("<tbody>");
            departmentsService.GetAllDepartments().ForEach(departments =>
            {
                htmlTableString.AppendLine("<tr>");
                htmlTableString.AppendLine($"<td>{departments.DepartmentID}</td>");
                htmlTableString.AppendLine($"<td>{departments.DepartmentName}</td>");
                //htmlTableString.AppendLine("<th>Employees</th>");
                htmlTableString.AppendLine("</tr>");
            });
            htmlTableString.AppendLine("</tbody>");
            htmlTableString.AppendLine("</table>");
            litTable.Text = htmlTableString.ToString();
        }

        
    }
}