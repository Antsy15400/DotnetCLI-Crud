using DotnetCLI_Crud.data.Repository;
using DotnetCLI_Crud.data.Repository.interfaces;
using Microsoft.EntityFrameworkCore;
using Practica.data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Connectionstring
var connectionString = builder.Configuration.GetConnectionString("ProductoContext"); 
builder.Services.AddDbContext<ProductoContext>(options => options.UseSqlite(connectionString));

// Repository
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();

var app = builder.Build();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
