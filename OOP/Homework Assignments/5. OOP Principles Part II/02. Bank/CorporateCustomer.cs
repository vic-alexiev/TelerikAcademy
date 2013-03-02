using System;

namespace Bank
{
    public class CorporateCustomer : Customer
    {
        public CorporateCustomer(string id, string name, string address, string phone)
            : base(id, name, String.Empty, address, phone)
        {
        }
    }
}
