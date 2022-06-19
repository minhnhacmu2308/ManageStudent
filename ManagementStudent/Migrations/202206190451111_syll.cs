namespace ManagementStudent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class syll : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "nguontuyen", c => c.String(maxLength: 500));
            AddColumn("dbo.Users", "truongchuyen", c => c.String(maxLength: 500));
            AddColumn("dbo.Users", "dantoc", c => c.String(maxLength: 500));
            AddColumn("dbo.Users", "tongiao", c => c.String(maxLength: 500));
            AddColumn("dbo.Users", "quoctinh", c => c.String(maxLength: 500));
            AddColumn("dbo.Users", "cmnd", c => c.String(maxLength: 500));
            AddColumn("dbo.Users", "noicap", c => c.String(maxLength: 500));
            AddColumn("dbo.Users", "chieucao", c => c.String(maxLength: 500));
            AddColumn("dbo.Users", "cannang", c => c.String(maxLength: 500));
            AddColumn("dbo.Users", "sonambodoi", c => c.String(maxLength: 500));
            AddColumn("dbo.Users", "sonamtnxp", c => c.String(maxLength: 500));
            AddColumn("dbo.Users", "ngaycap", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "ngaycap");
            DropColumn("dbo.Users", "sonamtnxp");
            DropColumn("dbo.Users", "sonambodoi");
            DropColumn("dbo.Users", "cannang");
            DropColumn("dbo.Users", "chieucao");
            DropColumn("dbo.Users", "noicap");
            DropColumn("dbo.Users", "cmnd");
            DropColumn("dbo.Users", "quoctinh");
            DropColumn("dbo.Users", "tongiao");
            DropColumn("dbo.Users", "dantoc");
            DropColumn("dbo.Users", "truongchuyen");
            DropColumn("dbo.Users", "nguontuyen");
        }
    }
}
