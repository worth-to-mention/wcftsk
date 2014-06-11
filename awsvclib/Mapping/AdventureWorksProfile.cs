using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts = awsvclib.Contracts;
using EM = awsvclib.EntityModel;
using AutoMapper;
using System.IO;


namespace awsvclib.Mapping
{
    public class AdventureWorksProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<EM.SalesOrderHeader, Contracts.SalesOrder>()
                .ForMember(
                    dest => dest.OrderID,
                    opt => opt.MapFrom(src => src.SalesOrderID)
                )
                .ReverseMap()
                .ForMember(
                    dest => dest.SalesOrderID,
                    opt => opt.MapFrom(src => src.OrderID)
                );

            Mapper.CreateMap<EM.Person, Contracts.Person>()
                .ReverseMap();

            Mapper.CreateMap<EM.Address, Contracts.Address>()
                .ReverseMap();

            Mapper.CreateMap<EM.Product, Contracts.SalesOrderDetails>()
                .ForMember(
                    dest => dest.ProductImageIds,
                    opt => opt.MapFrom(
                        src => src.ProductProductPhotoes
                            .Select(x => x.ProductPhotoID)
                            .ToArray()
                    )
                ).ForMember(
                    dest => dest.ProductName,
                    opt => opt.MapFrom(
                        src => src.Name
                    )
                ).ForMember(
                    dest => dest.ProductColor,
                    opt => opt.MapFrom(
                        src => src.Color
                    )
                ).ForMember(
                    dest => dest.ProductListPrice,
                    opt => opt.MapFrom(
                        src => src.ListPrice
                    )
                ).ForMember(
                    dest => dest.ProductStandardCost,
                    opt => opt.MapFrom(
                        src => src.StandardCost
                    )
                );

            Mapper.CreateMap<EM.SalesOrderDetail, Contracts.SalesOrderDetails>()
                .ForMember(
                    dest => dest.OrderQuantity,
                    opt => opt.MapFrom(src => src.OrderQty)
                )
                .ReverseMap()
                .ForMember(
                    dest => dest.OrderQty,
                    opt => opt.MapFrom(src => src.OrderQuantity)
                );

            Mapper.CreateMap<EM.ProductPhoto, Contracts.ProductImageMessage>()
                .ForMember(
                    dest => dest.FileName,
                    opt => opt.MapFrom(src => src.LargePhotoFileName)
                )
                .ForMember(
                    dest => dest.ImageData,
                    opt => opt.MapFrom(
                            src => new MemoryStream(src.LargePhoto)
                    )
                );
            Mapper.CreateMap<EM.Customer, Contracts.Customer>()
                .ReverseMap();
            
            Mapper.CreateMap<Contracts.Customer, EM.Person>();

            Mapper.CreateMap<EM.SalesPerson, Contracts.SalesPerson>()
                .ReverseMap();

            Mapper.CreateMap<Contracts.SalesPerson, EM.Person>();
        }

        public override string ProfileName
        {
            get
            {
                return this.GetType().Name;
            }
        }
    }
}
