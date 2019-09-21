namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class startrack : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Case",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(maxLength: 50, unicode: false),
                        Image = c.Binary(storeType: "image"),
                        Price = c.Double(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DropHistory",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        WeaponId = c.Int(nullable: false),
                        CaseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Weapon", t => t.WeaponId)
                .ForeignKey("dbo.Case", t => t.CaseId)
                .Index(t => t.WeaponId)
                .Index(t => t.CaseId);
            
            CreateTable(
                "dbo.Weapon",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        TypeId = c.Int(nullable: false),
                        SkinNameId = c.Int(nullable: false),
                        Image = c.Binary(nullable: false, storeType: "image"),
                        WeapNId = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Startrack = c.Boolean(nullable: false),
                        Rare = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SkinN", t => t.SkinNameId)
                .ForeignKey("dbo.Type", t => t.TypeId)
                .ForeignKey("dbo.WeapN", t => t.WeapNId)
                .Index(t => t.TypeId)
                .Index(t => t.SkinNameId)
                .Index(t => t.WeapNId);
            
            CreateTable(
                "dbo.possSkinsInCase",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Caseid = c.Int(),
                        Weaponid = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Case", t => t.Caseid)
                .ForeignKey("dbo.Weapon", t => t.Weaponid)
                .Index(t => t.Caseid)
                .Index(t => t.Weaponid);
            
            CreateTable(
                "dbo.SkinN",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Type",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 23),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WeapN",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rare",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 21),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DropHistory", "CaseId", "dbo.Case");
            DropForeignKey("dbo.Weapon", "WeapNId", "dbo.WeapN");
            DropForeignKey("dbo.Weapon", "TypeId", "dbo.Type");
            DropForeignKey("dbo.Weapon", "SkinNameId", "dbo.SkinN");
            DropForeignKey("dbo.possSkinsInCase", "Weaponid", "dbo.Weapon");
            DropForeignKey("dbo.possSkinsInCase", "Caseid", "dbo.Case");
            DropForeignKey("dbo.DropHistory", "WeaponId", "dbo.Weapon");
            DropIndex("dbo.possSkinsInCase", new[] { "Weaponid" });
            DropIndex("dbo.possSkinsInCase", new[] { "Caseid" });
            DropIndex("dbo.Weapon", new[] { "WeapNId" });
            DropIndex("dbo.Weapon", new[] { "SkinNameId" });
            DropIndex("dbo.Weapon", new[] { "TypeId" });
            DropIndex("dbo.DropHistory", new[] { "CaseId" });
            DropIndex("dbo.DropHistory", new[] { "WeaponId" });
            DropTable("dbo.Rare");
            DropTable("dbo.WeapN");
            DropTable("dbo.Type");
            DropTable("dbo.SkinN");
            DropTable("dbo.possSkinsInCase");
            DropTable("dbo.Weapon");
            DropTable("dbo.DropHistory");
            DropTable("dbo.Case");
        }
    }
}
