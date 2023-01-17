using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace Conversor_de_moedas
{
    internal class Program
    {       
        static void Main(string[] args)
        {

            Menu M = new Menu();

            try
            {
                M.menu();
            }
            catch(ArgumentNullException)
            {
                Console.Clear();
                Console.WriteLine("As moedas precisam ser diferentes!");
                M.menu();

            }
            catch(InvalidEnumArgumentException) 
            {
                Console.Clear();
                Console.WriteLine("Moeda não contida na lista de moedas válidas");
                M.menu();
            }
        }
    }
}
