using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

using AdventureWorksService.Contracts;

namespace AdventureWorksService
{
    [ServiceContract(Name=@"AdventuresWorks", Namespace=@"http://adventure.works")]
    public interface IAdventuresWorks
    {
        [OperationContract]
        List<SalesOrder> GetSalesOrders(Int32 from, Int32 count);

        [OperationContract]
        Int32 GetSalesOrdersCount();

        [OperationContract]
        List<SalesOrderDetails> GetSalesOrderDetails(Int32 salesOrderID);

        [OperationContract]
        List<Person> GetPeople(Int32 from, Int32 count);

        [OperationContract]
        Int32 GetPeopleCount();

        [OperationContract]
        List<Address> GetAddresses(Int32 from, Int32 count);

        [OperationContract]
        Int32 GetAddressesCount();

        [OperationContract]
        ProductImageMessage GetProductImage(ProductImageRequest imageRequest);

    }
}
