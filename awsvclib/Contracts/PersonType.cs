using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace awsvclib.Contracts
{
    //Primary type of person: SC = Store Contact, IN = Individual (retail) customer, SP = Sales person, EM = Employee (non-sales), VC = Vendor contact, GC = General contact
    public enum PersonType
    {
        StoreContact,
        IndividualCustomer,
        SalesPerson,
        Employee,
        VendorContact,
        GeneralContact
    }

}
namespace awsvclib.Extensions
{
    using awsvclib.Contracts;

    public static class PersonTypeExtentions
    {
        public static String ToDBValue(this PersonType source)
        {
            switch (source)
            {
                case PersonType.StoreContact:
                    return "SC";
                case PersonType.IndividualCustomer:
                    return "IN";
                case PersonType.SalesPerson:
                    return "SP";
                case PersonType.Employee:
                    return "EM";
                case PersonType.VendorContact:
                    return "VC";
                case PersonType.GeneralContact:
                    return "GC";
                default:
                    throw new NotSupportedException();
            }
        }

        public static PersonType PersonTypeFromDBValue(String dbPersonType)
        {
            switch (dbPersonType)
            {
                case "SC":
                    return PersonType.StoreContact;
                case "IN":
                    return PersonType.IndividualCustomer;
                case "SP":
                    return PersonType.SalesPerson;
                case "EM":
                    return PersonType.Employee;
                case "VC":
                    return PersonType.VendorContact;
                case "GC":
                    return PersonType.GeneralContact;
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
