using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts = AdventureWorksService.Contracts;
using EM = AdventureWorksService.EntityModel;
using AutoMapper;


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
            Mapper.CreateMap<EM.Product, Contracts.Product>();
            Mapper.CreateMap<EM.SalesOrderDetail, Contracts.SalesOrderDetails>()
                .ForMember(
                    dest => dest.OrderQuantity,
                    opt => opt.MapFrom(src => src.OrderQty)
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
