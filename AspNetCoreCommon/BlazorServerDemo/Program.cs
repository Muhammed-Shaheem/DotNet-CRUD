using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using BlazorServerDemo.Data;
using ShaheemsDinerLibrary.Data;
using ShaheemsDinerLibrary.Db;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
