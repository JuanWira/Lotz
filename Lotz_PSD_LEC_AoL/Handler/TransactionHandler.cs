using Lotz_PSD_LEC_AoL.Model;
using Lotz_PSD_LEC_AoL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lotz_PSD_LEC_AoL.Handler
{
    public class TransactionHandler
    {
        public static List<TransactionHeader> GetTransactionByCustomer(int customerId)
        {
            return TransactionRepository.GetTransactionByCustomer(customerId);
        }

        public static List<TransactionHeader> GetAllTransaction()
        {
            return TransactionRepository.GetAllTransaction();
        }

        public static TransactionHeader CreateTransactionHeader(Customer cust, Payment payment, Cloth c, int qty, int price)
        {
            return TransactionRepository.CreateTransactionHeader(cust, payment, c, qty, price);
        }
    }
}