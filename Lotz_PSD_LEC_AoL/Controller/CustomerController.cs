using Lotz_PSD_LEC_AoL.Handler;
using Lotz_PSD_LEC_AoL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Lotz_PSD_LEC_AoL.Controller
{
    public class CustomerController
    {
        public static String validateLoginCustomer(String email, String password)
        {

            String response = "";
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                response = "Email and password must be filled";
            }
            else
            {
                Customer cust = doLogin(email, password);
                if (cust == null)
                {
                    response = "Email or password does not exist";
                }

            }
            return response;
        }

        public static Customer doLogin(String email, String password)
        {
            return CustomerHandler.Login(email, password);
        }

        public static String validateRegisterCustomer(String name, String email, String gender, String address, String password, String number, String role)
        {
            String response = "";
            // validasi name, email, gender, address, password lalu return error msg
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(address) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(gender))
            {
                response = "All field must be filled";
            }
            else if (name.Length < 5 || name.Length > 50)
            {
                response = "Name length must be between 5 and 50 characters";
            }
            else if (CustomerHandler.CheckEmailUnique(email) == false)
            {
                response = "Email must be unique, this email is already registered";
            }
            else if (!address.EndsWith("Street"))
            {
                response = "Address must ends with Street";
            }
            else if (Regex.IsMatch(password, "^[a-zA-Z0-9]*$") == false)
            {
                response = "Password must be alphanumeric";
            }
            else if(number.Length < 8 || number.Length > 15)
            {
                response = "Phone number must be between 8-15 numbers";
            }
            else if (!number.ToString().StartsWith("0"))
            {
                response = "Phone number must starts with 0";
            }
            else
            {
                doRegister(name, email, gender, address, password, number, role);
            }

            return response;
        }
        public static void doRegister(String name, String email, String gender, String address, String password, String number, String role)
        {
            CustomerHandler.CreateCustomer(name, email, gender, address, password, number, role);
        }

        public static String doUpdateProfile(int id, String name, String email, String gender, String address, String password, String number, String role)
        {
            String response = "";
            // validasi name, email, gender, address, password lalu return error msg
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(address) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(gender))
            {
                response = "All field must be filled";
            }
            else if (name.Length < 5 || name.Length > 50)
            {
                response = "Name length must be between 5 and 50 characters";
            }
            else if (CustomerHandler.CheckEmailUnique(email) == false)
            {
                response = "Email must be unique, this email is already registered";
            }
            else if (!address.EndsWith("Street"))
            {
                response = "Address must ends with Street";
            }
            else if (Regex.IsMatch(password, "^[a-zA-Z0-9]*$") == false)
            {
                response = "Password must be alphanumeric";
            }
            else if (number.Length < 8 || number.Length > 15)
            {
                response = "Phone number must be between 8-15 numbers";
            }
            else
            {
                Customer cust = CustomerHandler.GetCustomerById(id);
                CustomerHandler.UpdateCustomer(cust.CustomerID, name, email, gender, address, password, number);
            }

            return response;

        }

        public static Customer GetCustomerById(int id)
        {
            return CustomerHandler.GetCustomerById(id);
        }
    }
}