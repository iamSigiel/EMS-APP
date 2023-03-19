using EMS_APP.Data;
using EMS_APP.Repository.Interfaces;
using EMS_APP.Repository.Repo.InMemory;
using EMS_APP.Repository.Repo.MSSQL;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<EMS_DBContext>();

builder.Services.AddSingleton<IEmployeeRepo, InMemEmployee>();
builder.Services.AddSingleton<IDepartmentRepo, InMemDepartment>();

//builder.Services.AddScoped<IEmployeeRepo, DBEmployee>();
//builder.Services.AddScoped<IDepartmentRepo, DBDepartment>();

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
