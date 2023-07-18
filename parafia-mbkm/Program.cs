using Microsoft.EntityFrameworkCore;
using parafia_mbkm;
using parafia_mbkm.data;
using parafia_mbkm.Services;
using parafia_mbkm.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<ParafiaDbDataContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("ParafiaDb"),
    b => b.MigrationsAssembly("parafia-mbkm.data"))
    );
builder.Services.AddScoped<IContactService, ContactService>();

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

app.MapControllers();
app.Seed();
app.MapFallbackToFile("index.html");

app.Run();
