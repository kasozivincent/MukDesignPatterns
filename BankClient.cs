using System.Text;
using static System.Console;

namespace DesignPatterns
{
    public class BankClient
    {
        private bool done = false;
        private Bank bank = new Bank();

        public void Run()
        {
            if(done)
            {
                WriteLine("Good bye, thanks for using our services");
            }
            else{
                var menu = new StringBuilder();
                menu.AppendLine("Enter command");
                menu.AppendLine("0 --> Quit");
                menu.AppendLine("1 --> Create Account");
                menu.AppendLine("2 --> Select Account");
                menu.AppendLine("3 --> Deposit Money");
                menu.AppendLine("4 --> Process Loan");
                menu.AppendLine("5 --> Display Accounts");
                menu.AppendLine("6 --> Compute Interest");
                menu.AppendLine("7 --> Transfer Money");
                WriteLine(menu.ToString());
                var input = int.Parse(ReadLine());
                ProcessCommand(input);
                Run();
            }
        }

        private void ProcessCommand(int command)
        {
            
            if(command == 0) Quit();
            else if(command == 1) CreateAccount();
            else if(command == 2) SelectAccount();
            else if(command == 3) DepositMoney();
            else if(command == 4) ProcessLoan();
            else if(command == 5) DisplayAccounts();
            else if(command == 6) AddInterest();
            else if(command == 7) TransferMoney();
            else WriteLine("illegal command");
        }

        private void Quit(){
            done = true;
            WriteLine("Goodbye!");
        }

        private void CreateAccount(){
            var accountNumber = bank.CreateAccount();
            WriteLine($"Your new account number is {accountNumber}");
        }


        private void SelectAccount(){
            WriteLine("Enter account number: ");
            var accountNumber = int.Parse(ReadLine());
            var balance = bank.GetBalance(accountNumber);
            WriteLine($"The balance of account {accountNumber}  is  {balance}");
        }

        private void DepositMoney(){
            WriteLine("Enter account number: ");
            int accountNumber = int.Parse(ReadLine());

            WriteLine("Enter amount: ");
            int amount = int.Parse(ReadLine());

            var message = bank.DepositMoney(accountNumber, amount);
            WriteLine(message);
        }

        private void ProcessLoan(){
            WriteLine("Enter account number: ");
            int accountNumber = int.Parse(ReadLine());

            WriteLine("Enter amount: ");
            int loanAmount = int.Parse(ReadLine());

            if(bank.IsElligibleForLoan(accountNumber, loanAmount))
                WriteLine("Your loan is approved");
            else
                WriteLine("Your loan is denied");
        }

         private void TransferMoney(){
           WriteLine("Enter sender account number: ");
           var senderAccountNumber = int.Parse(ReadLine());

           WriteLine("Enter recipient's account number: ");
           var recipientAccountNumber = int.Parse(ReadLine());

           WriteLine("Enter amount: ");
           var amount = int.Parse(ReadLine());

           bank.TransferMoney(senderAccountNumber, recipientAccountNumber, amount);
        
        }

        private void AddInterest() {
            bank.AddInterest();
        }

        public void DisplayAccounts()
        {
            WriteLine(bank.DisplayAccounts());
        }
    }
}