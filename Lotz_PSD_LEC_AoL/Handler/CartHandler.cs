using Lotz_PSD_LEC_AoL.Model;
using Lotz_PSD_LEC_AoL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lotz_PSD_LEC_AoL.Handler
{
    public class CartHandler
    {
        public static bool CheckOut(int customerId, Payment payment, Cloth cloth, int qty, int price)
        {
            Customer customer = CustomerHandler.GetCustomerById(customerId);
            // hapus semua cart customer ini
            List<Cart> cart = CartRepository.GetAllCartByCustomerIdPure(customerId);

            TransactionHeader thLast = TransactionRepository.CreateTransactionHeader(customer, payment, cloth, qty, price);
            // TransactionHeader thLast = TransactionRepository.GetLatestTransactionByCustomer(customerId);

            if (thLast != null && cart.Count > 0)
            {
                foreach (Cart c in cart)
                {
                    ClothRepository.UpdateClothStock(c.ClothID, c.Qty);
                }

                // delete all cart from this customer
                CartRepository.RemoveAllCartByCustomer(cart);
                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool DeleteCartByID(int cartID)
        {
            return CartRepository.DeleteCartByID(cartID);
        }
        public static List<Cart> GetAllCartByCustomerId(int customerId)
        {
            return CartRepository.GetAllCartByCustomerId(customerId);
        }

        public static Cart GetCartByID(int cartID)
        {
            return CartRepository.GetCartByID(cartID);
        }

        public static bool DeleteCartByClothID(int clothID)
        {
            return CartRepository.DeleteCartByClothID(clothID);
        }

        // add cart
        public static void CreateCart(Customer cust, Cloth c, int qty, int price)
        {
            // search by cust and c first
            Cart item = GetCartByCustomerAndCloth(cust.CustomerID, c.ClothID);
            // if exist, add the qty to the item
            if (item != null)
            {
                // update the cart qty
                CartRepository.UpdateCartQuantity(item, qty, price);
            }
            else
            {
                // if not exist, create new item to cart
                CartRepository.CreateCart(cust, c, qty, price);
            }

        }

        public static List<Cart> GetAllCart()
        {
            return CartRepository.GetAllCart();
        }

        // remove individual data in cart
        public static bool RemoveOneCart(int customerId, int clothId)
        {
            return CartRepository.RemoveOneCart(customerId, clothId);
        }

        // find cart by customer id and album id
        public static Cart GetCartByCustomerAndCloth(int customerId, int clothId)
        {
            return CartRepository.GetCartByCustomerAndCloth(customerId, clothId);
        }
    }
}