using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuotingDojo.Models;
using DbConnection;

namespace QuotingDojo.Controllers
{
    public class HomeController : Controller
    {
        // INDEX ROUTE
        [HttpGet("")] // <-- do this for all your routes below
        public IActionResult Index()
        {
            return View();
        }

        // PROCESS NEW QUOTE ROUTE
        [HttpPost("quotes")]
        public RedirectToActionResult CreateQuote()
        {
            Console.WriteLine("\n\n\nPOSTING\n\n\n");
            return RedirectToAction("Quotes");
        }

        // SHOW ALL QUOTES ROUTE
        [HttpGet("quotes")]
        public IActionResult Quotes()
        {
            List<Dictionary<string, object>> Quotes = DbConnector.Query("SELECT * FROM quotes;");
            ViewBag.quotes = Quotes;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
