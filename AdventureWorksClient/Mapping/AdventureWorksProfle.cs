﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using AWSvc = AdventureWorksClient.AdventureWorksServiceReference;


using AutoMapper;
using System.Drawing;
using System.Windows.Media.Imaging;

namespace AdventureWorksClient.Mapping
{
    public class AdventureWorksProfle : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<AWSvc.SalesOrder, Models.SalesOrder>();
            Mapper.CreateMap<AWSvc.SalesOrderDetails, Models.SalesOrderDetails>()
                .ForMember(
                    dest => dest.ProductImages,
                    opt => opt.MapFrom(src => new ObservableCollection<Models.ProductImage>(
                            src.ProductImageIds.Select(x => 
                                new Models.ProductImage
                                { 
                                    ImageID = x
                                }
                            )
                        )
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
