using FirstAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace  FirstAPI.Repo
{
    interface ICart
    {
        public void AddItemtoCart(Cart c);
        public void CancelItem(int id);

        public List<Cart> getCarts();
        public Cart getCartItemById(int id);

    }
}