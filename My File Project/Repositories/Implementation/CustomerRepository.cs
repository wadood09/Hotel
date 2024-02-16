using System.Text.Json;
using My_File_Project.Context;
using My_File_Project.Models.Entities;
using My_File_Project.Repositories.Interface;

namespace My_File_Project.Repositories.Implementation
{
    public class CustomerRepository : IRepository<Customer>
    {
        public void Add(Customer customer)
        {
            HotelContext.Customers.Add(customer);

            using (StreamWriter writer = new(HotelContext.CustomerFile, true))
            {
                writer.WriteLine(JsonSerializer.Serialize(customer));
            }
        }

        public Customer? Get(Func<Customer, bool> pred)
        {
            Customer? customer = HotelContext.Customers.SingleOrDefault(pred);
            return customer;
        }

        public List<Customer> GetAll()
        {
            return HotelContext.Customers;
        }

        public List<Customer> GetSelected(Func<Customer, bool> pred)
        {
            return HotelContext.Customers.Where(pred).ToList();
        }

        public void RefreshFile()
        {
            using (StreamWriter writer = new(HotelContext.CustomerFile, false))
            {
                foreach (Customer customer in HotelContext.Customers)
                {
                    writer.WriteLine(JsonSerializer.Serialize(customer));
                }
            }
        }

        public void RefreshList()
        {
            string[] customers = File.ReadAllLines(HotelContext.CustomerFile);
            foreach (string customer in customers)
            {
                HotelContext.Customers.Add(JsonSerializer.Deserialize<Customer>(customer)!);
            }
        }
    }
}