using ShoppingCart.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Repositories
{
    public class ShoppingCartRepository
    {
        private ShoppingCartContext db;
        public ShoppingCartRepository(ShoppingCartContext context)
        {
            db = context;
        }

        public List<Cart> GetAllItems()
        {
            return db.Cart.Select(c => c).ToList();
        }

        //method for add an item
    }
}
