namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LastOne : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Image = c.Binary(),
                        Price = c.Double(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DropHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        WeaponId = c.Int(nullable: false),
                        CaseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Weapons", t => t.WeaponId)
                .ForeignKey("dbo.Cases", t => t.CaseId)
                .Index(t => t.WeaponId)
                .Index(t => t.CaseId);
            
            CreateTable(
                "dbo.Weapons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeId = c.Int(nullable: false),
                        SkinNameId = c.Int(nullable: false),
                        Image = c.Binary(),
                        WeapNId = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        RareId = c.Int(nullable: false),
                        Startrack = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rares", t => t.RareId)
                .ForeignKey("dbo.SkinNs", t => t.SkinNameId)
                .ForeignKey("dbo.Types", t => t.TypeId)
                .ForeignKey("dbo.WeapNs", t => t.WeapNId)
                .Index(t => t.TypeId)
                .Index(t => t.SkinNameId)
                .Index(t => t.WeapNId)
                .Index(t => t.RareId);
            
            CreateTable(
                "dbo.possSkinsInCases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Caseid = c.Int(),
                        Weaponid = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cases", t => t.Caseid)
                .ForeignKey("dbo.Weapons", t => t.Weaponid)
                .Index(t => t.Caseid)
                .Index(t => t.Weaponid);
            
            CreateTable(
                "dbo.Rares",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SkinNs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Types",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WeapNs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 128, fixedLength: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DropHistories", "CaseId", "dbo.Cases");
            DropForeignKey("dbo.Weapons", "WeapNId", "dbo.WeapNs");
            DropForeignKey("dbo.Weapons", "TypeId", "dbo.Types");
            DropForeignKey("dbo.Weapons", "SkinNameId", "dbo.SkinNs");
            DropForeignKey("dbo.Weapons", "RareId", "dbo.Rares");
            DropForeignKey("dbo.possSkinsInCases", "Weaponid", "dbo.Weapons");
            DropForeignKey("dbo.possSkinsInCases", "Caseid", "dbo.Cases");
            DropForeignKey("dbo.DropHistories", "WeaponId", "dbo.Weapons");
            DropIndex("dbo.possSkinsInCases", new[] { "Weaponid" });
            DropIndex("dbo.possSkinsInCases", new[] { "Caseid" });
            DropIndex("dbo.Weapons", new[] { "RareId" });
            DropIndex("dbo.Weapons", new[] { "WeapNId" });
            DropIndex("dbo.Weapons", new[] { "SkinNameId" });
            DropIndex("dbo.Weapons", new[] { "TypeId" });
            DropIndex("dbo.DropHistories", new[] { "CaseId" });
            DropIndex("dbo.DropHistories", new[] { "WeaponId" });
            DropTable("dbo.WeapNs");
            DropTable("dbo.Types");
            DropTable("dbo.SkinNs");
            DropTable("dbo.Rares");
            DropTable("dbo.possSkinsInCases");
            DropTable("dbo.Weapons");
            DropTable("dbo.DropHistories");
            DropTable("dbo.Cases");
        }
    }
}
