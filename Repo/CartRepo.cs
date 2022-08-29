using FirstAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAPI.Repo
{
    public class CartRepo : ICart
    {
        Cart c = new Cart();

        public void AddItemtoCart(Cart c)
        {
            c.AddItem(c);
        }

        public void CancelItem(int id)
        {
            c.DeleteItem(id);
        }

        public Cart getCartItemById(int id)
        {
            return c.GetCartById(id);
        }

        public List<Cart> getCarts()
        {
            return c.getCartItems();
        }
    }
}
