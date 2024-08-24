using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bloggie.web.Migrations
{
    // This class represents a migration, which is a set of operations that modify the database schema.
    // The "InitialMigration" class is automatically generated to create the initial database structure.
    public partial class InitialMigration : Migration
    {
        // The "Up" method defines the operations to apply to the database when the migration is applied.
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Creating the "BlogPosts" table with the specified columns and types.
            migrationBuilder.CreateTable(
                name: "BlogPosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false), // Primary key of type GUID
                    Heading = table.Column<string>(type: "nvarchar(max)", nullable: false), // Column for the blog post heading
                    PageTitle = table.Column<string>(type: "nvarchar(max)", nullable: false), // Column for the page title
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false), // Column for the content of the blog post
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false), // Column for a short description
                    FeaturedImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false), // Column for the URL of the featured image
                    UrlHandle = table.Column<string>(type: "nvarchar(max)", nullable: false), // Column for the URL handle (slug)
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: false), // Column for the published date
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false), // Column for the author's name
                    Visible = table.Column<bool>(type: "bit", nullable: false) // Column indicating if the blog post is visible
                },
                constraints: table =>
                {
                    // Defining the primary key for the "BlogPosts" table
                    table.PrimaryKey("PK_BlogPosts", x => x.Id);
                });

            // Creating the "Tags" table with the specified columns and types.
            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false), // Primary key of type GUID
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false), // Column for the tag name
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false) // Column for the display name of the tag
                },
                constraints: table =>
                {
                    // Defining the primary key for the "Tags" table
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            // Creating the join table "BlogPostTag" to establish a many-to-many relationship between "BlogPosts" and "Tags".
            migrationBuilder.CreateTable(
                name: "BlogPostTag",
                columns: table => new
                {
                    TagsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false), // Foreign key to the "Tags" table
                    blogPostsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false) // Foreign key to the "BlogPosts" table
                },
                constraints: table =>
                {
                    // Defining the composite primary key for the "BlogPostTag" table using both foreign keys
                    table.PrimaryKey("PK_BlogPostTag", x => new { x.TagsId, x.blogPostsId });

                    // Setting up a foreign key constraint from "BlogPostTag" to "BlogPosts" with cascading delete
                    table.ForeignKey(
                        name: "FK_BlogPostTag_BlogPosts_blogPostsId",
                        column: x => x.blogPostsId,
                        principalTable: "BlogPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);

                    // Setting up a foreign key constraint from "BlogPostTag" to "Tags" with cascading delete
                    table.ForeignKey(
                        name: "FK_BlogPostTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            // Creating an index on the "blogPostsId" column in the "BlogPostTag" table to optimize queries
            migrationBuilder.CreateIndex(
                name: "IX_BlogPostTag_blogPostsId",
                table: "BlogPostTag",
                column: "blogPostsId");
        }

        // The "Down" method defines the operations to revert the database to its previous state when the migration is rolled back.
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Dropping the "BlogPostTag" join table if the migration is rolled back
            migrationBuilder.DropTable(
                name: "BlogPostTag");

            // Dropping the "BlogPosts" table if the migration is rolled back
            migrationBuilder.DropTable(
                name: "BlogPosts");

            // Dropping the "Tags" table if the migration is rolled back
            migrationBuilder.DropTable(
                name: "Tags");
        }
    }
}
