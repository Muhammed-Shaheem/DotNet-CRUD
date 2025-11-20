using ShaheemsDinerLibrary.Data;
using ShaheemsDinerLibrary.Db;

namespace ApiDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<IOrderData, OrderData>();
            builder.Services.AddSingleton<IFoodData, FoodData>();
            builder.Services.AddSingleton<IDataAccess, SqlDb>();
            builder.Services.AddSingleton(new ConnectionStringName
            {
                SqlConnection = "Default"
            });
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin", builder => builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());
            });


            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("AllowOrigin");
            app.MapControllers();

            app.Run();
        }
    }
}
