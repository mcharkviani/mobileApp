namespace MobileApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateManufacturer : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Manufacturers(Name) VALUES('Apple')");
            Sql("INSERT INTO Manufacturers(Name) VALUES('Nokia')");
            Sql("INSERT INTO Manufacturers(Name) VALUES('Sony')");
            Sql("INSERT INTO Manufacturers(Name) VALUES('Huawei')");
            Sql("INSERT INTO Manufacturers(Name) VALUES('LG')");
            Sql("INSERT INTO Manufacturers(Name) VALUES('Samsung')");
            Sql("INSERT INTO Manufacturers(Name) VALUES('Microsoft')");

        }
        
        public override void Down()
        {
        }
    }
}
