using Bloggie.web.Data; // Importing the namespace for data access
using Bloggie.web.Models.Domain; // Importing the namespace for domain models
using Bloggie.web.Models.ViewModels; // Importing the namespace for view models
using Microsoft.AspNetCore.Mvc; // Importing the ASP.NET Core MVC framework

namespace Bloggie.web.Controllers
{
    // This controller handles administrative tasks related to "Tags" in the application.
    public class AdminTagsController : Controller
    {
        private readonly BloggieDbContext bloggieDbContext; // Private field for the database context

        // Constructor that accepts a BloggieDbContext object via dependency injection
        // This allows interaction with the database
        public AdminTagsController(BloggieDbContext bloggieDbContext)
        {
            this.bloggieDbContext = bloggieDbContext; // Initializing the private field with the injected context
        }

        // HTTP GET method for displaying the "Add Tag" form
        [HttpGet]
        public IActionResult Add()
        {
            return View(); // Returns the view to render the form for adding a new tag
        }

        // HTTP POST method for handling the submission of the "Add Tag" form
        // The [ActionName("Add")] attribute allows this method to be accessed using the "Add" action name
        [HttpPost]
        [ActionName("Add")]
        public IActionResult Add(AddTagRequest addTagRequest)
        {
            // Mapping the data from the AddTagRequest view model to the Tag domain model
            var tag = new Tag
            {
                Name = addTagRequest.Name, // Assigning the Name from the view model to the domain model
                DisplayName = addTagRequest.DisplayName // Assigning the DisplayName from the view model to the domain model
            };

            // Adding the new Tag object to the database context
            bloggieDbContext.Tags.Add(tag);

            // Saving the changes to the database
            bloggieDbContext.SaveChanges();

            // After saving, returning the view for the "Add" form (typically to allow adding more tags)
            return View("Add");
        }
    }
}
