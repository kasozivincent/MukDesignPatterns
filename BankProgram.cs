using System.Text;
using static System.Console;
namespace DesignPatterns
{
    public class BankProgram
    {
       public static void Main()
       {
           var accounts = new Dictionary<Guid, Account>();
           var rate = 0.1;
           var bank = new Bank(accounts, rate);
           var bankClient = new BankClient(bank);
           bankClient.Run();
       }
    }
    
}