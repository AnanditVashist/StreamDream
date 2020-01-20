namespace StreamDream.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulatedGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres(Name) VALUES('Comedy')");
            Sql("INSERT INTO Genres(Name) VALUES('Romance')");
            Sql("INSERT INTO Genres(Name) VALUES('Action')");
            Sql("INSERT INTO Genres(Name) VALUES('Thriller')");
        }

        public override void Down()
        {
        }
    }
}
