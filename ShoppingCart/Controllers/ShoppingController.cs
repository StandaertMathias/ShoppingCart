using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
    }
}