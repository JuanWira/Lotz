using Lotz_PSD_LEC_AoL.Factory;
using Lotz_PSD_LEC_AoL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lotz_PSD_LEC_AoL.Repository
{
    public class TransactionRepository
    {
        private static LotzDatabaseEntities db = DatabaseSingleton.GetInstance();


        // add data
        public static TransactionHeader CreateTransactionHeader(Customer cust, Payment payment, Cloth cloth, int qty, int price)
        {
            TransactionHeader th = TransactionFactory.CreateTransactionHeader(cust, payment, cloth, qty, price);
            db.TransactionHeaders.Add(th);
            db.SaveChanges();
            return th;
        }

        // show data by customer
        public static List<TransactionHeader> GetTransactionByCustomer(int customerId)
        {
            return (from t in db.TransactionHeaders where t.CustomerID == customerId orderby t.TransactionID descending select t).ToList();

        }

        public static List<TransactionHeader> GetAllTransaction()
        {
            return db.TransactionHeaders.ToList();
        }
    }
}