using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();
            if (existProduct)
            {
                productCollection.InsertManyAsync(GetPredefinedProducts());
            }
        }

        public static IEnumerable<Product> GetPredefinedProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Id = "602d2149e773f2a3990b47f5",
                    Name = "Galexy A30",
                    Category = "Smart Phone",
                    Description = "Best phone that i have ever.",
                    Summary = "Sumsung galexy A30 smart phone. best in A series.",
                    ImageFile = "Product-A30.jpg",
                    Price = 950.00M
                },
                new Product()
                {
                    Id = "602d2149e773f2a3990b47f9",
                    Name = "IPhone 13",
                    Category = "Smart Phone",
                    Description = "Best phone that i have ever.",
                    Summary = "IPhone 13 smart phone. best in IPhone series.",
                    ImageFile = "Product-IPhone13.jpg",
                    Price = 950.00M
                }
            };
        }
    }
}
