using Joshua_POE_CLDV.Models;
using Microsoft.AspNetCore.Mvc;

namespace Joshua_POE_CLDV.Controllers
{
    public class userController : Controller
    {
        // Create an instance of the Table_1 model to interact with the database
        public Table_1 tbl1 = new Table_1();

        // This action method handles the POST request when the user submits the About form
        [HttpPost]
        public ActionResult About(Table_1 Users)
        {
            // Call the InsertUser method of the Table_1 model to insert user data into the database
            var result = tbl1.InsertUser(Users);

            // Check if the insertion was successful
            if (result > 0)
            {
                // Insertion successful, redirect to home page or any other page
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Insertion failed, handle error
                
                return RedirectToAction("Error", "Home");
            }
        }

        // This action method handles the GET request when the user navigates to the About page
        [HttpGet]
        public ActionResult About()
        {
            // Return the About view to display the About page
            // You can return the About view with any necessary data
            return View("~/Views/Users/About.cshtml");
        }
    }
}
