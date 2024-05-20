using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.CargoCustomerDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class CargoCustomersController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;
        private readonly IMapper _mapper;


        public CargoCustomersController(ICargoCustomerService cargoCustomerService, IMapper mapper)
        {
            _cargoCustomerService = cargoCustomerService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCargoCustomerList()
        {
            var result = _cargoCustomerService.TGetAll();
            return Ok(_mapper.Map<List<GetListCargoCustomerDto>>(result));
        }
        [HttpGet("{id}")]
        public IActionResult GetCargoCustomerById(int id)
        {
            var result = _cargoCustomerService.TGetById(id);
            return Ok(_mapper.Map<GetCargoCustomerDto>(result));
        }
        [HttpPost]
        public IActionResult CreateCargoCustomer(CreateCargoCustomerDto request)
        {
            _cargoCustomerService.TInsert(_mapper.Map<CargoCustomer>(request));
            return Ok("Başarıyla Kaydedildi");
        }
        [HttpDelete]
        public IActionResult RemoveCargoCustomer(int id)
        {
            _cargoCustomerService.TDelete(id);
            return Ok("Başarıyla Silindi");
        }

        [HttpPut]
        public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto request)
        {
            _cargoCustomerService.TUpdate(_mapper.Map<CargoCustomer>(request));
            return Ok("Başarıyla Güncellendi");
        }
        [HttpGet("GetCargoCustomerById")]
        public IActionResult GetCargoCustomerById(string id)
        {
            return Ok(_cargoCustomerService.BGetCargoCustomerById(id));
        }
    }
}
