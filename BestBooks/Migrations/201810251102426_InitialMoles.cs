namespace BestBooks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMoles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        Country = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.AuthorId);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        DatePublished = c.DateTime(nullable: false),
                        Publisher_PublisherID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookId)
                .ForeignKey("dbo.Publishers", t => t.Publisher_PublisherID, cascadeDelete: true)
                .Index(t => t.Publisher_PublisherID);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        GenreName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.GenreId);
            
            CreateTable(
                "dbo.Publishers",
                c => new
                    {
                        PublisherID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Country = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.PublisherID);
            
            CreateTable(
                "dbo.BookAuthor",
                c => new
                    {
                        BookId = c.Int(nullable: false),
                        AuthorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BookId, t.AuthorId })
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .Index(t => t.BookId)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.BookGenres",
                c => new
                    {
                        BookId = c.Int(nullable: false),
                        GenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BookId, t.GenreId })
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.BookId)
                .Index(t => t.GenreId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "Publisher_PublisherID", "dbo.Publishers");
            DropForeignKey("dbo.BookGenres", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.BookGenres", "BookId", "dbo.Books");
            DropForeignKey("dbo.BookAuthor", "AuthorId", "dbo.Authors");
            DropForeignKey("dbo.BookAuthor", "BookId", "dbo.Books");
            DropIndex("dbo.BookGenres", new[] { "GenreId" });
            DropIndex("dbo.BookGenres", new[] { "BookId" });
            DropIndex("dbo.BookAuthor", new[] { "AuthorId" });
            DropIndex("dbo.BookAuthor", new[] { "BookId" });
            DropIndex("dbo.Books", new[] { "Publisher_PublisherID" });
            DropTable("dbo.BookGenres");
            DropTable("dbo.BookAuthor");
            DropTable("dbo.Publishers");
            DropTable("dbo.Genres");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
