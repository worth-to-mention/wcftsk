using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace awsvclib.Contracts
{
    [DataContract]
    public class Customer : Person
    {
        [DataMember]
        public Int32 CustomerID { get; set; }

        [DataMember]
        public String AccountNumber { get; set; }
    }
}
