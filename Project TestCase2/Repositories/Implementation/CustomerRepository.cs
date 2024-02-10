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
            return HotelContext.Customers.FirstOrDefault(customer => customer.Id == id);
        }

        public Customer GetByName(string email)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetList(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Customer customer)
        {
            HotelContext.Customers.Remove(customer);
        }
    }
}