using Lotz_PSD_LEC_AoL.Factory;
using Lotz_PSD_LEC_AoL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lotz_PSD_LEC_AoL.Repository
{
    public class CustomerRepository
    {
        private static LotzDatabaseEntities db = DatabaseSingleton.GetInstance();
        public static void CreateCustomer(String name, String email, String gender, String address, String password, String number, String role)
        {
            Customer c = CustomerFactory.CreateCustomer(name, email, password, gender, address, number, role);
            db.Customers.Add(c);
            db.SaveChanges();
        }

        public static Customer Login(String email, String password)
        {
            return (from c in db.Customers where c.CustomerEmail == email && c.CustomerPassword == password select c).FirstOrDefault();
        }

        public static Customer GetCustomerById(int id)
        {
            return (from c in db.Customers where c.CustomerID == id select c).FirstOrDefault();
        }

        public static bool UpdateCustomer(int id, String name, String email, String gender, String address, String password, String number)
        {
            Customer c = GetCustomerById(id);
            if (c != null)
            {
                c.CustomerName = name;
                c.CustomerEmail = email;
                c.CustomerGender = gender;
                c.CustomerAddress = address;
                c.CustomerPassword = password;
                c.CustomerNumber = number;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public static bool CheckEmailUnique(String email)
        {
            Customer cust = (from c in db.Customers where c.CustomerEmail == email select c).FirstOrDefault();
            if (cust == null)
            {
                return true;
            }
            else return false;
        }
    }
}