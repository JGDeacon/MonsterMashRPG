namespace CharacterCreatorData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attributes",
                c => new
                    {
                        Level = c.Int(nullable: false, identity: true),
                        HP = c.Int(nullable: false),
                        STR = c.Int(nullable: false),
                        SPD = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Level);
            
            CreateTable(
                "dbo.Character",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        User = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 16),
                        BaseHP = c.Int(nullable: false),
                        BaseStr = c.Int(nullable: false),
                        BaseSpd = c.Int(nullable: false),
                        Level = c.Int(nullable: false),
                        InventoryOne_ID = c.Int(),
                        InventoryThree_ID = c.Int(),
                        InventoryTwo_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Item", t => t.InventoryOne_ID)
                .ForeignKey("dbo.Item", t => t.InventoryThree_ID)
                .ForeignKey("dbo.Item", t => t.InventoryTwo_ID)
                .Index(t => t.InventoryOne_ID)
                .Index(t => t.InventoryThree_ID)
                .Index(t => t.InventoryTwo_ID);
            
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Image = c.String(),
                        HPModifier = c.Int(nullable: false),
                        STRModifier = c.Int(nullable: false),
                        SPDModifier = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.LevelTable",
                c => new
                    {
                        Level = c.Int(nullable: false, identity: true),
                        XP = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Level);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Character", "InventoryTwo_ID", "dbo.Item");
            DropForeignKey("dbo.Character", "InventoryThree_ID", "dbo.Item");
            DropForeignKey("dbo.Character", "InventoryOne_ID", "dbo.Item");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Character", new[] { "InventoryTwo_ID" });
            DropIndex("dbo.Character", new[] { "InventoryThree_ID" });
            DropIndex("dbo.Character", new[] { "InventoryOne_ID" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.LevelTable");
            DropTable("dbo.Item");
            DropTable("dbo.Character");
            DropTable("dbo.Attributes");
        }
    }
}
