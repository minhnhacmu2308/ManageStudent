namespace ManagementStudent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schedules", "id_major", c => c.Int(nullable: false));
            CreateIndex("dbo.Schedules", "id_major");
            AddForeignKey("dbo.Schedules", "id_major", "dbo.Majors", "id_major", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schedules", "id_major", "dbo.Majors");
            DropIndex("dbo.Schedules", new[] { "id_major" });
            DropColumn("dbo.Schedules", "id_major");
        }
    }
}
