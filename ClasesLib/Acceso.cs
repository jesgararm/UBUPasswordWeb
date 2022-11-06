using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesLib
{
    public class Acceso
    {
        private int idAcceso;
        private DateTime fechaAcceso;
        private Usuario usuario;
        private List<EntradaLog> entradasLog;

        public Acceso(Usuario usuario) 
        {
            this.idAcceso = 0;
            this.fechaAcceso = DateTime.Now;
            this.usuario = usuario;
            this.entradasLog = new List<EntradaLog>();
        }
        public int IdAcceso
        {
            get { return idAcceso; }
            set { idAcceso = value; }
        }
        public DateTime FechaAcceso
        {
            get { return fechaAcceso; }
            set { fechaAcceso = value; }
        }
        public Usuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
        public List<EntradaLog> EntradasLog
        {
            get { return entradasLog; }
            set { entradasLog = value; }
        }

        // Busca todos los logs que contengan la entrada pasada por parámetro.
        public List<EntradaLog> BuscarEntrada(Entrada entrada) {
            List<EntradaLog> listaEntradas = new List<EntradaLog>();
            
            foreach (EntradaLog entradaLog in entradasLog)
            {
                if (entradaLog.Entrada.IdEntrada == entrada.IdEntrada)
                {
                    listaEntradas.Add(entradaLog);
                }
            }
            return listaEntradas;
        }



    }
}
