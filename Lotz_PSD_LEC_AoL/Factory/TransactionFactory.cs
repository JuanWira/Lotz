using Lotz_PSD_LEC_AoL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lotz_PSD_LEC_AoL.Factory
{
    public class TransactionFactory
    {
        public static TransactionHeader CreateTransactionHeader(Customer cust, Payment payment, Cloth cloth, int qty, int price)
        {
            TransactionHeader th = new TransactionHeader();
            th.TransactionDate = DateTime.Today;
            th.CustomerID = cust.CustomerID;
            th.PaymentID = payment.PaymentId;
            th.ClothID = cloth.ClothID;
            th.Qty = qty;
            th.Price = price;
            return th;
        }
    }
}