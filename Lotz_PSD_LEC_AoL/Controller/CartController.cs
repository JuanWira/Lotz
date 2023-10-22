using Lotz_PSD_LEC_AoL.Handler;
using Lotz_PSD_LEC_AoL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lotz_PSD_LEC_AoL.Controller
{
    public class CartController
    {
        public static String validateCart(int qty, int clothStock)
        {
            String response = "";
            // validate qty
            if (qty == -1)
            {
                response = "Quantity must be filled";
            }
            else if (qty > clothStock)
            {
                response = "Quantity cant be more than the cloth stock";
            }
            return response;
        }

        public static void AddItemToCart(Customer cust, Cloth c, int qty)
        {
            int price = ClothHandler.GetPriceById(c.ClothID);
            CartHandler.CreateCart(cust, c, qty, price);
        }

        public static bool CheckOut(int customerId, Payment payment, Cloth c, int qty, int price)
        {
            return CartHandler.CheckOut(customerId, payment, c, qty, price);
        }

        public static Cart GetCartByID(int cartID)
        {
            return CartHandler.GetCartByID(cartID);
        }

        public static bool DeleteCartByID(int cartID)
        {
            return CartHandler.DeleteCartByID(cartID);
        }

        public static bool DeleteCartByClothID(int clothID)
        {
            return CartHandler.DeleteCartByClothID(clothID);
        }

        public static List<Cart> GetAllCartByCustomerId(int customerId)
        {
            return CartHandler.GetAllCartByCustomerId(customerId);
        }

        // remove individual data in cart
        public static bool RemoveOneCart(int customerId, int clothId)
        {
            return CartHandler.RemoveOneCart(customerId, clothId);
        }

        public static List<Cart> GetAllCart()
        {
            return CartHandler.GetAllCart();
        }

        // find cart by customer id and cloth id
        public static Cart GetCartByCustomerAndCloth(int customerId, int clothId)
        {
            return CartHandler.GetCartByCustomerAndCloth(customerId, clothId);
        }
    }
}