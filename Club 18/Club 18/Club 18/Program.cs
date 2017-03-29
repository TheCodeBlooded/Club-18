using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Club_18
{
    class Program
    {

        protected static List<Location> locations = new List<Location>();

        static void Main(string[] args)
        {

            initialise();

            Console.WriteLine("==== Program Initialised ====");

            foreach (Location location in locations)
            {
                Console.WriteLine("Location: " + location.getName());

                Console.WriteLine("     Price: " + location.getPrice());
            }

            int age = -1;

            while (age == -1)
            {
                Console.WriteLine("Please enter your age: ");

                try
                {
                    age = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("You have entered an invalid number.");

                    continue;
                }

                if (!(checkAge(age)))
                {
                    Console.WriteLine("You're not the right age to book a holiday.");

                    age = -1;

                    continue;
                }
            }

            while (true)
            {
                Console.WriteLine("Please enter the location you would like to visit: ");

                Location location = null;

                try
                {
                    location = getLocation(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("You have entered an invalid location.");

                    continue;
                }

                if (location == null)
                {
                    Console.WriteLine("You have entered an invalid location.");

                    continue;
                }

                while (true)
                {
                    int personCount = -1;

                    Console.WriteLine("Please enter the number of guests that will be attending: ");

                    try
                    {
                        personCount = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("You have entered an invalid number.");

                        continue;
                    }

                    if (personCount <= 0)
                    {
                        Console.WriteLine("You have entered an invalid number.");

                        continue;
                    }

                    Console.WriteLine("The holiday is £" + location.getPrice() + " per person.");

                    Console.WriteLine("The total cost for " + personCount + " guests is £" + (location.getPrice() * personCount));

                    Console.WriteLine("With applied discount the total price is £" + getDiscountedPrice(personCount, (location.getPrice() * personCount)));

                    break;
                }
                break;
            }
            Console.ReadLine();
        }

        protected static void initialise()
        {
            foreach (string line in File.ReadLines(@"C:\Users\P110109979\Locations.txt", Encoding.UTF8))
            {
                string[] args = line.Split('-');

                Location location = new Location(args[0], int.Parse(args[1]));

                locations.Add(location);

                Console.WriteLine("Successfully loaded new location. Name: " + location.getName() + " - Price: " + location.getPrice());
            }
        }

        protected static Location getLocation(string name)
        {
            foreach (Location location in locations)
            {
                if (location.getName().ToLower() == name.ToLower())
                    return location;
            }
            return null;
        }

        protected static double getDiscountedPrice(int personCount, int price)
        {
            if (personCount >= 5 && personCount <= 10)
                return price * 0.95;
            else if (personCount >= 11 && personCount <= 20)
                return price * 0.9;
            else if (personCount >= 21)
                return price * 0.85;
            return price;
        }

        protected static Boolean checkAge(int age)
        {
            if (age >= 18 && age <= 30)
                return true;
            return false;
        }
    }

    class Location
    {

        private string name;

        private int price;

        public Location(string name, int price)
        {
            this.name = name;

            this.price = price;
        }

        public string getName()
        {
            return this.name;
        }

        public int getPrice()
        {
            return this.price;
        }
    }
}
