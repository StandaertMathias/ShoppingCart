using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Entities;
using ShoppingCart.Repositories;

namespace ShoppingCart.Controllers
{
    [Route("Shopping")]
    public class ShoppingController : Controller
    {
        private ShoppingCartRepository CartRepo;

        public ShoppingController(ShoppingCartRepository cartRepo)
        {
            CartRepo = cartRepo;
        }

        [Route("")]
        public IActionResult Index()
        {
            return View(CartRepo.GetAllItems());
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(Cart item)
        {
            CartRepo.AddItem(item);
            return RedirectToAction("index");
        }

        [HttpGet]
        [Route("Edit")]
        public IActionResult Edit(string naam)
        {
            Cart item = CartRepo.GetItem(naam);
            return View(item);
        }
        [HttpPost]
        [Route("Edit")]
        public IActionResult Edit(Cart item)
        {
            CartRepo.EditItem(item);
            return RedirectToAction("index");
        }
        [Route("Delete")]
        public IActionResult Delete(string naam)
        {
            CartRepo.DeleteItem(naam);
            return RedirectToAction("index");
        }
        //[Route("Find")]
        //public IActionResult Find(string item, int? aantal)
        //{
        //    List<Cart> found = CartRepo.FindItems(item, aantal);
        //    return View("Index",found);
        //}
    }
}