namespace FriendOrganizer.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFriendPhoneNumbers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FriendPhoneNumber",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(nullable: false),
                        FriendID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Friend", t => t.FriendID, cascadeDelete: true)
                .Index(t => t.FriendID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FriendPhoneNumber", "FriendID", "dbo.Friend");
            DropIndex("dbo.FriendPhoneNumber", new[] { "FriendID" });
            DropTable("dbo.FriendPhoneNumber");
        }
    }
}
