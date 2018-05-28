using Microsoft.EntityFrameworkCore;
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
            return db.Cart.Select(c => c).OrderBy(c => c.Naam).ToList();
        }

        public void AddItem(Cart item)
        {
            db.Database.ExecuteSqlCommand($"Insert Into Cart (Naam, Aantal) " +
                                $"Values ('{item.Naam}', '{item.Aantal}')");
            db.SaveChanges();
        }

        public Cart GetItem(string naam)
        {
            return db.Cart.SingleOrDefault(c => c.Naam.Equals(naam));
        }
        public void DeleteItem(string naam)
        {
            db.Database.ExecuteSqlCommand($"delete from Cart where naam={naam}");
            db.SaveChanges();
        }
        public void EditItem(Cart item)
        {
            DeleteItem(item.Naam);
            AddItem(item);
        }

        public List<Cart> FindItems(string item, int? aantal)
        {
            string sql = $"Select * from Cart " +
                 $"where Naam like '{item ?? "%"}%' " +
                 $"and Aantal <= {aantal ?? byte.MaxValue}";
            return db.Cart.FromSql(sql).ToList();
        }
    }
}
