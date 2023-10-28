using System;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Xml.Linq;
using YumYumExpress.Controller;

namespace YumYumExpress.View
{
    public static class MainProgram
    {
        static void Main()
        {
            Console.WriteLine("******************Yum Yum Express******************");
            Console.WriteLine("Welcome to Yum Yum Express.");
            Console.WriteLine("Enter 1 to Login and 2 to SignUp.");

        start1:
            Console.WriteLine("1. Login\n2. Signup\n3. Exit Application.");
            Console.WriteLine("----------------------------------------------------");
            int input = Convert.ToInt32(Console.ReadLine());

            switch (input)
            {
                case 1:
                    var user = new User();
                    user.ManageLogin();
                    break;

                case 2:
                    var a = new AuthManager();
                    a.ManageRegister();
                    break;

                case 3:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Enter a Valid Input.");
                    goto start1;
            }


        }

       
    }
}
