namespace ManagementStudent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class n2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Days",
                c => new
                    {
                        id_day = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.id_day);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        id_role = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.id_role);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        id_role = c.Int(nullable: false, identity: true),
                        id_subject = c.Int(nullable: false),
                        id_day = c.Int(nullable: false),
                        id_session = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_role)
                .ForeignKey("dbo.Days", t => t.id_day, cascadeDelete: true)
                .ForeignKey("dbo.Sessions", t => t.id_session, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.id_subject, cascadeDelete: true)
                .Index(t => t.id_subject)
                .Index(t => t.id_day)
                .Index(t => t.id_session);
            
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        id_session = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.id_session);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        id_subject = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 255),
                        status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_subject);
            
            CreateTable(
                "dbo.Scores",
                c => new
                    {
                        id_score = c.Int(nullable: false, identity: true),
                        id_user = c.Int(nullable: false),
                        id_subject = c.Int(nullable: false),
                        point = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.id_score)
                .ForeignKey("dbo.Subjects", t => t.id_subject, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.id_user, cascadeDelete: true)
                .Index(t => t.id_user)
                .Index(t => t.id_subject);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id_user = c.Int(nullable: false, identity: true),
                        username = c.String(nullable: false, maxLength: 255),
                        password = c.String(nullable: false, maxLength: 255),
                        fullname = c.String(nullable: false, maxLength: 255),
                        address = c.String(nullable: false, maxLength: 255),
                        gender = c.Int(nullable: false),
                        grade = c.String(nullable: false, maxLength: 255),
                        status = c.Int(nullable: false),
                        id_role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_user)
                .ForeignKey("dbo.Roles", t => t.id_role, cascadeDelete: true)
                .Index(t => t.id_role);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Scores", "id_user", "dbo.Users");
            DropForeignKey("dbo.Users", "id_role", "dbo.Roles");
            DropForeignKey("dbo.Scores", "id_subject", "dbo.Subjects");
            DropForeignKey("dbo.Schedules", "id_subject", "dbo.Subjects");
            DropForeignKey("dbo.Schedules", "id_session", "dbo.Sessions");
            DropForeignKey("dbo.Schedules", "id_day", "dbo.Days");
            DropIndex("dbo.Users", new[] { "id_role" });
            DropIndex("dbo.Scores", new[] { "id_subject" });
            DropIndex("dbo.Scores", new[] { "id_user" });
            DropIndex("dbo.Schedules", new[] { "id_session" });
            DropIndex("dbo.Schedules", new[] { "id_day" });
            DropIndex("dbo.Schedules", new[] { "id_subject" });
            DropTable("dbo.Users");
            DropTable("dbo.Scores");
            DropTable("dbo.Subjects");
            DropTable("dbo.Sessions");
            DropTable("dbo.Schedules");
            DropTable("dbo.Roles");
            DropTable("dbo.Days");
        }
    }
}
