namespace ManagementStudent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Majors",
                c => new
                    {
                        id_major = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_major);
            
            AddColumn("dbo.Scores", "pointWord", c => c.String());
            AddColumn("dbo.Users", "id_major", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "id_major");
            AddForeignKey("dbo.Users", "id_major", "dbo.Majors", "id_major", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "id_major", "dbo.Majors");
            DropIndex("dbo.Users", new[] { "id_major" });
            DropColumn("dbo.Users", "id_major");
            DropColumn("dbo.Scores", "pointWord");
            DropTable("dbo.Majors");
        }
    }
}
