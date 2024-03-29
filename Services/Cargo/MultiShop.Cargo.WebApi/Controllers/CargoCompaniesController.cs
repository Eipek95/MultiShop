using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.CargoCompanyDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class CargoCompaniesController : ControllerBase
    {
        private readonly ICargoCompanyService _cargoCompanyService;
        private readonly IMapper _mapper;


        public CargoCompaniesController(ICargoCompanyService cargoCompanyService, IMapper mapper)
        {
            _cargoCompanyService = cargoCompanyService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCargoCompanyList()
        {
            var result = _cargoCompanyService.TGetAll();
            return Ok(_mapper.Map<List<GetListCargoCompanyDto>>(result));
        }
        [HttpGet("{id}")]
        public IActionResult GetCargoCompanyById(int id)
        {
            var result = _cargoCompanyService.TGetById(id);
            return Ok(_mapper.Map<GetCargoCompanyDto>(result));
        }
        [HttpPost]
        public IActionResult CreateCargoCompany(CreateCargoCompanyDto request)
        {
            _cargoCompanyService.TInsert(_mapper.Map<CargoCompany>(request));
            return Ok("Başarıyla Kaydedildi");
        }
        [HttpDelete]
        public IActionResult RemoveCargoCompany(int id)
        {
            _cargoCompanyService.TDelete(id);
            return Ok("Başarıyla Silindi");
        }

        [HttpPut]
        public IActionResult UpdateCargoCompany(UpdateCargoCompanyDto request)
        {
            _cargoCompanyService.TUpdate(_mapper.Map<CargoCompany>(request));
            return Ok("Başarıyla Güncellendi");
        }
    }
}
