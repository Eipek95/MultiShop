using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.SpecialOfferDtos;
using MultiShop.Catalog.Services.SpecialOfferServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class SpecialOfferController : ControllerBase
    {
        private readonly ISpecialOfferService _specialOfferService;

        public SpecialOfferController(ISpecialOfferService specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSpecialOfferList()
        {
            var values = await _specialOfferService.GetSpecialOfferAllAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpecialOfferById(string id)
        {
            var values = await _specialOfferService.GetByIdSpecialOfferAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
        {
            await _specialOfferService.CreateSpecialOfferAsync(createSpecialOfferDto);
            return Ok("Başarıyla Eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            await _specialOfferService.DeleteSpecialOfferAsync(id);
            return Ok("Başarıyla Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            await _specialOfferService.UpdateSpecialOfferAsync(updateSpecialOfferDto);
            return Ok("Başarıyla Güncellendi");
        }
    }
}
