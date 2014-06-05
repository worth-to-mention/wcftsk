using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AdventureWorksService.EntityModel;
using AutoMapper;

namespace AdventureWorksService
{
    public class AdventureWorks : IAdventuresWorks
    {
        #region IAdventuresWorks Members

        public List<Contracts.SalesOrder> GetSalesOrders(int from, int count)
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
                        detail.Product = Mapper.Map<Product, Contracts.Product>(product);

                        return detail;
                    }).ToList();
            }
            return details;
        }

        public Person GetPerson(Int32 PersonID)
        {
            return new Person();
        }



        public List<Contracts.Person> GetPeople(int from, int count)
        {
            List<Contracts.Person> people;
            using(var context = new AdventureWorksContext())
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
            using(var context = new AdventureWorksContext())
            {
                count = context.People.Count();
            }
            return count;
        }

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

        public void UpdateSalesOrder(Contracts.SalesOrder salesOrder)
        {
            throw new NotImplementedException();
        }

        public Contracts.ProductImageMessage GetProductImage(Contracts.ProductImageRequest imageRequest)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
