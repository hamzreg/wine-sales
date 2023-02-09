using AutoMapper;
using WineSales.Domain.DTO;
using WineSales.Domain.Models;
using WineSales.Domain.ModelsBL;

namespace WineSales.Domain.Utils
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<Customer, CustomerBL>().ReverseMap();
            CreateMap<LoginDetails, LoginDetailsBL>().ReverseMap();
            CreateMap<Sale, SaleBL>().ReverseMap();
            CreateMap<Supplier, SupplierBL>().ReverseMap();
            CreateMap<SupplierWine, SupplierWineBL>().ReverseMap();
            CreateMap<User, UserBL>().ReverseMap();
            CreateMap<Wine, WineBL>().ReverseMap();

            CreateMap<CustomerBaseDTO, CustomerBL>().ReverseMap();
            CreateMap<CustomerDTO, CustomerBL>().ReverseMap();
            CreateMap<LoginDetailsDTO, LoginDetailsBL>().ReverseMap();
            CreateMap<SaleBaseDTO, SaleBL>().ReverseMap();
            CreateMap<SaleDTO, SaleBL>().ReverseMap();
            CreateMap<SupplierBaseDTO, SupplierBL>().ReverseMap();
            CreateMap<SupplierDTO, SupplierBL>().ReverseMap();
            CreateMap<SupplierWineBaseDTO, SupplierWineDTO>().ReverseMap();
            CreateMap<SupplierWineDTO, SupplierWineDTO>().ReverseMap();
            CreateMap<UserBaseDTO, UserBL>().ReverseMap();
            CreateMap<UserDTO, UserBL>().ReverseMap();
            CreateMap<UserPasswordDTO, UserBL>().ReverseMap();
            CreateMap<UserIdPasswordDTO, UserBL>().ReverseMap();
            CreateMap<WineBaseDTO, WineBL>().ReverseMap();
            CreateMap<WineDTO, WineBL>().ReverseMap();
        }
    }
}
