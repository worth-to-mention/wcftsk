using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using AdventureWorksService.Contracts;

namespace AdventureWorksService.Contracts
{
    [DataContract]
    public class SalesOrder
    {
        [DataMember]
        public Int32 OrderID { get; set; }

        [DataMember]
        public DateTime OrderDate { get; set; }

        [DataMember]
        public DateTime DueDate { get; set; }

        [DataMember]
        public DateTime? ShipDate { get; set; }

        [DataMember]
        public SalesOrderStatus Status { get; set; }

        [DataMember]
        public Decimal SubTotal { get; set; }

        [DataMember]
        public Decimal TaxAmount { get; set; }

        [DataMember]
        public Decimal Freight { get; set; }

        [DataMember]
        public Decimal TotalDue { get; set; }

        [DataMember]
        public Int32 BillToAddressID { get; set; }

        [DataMember]
        public Int32 ShipToAddressID { get; set; }

        [DataMember]
        public Int32 ShipMethodID { get; set; }

        [DataMember]
        public Int32 CustomerID { get; set; }
    }
}
