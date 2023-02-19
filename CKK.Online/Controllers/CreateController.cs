using CKK.DB.Interfaces;
using CKK.Logic.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CKK.Online.Controllers
{
    public class CreateController : Controller
    {
        private readonly IUnitOfWork UOW;
        public CreateController(IUnitOfWork connection)
        {
            UOW = connection;
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product prod)
        {
            if(prod != null)
            {
            UOW.Products.AddAsync(prod);
            }
            return RedirectToAction("Index", "Shop");
        }
    }
}
