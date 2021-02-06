
using MCS_oneday_intern.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
namespace MCS_oneday_intern.Controllers
{
    public class ProductDetailController : Controller
    {
        
        public ActionResult Index(int ProductNumber)
        {
            var path = "JsonData/fake_DB.json";
            //var Products = new List<Product>();
            using (StreamReader sr = new StreamReader(path))
            {
                var Products = JsonConvert.DeserializeObject<List<Product>>(sr.ReadToEnd());
                ViewBag.Product = Products[ProductNumber];
            }
            return View();
        }
    }
}
