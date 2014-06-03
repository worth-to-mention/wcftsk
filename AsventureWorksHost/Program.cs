using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

using AdventureWorksService;
using AdventureWorksService.Mapping;
using System.ServiceModel.Description;


namespace AsventureWorksHost
{
    class Program
    {
        static void Main(string[] args)
        {
            MappingConfig.Init();
            var baseAddress = new Uri(@"http://localhost:8001");
            var host = new ServiceHost(typeof(AdventureWorks), baseAddress);

            try
            {
                host.AddServiceEndpoint(typeof(IAdventuresWorks), new BasicHttpBinding(), "aws");

                var serviceBehavior = new ServiceMetadataBehavior();
                serviceBehavior.HttpGetEnabled = true;
                host.Description.Behaviors.Add(serviceBehavior);

                host.Open();

                Console.WriteLine("The AdventureWorks service has been started.");
                Console.WriteLine("Press any key to terminate the service.");
                Console.ReadKey(
                    intercept: true
                );

                host.Close();

            }
            catch (CommunicationException e)
            {
                Console.WriteLine("An exception has occured: {0}", e.Message);
                host.Abort();
            }

        }
    }
}
