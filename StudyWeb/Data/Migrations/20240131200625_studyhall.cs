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

            // Drop the 'sourceType' table if it exists
            migrationBuilder.Sql(@"IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'sourceType') DROP TABLE [dbo].[sourceType]");

            


            // Check if the 'Source' table exists and create it if it does not
            migrationBuilder.Sql(@"
        IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'Source')
        BEGIN
            CREATE TABLE [dbo].[Source] (
                [Id] int NOT NULL IDENTITY(1,1),
                [Link] nvarchar(max) NOT NULL,
                [Title] nvarchar(max) NOT NULL,
                [Type] int NOT NULL,
                [Owner] nvarchar(max) NOT NULL,
                CONSTRAINT [PK_Source] PRIMARY KEY ([Id])
            )
        END
    ");

            // Check if the 'sourceType' table exists and create it if it does not
            migrationBuilder.Sql(@"
        IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'sourceType')
        BEGIN
            CREATE TABLE [dbo].[sourceType] (
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
                    { 5, "image" },      // ID for 'image' as specified
                    { 6, "imagelink" }   // ID for 'imagelink' as specified
                });

            // Check if the 'Note' table exists and create it if it does not
            migrationBuilder.Sql(@"
        IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'Note')
        BEGIN
            CREATE TABLE [dbo].[Note] (
                [Id] int NOT NULL IDENTITY(1,1),
                [Text] nvarchar(max) NOT NULL,
                [SourceId] int  NOT NULL,
                CONSTRAINT [PK_Note] PRIMARY KEY ([Id]),
                CONSTRAINT [FK_Note_Source] FOREIGN KEY ([SourceId]) REFERENCES [dbo].[Source] ([Id])
            )
        END
    ");

            // Create any additional indexes or constraints here, if necessary
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drop the 'Note' table if it exists
            migrationBuilder.Sql(@"IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'Note') DROP TABLE [dbo].[Note]");

            // Drop the 'sourceType' table if it exists
            migrationBuilder.Sql(@"IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'sourceType') DROP TABLE [dbo].[sourceType]");

            // Drop the 'Source' table if it exists
            migrationBuilder.Sql(@"IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'Source') DROP TABLE [dbo].[Source]");

        }
    }
}
