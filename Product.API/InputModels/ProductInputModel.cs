using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.InputModels
{
    public class ProductInputModel
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public int StockNumber { get; set; }
    }
}
