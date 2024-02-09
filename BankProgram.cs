using System.Text;
using static System.Console;
namespace DesignPatterns
{
    public class BankProgram
    {
       public static void Main()
       {
           var bankClient = new BankClient();
           bankClient.Run();
       }
    }
    
}