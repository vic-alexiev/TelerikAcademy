namespace Bank
{
    public class IndividualCustomer : Customer
    {
        public IndividualCustomer(string id, string name, string lastName, string address, string phone)
            : base(id, name, lastName, address, phone)
        {
        }
    }
}
