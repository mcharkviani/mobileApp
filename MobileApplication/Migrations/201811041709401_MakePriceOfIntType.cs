namespace MobileApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakePriceOfIntType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Mobiles", "Price", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Mobiles", "Price", c => c.String());
        }
    }
}
