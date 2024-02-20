namespace WebFormAPP.Migrations
{
    using Domain.Entites;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebFormAPP.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebFormAPP.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebFormAPP.Models.ApplicationDbContext context)
        {
            context.Departments.AddOrUpdate(new Departments() {DepartmentID =1, DepartmentName = "Department 1" });
            context.Departments.AddOrUpdate(new Departments() { DepartmentID = 2, DepartmentName = "Department 2" });
            context.Departments.AddOrUpdate(new Departments() { DepartmentID = 3, DepartmentName = "Department 3" });

            var manager1 = new RoleManager<IdentityRole>((IRoleStore<IdentityRole, string>)new RoleStore<IdentityRole>((DbContext)context));
            var manager2 = new UserManager<ApplicationUser>((IUserStore<ApplicationUser>)new UserStore<ApplicationUser>((DbContext)context));
            if (!manager1.RoleExists<IdentityRole, string>("Developer"))
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Developer";
                manager1.Create<IdentityRole, string>(role);
                ApplicationUser user = new ApplicationUser();
                user.UserName = "ibrahim.wahbi.123@gmail.com";
                user.Email = "ibrahim.wahbi.123@gmail.com";
                string password = "123456789";
                if (manager2.Create<ApplicationUser, string>(user, password).Succeeded)
                    manager2.AddToRole<ApplicationUser, string>(user.Id, "Developer");
            }
            if (!manager1.RoleExists<IdentityRole, string>("Admin"))
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                manager1.Create(role);
                ApplicationUser user = new ApplicationUser();
                user.UserName = "admin@gmail.com";
                user.Email = "admin@gmail.com";
                string password = "123456789";
                if (manager2.Create(user, password).Succeeded)
                    manager2.AddToRole(user.Id, "admin");
            }
            if (!manager1.RoleExists("ReadOnly"))
            {
                IdentityRole role = new IdentityRole();
                role.Name = "ReadOnly";
                manager1.Create(role);
            }
            if (!manager1.RoleExists("Editor"))
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Editor";
                manager1.Create(role);
            }
            if (!manager1.RoleExists("Adder"))
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Adder";
                manager1.Create(role);
            }
        }
    }
}
