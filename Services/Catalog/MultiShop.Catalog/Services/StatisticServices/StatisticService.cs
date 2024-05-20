using MongoDB.Bson;
using MongoDB.Driver;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.StatisticServices
{
    public class StatisticService : IStatisticService
    {
        private readonly IMongoCollection<Product> _products;
        private readonly IMongoCollection<Category> _categories;
        private readonly IMongoCollection<Brand> _brands;
        private readonly ILogger<StatisticService> _logger;

        public StatisticService(IDatabaseSettings _databaseSettings, ILogger<StatisticService> logger)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _products = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _categories = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _brands = database.GetCollection<Brand>(_databaseSettings.BrandCollectionName);
            _logger = logger;
        }

        public async Task<long> GetBrandCountAsync()
        {
            return await _brands.CountDocumentsAsync(FilterDefinition<Brand>.Empty);
        }

        public async Task<long> GetCategoryCountAsync()
        {
            return await _categories.CountDocumentsAsync(FilterDefinition<Category>.Empty);
        }

        public async Task<string> GetMaxPriceProductNameAsync()
        {
            var filter = Builders<Product>.Filter.Empty;
            var sortProduct = Builders<Product>.Sort.Descending(x => x.ProductPrice);
            var projection = Builders<Product>.Projection.Include(y => y.ProductName).Exclude("ProductID");
            var product = await _products.Find(filter).Sort(sortProduct).Project(projection).FirstOrDefaultAsync();

            return product.GetValue("ProductName").AsString;
        }

        public async Task<string> GetMinPriceProductNameAsync()
        {
            var filter = Builders<Product>.Filter.Empty;
            var sortProduct = Builders<Product>.Sort.Ascending(x => x.ProductPrice);
            var projection = Builders<Product>.Projection.Include(y => y.ProductName).Exclude("ProductID");
            var product = await _products.Find(filter).Sort(sortProduct).Project(projection).FirstOrDefaultAsync();

            return product.GetValue("ProductName").AsString;
        }

        public async Task<decimal> GetProductAvgPriceAsync()
        {
            var pipeline = new BsonDocument[]
            {
                new BsonDocument("$group",new BsonDocument
                  {
                      { "_id",null},
                      { "averagePrice",new BsonDocument("$avg","$ProductPrice")}
                  })
            };
            _logger.LogError(pipeline.ToString());
            var result = await _products.AggregateAsync<BsonDocument>(pipeline);
            var value = result.FirstOrDefault().GetValue("averagePrice", decimal.Zero).AsDecimal;
            return value;

        }

        public async Task<long> GetProductCountAsync()
        {
            return await _products.CountDocumentsAsync(FilterDefinition<Product>.Empty);
        }
    }
}
