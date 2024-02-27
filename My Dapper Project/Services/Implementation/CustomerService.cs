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
            Customer customer = new()
            {
                UserEmail = userEmail
            };
            repository.Add(customer);
        }

        public Customer? Get(Func<Customer, bool> pred)
        {
            return repository.Get(pred);
        }

        public List<Customer> GetSelected(Func<Customer, bool> pred)
        {
            return repository.GetSelected(pred);
        }

        public bool IsDeleted(Customer customer)
        {
            List<Booking> bookings = bookingService.GetSelected(booking => booking.CustomerID == customer.Id);
            foreach (Booking booking in bookings)
            {
                return false;
            }

            User user = userService.Get(user => user.Email == customer.UserEmail && user.Role == "CUSTOMER")!;
            userService.Delete(user);
            repository.Remove(customer);
            return true;
        }

        public void UpdateFile()
        {
            repository.RefreshFile();
        }

        public void UpdateList()
        {
            repository.RefreshList();
        }
    }
}