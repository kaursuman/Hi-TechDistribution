using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hi_TechDistribution.DataAccess;

namespace Hi_TechDistribution.Business
{
    public class Customer
    {
        private int customerId;
        private string name;
        private string street;
        private string city;
        private string postalCode;
        private string phoneNumber;
        private string faxNumber;
        private int creditLimit;

        public int CustomerId { get => customerId; set => customerId = value; }
        public string Name { get => name; set => name = value; }
        public string Street { get => street; set => street = value; }
        public string City { get => city; set => city = value; }
        public string PostalCode { get => postalCode; set => postalCode = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string FaxNumber { get => faxNumber; set => faxNumber = value; }
        public int CreditLimit { get => creditLimit; set => creditLimit = value; }

        public List<Customer> ListCustomer()
        {
            return (CustomerDB.ListRecord());
        }
        
    }
}
