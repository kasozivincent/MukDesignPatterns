using System.ComponentModel;
using System.Data;

namespace DesignPatterns
{
    public class Account
    {
        private Account(){}
        public Guid AccountNumber { get; set; }
        public decimal Balance {get; set;} 
        public State State { get; set; }
        public Category Category {get; set; }
        public DateTime CreatedOn { get; set; }

        public static Account Create(decimal balance, Category category)
        {
            return new Account {
                AccountNumber = Guid.NewGuid(),
                Category = category,
                Balance = balance,
                State = State.Active,
                CreatedOn = DateTime.Now
            };
        }
        public override string ToString()
        {
            return $"Account Number: {AccountNumber} -- Balance: {Balance} -- Creation Date: {CreatedOn} -- State: {State}";
        }

    }
}