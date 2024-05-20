using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CargoDtos.CargoCompanyDtos;
using MultiShop.WebUI.Services.CargoServices.CargoCompanyServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CargoController : Controller
    {
        private readonly ICargoCompanyService _cargoCompanyService;

        public CargoController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }
        [HttpGet]
        public async Task<IActionResult> CargoCompanyList()
        {
            var values = await _cargoCompanyService.GetCargoCompanyAllAsync();
            return View(values.ToList());
        }
        [HttpGet]
        public IActionResult CreateCargoCompany()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCargoCompany(CreateCargoCompanyDto request)
        {
            await _cargoCompanyService.CreateCargoCompanyAsync(request);
            return RedirectToAction(nameof(CargoCompanyList), new { area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCargoCompany(int id)
        {
            var result = await _cargoCompanyService.GetByIdCargoCompanyAsync(id);
            return View(new UpdateCargoCompanyDto
            {
                cargoCompanyId = result.cargoCompanyId,
                cargoCompanyName = result.cargoCompanyName
            });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCargoCompany(UpdateCargoCompanyDto request)
        {
            await _cargoCompanyService.UpdateCargoCompanyAsync(request);
            return RedirectToAction(nameof(CargoCompanyList), new { area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCargoCompany(int id)
        {
            await _cargoCompanyService.DeleteCargoCompanyAsync(id);
            return RedirectToAction(nameof(CargoCompanyList), new { area = "Admin" });
        }
    }
}
