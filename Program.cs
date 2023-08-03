namespace ApcMoneyBoxProof
{
    public class Program
    {
        public static List<Denomination> CoinsAtBank = Denomination.EmptyCoinList();
        public static List<Transaction> Transactions = new List<Transaction>();
        public static string Pin = "0000";

        static void Main(string[] args)
        {
            Console.WriteLine("'Smart Money Box' Software Proof of Concept");
            Console.WriteLine("By Alex and Abdul, for 11APC Unit 2, Outcome 1");
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine($"BALANCE: ${CalculateTotal(CoinsAtBank).ToString("0.00")}");
                Console.WriteLine("[1] - Deposit | [2] - Withdraw | [3] - View Transactions");
                Console.Write(">>> ");
                var response = Console.ReadLine();

                switch (response)
                {
                    case "1":
                        Deposit.DepositAmount();
                        break;
                    case "2":
                        Withdraw.WithdrawAmount();
                        break;
                    case "3":
                        ListTransactions();
                        break;
                }
            }
        }

        public static decimal CalculateTotal(List<Denomination> coinList)
        {
            decimal total = 0;
            foreach (var denomination in coinList)
            {
                total += denomination.Subtotal();
            }
            return total;
        }

        public static List<Denomination> InputCoinsString()
        {
            var coinsString = Console.ReadLine();
            var coinList = Denomination.EmptyCoinList();

            foreach (var character in coinsString)
            {
                var charUpper = character.ToString().ToUpper();
                switch (charUpper)
                {
                    case "Q": // 5 cents
                        coinList[0].Count++;
                        break;
                    case "W": // 10 cents
                        coinList[1].Count++;
                        break;
                    case "E": // 20 cents
                        coinList[2].Count++;
                        break;
                    case "R": // 50 cents
                        coinList[3].Count++;
                        break;
                    case "T": // 1 dollar
                        coinList[4].Count++;
                        break;
                    case "Y": // 2 dollars
                        coinList[5].Count++;
                        break;
                }
            }

            return coinList;
        }

        static void ListTransactions()
        {
            var transactions = Program.Transactions.OrderByDescending(x => x.Time).ToList();
            Console.WriteLine($"Showing {transactions.Count} transactions");

            foreach (var transaction in transactions)
            {
                Console.WriteLine($"{transaction.Time.ToString("dd/MM/yyyy")}: {(transaction.Withdrawal ? "-" : "+")}${transaction.Amount.ToString("0.00")}");
            }

            Console.WriteLine("ENTER to proceed");
            Console.ReadLine();
        }
    }
}