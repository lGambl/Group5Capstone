using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudyWeb.Data.Migrations
{
    /// <inheritdoc />
    public partial class studyhall : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            // Drop the 'PhonebookEntry' table if it exists
            migrationBuilder.Sql(@"IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'PhonebookEntry') DROP TABLE [dbo].[PhonebookEntry]");

            // Drop the 'Note' table if it exists
            migrationBuilder.Sql(@"IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'Note') DROP TABLE [dbo].[Note]");

            // Drop the 'Source' table if it exists
            migrationBuilder.Sql(@"IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'Source') DROP TABLE [dbo].[Source]");

            // Drop the 'SourceType' table if it exists
            migrationBuilder.Sql(@"IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'SourceType') DROP TABLE [dbo].[SourceType]");

            migrationBuilder.Sql(@"
        IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'Source')
        BEGIN
            CREATE TABLE [dbo].[Source] (
                [Id] int NOT NULL IDENTITY(1,1),
                [Link] nvarchar(max) NOT NULL,
                [Title] nvarchar(max) NOT NULL,
                [Type] int NOT NULL,
                [Owner] nvarchar(450) NOT NULL,
                CONSTRAINT [FK_Source_AspNetUsers] FOREIGN KEY ([Owner]) REFERENCES [dbo].[AspNetUsers] ([Id]),
                CONSTRAINT [PK_Source] PRIMARY KEY ([Id])
            )
        END
    ");

            
            migrationBuilder.Sql(@"
        IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'SourceType')
        BEGIN
            CREATE TABLE [dbo].[SourceType] (
                [Id] int NOT NULL IDENTITY(1,1),
                [Name] nvarchar(max) NOT NULL,
                CONSTRAINT [PK_sourceType] PRIMARY KEY ([Id])
            )
        END
    ");

            migrationBuilder.InsertData(
                table: "sourceType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Video" },
                    { 2, "VideoLink" },
                    { 3, "pdf" },
                    { 4, "pdfLink" },
                    { 5, "image" },
                    { 6, "imagelink" }   
                });

            migrationBuilder.Sql(@"
        IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'Note')
        BEGIN
            CREATE TABLE [dbo].[Note] (
                [Id] int NOT NULL IDENTITY(1,1),
                [Text] nvarchar(max) NOT NULL,
                [SourceId] int  NOT NULL,
                [Owner] nvarchar(450) NOT NULL,
                CONSTRAINT [PK_Note] PRIMARY KEY ([Id]),
                CONSTRAINT [FK_NOTE_ASPNETUSERS] FOREIGN KEY ([Owner]) REFERENCES [dbo].[AspNetUsers] ([Id]),
                CONSTRAINT [FK_Note_Source] FOREIGN KEY ([SourceId]) REFERENCES [dbo].[Source] ([Id])
            )
        END
    ");

            
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE [dbo].[AspNetUsers] NOCHECK CONSTRAINT ALL");
            migrationBuilder.Sql("ALTER TABLE [dbo].[Source] NOCHECK CONSTRAINT ALL");
            migrationBuilder.Sql("ALTER TABLE [dbo].[sourceType] NOCHECK CONSTRAINT ALL");
            migrationBuilder.Sql("ALTER TABLE [dbo].[Note] NOCHECK CONSTRAINT ALL");

            // Drop the 'Note' table if it exists
            migrationBuilder.Sql(@"IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'Note') DROP TABLE [dbo].[Note]");
            
            // Drop the 'Source' table if it exists
            migrationBuilder.Sql(@"IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'Source') DROP TABLE [dbo].[Source]");

            // Drop the 'sourceType' table if it exists
            migrationBuilder.Sql(
                    @"IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'sourceType') DROP TABLE [dbo].[sourceType]");
            

            migrationBuilder.Sql("ALTER TABLE [dbo].[AspNetUsers] WITH CHECK CHECK CONSTRAINT ALL");
        }
    }
}
