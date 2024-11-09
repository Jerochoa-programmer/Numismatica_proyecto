using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nimusmatica
{
    

    internal class elementos
    {
        private int cod = 0;
        private string valor = "";
        private string fecha = "";
        private string pais = "";

        public elementos(int cod, string valor, string fecha, string pais)
        {
            this.cod = cod;
            string nuevo_valor = valor.Replace(",", "");
            this.valor = nuevo_valor;
            this.fecha = fecha;
            this.pais = pais;
        }

        public int Cod { get => cod; set => cod = value; }
        public string Valor { get => valor; set => valor = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public string Pais { get => pais; set => pais = value; }

        private long convertir_valor()
        {
            long valor_convertido = long.Parse(valor);
            return valor_convertido/10000;
        }
        public string tostring()
        {
            return ("Valor: " + convertir_valor() + " Fecha: " + fecha + " Pais: " + pais);
                
        }
        
    }
}
