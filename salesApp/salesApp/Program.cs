using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using salesApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Configuração do DbContext para usar MySQL
builder.Services.AddDbContext<salesAppContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("salesAppContext") ?? throw new InvalidOperationException("Connection string 'salesAppContext' not found."),
        new MySqlServerVersion(new Version(8, 0, 25)) // Use a versão do MySQL Server que você está usando
    )
);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
