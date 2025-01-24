using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6_2B.Model
{
    public class Order
    {
        //  for the order
        public int OrderId { get; set; }

        // Order date
        public DateTime Date { get; set; }

        // Customer ID placing the order
        public int CustomerId { get; set; }

        // Product ID being ordered
        public int ProductId { get; set; }

        // Name of the product being ordered
        public string ProductName { get; set; }

        // Quantity of the product ordered
        public int Quantity { get; set; }

        // Rate of the product
        public double Rate { get; set; }

        // Calculated total amount for the order
        public double TotalAmount { get; set; }

    }
}

