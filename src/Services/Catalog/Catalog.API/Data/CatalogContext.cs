using Catalog.API.Common;
using Catalog.API.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        private readonly DatabaseSettingOptions _settings;
        public CatalogContext(IConfiguration configuration,
            IOptions<DatabaseSettingOptions> setting)
        {
            _settings = setting.Value;

            var client = new MongoClient(_settings.ConnectionString);
            var db = client.GetDatabase(_settings.DatabaseName);

            Products = db.GetCollection<Product>(_settings.CollectionName);
            CatalogContextSeed.SeedData(Products);
        }
        public IMongoCollection<Product> Products { get; }
    }
}
