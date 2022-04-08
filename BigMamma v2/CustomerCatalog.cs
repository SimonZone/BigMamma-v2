using System;
using System.Collections.Generic;


namespace BigMamma_v2
{
    public class CustomerCatalog
    {
        Dictionary<int, Customer> customers;

        public CustomerCatalog()
        {
            customers = new Dictionary<int, Customer>();
        }

        #region properties

        #endregion

        #region Methods
        public void CreateCustomer(Customer customer)
        {
            customers.Add(customer.ID, customer);
        }

        public Customer ReadCustomer(int customerID)
        {
            return customers[customerID];
        }

        public void UpdateCustomer(Customer customer, string newName)
        {
            customer.Name = newName;
        }

        public void DeleteCustomer(Customer customer)
        {
            customers.Remove(customer.ID);
        }

        public void SearchCustomer(Customer customer)
        {
            var key = customer.ID;
            var value = customer.Name;
            Console.WriteLine("ID. {0} Name: {1}", key, value);
        }

        #endregion
    }
}
