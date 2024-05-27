﻿using Microsoft.AspNetCore.Mvc;
using Joshua_POE_CLDV.Models;


namespace Joshua_POE_CLDV.Controllers
{
        public class ProductController : Controller
        {
            public productTable prodtbl = new productTable();



            [HttpPost]
            public ActionResult MyWork(productTable products)
            {
                var result2 = prodtbl.insert_product(products);
                return RedirectToAction("Index", "Home");
            }

            [HttpGet]
            public ActionResult MyWork()
            {
                return View(prodtbl);
            }
        }
    

}
