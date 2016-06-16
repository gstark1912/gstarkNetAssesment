namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Operation",
                c => new
                    {
                        IDOperation = c.Int(nullable: false, identity: true),
                        IDOperationCode = c.Int(nullable: false),
                        IDCard = c.Int(nullable: false),
                        Amount = c.Decimal(precision: 18, scale: 2),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.IDOperation);
            
            CreateTable(
                "dbo.OperationCode",
                c => new
                    {
                        IDOperationCode = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.IDOperationCode);
            
            CreateTable(
                "dbo.UserCard",
                c => new
                    {
                        IDUserCard = c.Int(nullable: false, identity: true),
                        CardNumber = c.Long(nullable: false),
                        Password = c.Int(nullable: false),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Blocked = c.Boolean(nullable: false),
                        LoginAttempts = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDUserCard)
                .Index(t => t.CardNumber, unique: true, name: "Index");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.UserCard", "Index");
            DropTable("dbo.UserCard");
            DropTable("dbo.OperationCode");
            DropTable("dbo.Operation");
        }
    }
}
