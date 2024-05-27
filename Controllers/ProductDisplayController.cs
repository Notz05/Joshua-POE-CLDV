using Joshua_POE_CLDV.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Joshua_POE_CLDV.Controllers
{
    
        public class ProductDisplayController : Controller
        {
            [HttpGet]
            public IActionResult Index()
            {
                var products = ProductDisplayModel.SelectProducts();
                return View(products);
            }
        }
    

}

