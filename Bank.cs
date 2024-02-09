using System.Text;

namespace DesignPatterns
{
    public class Bank
    {
        private IDictionary<int, int> accounts = new Dictionary<int, int>();
        private double rate = 0.01;
        
        private int currentAccountNumber = 0;

        public string CreateAccount(){
            currentAccountNumber = currentAccountNumber++;
            accounts.Add(currentAccountNumber, 0);
            return $"Your new account number is {currentAccountNumber}";
        }

        public int GetBalance(int accountNumber){
            var balance = accounts[accountNumber];
            return balance;
        }

        public string DepositMoney(int accountNumber, int amount){
            int balance = accounts[accountNumber];
            accounts.Add(accountNumber, balance + amount);
            return $"Your new account balance is {balance + amount}";
        }

        public bool IsElligibleForLoan(int accountNumber, int loanAmount){
            int balance = accounts[accountNumber];
            return (balance >= loanAmount / 2);
        }

        public string DisplayAccounts()
        {
            var builder = new StringBuilder();

            var accountNumbers = accounts.Keys;
            builder.AppendLine($"The bank has {accountNumbers.Count} accounts");
            foreach(var accountNumber in accountNumbers)
            {
                builder.AppendLine($"Account Number: {accountNumber}, Balance: {accounts[accountNumber]}");
            }
            return builder.ToString();
        }

        public void AddInterest(){
            var accountNumbers = accounts.Keys;
            foreach(var accountNumber in accountNumbers)
            {
                var balance = accounts[accountNumber];
                var newbalance = (int) (balance * (1 + rate));
                accounts.Add(accountNumber, newbalance);
            }
        }

        public void TransferMoney(int senderAccountNumber, 
                                  int recipientAccountNumber, 
                                  int amount){
           var currentBalance = accounts[senderAccountNumber];

           if(amount > currentBalance)
               throw new Exception("The sender doesn't have sufficient balance");
            
           accounts.Add(senderAccountNumber, currentBalance - amount);
           accounts.Add(recipientAccountNumber, accounts[recipientAccountNumber] + amount);
        
        }
    }
}