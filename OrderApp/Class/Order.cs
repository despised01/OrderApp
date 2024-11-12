using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Class
{
    public class Order
    {
        public DateTime OrderDate { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int TradeAgentID { get; set; }
        public string DiscountCard { get; set; }
        public int PaymentConditionID { get; set; }
        public double ExchangeRate { get; set; }
        public string CommandNumber { get; set; }
    }
}
