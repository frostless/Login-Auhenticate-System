using System.Web.Mvc;
using Login_Authenticate.Models;
using Login_Authenticate.Business;


namespace Login_Authenticate.Controllers
{ 

    public class HomeController : Controller
    {
        private ICustomerService _customerSercvice;

        public HomeController()
        {
            _customerSercvice = new CustomerService();
        }

        public HomeController(ICustomerService cs)
        {
            _customerSercvice = cs;
        }



        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "";

            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View(new Login { Username = "test1" });
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {

            var customer = _customerSercvice.GetCustomer(username, password);


            if (customer != null)
            {
                //FormsAuthentication.SetAuthCookie(username, true);
                var isAdminUser = new AuthenticationService(customer).Authenticate();

                if (isAdminUser) return View("Enrol");
            }

            ModelState.AddModelError(string.Empty, "Invalid username and password.");
            return View("Index");

        }

        public ActionResult Enrol()
        {
            ViewBag.Message = "This is the enrollment page.";
            return View();
        }

        [HttpPost]
        public ActionResult Enrol(EnrollmentRequest enrollmentRequest)
        {
            ViewBag.Message = "This is the enrollment page.";
            HttpContext.Session.Add("Course", enrollmentRequest);
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}