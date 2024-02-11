namespace DesignPatterns
{
    public class SavingsAccount : Account
    {
        public SavingsAccount(decimal balance, Category category)
               : base(balance, category)
        {}

        public override Status IsElligibleForLoan(decimal loanAmount){
            return (Balance >= loanAmount / 2)
            ? Status.Approved
            : Status.Rejected;
        }

        public override string ToString()
        {
            return $"SavingsAccount: Account Number: {AccountNumber} -- Balance: {Balance} -- Creation Date: {CreatedOn} -- State: {State}";
        }

        public override void AddInterest(double rate) {
            Balance += Balance * (decimal)rate;
        }
    }
}