using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Channels;
using ClasesLib;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace Datos
{
	public class BaseDatos : ICapaDatos
	{
		// estructuras para simular BBDD

		private int ultimoIdUsuario = 0;
		private int ultimoIdEntrada = 0;
		private int ultimoIdAccesoLog = 0;

		private Dictionary<int, Usuario> dicUsuario;
		private Dictionary<int, Acceso> dicLog;
		private Dictionary<int, Entrada> dicEntradas;

		public BaseDatos()
		{
			// inicializamos
			this.ultimoIdUsuario = 0;
			this.ultimoIdEntrada = 0;
			this.ultimoIdAccesoLog = 0;

			this.dicUsuario = new Dictionary<int, Usuario>();
			this.dicLog = new Dictionary<int, Acceso>();
			this.dicEntradas = new Dictionary<int, Entrada>();

			Usuario admin = new Usuario("admin@gmail.com", "admin", "admin", "admin",true);
			InsertarUsuario(admin);
            string ubicacion = GetAbsolutePath("..\\Datos\\Usuarios.csv");
            System.IO.StreamReader archivo = new System.IO.StreamReader(ubicacion);
			char separador = ';';
			string linea;
            
			while ((linea = archivo.ReadLine()) != null) 
			{
				string[] fila = linea.Split(separador);
                Usuario u = new Usuario(fila[0], fila[1], fila[2], fila[3]);
                InsertarUsuario(u);
            }
		}

		public bool InsertarUsuario(Usuario usuario)
		{
			// si el usuario no existe previamente.
			if (usuario.IdUsuario == 0 && this.ObtenerUsuario(usuario.Email) == null)
			{
				usuario.IdUsuario = ++this.ultimoIdUsuario;

				dicUsuario.Add(usuario.IdUsuario, usuario);

				return true;
            }

			return false;
		}

		public bool EliminaUsuario(Usuario usuario)
		{
			if (usuario == null || usuario.IdUsuario == 0)
				return false;

			// Eliminamos si existe
            if (dicUsuario.Remove(usuario.IdUsuario))
			{
				var lista = this.dicEntradas.Values.ToList();
                // Eliminamos el usuario de las entradas
                foreach (Entrada e in lista)
				{
					if (e.Usuario.IdUsuario == usuario.IdUsuario)
					{
						EliminaEntrada(e);
					}
					else
					{
						e.EliminarUsuario(usuario);
					}
				}
				return true;
			}
			return false;
		}

		public bool ModificarDatosUsuario(Usuario usuario)
		{
			if (usuario == null || !dicUsuario.ContainsKey(usuario.IdUsuario))
				return false;

			Usuario usuarioRecuperado = ObtenerUsuario(usuario.Email);

			if (usuarioRecuperado.IdUsuario != 0 && usuarioRecuperado.IdUsuario != usuario.IdUsuario)
				return false;

			usuarioRecuperado.Nombre = usuario.Nombre;
			usuarioRecuperado.Apellido = usuario.Apellido;

            dicUsuario[usuarioRecuperado.IdUsuario] = usuarioRecuperado;

			return true;
		}

		public Usuario ObtenerUsuario(string email)
		{
			foreach (Usuario u in this.dicUsuario.Values)
			{
				if (u.Email.Equals(email))
					return u;
			}
			return null;
		}

        public Entrada ObtenerEntrada(int idEntrada)
        {
			Entrada devolver;

			dicEntradas.TryGetValue(idEntrada,out devolver);

			return devolver;
        }

        public List<int> ObtenerIdEntradasPropiedadUsuario(Usuario usuario)
        {
            List<int> devolver = new List<int>();
            var entradas = this.dicEntradas.Values.Where(e => e.Usuario.IdUsuario == usuario.IdUsuario);

			foreach (Entrada e in entradas) 
			{
                devolver.Add(e.IdEntrada);
            }
			
            return devolver;
        }

        public List<int> ObtenerIdEntradasAccesoUsuario(Usuario usuario)
        {
            List<int> devolver = new List<int>();
            var entradas = this.dicEntradas.Values.Where(e => e.ExisteUsuario(usuario) == true);

            foreach (Entrada e in entradas)
            {
                devolver.Add(e.IdEntrada);
            }

            return devolver;
        }

        public List<string> ObtenerListaEmailUsuarios()
        {
			List<string> devolver = new List<string>();

            foreach (Usuario u in dicUsuario.Values)
            {
                devolver.Add(u.Email);
            }

            return devolver;
        }

        public bool InsertaEntrada(Entrada entrada)
		{
            // si la entrada no existe previamente.
            if (entrada.IdEntrada == 0 && ObtenerUsuario(entrada.Usuario.Email) != null)
            {
                entrada.IdEntrada = ++ultimoIdEntrada;

                dicEntradas.Add(entrada.IdEntrada, entrada);
				return true;
            }

            return false;
        }

		public bool EliminaEntrada(Entrada entrada)
		{
			return dicEntradas.Remove(entrada.IdEntrada);
		}

		public bool InsertaAcceso(Acceso acceso)
		{
            // si el acceso no tiene id.
            if (acceso.IdAcceso == 0)
            {
                acceso.IdAcceso = ++ultimoIdAccesoLog;

				dicLog.Add(acceso.IdAcceso, acceso);
				return true;
            }
			return false;
        }

		public Acceso ObtenerAcceso(int idAcceso)
		{
            Acceso devolver;
            dicLog.TryGetValue(idAcceso, out devolver);

            return devolver;
        }

		public int NumeroUsuarios()
		{
            return dicUsuario.Count;
        }

        public int NumeroEntradas()
        {
            return dicEntradas.Count;
        }
        public int NumeroAccesos()
        {
            return dicLog.Count;
        }

		public bool ModificarUsuario(Usuario usuario)
		{
			throw new NotImplementedException();
		}

        // Obtiene la ruta absoluta a un fichero
        private string GetAbsolutePath(string relativePath)
		{
            
			string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
			int lastIndex = path.LastIndexOf("bin", StringComparison.OrdinalIgnoreCase);
            string actualPath = path.Substring(0, lastIndex);
            string projectPath = new Uri(actualPath).LocalPath;
            string absolutePath = projectPath + relativePath;

			return absolutePath;
            
        }
    }
}

