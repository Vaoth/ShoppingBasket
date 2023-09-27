using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasket
{
    internal class Product
    {
        public uint Id {  get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }

        public Product(uint id, string name, double weight) {
            Id = id;
            Name = name;
            Weight = weight;
        }
    }
}
