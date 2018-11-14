namespace chatapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChatUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        LoginTime = c.String(),
                        ConnectionId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.MessageInfoes", "ChatUsers_Id", c => c.Int());
            CreateIndex("dbo.MessageInfoes", "ChatUsers_Id");
            AddForeignKey("dbo.MessageInfoes", "ChatUsers_Id", "dbo.ChatUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MessageInfoes", "ChatUsers_Id", "dbo.ChatUsers");
            DropIndex("dbo.MessageInfoes", new[] { "ChatUsers_Id" });
            DropColumn("dbo.MessageInfoes", "ChatUsers_Id");
            DropTable("dbo.ChatUsers");
        }
    }
}
