namespace ManagementStudent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        id_feedBack = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        content = c.String(),
                        id_user = c.Int(nullable: false),
                        created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id_feedBack)
                .ForeignKey("dbo.Users", t => t.id_user)
                .Index(t => t.id_user);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        id_post = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        content = c.String(),
                        created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id_post);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Feedbacks", "id_user", "dbo.Users");
            DropIndex("dbo.Feedbacks", new[] { "id_user" });
            DropTable("dbo.Posts");
            DropTable("dbo.Feedbacks");
        }
    }
}
