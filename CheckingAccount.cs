namespace DesignPatterns
{
    public class CheckingAccount : Account
    {
        public CheckingAccount(decimal balance, Category category)
               : base(balance, category)
        {}

        public override Status IsElligibleForLoan(decimal loanAmount){
            return (Balance >= 2 * loanAmount / 3)
            ? Status.Approved
            : Status.Rejected;
        }

        public override string ToString()
        {
            return $"CheckingAccount: Account Number: {AccountNumber} -- Balance: {Balance} -- Creation Date: {CreatedOn} -- State: {State}";
        }

        public override void AddInterest(double rate) {
        }

    }
}