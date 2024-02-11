using System.ComponentModel;
using System.Data;

namespace DesignPatterns
{
    public abstract class Account
    {
        public Guid AccountNumber { get; set; }
        public decimal Balance {get; protected set;} 
        public State State { get; set; }
        public Category Category {get; set; }
        public DateTime CreatedOn { get; set; }

        protected  Account(decimal balance, Category category)
        {
            Balance = balance;
            Category = category;
            State = State.Active;
            CreatedOn = DateTime.Now;
        }

        public decimal DepositMoney(decimal amount){
            if(State != State.Active)
                throw new Exception("Account is not active");
            Balance += amount;
            return Balance;
        }

        public void WithDrawMoney(decimal amount){
            if(amount > Balance)
                throw new Exception("Insufficient Balance");
            if(State != State.Active)
                throw new Exception("Account is not active");
            Balance -= amount;
        }

        public abstract Status IsElligibleForLoan(decimal loanAmount);

    }
}