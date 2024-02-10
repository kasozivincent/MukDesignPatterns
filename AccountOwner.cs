namespace DesignPatterns
{
   public class AccountOwner
   {
      public Guid AccountOwnerId {get; init; }
      public string SurName {get; set; }
      public string LastName {get; set; }
      public Address Address {get; set;}
      public List<Account> Accounts { get; set; }
   }
}