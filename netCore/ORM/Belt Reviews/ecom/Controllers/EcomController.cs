using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ecom.Factory;
using ecom.Models;

namespace ecom.Controllers
{
    public class EcomController : Controller
    {
        private readonly CustomerFactory customerFactory;
        private readonly OrderFactory orderFactory;
        private readonly ProductFactory productFactory;
        // pivate readonly OrderFactory orderFactory;
        public EcomController(CustomerFactory cf, OrderFactory of, ProductFactory pf){
            customerFactory = cf;
            orderFactory = of;
            productFactory = pf;
        }
        // GET: /Home/
        [HttpGet]
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("/Customers")]
        public IActionResult Customers()
        {
            ViewBag.Customers = customerFactory.GetAllCustomers();
            return View();
        }

        [HttpPost]
        [Route("/Customers")]
        public IActionResult AddCustomer(Customer newCustomer)
        {
            if(customerFactory.GetCustomerByName(newCustomer.name) == false){
                customerFactory.Add(newCustomer);
                return RedirectToAction("Customers");
            }
            else{
                ViewBag.Error = "This customer is already registered.";
                return View("Customers");
            }
        }

        [HttpGet]
        [Route("/Remove/{id}")]
        public IActionResult Remove(int id)
        {
            customerFactory.Remove(id);
            return RedirectToAction("Customers");
        }

        [HttpGet]
        [Route("/Products")]
        public IActionResult Products(){
            ViewBag.Products = productFactory.GetAllProducts();
            return View();
        }

        [HttpPost]
        [Route("/Products")]
        public IActionResult AddProduct(Product newProduct){
            if(ModelState.IsValid){
                productFactory.Add(newProduct);
            } 
            return View();
        }

        [HttpGet]
        [Route("/Orders")]
        public IActionResult Orders(){
            ViewBag.Orders = orderFactory.GetAllOrders();
            return View();
        }

        [HttpPost]
        [Route("/Orders")]
        public IActionResult AddOrder(Order newOrder){
            if(ModelState.IsValid){
                orderFactory.Add(newOrder);
            } 
            return View();
        }
    }
}
