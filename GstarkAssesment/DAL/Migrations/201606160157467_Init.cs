namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Operation", "IDOperationCode");
            CreateIndex("dbo.Operation", "IDCard");
            AddForeignKey("dbo.Operation", "IDOperationCode", "dbo.OperationCode", "IDOperationCode", cascadeDelete: true);
            AddForeignKey("dbo.Operation", "IDCard", "dbo.UserCard", "IDUserCard", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Operation", "IDCard", "dbo.UserCard");
            DropForeignKey("dbo.Operation", "IDOperationCode", "dbo.OperationCode");
            DropIndex("dbo.Operation", new[] { "IDCard" });
            DropIndex("dbo.Operation", new[] { "IDOperationCode" });
        }
    }
}
