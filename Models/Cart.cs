using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAPI.Models
{
    public class Cart
    {
        public int Cid { get; set; }
        public string Desc { get; set; }
        public DateTime OrdDate { get; set; }
        public float Amount { get; set; }

        List<Cart> carts = new List<Cart>();
        public Cart()
        {

        }

        public Cart(int cid, string desc, DateTime orddate, float amt)
        {
            Cid = cid;
            Desc = desc;
            OrdDate = orddate;
            Amount = amt;
        }

        public List<Cart> getCartItems()
        {
            carts.Add(new Cart(10001, "Bought Pencil", DateTime.Now, 340));
            carts.Add(new Cart(10002, "Bought Erasor", DateTime.Now, 980));
            carts.Add(new Cart(10003, "Bought Pen", DateTime.Now, 870));
            carts.Add(new Cart(10004, "Bought Fruits", DateTime.Now, 370));
            carts.Add(new Cart(10005, "Bought Ginger", DateTime.Now, 500));
            carts.Add(new Cart(10006, "Bought Pencil", DateTime.Now, 340));
            return carts;
        }

        public void AddItem(Cart c)
        {
            carts.Add(c);

        }

        public void DeleteItem(int id)
        {
            Cart P = GetCartById(id);
            carts.Remove(P);
        }

        public Cart GetCartById(int id)
        {
            Cart c = carts.Where(p => p.Cid == id).FirstOrDefault();
            return c;
        }

    }

}
