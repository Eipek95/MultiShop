using AutoMapper;
using MultiShop.Cargo.DtoLayer.CargoCompanyDtos;
using MultiShop.Cargo.DtoLayer.CargoCustomerDtos;
using MultiShop.Cargo.DtoLayer.CargoDetailDtos;
using MultiShop.Cargo.DtoLayer.CargoOperationDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<CreateCargoDetailDto, CargoDetail>().ReverseMap();
            CreateMap<UpdateCargoDetailDto, CargoDetail>().ReverseMap();
            CreateMap<GetListCargoDetailDto, CargoDetail>().ReverseMap();
            CreateMap<GetCargoDetailDto, CargoDetail>().ReverseMap();


            CreateMap<CreateCargoCompanyDto, CargoCompany>().ReverseMap();
            CreateMap<UpdateCargoCompanyDto, CargoCompany>().ReverseMap();
            CreateMap<GetListCargoCompanyDto, CargoCompany>().ReverseMap();
            CreateMap<GetCargoCompanyDto, CargoCompany>().ReverseMap();


            CreateMap<CreateCargoCustomerDto, CargoCustomer>().ReverseMap();
            CreateMap<UpdateCargoCustomerDto, CargoCustomer>().ReverseMap();
            CreateMap<GetListCargoCustomerDto, CargoCustomer>().ReverseMap();
            CreateMap<GetCargoCustomerDto, CargoCustomer>().ReverseMap();


            CreateMap<CreateCargoOperationDto, CargoOperation>().ReverseMap();
            CreateMap<UpdateCargoOperationDto, CargoOperation>().ReverseMap();
            CreateMap<GetListCargoOperationDto, CargoOperation>().ReverseMap();
            CreateMap<GetCargoOperationDto, CargoOperation>().ReverseMap();
        }
    }
}
