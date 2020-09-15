using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;
using Type = Core.Entities.Type;

namespace Infrastructure.Data.SeedData
{
    public class StoreContextSeed
    {
        public async static Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.Types.Any())
                {
                    var jsonFile = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                    var types = JsonSerializer.Deserialize<List<Type>>(jsonFile);
                    foreach (var item in types)
                    {
                        await context.Types.AddAsync(item);
                    }
                }

                if (!context.Brands.Any())
                {
                    var jsonFile = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<Brand>>(jsonFile);
                    foreach (var item in brands)
                    {
                        await context.Brands.AddAsync(item);
                    }
                }
                if (!context.Products.Any())
                {
                    var jsonFile = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(jsonFile);
                    foreach (var item in products)
                    {
                        await context.Products.AddAsync(item);
                    }
                }
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}