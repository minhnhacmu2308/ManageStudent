namespace ManagementStudent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Scores", "point2", c => c.Single(nullable: false));
            DropColumn("dbo.Scores", "id_semester");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Scores", "id_semester", c => c.Int(nullable: false));
            DropColumn("dbo.Scores", "point2");
        }
    }
}
