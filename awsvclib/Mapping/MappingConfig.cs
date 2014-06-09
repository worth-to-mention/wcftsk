using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

namespace awsvclib.Mapping
{
    public static class MappingConfig
    {
        public static void Init()
        {
            Mapper.Initialize(config => config.AddProfile<AdventureWorksProfile>());
        }
    }
}
