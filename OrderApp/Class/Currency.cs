using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Class
{
    public class Currency
    {
        public string GetCommandNumberByDate(DateTime date)
        {
            return "CMD123";
        }

        public double GetExchangeRate(DateTime date, string currency)
        {
            return 0.85;
        }
    }
}
