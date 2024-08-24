namespace Bloggie.web.Models.Domain
{
    // This class represents the "Tag" domain model, which is used to categorize or tag blog posts in the application.
    public class Tag
    {
        // Unique identifier for the Tag, using Guid as the data type for globally unique IDs.
        public Guid Id { get; set; }

        // The name of the tag (e.g., "Tech", "Lifestyle").
        public string Name { get; set; }

        // The display name of the tag, which might be more user-friendly or formatted differently than the Name.
        public string DisplayName { get; set; }

        // A collection of BlogPost objects associated with this tag.
        // This defines a relationship where a tag can be linked to multiple blog posts.
        public ICollection<BlogPost> blogPosts { get; set; }
    }
}
