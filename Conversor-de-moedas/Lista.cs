using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Conversor_de_moedas
{
    public class Lista
    {

        List<string> lista_de_moedas = new List<string>()
        {
            "BRL",
            "EUR",
            "USD",
        };

        public void listar()
        {
            for (int i = 0; i < lista_de_moedas.Count; i++)
            {
                Console.WriteLine($"{i} - {lista_de_moedas[i]}");
            }
        }

    }
}
