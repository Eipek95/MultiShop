using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.CargoDetailDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;
        private readonly IMapper _mapper;

        public CargoDetailsController(ICargoDetailService cargoDetailService, IMapper mapper)
        {
            _cargoDetailService = cargoDetailService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCargoDetailList()
        {
            var result = _cargoDetailService.TGetAll();
            return Ok(_mapper.Map<List<GetListCargoDetailDto>>(result));
        }
        [HttpGet("{id}")]
        public IActionResult GetCargoDetailById(int id)
        {
            var result = _cargoDetailService.TGetById(id);
            return Ok(_mapper.Map<GetCargoDetailDto>(result));
        }
        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoDetailDto request)
        {
            _cargoDetailService.TInsert(_mapper.Map<CargoDetail>(request));
            return Ok("Başarıyla Kaydedildi");
        }
        [HttpDelete]
        public IActionResult RemoveCargoDetail(int id)
        {
            _cargoDetailService.TDelete(id);
            return Ok("Başarıyla Silindi");
        }

        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDto request)
        {
            _cargoDetailService.TUpdate(_mapper.Map<CargoDetail>(request));
            return Ok("Başarıyla Güncellendi");
        }
    }
}
