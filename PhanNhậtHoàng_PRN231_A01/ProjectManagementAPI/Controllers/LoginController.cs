﻿using BussinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Repository;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using DataAccess;
using BussinessObject.DataAccess;

namespace ProjectManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
         CustomerRepository customer = new CustomerRepository();
       
       
        [HttpGet]

        public ActionResult<IEnumerable<Customer>> GetProducts() => customer.GetCustomer();
       
        [HttpPost]
        public ActionResult PostLogin(Customer p)
        {
            var cus = customer.FindCustomerById(p.Email, p.Password);
            var admin = customer.checkAdminLogin(p.Email, p.Password);

            if (cus == null && admin == null)
            {
                string value = "Login Fail";
                return Ok(value);
            }

            var data = new { cus, admin };
            return Ok(data);
        }


        [HttpPost("Register")]
        public ActionResult PostProduct(Customer p)
        {
            var check = customer.FindCustomerByEmail(p.Email);
            if(check == null)
            {
                customer.SaveCustomer(p);
                return Ok();
            }
           
            return NotFound();
        }






    }
}
