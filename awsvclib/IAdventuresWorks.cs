using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

using awsvclib.Contracts;

namespace awsvclib
{
    [ServiceContract(Name=@"AdventuresWorks", Namespace=@"http://adventure.works")]
    public interface IAdventuresWorks
    {
#region SalesOrders operations
        [OperationContract]
        List<SalesOrder> GetSalesOrders(Int32 from, Int32 count);
        
        [OperationContract]
        Int32 GetSalesOrdersCount();
        
        [OperationContract]
        Int32 AddSalesOrder(SalesOrder salesOrder);

        [OperationContract(IsOneWay=true)]
        void SetSalesOrderStatus(Int32 salesOrderID, SalesOrderStatus status);
#endregion

#region SalesOrderDetails CRUD
        [OperationContract]
        List<SalesOrderDetails> GetSalesOrderDetails(Int32 salesOrderID);
        
        [OperationContract]
        Int32 GetSalesOrderDetailsCount(Int32 salesOrderID);
        
        [OperationContract]
        Int32 AddSalesOrderDetails(SalesOrderDetails salesOrderDetails);
#endregion

#region Person CRUD
        [OperationContract]
        List<Person> GetPeople(Int32 from, Int32 count);
        
        [OperationContract]
        Int32 GetPeopleCount();
        
        [OperationContract]
        Int32 AddPerson(Person person);
#endregion

#region Address CRUD
        [OperationContract]
        List<Address> GetAddresses(Int32 from, Int32 count);
        
        [OperationContract]
        Int32 GetAddressesCount();
        
        [OperationContract]
        void AddAddress(Address address);
#endregion

#region Customer CRUD
        [OperationContract]
        List<Customer> GetCustomers(Int32 from, Int32 count);
        
        [OperationContract]
        Int32 GetCustomersCount();
        
        [OperationContract]
        Int32 AddCustomer(Customer customer);
#endregion

#region SalesPerson CRUD
        [OperationContract]
        List<SalesPerson> GetSalesPeople(Int32 from, Int32 count);
        
        [OperationContract]
        Int32 GetSalesPeopleCount();
        
        [OperationContract]
        Int32 AddSalesPerson(SalesPerson salesPerson);
#endregion

#region Product operations
        [OperationContract]
        List<Product> GetProducts(Int32 from, Int32 count);
        
        [OperationContract]
        Int32 GetProductsCount();

        [OperationContract]
        Int32 AddProduct(Product product);

        [OperationContract]
        ProductImageMessage GetProductImage(ProductImageRequest imageRequest);
#endregion


    }
}
