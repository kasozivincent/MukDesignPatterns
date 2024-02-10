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
                menu.AppendLine("8 --> Change account state");
                menu.AppendLine("9 --> Change account category");
                WriteLine(menu.ToString());
                var input = int.Parse(ReadLine()!);
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
            else if (command == 8) ChangeAccountState();
            else if (command == 9) ChangeAccountCategory();
            else WriteLine("illegal command");
        }

        private void ChangeAccountCategory()
        {
            WriteLine("Enter the account number");
            var accountNumber = Guid.Parse(ReadLine()!);

            WriteLine("Enter the account category");
            var result = ReadLine();
            var category = (Category)Enum.Parse(typeof(Category), result!);
            bank.ChangeAccountCategory(accountNumber, category);
        }

        private void ChangeAccountState()
        {
            WriteLine("Enter the account number");
            var accountNumber = Guid.Parse(ReadLine());

            WriteLine("Enter the account state");
            var state = ReadLine();
            var enumValue = (State)Enum.Parse(typeof(State), state!);
            bank.ChangeAccountState(accountNumber, enumValue);
        }

        private void Quit(){
            done = true;
            WriteLine("Goodbye!");
        }

        private void CreateAccount(){
            WriteLine("Enter the initial deposit");
            var amount = decimal.Parse(ReadLine());

            WriteLine("Enter the account category");
            var input = ReadLine();
            var category = (Category)Enum.Parse(typeof(Category), input!);
            var accountNumber = bank.CreateAccount(amount, category);
            WriteLine($"Your new account number is {accountNumber}");
        }


        private void SelectAccount(){
            WriteLine("Enter account number: ");
            var accountNumber = Guid.Parse(ReadLine());
            var balance = bank.GetBalance(accountNumber);
            WriteLine($"The balance of account {accountNumber}  is  {balance}");
        }

        private void DepositMoney(){
            WriteLine("Enter account number: ");
            var accountNumber = Guid.Parse(ReadLine());

            WriteLine("Enter amount: ");
            var amount = decimal.Parse(ReadLine());

            var message = bank.DepositMoney(accountNumber, amount);
            WriteLine(message);
        }

        private void ProcessLoan(){
            WriteLine("Enter account number: ");
            var accountNumber = Guid.Parse(ReadLine());

            WriteLine("Enter amount: ");
            var loanAmount = decimal.Parse(ReadLine());

            switch (bank.IsElligibleForLoan(accountNumber, loanAmount))
            {
                case Status.Approved: {
                   WriteLine("Your loan is approved");
                   break;
                }
                case Status.Rejected: {
                    WriteLine("Your loan is denied");
                    break;
                }
                default: break;
            }
        }

         private void TransferMoney(){
           WriteLine("Enter sender account number: ");
           var senderAccountNumber = Guid.Parse(ReadLine());

           WriteLine("Enter recipient's account number: ");
           var recipientAccountNumber = Guid.Parse(ReadLine());

           WriteLine("Enter amount: ");
           var amount = decimal.Parse(ReadLine());

           bank.TransferMoney(senderAccountNumber, recipientAccountNumber, amount);
        
        }

        private void AddInterest() {
            bank.AddInterest();
        }

        private void DisplayAccounts()
        {
            WriteLine(bank.DisplayAccounts());
        }
    }
}