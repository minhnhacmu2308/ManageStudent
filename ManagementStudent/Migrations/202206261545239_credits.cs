namespace ManagementStudent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class credits : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Credits",
                c => new
                    {
                        id_credit = c.Int(nullable: false, identity: true),
                        id_user = c.Int(nullable: false),
                        id_subject = c.Int(nullable: false),
                        status = c.Int(nullable: false),
                        created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id_credit)
                .ForeignKey("dbo.Subjects", t => t.id_subject)
                .ForeignKey("dbo.Users", t => t.id_user)
                .Index(t => t.id_user)
                .Index(t => t.id_subject);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Credits", "id_user", "dbo.Users");
            DropForeignKey("dbo.Credits", "id_subject", "dbo.Subjects");
            DropIndex("dbo.Credits", new[] { "id_subject" });
            DropIndex("dbo.Credits", new[] { "id_user" });
            DropTable("dbo.Credits");
        }
    }
}
