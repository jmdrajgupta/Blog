namespace Bloggie.web.Models.Domain
{
    // The BlogPost class represents a blog post entity in the application
    public class BlogPost
    {
        // Unique identifier for the blog post, generated as a GUID
        public Guid Id { get; set; }

        // The heading of the blog post. This property is required and cannot be null.
        public string Heading { get; set; }

        // The title of the page for SEO purposes. This property is required and cannot be null.
        public string PageTitle { get; set; }

        // The main content of the blog post. This property is required and cannot be null.
        public string Content { get; set; }

        // A short description of the blog post, often used in previews. This property is required and cannot be null.
        public string ShortDescription { get; set; }

        // URL for the featured image of the blog post. This property is required and cannot be null.
        public string FeaturedImageUrl { get; set; }

        // A URL-friendly version of the title, often used in the post's URL. This property is required and cannot be null.
        public string UrlHandle { get; set; }

        // The date and time when the blog post was published. This property is required and cannot be null.
        public DateTime PublishedDate { get; set; }

        // The author of the blog post. This property is required and cannot be null.
        public string Author { get; set; }

        // A boolean flag indicating whether the blog post is visible or hidden. This property is required and cannot be null.
        public bool Visible { get; set; }

        // A collection of tags associated with the blog post, allowing for many-to-many relationships.
        public ICollection<Tag> Tags { get; set; }
    }
}
