using ClasesLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    internal interface ICapaDatos
    {
        #region Gestion de Usuarios
        // Método que inserta el objeto Usuario si no existe
        // Retorna: true si se ha realizado correctamente a accion.
        bool InsertarUsuario(Usuario usuario);

        // Método que modifica el objeto Usuario si ya existe
        // Retorna: true si se ha realizado correctamente a accion.
        bool ModificarDatosUsuario(Usuario usuario);

        // Método que elimina el objeto Usuario
        // Retorna: true si se ha realizado correctamente a accion.
        bool EliminaUsuario(Usuario usuario);
        // Método que retorna el objeto Usuario a partir del email pasado
        // Retorna: Objeto Usuario o null
        Usuario ObtenerUsuario(string email);
        List<int> ObtenerIdEntradasPropiedadUsuario(Usuario usuario);
        List<int> ObtenerIdEntradasAccesoUsuario(Usuario usuario);
        List<string> ObtenerListaEmailUsuarios();

        // Método que retorna el número de usuarios
        // Retorna: Número de usuarios
        int NumeroUsuarios();
        #endregion

        #region Gestion de Entradas
        // Método que inserta el objeto Entrada si ya existe
        // Retorna: true si se ha realizado correctamente a accion.
        bool InsertaEntrada(Entrada entrada);
        // Método que modifica el objeto Entrada si ya existe
        // Retorna: true si se ha realizado correctamente a accion.
        bool EliminaEntrada(Entrada entrada);
        // Método que obtiene el objeto Entrada a partir del id pasado
        // Retorna: Objeto Entrada
        Entrada ObtenerEntrada(int idEntrada);
        int NumeroEntradas();
        #endregion

        #region Gestion de Accesos
        // Método que inserta el objeto Acceso si ya existe
        // Retorna: true si se ha realizado correctamente a accion.
        bool InsertaAcceso(Acceso acceso);
        // Método que obtiene el objeto Acceso a partir del id pasado
        // Retorna: Objeto Acceso
        Acceso ObtenerAcceso(int idAcceso);
        int NumeroAccesos();
        #endregion
    }
}