namespace StreamDream.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddedNameToMembershipType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    MyProperty = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            AddColumn("dbo.MembershipTypes", "Name", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "Name");
            DropTable("dbo.Movies");
        }
    }
}
