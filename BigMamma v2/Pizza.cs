using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigMamma_v2
{
    public enum T { Pepperoni, Cheese, Mushrooms, Black_Olives, Green_Peppers, Onions, Pineapple, Sausage, Spinach, No_topping }

    public class Pizza
    {
        private int _price;
        private string _name;
        private static int _ID = 1;
        private int _pizzaID;
        private List<T> _toppings;

        public Pizza(string name, int price, List<T> toppings)
        {
            _pizzaID = _ID++;
            _name = name;
            _price = price;
            _toppings = toppings;
        }

        #region properties
        public string Name
        {
            get { return _name; }
            set { _name = value; }

        }
        public int Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public int PizzaID
        {
            get { return _pizzaID; }
        }

        public List<T> Toppings
        {
            get { return _toppings; }
            set { ; }
        }
        #endregion

        public override string ToString()
        {
            Console.WriteLine();

            //prints first part
            string top = _pizzaID + ". " + _name + " which includes: ";
            Console.Write(top);

            _toppings.ForEach(x => Console.Write($"{x}, "));

            //prints second part
            string bot = "and costs: " + _price + " kr";
            Console.Write(bot);

            return "";
        }

        public void AddTopping(T toppings)
        {
            Toppings.Add(toppings);
        }
    }
}
