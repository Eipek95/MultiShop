using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.CargoOperationDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CargoOperationsController : ControllerBase
    {
        private readonly ICargoOperationService _cargoOperationService;
        private readonly IMapper _mapper;

        public CargoOperationsController(ICargoOperationService cargoOperationService, IMapper mapper)
        {
            _cargoOperationService = cargoOperationService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCargoOperationList()
        {
            var result = _cargoOperationService.TGetAll();
            return Ok(_mapper.Map<List<GetListCargoOperationDto>>(result));
        }
        [HttpGet("{id}")]
        public IActionResult GetCargoOperationById(int id)
        {
            var result = _cargoOperationService.TGetById(id);
            return Ok(_mapper.Map<GetCargoOperationDto>(result));
        }
        [HttpPost]
        public IActionResult CreateCargoOperation(CreateCargoOperationDto request)
        {
            _cargoOperationService.TInsert(_mapper.Map<CargoOperation>(request));
            return Ok("Başarıyla Kaydedildi");
        }
        [HttpDelete]
        public IActionResult RemoveCargoOperation(int id)
        {
            _cargoOperationService.TDelete(id);
            return Ok("Başarıyla Silindi");
        }

        [HttpPut]
        public IActionResult UpdateCargoOperation(UpdateCargoOperationDto request)
        {
            _cargoOperationService.TUpdate(_mapper.Map<CargoOperation>(request));
            return Ok("Başarıyla Güncellendi");
        }
    }
}
