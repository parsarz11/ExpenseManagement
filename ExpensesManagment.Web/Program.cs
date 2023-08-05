using ExpensesManagment.Web.Data.Context;
using ExpensesManagment.Web.Data.Repository;
using ExpensesManagment.Web.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<CategoryRepo>();
builder.Services.AddScoped<IncomeRepo>();
builder.Services.AddScoped<ExpensesRepo>();
builder.Services.AddScoped<ExpenseService>();
builder.Services.AddScoped<IncomeService>();
builder.Services.AddScoped<DashBoardServices>();

builder.Services.AddDbContext<DatabaseContext>(config =>
{
    config.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
builder.Services.AddControllersWithViews();

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
    pattern: "{controller=DashBoard}/{action=DashBoard}/{id?}");

app.Run();
