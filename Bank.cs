using System.Text;

namespace DesignPatterns
{
    public class Bank
    {
        private IDictionary<Guid, Account> accounts = new Dictionary<Guid, Account>();
        private double rate = 0.01;
        
        public string CreateAccount(decimal intialDeposit, Category category){
            var accountNumber = Guid.NewGuid();
            accounts.Add(accountNumber, Account.Create(intialDeposit, category));
            return $"Your new account number is {accountNumber}";
        }

        public void ChangeAccountState(Guid accountNumber, State state)
        {
            var account = accounts[accountNumber];
            account.State = state;
        }

        public void ChangeAccountCategory(Guid accountNumber, Category category)
        {
            var account = accounts[accountNumber];
            account.Category = category;
        }


        public decimal GetBalance(Guid accountNumber){
            var account = accounts[accountNumber];
            return account.Balance;
        }

        public string DepositMoney(Guid accountNumber, decimal amount){
            var account = accounts[accountNumber];
            var balance = account.Balance;
            account.Balance = balance + amount;
            return $"Your new account balance is {balance + amount}";
        }

        public Status IsElligibleForLoan(Guid accountNumber, decimal loanAmount){
            var account = accounts[accountNumber];
            var balance = account.Balance;
            return (balance >= loanAmount / 2)
            ? Status.Approved
            : Status.Rejected;
        }

        public string DisplayAccounts()
        {
            var builder = new StringBuilder();

            var accountNumbers = accounts.Keys;
            builder.AppendLine($"The bank has {accountNumbers.Count} accounts");
            foreach(var accountNumber in accountNumbers)
            {
                var account = accounts[accountNumber];
                builder.AppendLine(account.ToString());
            }
            return builder.ToString();
        }

        public void AddInterest(){
            var accountNumbers = accounts.Keys;
            foreach(var accountNumber in accountNumbers)
            {
                var account = accounts[accountNumber];
                account.Balance *= (decimal) (1 + rate);
            }
        }

        public void TransferMoney(Guid senderAccountNumber, 
                                  Guid recipientAccountNumber, 
                                  decimal amount){
           var senderAccount = accounts[senderAccountNumber];
           var recipientAccount = accounts[recipientAccountNumber];
           var currentBalance = senderAccount.Balance;

           if(amount > currentBalance)
               throw new Exception("The sender doesn't have sufficient balance");
            
           senderAccount.Balance -=  amount;
           recipientAccount.Balance += amount;
        }
    }
}