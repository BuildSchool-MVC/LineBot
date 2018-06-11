using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary.DtO_Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public DateTime OrderDay { get; set; }
        public int CustomerID { get; set; }
        public string Transport { get; set; }
        public string Payment { get; set; }
        public string Status { get; set; }
        public DateTime StatusUpdateDay { get; set; }
        public string Address { get; set; }
    }
}
