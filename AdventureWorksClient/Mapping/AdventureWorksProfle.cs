using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AWSvc = AdventureWorksClient.AdventureWorksServiceReference;


using AutoMapper;

namespace AdventureWorksClient.Mapping
{
    public class AdventureWorksProfle : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<AWSvc.SalesOrder, Models.SalesOrder>();

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
