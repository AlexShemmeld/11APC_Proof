using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApcMoneyBoxProof
{
    public class Denomination
    {
        public Denomination(decimal dollarValue)
        {
            DollarValue = dollarValue;
            FormattedDollarValue = dollarValue.ToString("0.00");
            Count = 0;
        }

        public decimal DollarValue { get; set; } // How many dollars the type of coin is.
        // E.g., a 20 cent coin will have DollarValue = 0.2m (i.e. $0.20)

        public string FormattedDollarValue { get; set; } // String formatted as $x.xx

        public int Count { get; set; } // The number of coins of this type that are in the money box.

        public decimal Subtotal()
        {
            return Count * DollarValue;
        }

        public static List<Denomination> EmptyCoinList()
        {
            return new List<Denomination>
            {
                new Denomination(0.05m),
                new Denomination(0.1m),
                new Denomination(0.2m),
                new Denomination(0.5m),
                new Denomination(1m),
                new Denomination(2m)
            };
        }
    }
}
