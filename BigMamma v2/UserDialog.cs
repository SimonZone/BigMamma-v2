using System;
using System.Collections.Generic;


namespace BigMamma_v2
{
    public static class UserDialog
    {
        
        static Pizza CreateP(MenuCatalog menuCatalog, Pizza pizza)
        {
            Pizza newPizza = new Pizza( "", 0, pizza.Toppings );

            Console.Clear();
            Console.WriteLine("----------------------");
            Console.WriteLine("  Creating new Pizza  ");
            Console.WriteLine("----------------------");
            Console.WriteLine();
            Console.WriteLine("Enter Pizza name: ");
            newPizza.Name = Console.ReadLine();
            Console.WriteLine("");
            string input = "";
            Console.WriteLine("Enter Pizza Price: ");
            try
            {
                input = Console.ReadLine();
                newPizza.Price = Convert.ToInt32(input);
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Unable to process '{input}' - {e.Message}");
                throw;
            }

            menuCatalog.CreatePizza(newPizza);
            return newPizza;
        }

        static int ReadP()
        {
            Console.Clear();
            Console.WriteLine("----------------------------");
            Console.WriteLine("       Finding Pizza        ");
            Console.WriteLine("----------------------------");
            Console.WriteLine();
            Console.WriteLine("Enter Pizza ID: ");
            string input = Console.ReadKey().KeyChar.ToString();
            Console.WriteLine("");
            try
            {
                int result = Int32.Parse(input);
                return result;
            }

            catch (FormatException)
            {
                Console.WriteLine($"\nUnable to parse '{input}'");
            }

            return 0;
        }

        static int UpdateP()
        {
            Console.Clear();
            Console.WriteLine("----------------------------");
            Console.WriteLine("       Updating Pizza       ");
            Console.WriteLine("----------------------------");
            Console.WriteLine();
            Console.WriteLine("What pizza ID do you want to update? Enter Pizza ID:");
            string input = Console.ReadKey().KeyChar.ToString();
            Console.WriteLine("");
            try
            {
                int result = Int32.Parse(input);
                return result;
            }

            catch (FormatException)
            {
                Console.WriteLine($"\nUnable to parse '{input}'");
            }

            return 0;
        }

        static int DeleteP()
        {
            Console.Clear();
            Console.WriteLine("----------------------------");
            Console.WriteLine("       Deleting Pizza       ");
            Console.WriteLine("----------------------------");
            Console.WriteLine();
            Console.WriteLine("Enter Pizza ID: ");
            string input = Console.ReadKey().KeyChar.ToString();
            Console.WriteLine("");

            try
            {
                int result = Int32.Parse(input);
                return result;
            }

            catch (FormatException)
            {
                Console.WriteLine($"\nUnable to parse '{input}'");
            }

            return 0;
        }

        static int MainMenuChoice(List<string> menuItems)
        {
            Console.Clear();
            Console.WriteLine("-------------------");
            Console.WriteLine("  Big Mamma Menu   ");
            Console.WriteLine("-------------------");
            Console.WriteLine();
            Console.WriteLine("Options: ");
            foreach (string choice in menuItems)
            {
                Console.WriteLine(choice);
            }

            Console.Write("Enter option#: ");
            string input = Console.ReadKey().KeyChar.ToString();

            try
            {
                int result = Int32.Parse(input);
                return result;
            }

            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{input}'");
            }
            return -1;
        }

        static void simulateOrder(OrderCatalog order, NumberGenerator RandomOrder)
        {
            Order o = order.ReadOrder(RandomOrder.Next(1, order.OrderCount()));
            Console.WriteLine(o);
        }


        static public void Run(MenuCatalog menuCatalog, CustomerCatalog customerCatalog, Pizza pizza, OrderCatalog order, OrderCatalog orderCatalog, NumberGenerator RandomOrder)
        {
            bool proceed = true;
            List<string> mainMenulist = new List<string>()
                {
                    "0. Quit",
                    "1. Create new Pizza",
                    "2. Search Pizza",
                    "3. Update Pizza",
                    "4. Delete Pizza",
                    "5. Show Menu",
                    "6. Create an order to the order list",
                    "7. Simulate An Order from order list",
                };

            while (proceed)
            {
                int MenuChoice = MainMenuChoice(mainMenulist);
                Console.WriteLine();
                switch (MenuChoice)
                {
                    case 0:
                        proceed = false;
                        Console.WriteLine("Quitting");
                        break;
                    case 1:
                        // Create new pizza to with name and price to menuCatalog
                        try
                        {
                            Pizza NP = CreateP(menuCatalog, pizza);
                            Console.WriteLine($"{NP} Was Created.");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine($"No fast food created");
                        }
                        Console.Write("\nHit any key to continue");
                        Console.ReadKey();
                        break;
                    case 2:
                        //Read a pizza from its ID
                        try
                        {

                            Console.WriteLine("What pizza ID do you want to see?");

                            Pizza p = menuCatalog.ReadPizza(ReadP());
                            Console.WriteLine(p);

                        }
                        catch (Exception)
                        {
                            Console.WriteLine($"Could not find your pizza");
                        }
                        Console.Write($"\nHit any key to continue");
                        Console.ReadKey();
                        break;
                    case 3:
                        //update pizza with new price
                        try
                        {
                            int up = UpdateP();
                            Pizza UP = menuCatalog.ReadPizza( up );

                            Console.WriteLine("What is the new price you want?");
                            string stringPrice = Console.ReadLine();
                            int newPrice = Int32.Parse( stringPrice );

                            menuCatalog.UpdatePizza( UP, newPrice );
                            Console.Write($"{UP} was Updated.");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine($"Could not Update Pizza");
                        }
                        Console.Write("\nHit any key to continue");
                        Console.ReadKey();
                        break;
                    case 4:
                        //Delete pizza from menuCatalog
                        try
                        {
                            Console.WriteLine("What pizza ID do you want to see?");
                            int dp = DeleteP();
                            Pizza DP = menuCatalog.ReadPizza(dp);

                            menuCatalog.DeletePizza(dp);
                            Console.Write($"{DP} was deleted.");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine($"Could not Delete Pizza");
                        }
                        Console.Write("\nHit any key to continue");
                        Console.ReadKey();
                        break;
                    case 5:
                        //prints the menu menuCatalog
                        try
                        {
                            menuCatalog.PrintMenu(menuCatalog);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine($"Could not show menu");
                        }
                        Console.Write("\nHit any key to continue");
                        Console.ReadKey();
                        break;
                    case 6:
                        //create new customer with: name, delivery and pizza
                        try
                        {
                            Console.WriteLine($"Enter name of customer of order:");
                            string Name = Console.ReadLine();
                            Customer newC = new Customer("");
                            newC.Name = Name;
                            customerCatalog.CreateCustomer(newC);
                            Console.WriteLine(newC);

                            bool delivery = false;
                            Console.WriteLine($"Do they want delivery: yes: press y, no: press enter");
                            string input = Console.ReadKey().KeyChar.ToString();
                            if (input == "y")
                            {
                                delivery = true;
                            }
                            else
                            {
                                Console.WriteLine($"failed");
                            }

                            int PfornewO = ReadP();
                            Pizza PFnewO = menuCatalog.ReadPizza(PfornewO);

                            Console.Clear();
                            Console.WriteLine($"here");
                            Order newO = new Order(newC, delivery, PFnewO) ;
                            orderCatalog.CreateOrder(newO);
                            Console.WriteLine(newO);


                        }
                        catch (Exception)
                        {
                            Console.WriteLine($"Could not create order");
                        }
                        Console.Write("\nHit any key to continue");
                        Console.ReadKey();
                        break;
                    case 7:
                        //Simulates 1 order for each order in OrderCatalog 
                        try
                        {
                            for (int i = 0; i < order.OrderCount(); i++)
                            {
                                simulateOrder(order, RandomOrder);
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine($"Could not simulate order");
                        }
                        Console.Write("\nHit any key to continue");
                        Console.ReadKey();
                        break;
                    default:
                        Console.Write("\nHit any key to continue");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
