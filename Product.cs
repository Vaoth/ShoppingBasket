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
        public uint Weight { get; set; }

        public Product(uint id, string name, uint weight) {
            Id = id;
            Name = name;
            Weight = weight;
        }

        public Product() { }
    }
}
