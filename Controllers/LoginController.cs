using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MCS_oneday_intern.Controllers
{
    public class LoginController : Controller
    {
        // GET: LoginController
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// login
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost]
        public  IActionResult LoginAccount(string accountName, string password)
        {
            if (password.Equals("test"))
            {
                return Ok(new { a = "a", b = "b" });
            }
            else
            {
                return BadRequest();
            }
        }


    }
}
