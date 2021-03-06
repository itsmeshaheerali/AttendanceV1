namespace AttendanceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LeaveApplicationModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LeaveApplications",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Reason = c.String(),
                        from = c.DateTime(nullable: false),
                        NoOfDays = c.Single(nullable: false),
                        ResponseMessage = c.String(),
                        MedicalCertificate = c.String(),
                        Haspermission = c.Boolean(),
                        LeaveType = c.Int(nullable: false),
                        AppliedByAdmin = c.Boolean(nullable: false),
                        EmployeeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Employees", t => t.EmployeeID, cascadeDelete: true)
                .Index(t => t.EmployeeID);
            
            DropTable("dbo.Attendances");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ComingTime = c.DateTime(nullable: false),
                        DateOfDay = c.DateTime(nullable: false),
                        LeaveTime = c.DateTime(),
                        EmployeeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            DropForeignKey("dbo.LeaveApplications", "EmployeeID", "dbo.Employees");
            DropIndex("dbo.LeaveApplications", new[] { "EmployeeID" });
            DropTable("dbo.LeaveApplications");
        }
    }
}
