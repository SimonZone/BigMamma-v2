using System;
using System.Collections.Generic;

namespace BigMamma_v2
{
    class Store
    {
        public void MyCode()
        {
            NumberGenerator RandomOrder = new NumberGenerator();
            MenuCatalog menuCatalog = new MenuCatalog();
            CustomerCatalog customerCatalog = new CustomerCatalog();
            OrderCatalog orderCatalog = new OrderCatalog();
            List<T> Toppings = new List<T>();
            #region Pizzas
            Pizza Pizza1 = new Pizza( "Margherita", 25, Toppings );
            menuCatalog.CreatePizza(Pizza1);
            Pizza Pizza2 = new Pizza( "Calzone", 44, Toppings );
            menuCatalog.CreatePizza(Pizza2);
            Pizza Pizza3 = new Pizza( "Italian", 28, Toppings );
            menuCatalog.CreatePizza(Pizza3);
            Pizza Pizza4 = new Pizza( "Dane", 28, Toppings );
            menuCatalog.CreatePizza(Pizza4);

            Pizza1.AddTopping(T.Cheese);
            #endregion


            //Toppings is the same for all pizzas

            #region Customers and Orders
            Customer customer1 = new Customer("Simon");
            customerCatalog.CreateCustomer(customer1);
            Customer customer2 = new Customer("Daniel");
            customerCatalog.CreateCustomer(customer2);
            Customer customer3 = new Customer("Peter");
            customerCatalog.CreateCustomer(customer3);
            Customer customer4 = new Customer("Julie");
            customerCatalog.CreateCustomer(customer4);

            Order order1 = new Order(customer1, true, Pizza1);
            orderCatalog.CreateOrder(order1);
            Order order2 = new Order(customer2, false, Pizza2);
            orderCatalog.CreateOrder(order2);
            Order order3 = new Order(customer3, true, Pizza3);
            orderCatalog.CreateOrder(order3);
            Order order4 = new Order(customer4, false, Pizza4);
            orderCatalog.CreateOrder(order4);
            #endregion
            UserDialog.Run(menuCatalog, customerCatalog, Pizza1, orderCatalog, orderCatalog, RandomOrder);
            #region Menu catalog
            Console.WriteLine("Pizza created:");
            Console.WriteLine(Pizza1);
            Console.WriteLine(Pizza2);
            Console.WriteLine(Pizza3);

            Console.WriteLine();
            Console.WriteLine("print out pizza: 2");
            Console.WriteLine(menuCatalog.ReadPizza(2));

            Console.WriteLine();
            menuCatalog.PrintMenu(menuCatalog);

            Console.WriteLine();
            menuCatalog.SearchPizza(Pizza2);

            Console.WriteLine();
            Console.WriteLine("delete pizza 1 and update pizza 2 price ");
            menuCatalog.DeletePizza(1);
            menuCatalog.UpdatePizza(Pizza2, 50);
            menuCatalog.PrintMenu(menuCatalog);
            #endregion
            #region Customer Catalog
            Console.WriteLine("Customer registered:");
            Console.WriteLine(customer1);
            Console.WriteLine(customer2);
            Console.WriteLine(customer3);

            Console.WriteLine();
            Console.WriteLine("print out Customer: 3");
            Console.WriteLine(customerCatalog.ReadCustomer(3));

            Console.WriteLine();
            customerCatalog.SearchCustomer(customer2);

            Console.WriteLine();
            Console.WriteLine("delete pizza 1 and update customer 2 name to Julie ");
            customerCatalog.DeleteCustomer(customer1);
            customerCatalog.UpdateCustomer(customer2, "Julie");
            Console.WriteLine(customer2);
            #endregion
            #region Order Catalog
            Console.WriteLine("Order recorded");
            Console.WriteLine(order1);
            Console.WriteLine(order2);

            Console.WriteLine();
            Console.WriteLine("print out 2nd order:");
            Console.WriteLine(orderCatalog.ReadOrder(2));

            Console.WriteLine();
            orderCatalog.SearchOrder(order2);

            Console.WriteLine();
            Console.WriteLine("delete order 1 and update order 2 delivery status to true ");
            orderCatalog.DeleteOrder(order1);
            orderCatalog.UpdateOrder(order2, true);
            Console.WriteLine(order2);
            #endregion
            
        }
    }


    // hjælp med flere toppings per pizza
}
