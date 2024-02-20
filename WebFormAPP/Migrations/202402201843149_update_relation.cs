namespace WebFormAPP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_relation : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.DepartmentsEmployess", name: "EmployeeID", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.DepartmentsEmployess", name: "DepartmentID", newName: "EmployeeID");
            RenameColumn(table: "dbo.DepartmentsEmployess", name: "__mig_tmp__0", newName: "DepartmentID");
            RenameIndex(table: "dbo.DepartmentsEmployess", name: "IX_EmployeeID", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.DepartmentsEmployess", name: "IX_DepartmentID", newName: "IX_EmployeeID");
            RenameIndex(table: "dbo.DepartmentsEmployess", name: "__mig_tmp__0", newName: "IX_DepartmentID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.DepartmentsEmployess", name: "IX_DepartmentID", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.DepartmentsEmployess", name: "IX_EmployeeID", newName: "IX_DepartmentID");
            RenameIndex(table: "dbo.DepartmentsEmployess", name: "__mig_tmp__0", newName: "IX_EmployeeID");
            RenameColumn(table: "dbo.DepartmentsEmployess", name: "DepartmentID", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.DepartmentsEmployess", name: "EmployeeID", newName: "DepartmentID");
            RenameColumn(table: "dbo.DepartmentsEmployess", name: "__mig_tmp__0", newName: "EmployeeID");
        }
    }
}
