using System;

namespace Bank
{
    public abstract class Customer
    {
        #region Private Fields

        private string id;
        private string name;
        private string lastName;
        private string address;
        private string phone;

        #endregion

        #region Properties

        public string Id
        {
            get
            {
                return id;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Id cannot be null or empty.");
                }
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or empty.");
                }
                name = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Last name cannot be null or empty.");
                }
                lastName = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Address cannot be null or empty.");
                }
                address = value;
            }
        }

        public string Phone
        {
            get
            {
                return phone;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Phone cannot be null or empty.");
                }
                phone = value;
            }
        }

        #endregion

        #region Constructors

        protected Customer(string id, string name, string lastName, string address, string phone)
        {
            this.id = id;
            this.name = name;
            this.lastName = lastName;
            this.address = address;
            this.phone = phone;
        }

        #endregion
    }
}
