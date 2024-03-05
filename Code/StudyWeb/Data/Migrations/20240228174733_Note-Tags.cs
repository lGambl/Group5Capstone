using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudyWeb.Data.Migrations
{
    /// <inheritdoc />
    public partial class NoteTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddForeignKey(
                name: "FK_Note_Source_SourceId",
                table: "Note",
                column: "SourceId",
                principalTable: "Source",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.Sql(@"IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'Tags')
        BEGIN
            CREATE TABLE [dbo].[Tags] (
                [Id] int NOT NULL IDENTITY(1,1),
                [Name] nvarchar(max) NOT NULL,
                CONSTRAINT [PK_Tags] PRIMARY KEY ([Id])
            )
        END");

            migrationBuilder.Sql(@"IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'NoteTags')
        BEGIN
            CREATE TABLE [dbo].[NoteTags] (
                [Id] int NOT NULL IDENTITY(1,1),
                [TagId] int DEFAULT 0 NOT NULL,
                [NoteId] int NOT NULL,
                CONSTRAINT [PK_NoteTags] PRIMARY KEY ([Id]),
                CONSTRAINT [FK_Tags_Note_NoteId] FOREIGN KEY ([NoteId]) REFERENCES [dbo].[Note] ([Id]),
                CONSTRAINT [FK_Tags_Tag_TagId] FOREIGN KEY ([TagId]) REFERENCES [dbo].[Tags] ([Id])
            )
        END");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                               name: "FK_Note_Source_SourceId",
                                              table: "Note");

            migrationBuilder.Sql(@"IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'NoteTags') DROP TABLE [dbo].[NoteTags]");
            migrationBuilder.Sql(@"IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'Tags') DROP TABLE [dbo].[Tags]");
        }
    }
}
