namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Operation", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Operation", "TimeStamp");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Operation", "TimeStamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            DropColumn("dbo.Operation", "Date");
        }
    }
}
