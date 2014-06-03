using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorksService.Contracts
{
    //Order current status. 1 = In process; 2 = Approved; 3 = Backordered; 4 = Rejected; 5 = Shipped; 6 = Cancelled'
    [DataContract]
    public enum SalesOrderStatus : byte
    {
        [EnumMember]
        InProcess = 1,

        [EnumMember]
        Approved,

        [EnumMember]
        Backordered,

        [EnumMember]
        Rejected,

        [EnumMember]
        Shipped,

        [EnumMember]
        Cancelled
    }
}
