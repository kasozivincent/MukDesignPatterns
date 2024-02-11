using System.Text;

namespace DesignPatterns
{
    public class Bank
    {
        public Bank(IDictionary<Guid, Account> accounts, double rate)
        {
            this.accounts = accounts;
            this.rate = rate;
        }
        private readonly IDictionary<Guid, Account> accounts;
        private double rate;
        
        public string CreateAccount(string type, decimal intialDeposit, Category category){
            var accountNumber = Guid.NewGuid();
            Account bankAccount;
            if (type == "Savings")
                bankAccount = new SavingsAccount(intialDeposit, category);
            else
                bankAccount = new CheckingAccount(intialDeposit, category);
            accounts.Add(accountNumber, bankAccount);
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
            var balance = account.DepositMoney(amount);
            return $"Your new account balance is {balance}";
        }

        public void WithDrawMoney(Guid accountNumber, decimal amount){
            var account = accounts[accountNumber];
            account.WithDrawMoney(amount);
        }

        public Status IsElligibleForLoan(Guid accountNumber, decimal loanAmount){
            var account = accounts[accountNumber];
            return account.IsElligibleForLoan(loanAmount);
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

        public void AddInterest()
        {
            var accountNumbers = accounts.Keys;
            foreach(var accountNumber in accountNumbers)
            {
                var account = accounts[accountNumber];
                if (account is SavingsAccount) 
                {
                    ((SavingsAccount)account).AddInterest(rate);
                }
            }
        }

        public void TransferMoney(Guid senderAccountNumber, 
                                  Guid recipientAccountNumber, 
                                  decimal amount){
           var senderAccount = accounts[senderAccountNumber];
           var recipientAccount = accounts[recipientAccountNumber];
           senderAccount.WithDrawMoney(amount);
           recipientAccount.DepositMoney(amount);
        }
    }
}