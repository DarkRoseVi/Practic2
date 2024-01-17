using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr2
{
      class Product
    {
        int Id { get; set; }
        string Name { get; set; }   

        int Count { get; set; } 
        double Cost { get; set; }   
        public Product(int id, string name, int count, double cost)
        {
            Id = id;
            Name = name;
            Count = count;
            Cost = cost;
        }   
    }
}
