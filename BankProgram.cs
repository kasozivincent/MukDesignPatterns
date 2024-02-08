using System.Text;
using static System.Console;
namespace DesignPatterns
{
    public class BankProgram
    {
        private IDictionary<int, int> accounts 
                                = new Dictionary<int, int>();
        private double rate = 0.01;
        private bool done = false;
        private int currentAccountNumber = 0;

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
            currentAccountNumber = currentAccountNumber++;
            accounts.Add(currentAccountNumber, 0);
            WriteLine($"Your new account number is {currentAccountNumber}");
        }

        private void SelectAccount(){
            WriteLine("Enter account number: ");
            var accountNumber = int.Parse(ReadLine());
            var balance = accounts[accountNumber];
            WriteLine($"The balance of account {accountNumber}  is  {balance}");
        }
        private void DepositMoney(){
            WriteLine("Enter account number: ");
            int accountNumber = int.Parse(ReadLine());

            WriteLine("Enter amount: ");
            int amount = int.Parse(ReadLine());

            int balance = accounts[accountNumber];
            accounts.Add(accountNumber, balance + amount);
            WriteLine($"Your new account balance is {balance + amount}");
        }

        private void ProcessLoan(){
            WriteLine("Enter account number: ");
            int accountNumber = int.Parse(ReadLine());

            WriteLine("Enter amount: ");
            int loanAmount = int.Parse(ReadLine());

            int balance = accounts[accountNumber];
            if (balance >= loanAmount / 2)
                WriteLine("Your loan is approved");
            else
                WriteLine("Your loan is denied");
        }

        private void DisplayAccounts(){
            var accountNumbers = accounts.Keys;
            WriteLine($"The bank has {accountNumbers.Count} accounts");
            foreach(var accountNumber in accountNumbers)
            {
                WriteLine($"Account Number: {accountNumber}, Balance: {accounts[accountNumber]}");
            }
        }

        private void AddInterest(){
            var accountNumbers = accounts.Keys;
            foreach(var accountNumber in accountNumbers)
            {
                var balance = accounts[accountNumber];
                var newbalance = (int) (balance * (1 + rate));
                accounts.Add(accountNumber, newbalance);
            }
        }
        private void TransferMoney(){
           WriteLine("Enter sender account number: ");
           var senderAccountNumber = int.Parse(ReadLine());

           WriteLine("Enter recipient's account number: ");
           var recipientAccountNumber = int.Parse(ReadLine());

           WriteLine("Enter amount: ");
           var amount = int.Parse(ReadLine());

           var currentBalance = accounts[senderAccountNumber];

           if(amount > currentBalance)
               WriteLine("The sender doesn't have sufficient balance");
            
           accounts.Add(senderAccountNumber, currentBalance - amount);
           accounts.Add(recipientAccountNumber, accounts[recipientAccountNumber] + amount);
        
        }
    }
    
}