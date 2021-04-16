namespace CharacterCreatorData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class XPColumnAgain : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Character", "XP", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Character", "XP");
        }
    }
}
