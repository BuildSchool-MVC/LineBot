using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary.DtO_Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public DateTime? Birthday { get; set; }
        public string Password { get; set; }
        public decimal ShoppingCash { get; set; }
        public string Account { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Salt { get; set; }
    }
}
