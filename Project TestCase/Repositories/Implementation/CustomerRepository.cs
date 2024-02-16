using Project_TestCase2.Context;
using Project_TestCase2.Models.Entities;
using Project_TestCase2.Repositories.Interface;

namespace Project_TestCase2.Repositories.Implementation
{
    public class CustomerRepository : IRepository<Customer>
    {
        public void Add(Customer customer)
        {
            HotelContext.Customers.Add(customer);
        }

        public List<Customer> GetAll()
        {
            return HotelContext.Customers;
        }

        public Customer GetById(int id)
        {
            foreach (Customer customer in HotelContext.Customers)
            {
                if(customer.Id == id)
                {
                    return customer;
                }
            }
            return null;
        }

        public Customer GetByName(string email)
        {
            foreach (Customer customer in HotelContext.Customers)
            {
                if(customer.Email == email)
                {
                    return customer;
                }
            }
            return null;
        }

        public List<Customer> GetList(int id)
        {
            List<Customer> customers = new();
            foreach (Customer customer in HotelContext.Customers)
            {
                if(customer.Id == id)
                {
                    customers.Add(customer);
                }
            }
            return customers;
        }

        public void Remove(Customer customer)
        {
            HotelContext.Customers.Remove(customer);
        }
    }
}