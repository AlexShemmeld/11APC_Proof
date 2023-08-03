using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApcMoneyBoxProof
{
    public class Withdraw
    {
        public static void WithdrawAmount()
        {
            Console.Write("Input PIN: ");
            var pinAttempt = Console.ReadLine();

            if (pinAttempt != Program.Pin)
            {
                return;
            }

            // Code won't reach this point if PIN is incorrect.
            
            var coinList = TakeOutCoins();
            Console.WriteLine("ENTER to proceed");
            Console.ReadLine();
            for (var i = 0; i <= 5; i++) // Each denomination in 'CoinsAtBank' and 'coinList' will match up as they are copies of the same base list
            {
                Program.CoinsAtBank[i].Count -= coinList[i].Count; // Subtracts coins from 'coinList' to the overall count
            }
            Program.Transactions.Add(new Transaction(coinList, true));
        }

        private static List<Denomination> TakeOutCoins()
        {
            Console.WriteLine($"[Q] - 5 cents ({Program.CoinsAtBank[0].Count}) | [W] - 10 cents ({Program.CoinsAtBank[1].Count}) | [E] - 20 cents ({Program.CoinsAtBank[2].Count}) | [R] - 50 cents ({Program.CoinsAtBank[3].Count}) | [T] - 1 dollar ({Program.CoinsAtBank[4].Count}) | [Y] - 2 dollars ({Program.CoinsAtBank[5].Count})");
            Console.WriteLine("Type a string of characters where each character corresponds to the type of coin that is being taken out of the box.");
            
            var coinList = Program.InputCoinsString();

            for (var i = 0; i <= 5; i++) // Checks for each denomination of coin, caps the number of coins taken out at the number present of the type of coin.
            {
                if (coinList[i].Count > Program.CoinsAtBank[i].Count)
                {
                    coinList[i].Count = Program.CoinsAtBank[i].Count;
                }
            }

            Console.WriteLine("You took out:");
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
