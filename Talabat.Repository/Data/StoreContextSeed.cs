using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Repository.Data
{
    public static class StoreContextSeed
    {
        public async static Task SeedAsync(StoreContext storeContext)
        {
            var brandsData = File.ReadAllText("../Talabat.Repository/Data/DataSeeding/brands.json");
            var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
            if (brands.Count()>0)
            {
                //brands = brands.Select(b => new ProductBrand()
                //{
                //    Name = b.Name
                //}).ToList();
                if (!(storeContext.ProductBrands.Count() >0))
                {
                    foreach (var brand in brands)
                    {
                        storeContext.Set<ProductBrand>().Add(brand);
                    }
                    await storeContext.SaveChangesAsync();
                }
            }
            var categoryData = File.ReadAllText("../Talabat.Repository/Data/DataSeeding/categories.json");
            var categories = JsonSerializer.Deserialize<List<ProductCategory>>(categoryData);
            if (categories.Count() > 0)
            {
                //brands = brands.Select(b => new ProductBrand()
                //{
                //    Name = b.Name
                //}).ToList();
                if (!(storeContext.ProductCategories.Count() > 0))
                {
                    foreach (var category in categories)
                    {
                        storeContext.Set<ProductCategory>().Add(category);
                    }
                    await storeContext.SaveChangesAsync();
                }
            }
            var productsData = File.ReadAllText("../Talabat.Repository/Data/DataSeeding/products.json");
            var products = JsonSerializer.Deserialize<List<Product>>(productsData);
            if (products.Count() > 0)
            {
                //brands = brands.Select(b => new ProductBrand()
                //{
                //    Name = b.Name
                //}).ToList();
                if (!(storeContext.Products.Count() > 0))
                {
                    foreach (var product in products)
                    {
                        storeContext.Set<Product>().Add(product);
                    }
                    await storeContext.SaveChangesAsync();
                }
            }
        }
    }
}
