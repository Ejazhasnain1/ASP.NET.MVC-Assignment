namespace MindfireSolutions.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeContacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        ContactNumber = c.String(),
                        ContactTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContactId)
                .ForeignKey("dbo.ContactTypes", t => t.ContactTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.ContactTypeId);
            
            CreateTable(
                "dbo.ContactTypes",
                c => new
                    {
                        ContactTypeId = c.Int(nullable: false, identity: true),
                        ContactTypeValue = c.String(),
                    })
                .PrimaryKey(t => t.ContactTypeId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        Firstname = c.String(nullable: false),
                        Lastname = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        EmployeeImage = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeContacts", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.EmployeeContacts", "ContactTypeId", "dbo.ContactTypes");
            DropIndex("dbo.EmployeeContacts", new[] { "ContactTypeId" });
            DropIndex("dbo.EmployeeContacts", new[] { "EmployeeId" });
            DropTable("dbo.Employees");
            DropTable("dbo.ContactTypes");
            DropTable("dbo.EmployeeContacts");
        }
    }
}
