using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApcMoneyBoxProof
{
    public class Deposit
    {
        public static void DepositAmount()
        {
            var coinList = InsertCoins();
            Console.WriteLine("ENTER to proceed");
            Console.ReadLine();
            for (var i = 0; i <= 5; i++) // Each denomination in 'CoinsAtBank' and 'coinList' will match up as they are copies of the same base list
            {
                Program.CoinsAtBank[i].Count += coinList[i].Count; // Adds coins from 'coinList' to the overall count
            }
            Program.Transactions.Add(new Transaction(coinList, false));
        }

        private static List<Denomination> InsertCoins()
        {
            Console.WriteLine("[Q] - 5 cents | [W] - 10 cents | [E] - 20 cents | [R] - 50 cents | [T] - 1 dollar | [Y] - 2 dollars");
            Console.WriteLine("Type a string of characters where each character corresponds to the type of coin that is being put in the coin acceptor.");

            var coinList = Program.InputCoinsString();

            Console.WriteLine("You inserted:");
            foreach (var denomination in coinList)
            {
                if (denomination.Count != 0)
                {
                    Console.WriteLine($"{denomination.Count} x ${denomination.FormattedDollarValue} = ${denomination.Subtotal().ToString("0.00")}");
                }
            }

            return coinList;
        }
    }
}
