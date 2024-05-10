namespace Shop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addConfirmdateContact : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contact", "ConfirmDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contact", "ConfirmDate");
        }
    }
}
