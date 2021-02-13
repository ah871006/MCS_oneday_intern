
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
        
        public ActionResult Index(int ProductNumber = 0)
        {
            var inventoryPath = "JsonData/inventory.json";
            using (StreamReader sr = new StreamReader(inventoryPath))
            {
                var Products = JsonConvert.DeserializeObject<List<Product>>(sr.ReadToEnd());
                ViewBag.Product = Products[ProductNumber];
            }

            var reviewPath = "JsonData/review.json";
            using (StreamReader sr = new StreamReader(reviewPath))
            {
                ViewBag.Reviews = JsonConvert.DeserializeObject<List<Review>>(sr.ReadToEnd());
            }
            return View();
        }
        
        public ActionResult Buy(int ProductNumber, int quantity)
        {
            var path = "JsonData/inventory.json";
            //var Products = new List<Product>();
            var json = string.Empty;
            using (StreamReader sr = new StreamReader(path))
            {
                var products = JsonConvert.DeserializeObject<List<Product>>(sr.ReadToEnd());
                var product = products[ProductNumber];
                product.Inventory -= quantity;
                json = JsonConvert.SerializeObject(products.ToArray(),Formatting.Indented);
            }
            System.IO.File.WriteAllText(path, json);
            return Ok(new{ message="ok", deductionQuantity=quantity});
        }

        public ActionResult SubmitReview(Review reviewModel)
        {
            var path = "JsonData/review.json";
            var json = string.Empty;
            using (StreamReader sr = new StreamReader(path))
            {
                var reviews = JsonConvert.DeserializeObject<List<Review>>(sr.ReadToEnd());
                reviewModel.ReviewId = reviews.Count;
                reviewModel.ReviewTime = DateTime.Now;
                reviews.Add(reviewModel);
                json = JsonConvert.SerializeObject(reviews.ToArray(),Formatting.Indented);
            }
            System.IO.File.WriteAllText(path, json);
            return Ok(new{ message="ok"});
        }
    }
}
