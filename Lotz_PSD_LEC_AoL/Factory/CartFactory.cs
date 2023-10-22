using Lotz_PSD_LEC_AoL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lotz_PSD_LEC_AoL.Factory
{
    public class CartFactory
    {
        public static Cart CreateCart(Customer customer, Cloth cloth, int qty, int price)
        {
            Cart cart = new Cart();
            cart.Customer = customer;
            cart.Cloth = cloth;
            cart.Qty = qty;
            cart.Price = price;
            return cart;
        }
    }
}