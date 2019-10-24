using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CookieDemo.Models;

namespace CookieDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GiveCookie()
        {
            Response.Cookies.Append("user", "peter");
            Response.Cookies.Append("balance", "42.00");
            return View();
        }

        public IActionResult GetCookie()
        {
            string user = Request.Cookies["user"];
            string balance = Request.Cookies["balance"];
            //these values could be null
            //try, parse, be good devs

            if (user == null)
            {
                return RedirectToAction("GiveCookie");
            }
            else
            {
                ViewData["user"] = user;
                ViewData["balance"] = balance;

                return View();
            }
        }

        public IActionResult ClearCookie()
        {
            Response.Cookies.Delete("user");
            Response.Cookies.Delete("balance");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
