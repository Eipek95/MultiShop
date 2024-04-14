using MultiShop.DtoLayer.BasketDtos;
using MultiShop.WebUI.Services.DiscountServices;

namespace MultiShop.WebUI.Services.BasketServices
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _httpClient;
        private readonly IDiscountService _discountService;

        public BasketService(HttpClient httpClient, IDiscountService discountService)
        {
            _httpClient = httpClient;
            _discountService = discountService;
        }

        public async Task AddBasketItem(BasketItemDto basketItemDto)
        {
            var values = await GetBasket();

            if (values.BasketItems.Count == 0)
            {
                values.BasketItems.Add(new BasketItemDto
                {
                    Price = basketItemDto.Price,
                    ProductId = basketItemDto.ProductId,
                    ProductName = basketItemDto.ProductName,
                    Quantity = basketItemDto.Quantity,
                    ProductImageUrl = basketItemDto.ProductImageUrl,
                });
            }
            else
            {
                if (!values.BasketItems.Any(x => x.ProductId == basketItemDto.ProductId))
                {
                    values.BasketItems.Add(basketItemDto);
                }
                else
                {
                    var existingItem = values.BasketItems.First(x => x.ProductId == basketItemDto.ProductId);
                    existingItem.Quantity += basketItemDto.Quantity;
                }
            }

            await SaveBasket(values);
        }

        public async Task<bool> ApplyDiscount(string discountCode)
        {
            await CancelApplyDiscount();//daha önceden kupon uygulanmışsa iptal etsin
            var basket = await GetBasket();

            var hasDiscount = await _discountService.GetDiscountCode(discountCode);
            if (hasDiscount == null)
            {
                return false;
            }
            basket.DiscountRate = hasDiscount.Rate;
            basket.DiscountCode = hasDiscount.Code;
            await SaveBasket(basket);
            return true;
        }

        public async Task<bool> CancelApplyDiscount()
        {
            var basket = await GetBasket();
            basket.DiscountCode = "-";
            await SaveBasket(basket);
            return true;
        }

        public async Task DeleteBasket(string userId)
        {
            await _httpClient.DeleteAsync("baskets?id=" + userId);
        }

        public async Task<BasketTotalDto> GetBasket()
        {
            var responseMessage = await _httpClient.GetAsync("baskets");
            var values = await responseMessage.Content.ReadFromJsonAsync<BasketTotalDto>();
            return values;
        }

        public async Task<bool> RemoveBasketItem(string productId)
        {
            var values = await GetBasket();
            var deletedItem = values.BasketItems.FirstOrDefault(x => x.ProductId == productId);
            var result = values.BasketItems.Remove(deletedItem);
            if (!values.BasketItems.Any())
            {
                values.DiscountCode = "-";
                values.DiscountRate = 0;
            }
            await SaveBasket(values);
            return true;
        }

        public async Task SaveBasket(BasketTotalDto basketTotalDto)
        {
            await _httpClient.PostAsJsonAsync<BasketTotalDto>("baskets", basketTotalDto);
        }
    }
}
