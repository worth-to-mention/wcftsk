using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts = awsvclib.Contracts;
using EM = awsvclib.EntityModel;
using AutoMapper;

namespace awsvclib.Mapping
{
    public static class MappingConfig
    {
        public static void Init()
        {
            //Mapper.Initialize(config => config.AddProfile<AdventureWorksProfile>());
            Mapper.Configuration.AddProfile(new AdventureWorksProfile());
        }
    }
}
