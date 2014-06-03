using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorksService.Contracts
{
    [DataContract]
    public class SalesOrderDetails
    {
        [DataMember]
        public Int16 OrderQuantity { get; set; }
        [DataMember]
        public Decimal UnitPrice { get; set; }
        [DataMember]
        public Decimal UnitPriceDiscount { get; set; }
        [DataMember]
        public Decimal LineTotal { get; set; }
        [DataMember]
        public Product Product { get; set; }
    }
}
