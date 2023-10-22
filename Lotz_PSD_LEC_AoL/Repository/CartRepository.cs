using Lotz_PSD_LEC_AoL.Factory;
using Lotz_PSD_LEC_AoL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lotz_PSD_LEC_AoL.Repository
{
    public class CartRepository
    {
        private static LotzDatabaseEntities db = DatabaseSingleton.GetInstance();

        // show cart
        public static List<Cart> GetAllCartByCustomerId(int customerId)
        {
            return (from ca in db.Carts
                          join al in db.Clothes on ca.ClothID equals al.ClothID
                          join cu in db.Customers on ca.CustomerID equals cu.CustomerID
                          where ca.CustomerID == customerId
                          orderby al.ClothID
                          select ca).ToList();
        }

        public static bool DeleteCartByID(int cartID)
        {
            Cart cart = GetCartByID(cartID);
            if (cart != null)
            {
                db.Carts.Remove(cart);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public static Cart GetCartByID(int cartID)
        {
            return (from ca in db.Carts where ca.CartID == cartID select ca).FirstOrDefault();
        }

        public static List<Cart> GetAllCartByCustomerIdPure(int customerId)
        {
            return (from ca in db.Carts
                    where ca.CustomerID == customerId
                    select ca).ToList();
        }

        public static List<Cart> GetAllCart()
        {
            return (from ca in db.Carts select ca).ToList();
        }

        // add cart
        public static void CreateCart(Customer cust, Cloth alb, int qty, int price)
        {
            Cart cart = CartFactory.CreateCart(cust, alb, qty, price*qty);
            db.Carts.Add(cart);
            db.SaveChanges();
        }

        // remove all cart by customer
        public static bool RemoveAllCartByCustomer(List<Cart> cartList)
        {
            if (cartList != null)
            {
                db.Carts.RemoveRange(cartList);
                db.SaveChanges();
                return true;
            }
            return false;

        }

        // remove individual data in cart
        public static bool RemoveOneCart(int customerId, int clothId)
        {
            Cart cart = GetCartByCustomerAndCloth(customerId, clothId);
            if (cart != null)
            {
                db.Carts.Remove(cart);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public static bool DeleteCartByClothID(int clothID)
        {
            List<Cart> cart = (from ca in db.Carts
                               join c in db.Clothes on ca.ClothID equals c.ClothID
                               where ca.ClothID == clothID
                               select ca).ToList();
            if (cart != null)
            {
                db.Carts.RemoveRange(cart);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        // find cart by customer id and cloth id
        public static Cart GetCartByCustomerAndCloth(int customerId, int clothId)
        {
            return (from ca in db.Carts where ca.ClothID == clothId && ca.CustomerID == customerId select ca).FirstOrDefault();
        }

        // update cart quantity
        public static bool UpdateCartQuantity(Cart item, int newQty, int price)
        {
            if (item != null)
            {
                item.Qty = newQty;
                item.Price = price;
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}