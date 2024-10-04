// Code to run the application
using newEmpty.Data;
using Microsoft.EntityFrameworkCore;
using newEmpty.Models;




var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
  {
      options.SignIn.RequireConfirmedAccount = false;
      options.Password.RequireDigit = true;
      options.Password.RequireLowercase = true;
      options.Password.RequireNonAlphanumeric = true;
      options.Password.RequireUppercase = true;
      options.Password.RequiredLength = 8;

      options.User.RequireUniqueEmail = true;
  }
).AddEntityFrameworkStores<ApplicationDbContext>();



var serverVersion = new MySqlServerVersion(new Version(11, 0, 2));

// Ajout du dbcontext au service container
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), serverVersion)
);


var app = builder.Build();

app.UseStaticFiles();
app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");


if (app.Environment.IsDevelopment())
{
    // Affiche les exceptions pour les développeurs en phase de développement
    app.UseDeveloperExceptionPage();
}
else
{
    // Middleware pour afficher une page d'erreur personnalisée en production
    app.UseExceptionHandler("../Error/Index");
    app.UseStatusCodePagesWithRedirects("../Error/Index"); // Gère les erreurs comme 404
}
var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();
context.Database.EnsureCreated();

app.UseStaticFiles(); // Enable static files

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();



