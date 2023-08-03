using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApcMoneyBoxProof
{
    public class Transaction
    {
        public Transaction(List<Denomination> coinList, bool withdraw)
        {
            Amount = Program.CalculateTotal(coinList);
            Withdrawal = withdraw;
            Time = DateTime.Now;
        }

        public decimal Amount { get; set; }
        public bool Withdrawal { get; set; }
        public DateTime Time { get; set; }
    }
}
