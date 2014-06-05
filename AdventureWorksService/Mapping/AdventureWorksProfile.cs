using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts = AdventureWorksService.Contracts;
using EM = AdventureWorksService.EntityModel;
using AutoMapper;
using System.IO;


namespace AdventureWorksService.Mapping
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
            Mapper.CreateMap<EM.Product, Contracts.Product>()
                .ForMember(
                    dest => dest.ProductImageIds,
                    opt => opt.MapFrom(
                        src => src.ProductProductPhotoes
                            .Select(x => x.ProductPhotoID)
                            .ToArray()
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
