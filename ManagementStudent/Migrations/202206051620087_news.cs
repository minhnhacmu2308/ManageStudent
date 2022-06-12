namespace ManagementStudent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class news : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Schedules", "id_day", "dbo.Days");
            DropForeignKey("dbo.Schedules", "id_major", "dbo.Majors");
            DropForeignKey("dbo.Schedules", "id_session", "dbo.Sessions");
            DropForeignKey("dbo.Schedules", "id_subject", "dbo.Subjects");
            DropForeignKey("dbo.Scores", "id_subject", "dbo.Subjects");
            DropForeignKey("dbo.Scores", "id_user", "dbo.Users");
            DropForeignKey("dbo.Users", "id_major", "dbo.Majors");
            DropForeignKey("dbo.Users", "id_role", "dbo.Roles");
            AddColumn("dbo.Subjects", "id_major", c => c.Int(nullable: false));
            CreateIndex("dbo.Subjects", "id_major");
            AddForeignKey("dbo.Subjects", "id_major", "dbo.Majors", "id_major");
            AddForeignKey("dbo.Schedules", "id_day", "dbo.Days", "id_day");
            AddForeignKey("dbo.Schedules", "id_major", "dbo.Majors", "id_major");
            AddForeignKey("dbo.Schedules", "id_session", "dbo.Sessions", "id_session");
            AddForeignKey("dbo.Schedules", "id_subject", "dbo.Subjects", "id_subject");
            AddForeignKey("dbo.Scores", "id_subject", "dbo.Subjects", "id_subject");
            AddForeignKey("dbo.Scores", "id_user", "dbo.Users", "id_user");
            AddForeignKey("dbo.Users", "id_major", "dbo.Majors", "id_major");
            AddForeignKey("dbo.Users", "id_role", "dbo.Roles", "id_role");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "id_role", "dbo.Roles");
            DropForeignKey("dbo.Users", "id_major", "dbo.Majors");
            DropForeignKey("dbo.Scores", "id_user", "dbo.Users");
            DropForeignKey("dbo.Scores", "id_subject", "dbo.Subjects");
            DropForeignKey("dbo.Schedules", "id_subject", "dbo.Subjects");
            DropForeignKey("dbo.Schedules", "id_session", "dbo.Sessions");
            DropForeignKey("dbo.Schedules", "id_major", "dbo.Majors");
            DropForeignKey("dbo.Schedules", "id_day", "dbo.Days");
            DropForeignKey("dbo.Subjects", "id_major", "dbo.Majors");
            DropIndex("dbo.Subjects", new[] { "id_major" });
            DropColumn("dbo.Subjects", "id_major");
            AddForeignKey("dbo.Users", "id_role", "dbo.Roles", "id_role", cascadeDelete: true);
            AddForeignKey("dbo.Users", "id_major", "dbo.Majors", "id_major", cascadeDelete: true);
            AddForeignKey("dbo.Scores", "id_user", "dbo.Users", "id_user", cascadeDelete: true);
            AddForeignKey("dbo.Scores", "id_subject", "dbo.Subjects", "id_subject", cascadeDelete: true);
            AddForeignKey("dbo.Schedules", "id_subject", "dbo.Subjects", "id_subject", cascadeDelete: true);
            AddForeignKey("dbo.Schedules", "id_session", "dbo.Sessions", "id_session", cascadeDelete: true);
            AddForeignKey("dbo.Schedules", "id_major", "dbo.Majors", "id_major", cascadeDelete: true);
            AddForeignKey("dbo.Schedules", "id_day", "dbo.Days", "id_day", cascadeDelete: true);
        }
    }
}
