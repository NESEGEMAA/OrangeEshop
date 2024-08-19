using Microsoft.EntityFrameworkCore;
using OrangeEshop.BLL;
using OrangeEshop.BLL.Interfaces;
using OrangeEshop.BLL.Repositories;
using OrangeEshop.BLL.Services;
using OrangeEshop.DAL;
using OrangeEshop.DAL.Interfaces;
using OrangeEshop.DAL.Repositories;

var config = new ConfigurationBuilder()
.AddJsonFile("appsettings.json")
.Build();

var connectionString = config.GetConnectionString("DefaultConnection");

// var services = new ServiceCollection();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register DbContext
builder.Services.AddDbContext<EshopDbContext>(options =>
options.UseSqlServer("Server=.;Database=EShop;Trusted_Connection=True;TrustServerCertificate=True;"));

// Register repository and service
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryServices, CategoryServices>();
builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();