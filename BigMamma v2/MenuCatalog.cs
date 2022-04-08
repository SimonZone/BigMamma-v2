using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigMamma_v2
{
    public class MenuCatalog
    {
        Dictionary<int, Pizza> pizzas;

        public MenuCatalog()
        {
            pizzas = new Dictionary<int, Pizza>();
        }

        #region properties

        #endregion

        #region Methods

        public void CreatePizza(Pizza pizza)
        {
            pizzas.Add(pizza.PizzaID, pizza);
        }

        public Pizza ReadPizza(int pizzaID)
        {
            return pizzas[pizzaID];
        }

        public void UpdatePizza(Pizza pizza, int newPrice)
        {
            pizza.Price = newPrice;
        }
        
        public void DeletePizza(int pizzaID)
        {
            pizzas.Remove(pizzaID);
        }

        public void PrintMenu(MenuCatalog menuCatalog)
        {
            Console.WriteLine($"\nmenu.");
            Console.WriteLine($"-------------------------------");
            foreach (KeyValuePair<int, Pizza> pizza in menuCatalog.pizzas)
            {
                Console.WriteLine("{0}", 
                    pizza.Value);
            }
        }

        public void SearchPizza(Pizza pizza)
        {
            var key = pizza.PizzaID;
            var value = pizza.Name;
            Console.WriteLine("ID. {0} Name: {1}", key, value);

        }

        #endregion
    }
}
