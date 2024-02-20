using Domain;
using Domain.Entites;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebFormAPP.ModelsConfig;

namespace WebFormAPP.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public IDbSet<Employees> Employees { get; set; }
        public IDbSet<Departments> Departments { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new DepartmentsConfig());
            modelBuilder.Configurations.Add(new DepartmentsEmployessConfig());
            modelBuilder.Configurations.Add(new EmployeesConfig());
        }
    }
}