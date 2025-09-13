using ShaheemsDinerLibrary.Data;
using ShaheemsDinerLibrary.Db;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
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
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
