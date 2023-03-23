using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using mvc_js.Models;

namespace mvc_js.Controllers
{
    public class CustomerController : Controller
    {
        public static List<Customer> _CustomerList = new List<Customer>();


        [HttpGet]
        public IActionResult Index()
        {
            return View(_CustomerList.ToList());
        }

        [HttpGet]
        public IActionResult GetList()
        {
            return Json(_CustomerList.ToList());
        }

        [HttpPost]
        public IActionResult Add(CustomerDto customerDto)
        {
            _CustomerList.Add(new Customer(customerDto.Fname, customerDto.Lname));

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        //[Consumes("")]
        public IActionResult AddJSON([FromBody] CustomerDto customerDto)
        {
            var newCustomer = new Customer(customerDto.Fname, customerDto.Lname);
            _CustomerList.Add(newCustomer);

            return Json(newCustomer);
        }
    }
}
