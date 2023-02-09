using Microsoft.EntityFrameworkCore;

using WineSales.Data;
using WineSales.Data.Repositories;
using WineSales.Domain.Interactors;
using WineSales.Domain.RepositoryInterfaces;

using AutoMapper;
using WineSales.Domain.Utils;



void ConfigureServices(IServiceCollection services)
{
    services.AddTransient<ICustomerInteractor, CustomerInteractor>();
    services.AddTransient<ISaleInteractor, SaleInteractor>();
    services.AddTransient<ISupplierInteractor, SupplierInteractor>();
    services.AddTransient<ISupplierWineInteractor, SupplierWineInteractor>();
    services.AddTransient<IUserInteractor, UserInteractor>();
    services.AddTransient<IWineInteractor, WineInteractor>();

    services.AddTransient<ICustomerRepository, CustomerRepository>();
    services.AddTransient<ISaleRepository, SaleRepository>();
    services.AddTransient<ISupplierRepository, SupplierRepository>();
    services.AddTransient<ISupplierWineRepository, SupplierWineRepository>();
    services.AddTransient<IUserRepository, UserRepository>();
    services.AddTransient<IWineRepository, WineRepository>();

    services.AddAutoMapper(typeof(AutoMappingProfile));
}


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Configure services.
ConfigureServices(builder.Services);

// Database connection
builder.Configuration.AddJsonFile("dbsettings.json");
builder.Services.AddDbContext<DataBaseContext>(options => options.UseNpgsql(
      builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
