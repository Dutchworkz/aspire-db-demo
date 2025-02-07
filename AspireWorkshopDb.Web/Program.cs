using AspireWorkshopDb.Data;
using AspireWorkshopDb.Web.Components;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("mydatabasename") ?? throw new InvalidOperationException("Connection string 'mydatabasename' not found.");

// Add the SqlServer database context, make sure to do this before adding service defaults!
builder.Services.AddDbContext<CollectionContext>((options) => options.UseSqlServer(connectionString)); // This is a reference to the name in the Host


// Add services to the container.
builder.Services.AddRazorComponents()
       .AddInteractiveServerComponents();

builder.Services.AddOutputCache();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    // This now creates the database if it doesn't exist, this is not the advised way to go (use migrations instead)!
    var context = scope.ServiceProvider.GetRequiredService<CollectionContext>();
    context.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.UseOutputCache();

app.MapStaticAssets();

app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode();

app.Run();