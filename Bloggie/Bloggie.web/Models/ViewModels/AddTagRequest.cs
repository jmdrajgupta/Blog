namespace Bloggie.web.Models.ViewModels
{
    // This class represents the data that will be sent from the view (the form) to the controller
    // when a user submits a request to add a new tag.
    public class AddTagRequest
    {
        // The name of the tag that the user wants to add (e.g., "Tech", "Lifestyle").
        public string Name { get; set; }

        // The display name of the tag, which might be more user-friendly or formatted differently than the Name.
        public string DisplayName { get; set; }
    }
}
