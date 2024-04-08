using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.OfferDiscountDtos;
using MultiShop.Catalog.Services.OfferDiscountServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class OfferDiscountController : ControllerBase
    {
        private readonly IOfferDiscountService _categoryService;

        public OfferDiscountController(IOfferDiscountService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetOfferDiscountList()
        {
            var values = await _categoryService.GetOfferDiscountAllAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOfferDiscountById(string id)
        {
            var values = await _categoryService.GetByIdOfferDiscountAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto)
        {
            await _categoryService.CreateOfferDiscountAsync(createOfferDiscountDto);
            return Ok("Başarıyla Eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOfferDiscount(string id)
        {
            await _categoryService.DeleteOfferDiscountAsync(id);
            return Ok("Başarıyla Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            await _categoryService.UpdateOfferDiscountAsync(updateOfferDiscountDto);
            return Ok("Başarıyla Güncellendi");
        }
    }
}
