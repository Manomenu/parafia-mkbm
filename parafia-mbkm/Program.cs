using Microsoft.EntityFrameworkCore;
using parafia_mbkm;
using parafia_mbkm.data.DataContexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MovieActorDataContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("ParafiaDb"),
    b => b.MigrationsAssembly("parafia-mbkm.data"))
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.Seed();

app.MapFallbackToFile("index.html");

app.Run();
