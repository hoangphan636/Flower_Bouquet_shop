﻿using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Net.Http;
using BussinessObject;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using System.Linq;
using System;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using BussinessObject.DataAccess;

namespace BouquetManagementWebClient.Controllers
{
    public class LoginController : Controller
    {
     
        private readonly HttpClient client = null;
        private string productApiUrl = "";

        public LoginController()
        {
           

            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            productApiUrl = "http://localhost:61010/api/Login";
        }

        public IActionResult index()
        {
            return View();
        }
       
        public async Task<IActionResult> Login(Customer p)
        {
          
            if (ModelState.IsValid)
            {
                string strDatas = JsonSerializer.Serialize(p);
                var contentData = new StringContent(strDatas, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(productApiUrl, contentData);
                string strData = await response.Content.ReadAsStringAsync();
                if (strData == "\"Login Fail\"")
                {
                    HttpContext.Session.SetString("CustomerName", "Seem Like wrong password or Email");
                    return RedirectToAction("Index", "Login");
                }
                using (JsonDocument document = JsonDocument.Parse(strData))
                {
                    JsonElement root = document.RootElement;
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    if (root.GetProperty("cus").ValueKind == JsonValueKind.Object)
                    {
                        // Lấy đối tượng "product" từ JSON "cus"
                        Customer product = JsonSerializer.Deserialize<Customer>(root.GetProperty("cus").ToString(), options);
                        HttpContext.Session.SetString("CustomerName", product.CustomerName);
                        HttpContext.Session.SetString("Email", product.Email);
                    }
                    else if (root.GetProperty("admin").ValueKind == JsonValueKind.Object)
                    {
                        // Lấy đối tượng "product" từ JSON "admin"
                        Customer product = JsonSerializer.Deserialize<Customer>(root.GetProperty("admin").ToString(), options);
                        HttpContext.Session.SetString("CustomerName", product.CustomerName);
                        HttpContext.Session.SetString("Email", product.Email);
                    }


                    return RedirectToAction("Index", "Customer");
                }
            }
            else
            {
                // Xử lý các lỗi từ ModelState.Error
                var errorMessages = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
                foreach (var errorMessage in errorMessages)
                {
                    // Thực hiện xử lý với từng errorMessage, ví dụ: đưa vào ViewBag để hiển thị trong view
                    ViewBag.ErrorMessage = errorMessage;
                 
                }
            }

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Register()  ///  http://localhost:44092/Customer/Index
        {

            return View();


        }






        public async Task<IActionResult> Create(Customer p)
        {
            if (ModelState.IsValid)
            {
                string strData = JsonSerializer.Serialize(p);
                var contentData = new StringContent(strData, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync($"{productApiUrl}/Register", contentData);

                if (response.IsSuccessStatusCode)
                {
                    ViewBag.Message = "Insert successfully!";
                }
                else
                {
                    ViewBag.Message = "Email already exists";
                    return View("Register"); // Truyền lại đối tượng Customer p cho Razor View Register.cshtml
                }
            }
            return RedirectToAction(nameof(Index));
        }


    }
}
