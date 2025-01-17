
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Store.Repository.Data.Contexts;
using Microsoft.EntityFrameworkCore.Design;
using System.IO;
using Store.Repository.Data;
using Store.Core.Services.contract;
using Store.Service.Services.product;
using Store.Core;
using Store.Repository;
using Store.Core.Mapping.Products;


namespace OnlineStoreApis
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


    

            builder.Services.AddDbContext<StoreDbContext>(option =>
            {
            option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
    
            builder.Services.AddScoped<IProductService , ProductService>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddAutoMapper(M => M.AddProfile(new ProductsProfile()));


            var app = builder.Build();

           using var scope = app.Services.CreateScope();
           var services =  scope.ServiceProvider;
           var context=  services.GetRequiredService<StoreDbContext>();
            var loggerFactory = services.GetRequiredService<ILoggerFactory>();

            try
            {
                await context.Database.MigrateAsync();

               await StoreDbContextSeed.SeedAsync(context);
            }
            catch (Exception ex)
            {
               var logger =  loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "There Are Problems During Applying Migrations !!");



            }




            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
