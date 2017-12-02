
using Login_Authenticate.Models;

namespace Login_Authenticate.Business
{
    public interface ICustomerService
    {
        Customer GetCustomer(string username, string password);
    }

    public class CustomerService : ICustomerService
    {
        public Customer GetCustomer(string username, string password)
        {
            return new Customer
            {
                Username = username,
                Password = password,
                IsAdmin = true,
            };
        }
    }

    public class CustomerService1 : ICustomerService
    {
        public Customer GetCustomer(string username, string password)
        {
            return new Customer
            {
                Username = username,
                Password = password,
                IsAdmin = false,
            };
        }
    }

    public class CustomerService2 : ICustomerService
    {
        public Customer GetCustomer(string username, string password)
        {
            return new Customer
            {
                Username = "testing",
                Password = "testing",
                IsAdmin = true,
            };
        }
    }

}