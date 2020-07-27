namespace TransactionDataUpload.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TransactionDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TransactionId = c.Int(nullable: false),
                        Identificator = c.String(maxLength: 4000),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CurrencyCode = c.String(maxLength: 4000),
                        TransactionDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Transactions", t => t.TransactionId, cascadeDelete: true)
                .Index(t => t.TransactionId);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 4000),
                        Created = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TransactionDatas", "TransactionId", "dbo.Transactions");
            DropIndex("dbo.TransactionDatas", new[] { "TransactionId" });
            DropTable("dbo.Transactions");
            DropTable("dbo.TransactionDatas");
        }
    }
}
