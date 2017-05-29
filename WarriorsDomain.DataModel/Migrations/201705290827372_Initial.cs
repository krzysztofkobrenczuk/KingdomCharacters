namespace WarriorsDomain.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bloods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BloodName = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Warriors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ServedInKingdom = c.Boolean(nullable: false),
                        BloodId = c.Int(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bloods", t => t.BloodId, cascadeDelete: true)
                .Index(t => t.BloodId);
            
            CreateTable(
                "dbo.WarriorEquipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        Warrior_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Warriors", t => t.Warrior_Id, cascadeDelete: true)
                .Index(t => t.Warrior_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WarriorEquipments", "Warrior_Id", "dbo.Warriors");
            DropForeignKey("dbo.Warriors", "BloodId", "dbo.Bloods");
            DropIndex("dbo.WarriorEquipments", new[] { "Warrior_Id" });
            DropIndex("dbo.Warriors", new[] { "BloodId" });
            DropTable("dbo.WarriorEquipments");
            DropTable("dbo.Warriors");
            DropTable("dbo.Bloods");
        }
    }
}
