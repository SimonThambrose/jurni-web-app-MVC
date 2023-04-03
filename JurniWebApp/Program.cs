using JurniWebApp.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// UNCOMMENT LINES APPROPRIATE TO DESIRED DATABASE TYPE
// When using SSH tunneling to connect to a remote database
var connectionString = builder.Configuration.GetConnectionString("JurniWebAppDb");
builder.Services.AddDbContext<JurniWebAppDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// When using a local database
// var connectionString = builder.Configuration.GetConnectionString("JurniWebAppDb_local");
// builder.Services.AddDbContext<JurniWebAppDbContext>(options => options.UseSqlite(connectionString));

builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
} else if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();