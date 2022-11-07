﻿using System;
using System.Collections.Generic;
using System.Linq;
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
			string ubicacion = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\Datos\\Usuarios.csv");
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

		public bool ModificarUsuario(Usuario usuario)
		{
			if (!dicUsuario.ContainsKey(usuario.IdUsuario))
				return false;

			dicUsuario[usuario.IdUsuario] = usuario;

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
			Entrada devolver = null;

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
            Acceso devolver = null;
            dicLog.TryGetValue(idAcceso, out devolver);

            return devolver;
        }

		public int NumeroUsuarios()
		{
            return dicUsuario.Count;
        }
	}
}

