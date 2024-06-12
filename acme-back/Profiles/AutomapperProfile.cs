using acme_back.Customer;
using acme_back.Product;
using AutoMapper;

namespace acme_back.Profiles;

public class AutomapperProfile : Profile
{

    public AutomapperProfile()
    {
        // Product Mapper
        CreateMap<Product.Product, ProductDto>();
        CreateMap<CreateProductDto, Product.Product>();
        CreateMap<UpdateProductDto, Product.Product>();

        
        // Customer Mapper
        CreateMap<Customer.Customer, CustomerDto>()
            .ForMember(
                dest => dest.Products, 
                opt => opt.MapFrom(
                    src => src.Products));
        
        CreateMap<CreateCustomerDto, Customer.Customer>();
        CreateMap<UpdateCustomerDto, Customer.Customer>();
    }
    
    
}