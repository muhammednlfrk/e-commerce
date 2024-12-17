WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
// TODO: Add app.UseHsts()
// TODO: Add HTTPS redirection for production.
// TODO: Create custom Exception handler for production.
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute("default", "");

app.Run();
