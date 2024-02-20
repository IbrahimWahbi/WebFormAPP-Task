using Domain.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace WebFormAPP.ModelsConfig
{
    public class EmployeesConfig : EntityTypeConfiguration<Employees>
    {
        public EmployeesConfig()
        {
            this.ToTable("Employees");
            HasKey(x => x.EmployeeID)
              .Property(x => x.EmployeeID).HasColumnType("bigint")
              .IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Salary)
                .HasColumnName("Salary")
                .HasColumnType("decimal")
                .IsRequired();

            Property(x => x.Position)
                .HasColumnName("Position")
                .HasColumnType("nvarchar")
                .IsRequired().HasMaxLength(100);

            Property(x => x.FirstName)
                .HasColumnName("FirstName")
                .HasColumnType("nvarchar")
                .IsRequired().HasMaxLength(20);
           
            Property(x => x.LastName)
               .HasColumnName("LastName")
               .HasColumnType("nvarchar")
               .IsRequired().HasMaxLength(20);

            Property(x => x.DateOfBirth)
               .HasColumnName("DateOfBirth")
               .HasColumnType("datetime2")
               .IsOptional();
        }
    }
}