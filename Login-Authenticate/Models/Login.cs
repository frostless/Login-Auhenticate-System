
using System.ComponentModel;

namespace Login_Authenticate.Models
{
    public class Login
    {
        [DisplayName("Username")]
        public string Username { get; set; }
        [DisplayName("Password")]
        public string Password { get; set; }
    }
}