﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace awsvclib.Contracts
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
        [DataMember]
        public Int32 ProductID { get; set; }
        [DataMember]
        public String ProductName { get; set; }
        [DataMember]
        public String ProductNumber { get; set; }
        [DataMember]
        public String ProductColor { get; set; }
        [DataMember]
        public Decimal ProductStandardCost { get; set; }
        [DataMember]
        public Decimal ProductListPrice { get; set; }
        [DataMember]
        public List<Int32> ProductImageIds { get; set; }
    }
}
