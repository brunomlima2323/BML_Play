using BML_Play.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BML_PlayContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("BML_PlayContext"),
        new MySqlServerVersion(new Version(9, 6, 0)),
        b => b.MigrationsAssembly("BML_Play")
    )
);

// Add services to the container.
builder.Services.AddControllersWithViews();

var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<BML_PlayContext>();
    db.Database.Migrate();
}

app.Run();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Filmes}/{action=Intro}/{id?}");

app.Run();
