using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary.DtO_Models
{
    public class Products
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int CategoryID { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public string Size { get; set; }
        public DateTime Uptime { get; set; }
        public DateTime? Downtime { get; set; }
        public string Color { get; set; }
        public string ProductDetails { get; set; }
    }
}
