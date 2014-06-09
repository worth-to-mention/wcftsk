using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorksClient.Models
{
    public class SalesOrderDetails
    {
        
        public Int16 OrderQuantity { get; set; }
        
        public Decimal UnitPrice { get; set; }
        
        public Decimal UnitPriceDiscount { get; set; }
        
        public Decimal LineTotal { get; set; }
        
        public Int32 ProductID { get; set; }
        
        public String ProductName { get; set; }
        
        public String ProductNumber { get; set; }
        
        public String ProductColor { get; set; }
        
        public Decimal ProductStandardCost { get; set; }
        
        public Decimal ProductListPrice { get; set; }

        public List<ProductImage> ProductImages { get; set; }
    }
}
