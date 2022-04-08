using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigMamma_v2
{
    public class Customer
    {
        private string _customerName;
        private int _customerID; 
        private static int _ID = 1;

        public Customer(string name)
        {
            _customerName = name;
            _customerID = _ID++;
        }

        #region properties
        public string Name
        {
            get { return _customerName; }
            set { _customerName = value;  }
        }
        public int ID
        {
            get { return _customerID; }
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return "Name: " + _customerName + ", Customer ID: " + _customerID;
        }
        #endregion
    }
}
