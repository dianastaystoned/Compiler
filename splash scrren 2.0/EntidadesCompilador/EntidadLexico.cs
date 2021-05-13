using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompilador
{
    public class EntidadLexico
    {
        public int Numero { get; set; }
        public string Token { get; set; }
        public string Descripcion { get; set; }
        public string Linea { get; set; }
        public EntidadLexico(int numero, string token, string descripcion, string linea)
        {
            Numero = numero;
            Token = token;
            Descripcion = descripcion;
            Linea = linea;
        }
    }
}
