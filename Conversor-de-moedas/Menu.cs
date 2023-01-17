using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;

namespace Conversor_de_moedas
{
    public class Menu
    {

        enum moedas
        {
            BRL,
            EUR,
            USD
        }

        public string escolha()
        {
            int escolha;
            Enum.TryParse(Console.ReadLine(), out moedas moeda);
            escolha = (int)moeda;


            Console.WriteLine();
             
            switch (escolha)
            {
                case 0:
                    return "BRL";
                case 1:
                    return "EUR";
                case 2:
                    return "USD";
            }

            return "ERRO";
        }

        public double definirValor()
        {

            try 
            {
                double valor = Convert.ToDouble(Console.ReadLine());
                return valor;
            }
            
            catch(FormatException)
            {
                Console.WriteLine("Formato inválido insira um número!");
                definirValor();
                return double.MaxValue;
            }

            
        }

        public void menu()
        {
            Console.WriteLine("Bem-vindo ao conversor de moedas");
            Console.WriteLine(" ");
            
            Lista lista = new Lista();
            lista.listar();

            Console.WriteLine("------------------------------------");

            Console.WriteLine("Escolha a moeda de origem");

            string moedaOrigem = escolha();

            if (moedaOrigem != "ERRO")
            {
                Console.WriteLine($"Digite o valor em {moedaOrigem} a ser convertido: ");
                double valorMoedaOrigem = definirValor();

                Console.WriteLine(" ");
                Console.WriteLine($"Escolha a moeda final: ");

                string moedaFinal = escolha();

                if (moedaFinal != "ERRO")
                {
                    var conversor = new Conversor(moedaOrigem, moedaFinal, valorMoedaOrigem);
                    Console.WriteLine(" ");
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine($"{valorMoedaOrigem} {moedaOrigem} => {conversor.conversor()} {moedaFinal}");

                    Console.WriteLine($"Taxa: {conversor.Rate}");
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }

        }
    }
}