﻿using BussinessObject;
using Microsoft.AspNetCore.Mvc;
using Repository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Collections.Generic;

using BussinessObject.DataAccess;

namespace ProjectManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        CustomerRepository Customer = new CustomerRepository();
        OrderRepository Order = new OrderRepository();
        [HttpGet]

        public ActionResult<IEnumerable<Order>> GetProducts() => Order.GetOrder();

        [HttpPost]
        public ActionResult PostProduct(Order p)
        {
            int a = Order.FindOrderMaxId();
            p.OrderId = a + 1;
            Order.SaveOrder(p);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult Detail(int id)
        {
            var product = Order.FindOrderById(id);

            if (product == null)
            {
                return NotFound();
            }



            return Ok(product);
        }
        [HttpPut("{Order}")]
        public IActionResult UpdateProduct(Order p)
        {
          
            var product = Order.FindOrderById(p.OrderId.Value);
            if (product == null)
            {
                return NotFound();
            }

            Order.UpdateOrder(p);
            return RedirectToAction(nameof(Update), new { product });
        }

        [HttpGet("emails/{email}")]
        public IActionResult Details(string email)
        {

            var products = Customer.FindCustomerByEmail(email);
            var product = Order.FindOrderCustomerByEmail(products.CustomerId.Value);
            if (product == null)
            {
                return NotFound();
            }



            return Ok(product);
        }

        [HttpGet("Mail/{email}")]
        public IActionResult DetailCustomer(string email)
        {

            var product = Customer.FindCustomerByEmail(email);
            
            if (product == null)
            {
                return NotFound();
            }



            return Ok(product);
        }



        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            var product = Order.FindOrderById(id);
            if (product == null)
            {
                return NotFound();
            }

            Order.DeleteOrder(product);
            return Ok();
        }

        [HttpGet("OrderFlower")]
        public IActionResult CustomDetails()
        {


            var Customers = Customer.GetCustomer();
          


            var learn = new CustomerFul
            {
                FlowerBouquet = null,
                Customer = Customers,
              
            };



            return Ok(learn);
        }





    }
}
