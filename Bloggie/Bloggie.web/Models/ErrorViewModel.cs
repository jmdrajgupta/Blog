namespace Bloggie.web.Models
{
    // The ErrorViewModel class is used to represent error information in the application
    public class ErrorViewModel
    {
        // Optional property to hold the request ID associated with the error
        // The '?' indicates that this property can be null
        public string? RequestId { get; set; }

        // A computed property that checks if the RequestId is not null or empty
        // This property returns true if RequestId has a value, indicating that it should be displayed in the error view
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
