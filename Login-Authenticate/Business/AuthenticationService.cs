
using Login_Authenticate.Models;

namespace Login_Authenticate.Business
{
    public class AuthenticationService
    {
        private Customer _customer;

        public AuthenticationService(Customer customer)
        {
            _customer = customer;
        }

        public bool Authenticate()
        {
            return AuthenticateFacebook() || AuthenticateGoogle();
        }

        public bool AuthenticateFacebook()
        {
            return _customer.Username == "facebook" && _customer.Password == "facebook" && _customer.IsAdmin == true;
        }

        public bool AuthenticateGoogle()
        {
            return _customer.Username == "google" && _customer.Password == "google" && _customer.IsAdmin == true;
        }
    }
}