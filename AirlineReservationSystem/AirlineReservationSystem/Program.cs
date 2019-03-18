namespace AirlineReservationSystem
{
    using System;
    using System.Collections.Generic;
    using DataAccess;
    using DataAccess.Models;
    using AirlineReservationSystem;

    class Program
    {
        static void Main(string[] args)
        { 
            
            

            DataAccess da = new DataAccess();
            List<UserDO> l = new List<UserDO>();

            l = da.GetUsers();

            foreach (var _user in l)
            {
                Console.WriteLine("UserID: {0}", _user.UserID.ToString());
                Console.WriteLine("Firstname:{0}", _user.FirstName);
                Console.WriteLine("Lastname: {0}", _user.LastName);

            }
            Console.ReadLine();
            //requests username and password
            //Console.WriteLine("Enter username");
            //string username = Console.ReadLine();
            //Console.WriteLine("Enter password");
            //string password = Console.ReadLine();




            
            //{

            //    if (username == "user1" && password == "josh.adams")
            //    {
            //        Console.WriteLine("Access Granted");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Access Denied"); 
            //    }
            //}
            

            ////check to see if they are admin or guest or need to create an account
            ////won't be able to do this until sql 
            //Console.WriteLine("Welcome {0} to Airline Reservation system",username);

            //Console.WriteLine("To look at flights press 'L'");
            //Console.WriteLine("To book a flight press 'b'");
            //Console.WriteLine("To view your reservations press 'r'");
            //Console.WriteLine("To exit press 'x'");
            //Console.ReadLine();



        }
    }
}
