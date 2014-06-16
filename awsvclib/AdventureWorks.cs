using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using awsvclib.EntityModel;
using awsvclib.Extensions;
using AutoMapper;
using System.IO;

namespace awsvclib
{
    public class AdventureWorks : IAdventuresWorks
    {

        
        public AdventureWorks()
        {
            Mapping.MappingConfig.Init();
        }

        #region IAdventuresWorks Members

#region SalesOrders
        public List<Contracts.SalesOrder> GetSalesOrders(Int32 from, Int32 count)
        {
            List<Contracts.SalesOrder> orders = null;
            using(var context = new AdventureWorksContext())
            {
                orders = context.SalesOrderHeaders.OrderBy(x => x.SalesOrderID).Skip(from).Take(count).ToList()
                    .Select(x => Mapper.Map<SalesOrderHeader, Contracts.SalesOrder>(x))
                    .ToList();
            }
            return orders;
        }
        
        public Int32 GetSalesOrdersCount()
        {
            Int32 count = 0;
            using (var context = new AdventureWorksContext())
            {
                count = context.SalesOrderHeaders.Count();
            }
            return count;
        }

        public Int32 AddSalesOrder(Contracts.SalesOrder salesOrder)
        {
 	        throw new NotImplementedException();
        }
        public void SetSalesOrderStatus(Int32 salesOrderID, Contracts.SalesOrderStatus status)
        {
 	        throw new NotImplementedException();
        }
        public int AddSalesOrderDetails(Contracts.SalesOrderDetails salesOrderDetails)
        {
            throw new NotImplementedException();
        }
#endregion
        
#region SalesOrderDetails
        public List<Contracts.SalesOrderDetails> GetSalesOrderDetails(Int32 salesOrderID)
        {
            var details = new List<Contracts.SalesOrderDetails>();
            using (var context = new AdventureWorksContext())
            {
                details = context.SalesOrderDetails.Where(x => x.SalesOrderID == salesOrderID).ToList()
                    .Select(x => {
                        Product product = context.Products.FirstOrDefault(z => z.ProductID == x.ProductID);
                        context.Entry(product).Collection(p => p.ProductProductPhotoes).Load();
                        
                        var detail = Mapper.Map<SalesOrderDetail, Contracts.SalesOrderDetails>(x);
                        Mapper.Map<Product, Contracts.SalesOrderDetails>(product, detail);

                        return detail;
                    }).ToList();
            }
            return details;
        }
        
        public int GetSalesOrderDetailsCount(Int32 salesOrderID)
        {
 	        throw new NotImplementedException();
        }
#endregion

#region People
        public Person GetPerson(Int32 PersonID)
        {
            return new Person();
        }

        public List<Contracts.Person> GetPeople(Int32 from, Int32 count)
        {
            List<Contracts.Person> people;
            using (var context = new AdventureWorksContext())
            {
                people = context.People.OrderBy(x => x.BusinessEntityID).Skip(from).Take(count).ToList()
                    .Select(x => Mapper.Map<Person, Contracts.Person>(x))
                    .ToList();
            }
            return people;
        }

        public Int32 GetPeopleCount()
        {
            var count = 0;
            using (var context = new AdventureWorksContext())
            {
                count = context.People.Count();
            }
            return count;
        }

        public int AddPerson(Contracts.Person person)
        {
            throw new NotImplementedException();
        }
#endregion


#region Addresses
        public List<Contracts.Address> GetAddresses(int from, int count)
        {
            var adresses = new List<Contracts.Address>();

            using (var context = new AdventureWorksContext())
            {
                adresses = context.Addresses.OrderBy(x => x.AddressID).Skip(from).Take(count).ToList()
                    .Select(x => Mapper.Map<Address, Contracts.Address>(x))
                    .ToList();
            }

            return adresses;
        }
        
        public Int32 GetAddressesCount()
        {
            Int32 count = 0;

            using (var context = new AdventureWorksContext())
            {
                count = context.Addresses.Count();
            }

            return count;
        }
        
        public void AddAddress(Contracts.Address address)
        {
            throw new NotImplementedException();
        }
#endregion

#region Customers
        public List<Contracts.Customer> GetCustomers(int from, int count)
        {
            var customers = new List<Contracts.Customer>();
            using (var context = new AdventureWorksContext())
            {
                context.Customers.Include("Person");
                customers = context.Customers.OrderBy(x => x.ModifiedDate)
                    .Skip(from).Take(count).ToList()
                    .Select(x =>
                        Mapper.Map<Customer, Contracts.Customer>(x)
                    ).ToList();
            }
            return customers;
        }
        
        public int GetCustomersCount()
        {
            Int32 customersCount = 0;
            using (var context = new AdventureWorksContext())
            {
                customersCount = context.Customers.Count();
            }
            return customersCount;
        }
        
        public Int32 AddCustomer(Contracts.Customer customer)
        {
            Customer newCustomer = Mapper.Map<Contracts.Customer, Customer>(customer);
            Person customerPerson = Mapper.Map<Contracts.Customer, Person>(customer);
            var personType = Contracts.PersonType.IndividualCustomer;
            using (var contex = new AdventureWorksContext())
            {
                customerPerson.PersonType = personType.ToDBValue();
                customerPerson.ModifiedDate = DateTime.UtcNow;
                newCustomer.Person = customerPerson;
                newCustomer.ModifiedDate = customerPerson.ModifiedDate;
                contex.People.Add(customerPerson);
                contex.Customers.Add(newCustomer);

                contex.SaveChanges();
            }
            return newCustomer.CustomerID;
        }
#endregion

#region SalesPeople
        public List<Contracts.SalesPerson> GetSalesPeople(int from, int count)
        {
            throw new NotImplementedException();
        }

        public int GetSalesPeopleCount()
        {
            throw new NotImplementedException();
        }

        public int AddSalesPerson(Contracts.SalesPerson salesPerson)
        {
            throw new NotImplementedException();
        }
#endregion

#region Products
        public List<Contracts.Product> GetProducts(int from, int count)
        {
            throw new NotImplementedException();
        }

        public int GetProductsCount()
        {
            throw new NotImplementedException();
        }

        public int AddProduct(Contracts.Product product)
        {
            throw new NotImplementedException();
        }

        public Contracts.ProductImageMessage GetProductImage(Contracts.ProductImageRequest imageRequest)
        {
            var msg = new Contracts.ProductImageMessage();

            using (var context = new AdventureWorksContext())
            {
                var img = context.ProductPhotoes.Where(x => x.ProductPhotoID == imageRequest.ImageID).FirstOrDefault();
                if (img != null)
                {
                    var stream = new MemoryStream();
                    var fileName = String.Empty;
                    if (imageRequest.LargeImage)
                    {
                        stream.Write(img.LargePhoto, 0, img.LargePhoto.Length);
                        fileName = img.LargePhotoFileName;
                    }
                    else
                    {
                        stream.Write(img.ThumbNailPhoto, 0, img.ThumbNailPhoto.Length);
                        fileName = img.ThumbnailPhotoFileName;
                    }

                    // phfffffuuu
                    stream.Position = 0;

                    msg.ImageData = stream;
                    msg.FileName = fileName;
                }
            }
            return msg;
        }
#endregion
        























        #endregion
    }
}
