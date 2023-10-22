using Lotz_PSD_LEC_AoL.Handler;
using Lotz_PSD_LEC_AoL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lotz_PSD_LEC_AoL.Controller
{
    public class TransactionController
    {
        public static List<TransactionHeader> GetTransactionByCustomer(int customerId)
        {
            return TransactionHandler.GetTransactionByCustomer(customerId);
        }

        public static TransactionHeader CreateTransactionHeader(Customer cust, Payment payment, Cloth c, int qty, int price)
        {
            return TransactionHandler.CreateTransactionHeader(cust, payment, c, qty, price);
        }
    }
}