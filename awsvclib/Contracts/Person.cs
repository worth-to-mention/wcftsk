using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace awsvclib.Contracts
{
    [DataContract]
    public class Person
    {
        [DataMember]
        public Int32 BusinessEntityID { get; set; }
        [DataMember]
        public String FirstName { get; set; }
        [DataMember]
        public String LastName { get; set; }
    }
}
