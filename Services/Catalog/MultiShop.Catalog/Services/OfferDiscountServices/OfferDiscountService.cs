using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.OfferDiscountDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.OfferDiscountServices
{
    public class OfferDiscountService : IOfferDiscountService
    {
        private readonly IMongoCollection<OfferDiscount> _discountOfferCollection;
        private readonly IMapper _mapper;

        public OfferDiscountService(IDatabaseSettings _databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _discountOfferCollection = database.GetCollection<OfferDiscount>(_databaseSettings.OfferDiscountCollectionName);
            _mapper = mapper;
        }

        public async Task CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountDto)
        {
            var values = _mapper.Map<OfferDiscount>(createOfferDiscountDto);
            await _discountOfferCollection.InsertOneAsync(values);
        }

        public async Task DeleteOfferDiscountAsync(string id)
        {
            await _discountOfferCollection.DeleteOneAsync(x => x.OfferDiscountId == id);
        }

        public async Task<GetByIdOfferDiscountDto> GetByIdOfferDiscountAsync(string id)
        {
            var values = await _discountOfferCollection.Find<OfferDiscount>(x => x.OfferDiscountId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdOfferDiscountDto>(values);
        }

        public async Task<List<ResultOfferDiscountDto>> GetOfferDiscountAllAsync()
        {
            var values = await _discountOfferCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultOfferDiscountDto>>(values);
        }

        public async Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            var values = _mapper.Map<OfferDiscount>(updateOfferDiscountDto);
            await _discountOfferCollection.FindOneAndReplaceAsync(x => x.OfferDiscountId == updateOfferDiscountDto.OfferDiscountId, values);
        }
    }
}
