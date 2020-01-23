namespace StreamDream.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNumberInStockInMovies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "NumberInStock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "NumberInStock");
        }
    }
}
