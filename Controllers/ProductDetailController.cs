
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
        /// <summary>
        /// 產品頁
        /// </summary>
        /// <param name="ProductNumber">產品id</param>
        /// <returns>產品頁cshtml</returns>
        public ActionResult Index(int ProductNumber = 0)
        {
            // 使用streamReader 讀取存貨json檔
            var inventoryPath = "JsonData/inventory.json";

            // using語句，定義一個範圍，在範圍結束時處理物件
            using (StreamReader sr = new StreamReader(inventoryPath))
            {
                // streamReader將json檔讀成string,再將字串轉成json格式
                var Products = JsonConvert.DeserializeObject<List<Product>>(sr.ReadToEnd());

                // 將結果放至ViewBag, 就可以在View中使用此物件
                ViewBag.Product = Products[ProductNumber];
            }

            // 使用streamReader 讀取評價json檔
            var reviewPath = "JsonData/review.json";
            using (StreamReader sr = new StreamReader(reviewPath))
            {
                ViewBag.Reviews = JsonConvert.DeserializeObject<List<Review>>(sr.ReadToEnd());
            }

            // 回傳View物件(ProductDetail/index.cshtml)
            return View();
        }
        

        /// <summary>
        /// 購買產品action
        /// </summary>
        /// <param name="ProductNumber">產品id</param>
        /// <param name="quantity">購買數量</param>
        /// <returns>回傳ok 及 扣除數量</returns>
        public ActionResult Buy(int ProductNumber, int quantity)
        {
            // 使用streamReader 讀取存貨json檔
            var path = "JsonData/inventory.json";
            var json = string.Empty;

            // using語句，定義一個範圍，在範圍結束時處理物件
            using (StreamReader sr = new StreamReader(path))
            {
                // streamReader將json檔讀成string,再將字串轉成json格式
                var products = JsonConvert.DeserializeObject<List<Product>>(sr.ReadToEnd());
                var product = products[ProductNumber];

                // 存貨數量扣除購買數量
                product.Inventory -= quantity;

                // 將改寫結果轉換成formatted的json string
                json = JsonConvert.SerializeObject(products.ToArray(),Formatting.Indented);
            }

            // 將改寫結果寫回json檔中
            System.IO.File.WriteAllText(path, json);
            return Ok(new{ message="ok", deductionQuantity=quantity});
        }

        /// <summary>
        /// 購買產品action
        /// </summary>
        /// <param name="reviewModel">評價Model</param>
        /// <returns>回傳ok</returns>
        public ActionResult SubmitReview(Review reviewModel)
        {
            // 使用streamReader 讀取評價json檔
            var path = "JsonData/review.json";
            var json = string.Empty;

            // using語句，定義一個範圍，在範圍結束時處理物件
            using (StreamReader sr = new StreamReader(path))
            {
                // streamReader將json檔讀成string,再將字串轉成json格式
                var reviews = JsonConvert.DeserializeObject<List<Review>>(sr.ReadToEnd());

                // 新增的評價Id就是目前的評價的數量
                reviewModel.ReviewId = reviews.Count;

                // 評價時間帶入現在時間
                reviewModel.ReviewTime = DateTime.Now;

                // 將評價加在原本的評價list後面
                reviews.Add(reviewModel);

                // 將改寫結果轉換成formatted的json string
                json = JsonConvert.SerializeObject(reviews.ToArray(),Formatting.Indented);
            }

            // 將改寫結果寫回json檔中
            System.IO.File.WriteAllText(path, json);
            return Ok(new{ message="ok"});
        }
    }
}
