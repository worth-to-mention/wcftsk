using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorksService.Contracts
{
    [DataContract]
    public class Product
    {
        [DataMember]
        public Int32 ProductID { get; set; }
        [DataMember]
        public String Name { get; set; }
        [DataMember]
        public String ProductNumber { get; set; }
        [DataMember]
        public String Color { get; set; }
        [DataMember]
        public Decimal StandardCost { get; set; }
        [DataMember]
        public Decimal ListPrice { get; set; }

    }
}
