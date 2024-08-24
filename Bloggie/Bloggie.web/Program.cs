using Bloggie.web.Data; // Importing the namespace that contains the database context
using Microsoft.EntityFrameworkCore; // Importing the namespace for Entity Framework Core

var builder = WebApplication.CreateBuilder(args); // Initializing a builder to set up the web application

// Add services to the container.
builder.Services.AddControllersWithViews(); // Registering MVC services to support controllers and views

// Registering the DbContext for dependency injection and configuring it to use SQL Server
// The connection string is retrieved from the configuration file (e.g., appsettings.json)
builder.Services.AddDbContext<BloggieDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BloggieDbConnectionString")));

var app = builder.Build(); // Building the application using the configured services

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) // Checking if the application is not in the development environment
{
    app.UseExceptionHandler("/Home/Error"); // Use a custom error page in non-development environments
    app.UseHsts(); // Enforce HTTP Strict Transport Security (HSTS) for security in production
}

app.UseHttpsRedirection(); // Redirect HTTP requests to HTTPS for security
app.UseStaticFiles(); // Serve static files like CSS, JavaScript, and images

app.UseRouting(); // Enable routing, which matches incoming requests to endpoints (e.g., controllers)

app.UseAuthorization(); // Enable authorization to ensure users have access to protected resources

// Define the default route for the application
// If no specific controller or action is specified, it defaults to the Home controller and Index action
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run(); // Run the application and start listening for incoming HTTP requests
