using Bloggie.web.Models.Domain; // Importing the namespace that contains the domain models, such as BlogPost and Tag.
using Microsoft.EntityFrameworkCore; // Importing the namespace for Entity Framework Core, which is used for database operations.

namespace Bloggie.web.Data
{
    // The BloggieDbContext class represents the Entity Framework Core database context for the application.
    // It is responsible for managing the connection to the database and mapping domain models to database tables.
    public class BloggieDbContext : DbContext
    {
        // Constructor that accepts DbContextOptions and passes them to the base DbContext class.
        // These options typically include the database provider and connection string.
        public BloggieDbContext(DbContextOptions options) : base(options)
        {
        }

        // DbSet properties represent collections of entities that correspond to database tables.
        // Entity Framework Core will use these properties to query and save instances of the domain models.

        // DbSet for BlogPost entities, which represents the "BlogPosts" table in the database.
        public DbSet<BlogPost> BlogPosts { get; set; }

        // DbSet for Tag entities, which represents the "Tags" table in the database.
        public DbSet<Tag> Tags { get; set; }
    }
}
