using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.Json;
using Newtonsoft.Json;
using System.Web.UI.WebControls;

namespace Conversor_de_moedas
{
    public class Conversor
    {
        public string MoedaOrigem { get; set; }
        public string MoedaFinal { get; set; }
        public double Montante { get; private set; }

        public double conversor()
        {
            try {
                var request = (HttpWebRequest)WebRequest.Create($"https://api.exchangerate.host/convert?from={MoedaOrigem}&to={MoedaFinal}&amount={Montante}");

                var response = (HttpWebResponse)request.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                string json = responseString.ToString();

                Multiplicador m = JsonConvert.DeserializeObject<Multiplicador>(json);

                double montate = Math.Round(Convert.ToDouble(m.Result), 2); ;

                return montate;
            }
            catch(Exception)
            {
                Console.WriteLine("Erro ao acessar a API!");
                return -1;
            }
            
            
        }

        public double Rate
        {
            get
            {
                var request = (HttpWebRequest)WebRequest.Create($"https://api.exchangerate.host/convert?from={MoedaOrigem}&to={MoedaFinal}");

                var response = (HttpWebResponse)request.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                string json = responseString.ToString();

                Multiplicador m = JsonConvert.DeserializeObject<Multiplicador>(json);

                double rate = Convert.ToDouble(m.Result);

                return rate;
            }
        }

        public Conversor(string m1, string m2, double montante) {

            if (m1 != m2) 
            {
                MoedaOrigem = m1;
                MoedaFinal = m2;
                Montante = montante;
            }
            else
            {
                throw new ArgumentException("As moedas precisam ser diferentes!");
            }
            
        }
    }
}
