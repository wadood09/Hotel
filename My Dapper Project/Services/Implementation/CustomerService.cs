using System.Data;
using My_Dapper_Project.Models.Entities;
using My_Dapper_Project.Repositories.Implementation;
using My_Dapper_Project.Repositories.Interface;
using My_Dapper_Project.Services.Interface;

namespace My_Dapper_Project.Services.Implementation
{
    public class CustomerService : ICustomerService
    {
        IRepository<Customer> repository = new CustomerRepository();
        IBookingService bookingService = new BookingService();
        IUserService userService = new UserService();
        public void CreateCustomer(string userEmail)
        {
            var customer = new Customer
            {
                UserEmail = userEmail
            };
            repository.Add(customer);
        }

        public Customer? Get(Func<Customer, bool> pred)
        {
            return repository.GetAll().SingleOrDefault(pred);
        }

        public List<Customer> GetSelected(Func<Customer, bool> pred)
        {
            return repository.GetAll().Where(pred).ToList();
        }

        public bool IsDeleted(Customer customer)
        {
            using (IDbConnection connection = repository.Connection())
            {
                using (IDbTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        List<Booking> bookings = bookingService.GetSelected(booking => booking.CustomerID == customer.Id);
                        foreach (Booking booking in bookings)
                        {
                            bookingService.Delete(booking);
                        }

                        User user = userService.Get(user => user.Email == customer.UserEmail && user.Role == "CUSTOMER")!;
                        userService.Delete(user);
                        repository.Remove(customer);
                        transaction.Commit();
                        return true;
                    }
                    catch(Exception)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }

        public void Update(Customer customer)
        {
            repository.Update(customer);
        }
    }
}