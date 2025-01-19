
using AutoMapper;
using CustomerRegistrationApi.Domain;
using CustomerRegistrationApi.Request;
using CustomerRegistrationApi.Request.Customer;

namespace CustomerRegistrationApi.Mapping
{
    public class CustomerProfile : Profile
    {
        // Mapeamento de CustomerRequest para Customer
        public CustomerProfile()
        {
            // Mapeamento de CustomerRequest para Customer
            CreateMap<CompanyFileRequest, CompanyFile>()
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data))
                .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName))
                .ForMember(dest => dest.ContentType, opt => opt.MapFrom(src => src.ContentType));


            // Mapeamento de Customer para CustomerRequest
            CreateMap<CompanyFile, CompanyFileRequest>()
               .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data))
                .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName))
                .ForMember(dest => dest.ContentType, opt => opt.MapFrom(src => src.ContentType));

            // Mapeamento de CustomerRequest para Customer
            CreateMap<CustomerRequest, Customer>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.CompanyFile, opt => opt.MapFrom(src => src.CompanyFile))
                .ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => src.Addresses.Select(addr => new Address(addr)).ToList()));                

            // Mapeamento de Customer para CustomerRequest
            CreateMap<Customer, CustomerRequest>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => src.Addresses.Select(a => a.Street).ToList()))
                .ForMember(dest => dest.CompanyFile, opt => opt.MapFrom(src => src.CompanyFile));
        }
    }
}
