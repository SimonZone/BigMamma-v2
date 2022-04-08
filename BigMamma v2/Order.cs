using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigMamma_v2
{
    public class Order
    {
        private double _totalPrice { get; set; }
        private int _orderID;
        private static int _ID = 1;
        private bool _delivery;
        private const int DeliveryCost = 20;
        private const double Tax = 0.25;
        private Pizza P;
        private Customer C;

        
        public Order(Customer customer, bool Delivery, Pizza pizza)
        {
            _orderID = _ID++;
            C = customer;
            P = pizza;
            _delivery = Delivery;

        }

        #region properties
        public int OrderID
        {
            get { return _orderID; }
            set { _orderID = value; }
        }

        public bool Devilery
        {
            get { return _delivery; }
            set { _delivery = value; }
        }
        #endregion

        #region methods
        public double CalculateTotalPrice()
        {       
            //Calculate price for inhouse or delivery
            if (_delivery == true) 
            {
                _totalPrice = P.Price + ( Tax * P.Price  ) + DeliveryCost ;
            } else {
                _totalPrice = P.Price + (Tax * P.Price );
            }
            return _totalPrice;
        }

        public override string ToString()
        {
            CalculateTotalPrice();
            if (_delivery == true)
            {
                Console.Write($"{C} ordered: ");
                Console.Write(P);
                Console.Write($", with total price: " + _totalPrice + " kr. This is including delivery.");
                return "";
            }
            else
            {
                Console.Write($"{C} ordered: ");
                Console.Write(P);
                Console.Write($", with total price: " + _totalPrice + " kr.");
                return "";
            }
        }
        #endregion
    }
}
