using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesLib
{   public class EntradaLog
    {
        // Atributos
        private Entrada entrada;
        private DateTime fechaEntrada;

        // Constructor
        public EntradaLog(Entrada entrada, DateTime fecha)
        {
            this.entrada = entrada;
            this.fechaEntrada = fecha;
        }
        // Getters y Setters
        public Entrada Entrada
        {
            get { return entrada; }
            set { entrada = value; }
        }
        public DateTime Fecha
        {
            get { return fechaEntrada; }
            set { fechaEntrada = value; }
        }
    }
}
