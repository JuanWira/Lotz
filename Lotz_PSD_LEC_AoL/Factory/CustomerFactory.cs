using Lotz_PSD_LEC_AoL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lotz_PSD_LEC_AoL.Factory
{
    public class CustomerFactory
    {
        public static Customer CreateCustomer(String name, String email, String password, String gender, String address, String number, String role)
        {
            Customer c = new Customer();
            c.CustomerName = name;
            c.CustomerEmail = email;
            c.CustomerPassword = password;
            c.CustomerGender = gender;
            c.CustomerAddress = address;
            c.CustomerNumber = number;
            c.role = role;
            return c;
        }
    }
}