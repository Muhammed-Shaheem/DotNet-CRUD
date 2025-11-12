using ShaheemsDinerLibrary.Data;
using ShaheemsDinerLibrary.Db;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IDataAccess, SqlDb>();
builder.Services.AddTransient<IFoodData, FoodData>();
builder.Services.AddTransient<IOrderData, OrderData>();
builder.Services.AddSingleton(new ConnectionStringName
{
    SqlConnection = "Default"
});


var app = builder.Build();

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
    pattern: "{controller=Orders}/{action=Create}/{id?}");

app.Run();
