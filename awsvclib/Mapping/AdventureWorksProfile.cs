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
                );
            Mapper.CreateMap<EM.Person, Contracts.Person>();
            Mapper.CreateMap<EM.Address, Contracts.Address>();
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
