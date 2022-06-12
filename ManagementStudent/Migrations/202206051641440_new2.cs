namespace ManagementStudent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Scores", "id_semester", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Scores", "id_semester");
        }
    }
}
