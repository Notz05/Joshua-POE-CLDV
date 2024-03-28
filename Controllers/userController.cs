using Joshua_POE_CLDV.Models;
using Microsoft.AspNetCore.Mvc;

namespace Joshua_POE_CLDV.Controllers
{
    public class userController : Controller
    {
       public Table_1 tbl1 = new Table_1();
        [HttpPost]
        public ActionResult About(Table_1 Users)
        {
            var result = tbl1.InsertUser(Users);
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public ActionResult About() {
            return View("~/Views/Users/About.cshtml", tbl1); 
        
        
        }
    }
}
