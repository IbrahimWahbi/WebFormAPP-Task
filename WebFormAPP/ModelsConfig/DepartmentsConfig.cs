using Domain.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace WebFormAPP.ModelsConfig
{
    public class DepartmentsConfig : EntityTypeConfiguration<Departments>
    {
        public DepartmentsConfig()
        {
            this.ToTable("Departments");
            HasKey(x => x.DepartmentID)
              .Property(x => x.DepartmentID).HasColumnType("bigint")
              .IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.DepartmentName)
                .HasColumnName("DepartmentName")
                .HasColumnType("nvarchar")
                .IsRequired()
                .HasMaxLength(100);

        }
    }
}