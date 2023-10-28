using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using YumYumExpress.Database;
using YumYumExpress.View;

namespace YumYumExpress.Controller
{
    public class AuthManager
    {
        DatabaseLayer d = new DatabaseLayer();
        //public bool LoginValidateAdmin(string userid, string password)
        //{
        //    return d.ValidateAdmin(userid, password);

        //}
        //public bool LoginValidateRestaurant(string userid, string password)
        //{
        //    // Restaurant Validation.
        //    return d.ValidateRestaurant(userid, password);
        //}

        //public bool LoginValidateCustomer(string userid, string password)
        //{
        //    //Customer Validation
        //    return d.ValidateCustomer(userid, password);
        //}

        


        //public static void RegisterCustomer(string name, long contactno, string email, string address, string pw)
        //{
        //    DatabaseLayer d = new DatabaseLayer();
        //    CustomerUI customerUI = new CustomerUI()
        //    {
        //        Name = name, Address = address,
        //        ContactNo = contactno, Email = email,
        //        Password = pw, userType = UserType.Customer
        //    };
        //    d.StoreCustomer(customerUI);
        //}
        
        public Object CheckLogin(string email, string password)
        {
            var Customer =  d.CheckCustomer(email, password);
            if (Customer != null)
            {
                return Customer;
            }

            var Restaurant = d.CheckRestaurant(email, password);
            if (Restaurant != null)
            {
                return Restaurant;
            }

            var Admin = d.CheckAdmin(email, password);
            if (Admin != null)
            {
                return Admin;
            }

            return null;

        }
        public void ManageRegister()
        {
            Console.WriteLine("Hello New User. Welcome to Yum Yum Express.");
            Console.WriteLine("Please Enter the details to register.");

            Console.WriteLine("Name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Contact Number: ");
            long contactNo = Convert.ToInt64(Console.ReadLine());

            Console.WriteLine("Enter Email Address: ");
            string email = Console.ReadLine();

            Console.WriteLine("Password: ");
            string password = Console.ReadLine();

            Console.WriteLine("Address: ");
            string address = Console.ReadLine();


            CustomerController customerController = new CustomerController()
            {
                Name = name,
                ContactNo = contactNo,
                Email = email,
                Address = address,
                Password = password,
                CustomerId = DatabaseLayer.generateId()
            };

            CustomerController customer = new CustomerController();
            customer.StoreCustomer(customerController);
            Console.WriteLine("Registration Successful.");
        }
    }
}
