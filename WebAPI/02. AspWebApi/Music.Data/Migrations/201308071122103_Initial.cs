namespace Music.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Year = c.Int(nullable: false),
                        Genre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        BirthDate = c.DateTime(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Year = c.Int(),
                        Producer = c.String(),
                        Artist_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artists", t => t.Artist_Id)
                .Index(t => t.Artist_Id);
            
            CreateTable(
                "dbo.ArtistSongs",
                c => new
                    {
                        Artist_Id = c.Int(nullable: false),
                        Song_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Artist_Id, t.Song_Id })
                .ForeignKey("dbo.Artists", t => t.Artist_Id, cascadeDelete: true)
                .ForeignKey("dbo.Songs", t => t.Song_Id, cascadeDelete: true)
                .Index(t => t.Artist_Id)
                .Index(t => t.Song_Id);
            
            CreateTable(
                "dbo.AlbumSongs",
                c => new
                    {
                        Album_Id = c.Int(nullable: false),
                        Song_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Album_Id, t.Song_Id })
                .ForeignKey("dbo.Albums", t => t.Album_Id, cascadeDelete: true)
                .ForeignKey("dbo.Songs", t => t.Song_Id, cascadeDelete: true)
                .Index(t => t.Album_Id)
                .Index(t => t.Song_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.AlbumSongs", new[] { "Song_Id" });
            DropIndex("dbo.AlbumSongs", new[] { "Album_Id" });
            DropIndex("dbo.ArtistSongs", new[] { "Song_Id" });
            DropIndex("dbo.ArtistSongs", new[] { "Artist_Id" });
            DropIndex("dbo.Albums", new[] { "Artist_Id" });
            DropForeignKey("dbo.AlbumSongs", "Song_Id", "dbo.Songs");
            DropForeignKey("dbo.AlbumSongs", "Album_Id", "dbo.Albums");
            DropForeignKey("dbo.ArtistSongs", "Song_Id", "dbo.Songs");
            DropForeignKey("dbo.ArtistSongs", "Artist_Id", "dbo.Artists");
            DropForeignKey("dbo.Albums", "Artist_Id", "dbo.Artists");
            DropTable("dbo.AlbumSongs");
            DropTable("dbo.ArtistSongs");
            DropTable("dbo.Albums");
            DropTable("dbo.Artists");
            DropTable("dbo.Songs");
        }
    }
}
