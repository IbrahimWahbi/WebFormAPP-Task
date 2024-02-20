using Domain.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace WebFormAPP.ModelsConfig
{
    public class DepartmentsEmployessConfig : EntityTypeConfiguration<DepartmentsEmployess>
    {
        public DepartmentsEmployessConfig()
        {
            this.ToTable("DepartmentsEmployess");
            HasKey(x => x.DepartmentsEmployessID)
             .Property(x => x.DepartmentsEmployessID).HasColumnType("bigint")
             .IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(s=>s.Employees).WithMany(s=>s.DepartmentsEmployess).HasForeignKey(s=>s.EmployeeID);
            HasRequired(s => s.Departments).WithMany(s => s.DepartmentsEmployess).HasForeignKey(s => s.DepartmentID);

        }
    }
}