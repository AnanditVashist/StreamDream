using StreamDream.Models;
using StreamDream.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace StreamDream.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(C => C.MembershipType).ToList();
            return View(customers);
        }
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).Single(c => c.Id == id);
            return View(customer);
        }
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel
            {
                Customer = new Customer(),
                membershipTypes = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.Single(c => c.Id == id);
            var viewModel = new NewCustomerViewModel
            {
                Customer = customer,
                membershipTypes = _context.MembershipTypes
            };
            return View("CustomerForm", viewModel);
        }
        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewCustomerViewModel
                {
                    Customer = customer,
                    membershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }

            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                customerInDb.MembershipType = customer.MembershipType;
            }
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}