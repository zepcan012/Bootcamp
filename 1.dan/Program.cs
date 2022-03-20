using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Console.WriteLine("Which animal do you want to add?");
            var menu = new List<string>();
            menu.Add("1. Dog");
            menu.Add("2. Cat");

            foreach (var animal in menu)
            {
                Console.WriteLine(animal);
            }

            int choose= Convert.ToInt32(Console.ReadLine());
            switch (choose)
            {
                case 1:
                    Dog Option1 = new Dog();
                    Option1.DisplayMessage();
                    Console.WriteLine("Enter breed:");
                    Option1.breed = Console.ReadLine();
                    Console.WriteLine("Enter name:");
                    Option1.name = Console.ReadLine();
                    Console.WriteLine("Enter age:");
                    Option1.age = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Breed:" + " " + Option1.breed);
                    Console.WriteLine("Name:" + " " + Option1.name);
                    Console.WriteLine("Age:" + " " + Option1.age);

                    Option1.DisplayText();

                    break;

                case 2:
                    Cat Option2 = new Cat();
                    Option2.DisplayMessage();
                    Console.WriteLine("Enter color:");
                    Option2.color = Console.ReadLine();
                    Console.WriteLine("Enter name:");
                    Option2.name = Console.ReadLine();
                    Console.WriteLine("Enter age:");
                    Option2.age = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Color:" + " " + Option2.color);
                    Console.WriteLine("Name:" + " " + Option2.name);
                    Console.WriteLine("Age:" + " " + Option2.age);

                    Option2.DisplayText();

                    break;

                default:
                    Console.WriteLine("Invalid input");
                    break;


            }

            
        }
    }
}
