
using BussinessObject.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System.Collections.Generic;

namespace ProjectManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {

        OrderDetailRepository OrderDetail = new OrderDetailRepository();

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<OrderDetail>> FindFlowerBouquetById(int id)
        {
          var order =  OrderDetail.FindFlowerBouquetById(id);

            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        //[HttpPut("{id}")]
        //public IActionResult UpdateProduct(Order p)
        //{
        //    var product = OrderDetail.FindOrderById(p.OrderId.Value);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    OrderDetail.UpdateOrder(p);
        //    return RedirectToAction(nameof(Update), new { product });
        //}

        //[HttpGet("emails/{email}")]
        //public IActionResult Details(string email)
        //{

        //    var products = Customer.FindCustomerByEmail(email);
        //    var product = OrderDetail.FindOrderCustomerByEmail(products.CustomerId.Value);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }



        //    return Ok(product);
        //}

        //[HttpGet("Mail/{email}")]
        //public IActionResult DetailCustomer(string email)
        //{

        //    var product = Customer.FindCustomerByEmail(email);

        //    if (product == null)
        //    {
        //        return NotFound();
        //    }



        //    return Ok(product);
        //}



        //[HttpDelete("{id}")]
        //public ActionResult DeleteProduct(int id)
        //{
        //    var product = OrderDetail.FindOrderById(id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    OrderDetail.DeleteOrder(product);
        //    return Ok();
        //}

        //[HttpGet("OrderFlower")]
        //public IActionResult CustomDetails()
        //{


        //    var Customers = Customer.GetCustomer();



        //    var learn = new CustomerFul
        //    {
        //        FlowerBouquet = null,
        //        Customer = Customers,

        //    };



        //    return Ok(learn);
        //}










    }
}
