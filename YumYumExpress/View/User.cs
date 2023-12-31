﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YumYumExpress.Controller;

namespace YumYumExpress.View
{
    
    public enum UserType
    {
        Customer = 1,
        Restaurant = 2,
        Admin = 3
    }
    public class User
    {
        AuthManager a = new AuthManager();
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public long ContactNo { get; set; }

        public UserType userType { get; set; }

        public void ManageLogin()
        {
        stepLogin:
            Console.WriteLine("Enter Email: ");
            string email = Console.ReadLine();

            Console.WriteLine("Enter Password: ");
            string password = Console.ReadLine();

            //CustomerUI cust = new CustomerUI();
            var entity = a.CheckLogin(email, password);

            if (entity is CustomerController)
            {
                CustomerController customerUI = (CustomerController)entity;
                Console.WriteLine("Logged in as Customer.");
                var customerUI2 = new CustomerUI();
                customerUI2.Functions(email, password);
            }

            else if (entity is RestaurantController)
            {
                RestaurantController restaurant = (RestaurantController)entity;

                Console.WriteLine("Logged in as Restaurant.");
                Restaurant.Functions(email, password);
            }

            else if (entity is AdminController)
            {
                AdminController adminUI = (AdminController)entity;
                //
                Console.WriteLine("Logged in as Admin Successful");
                Admin.Functions(password);
            }

            else
            {
                Console.WriteLine("Enter a valid Email or Password.");
                goto stepLogin;
            }
        }

    }
}
