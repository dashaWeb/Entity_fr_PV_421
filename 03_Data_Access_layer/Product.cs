using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Data_Access_layer
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public int CostPrice { get; set; }
        public string Producer { get; set; }
        public int Price { get; set; }
        public override string ToString()
        {
            return $"{Id,16}{Name,16}{Type,16}{Quantity,16}{CostPrice,16}{Producer,16}{Price,16}";
        }
    }
}
