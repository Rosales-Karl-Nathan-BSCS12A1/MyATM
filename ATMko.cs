namespace MyATM
{
    public enum Action : int
    {
        CheckBalance = 1,
        DepositMoney = 2,
        WithdrawMoney = 3,
        Exit = 4
    }

    internal class Program
    {
        static int balance = 1000;

        static void Print(string message)
        {
            Console.WriteLine(message);
        }

        static Action Validate(string userInput)
        {
            if (int.TryParse(userInput, out int result) && Enum.IsDefined(typeof(Action), result))
            {
                return (Action)result;
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
                return Action.Exit; // Use a safe fallback
            }
        }

        static void CheckBalance()
        {
            Print($"Your balance is {balance} peso(s)");
        }

        static void DepositMoney()
        {
            Print("Enter the amount you want to deposit: ");
            int deposit = Convert.ToInt32(Console.ReadLine());
            balance += deposit;
            Print($"You have successfully deposited ₱{deposit}. Your new balance is  {balance} peso(s)");
        }

        static void WithdrawMoney()
        {
            Print("Enter the amount you want to withdraw: ");
            int withdraw = Convert.ToInt32(Console.ReadLine());

            if (withdraw > balance)
            {
                Print("Insufficient funds!");
            }
            else
            {
                balance -= withdraw;
                Print($"You have successfully withdrawn ₱{withdraw}. Your new balance is ₱{balance} peso(s)");
            }
        }

        static void Exit()
        {
            Print("Thank you for using our ATM. Goodbye!");
            Environment.Exit(0);
        }

        public static void Main(string[] args)
        {
            Print("ATM Simulator");

            while (true)
            {
                Print("\n1 - Check Balance");
                Print("2 - Deposit Money");
                Print("3 - Withdraw Money");
                Print("4 - Exit");

                Print("Enter your choice: ");
                string choice = Console.ReadLine();

                Action selectedAction = Validate(choice!);

                if (selectedAction == Action.CheckBalance)
                {
                    CheckBalance();
                }
                else if (selectedAction == Action.DepositMoney)
                {
                    DepositMoney();
                }
                else if (selectedAction == Action.WithdrawMoney)
                {
                    WithdrawMoney();
                }
                else if (selectedAction == Action.Exit)
                {
                    Exit();
                }
            }
        }
    }
}
