using System.Configuration;

namespace GFranca.Logic.BL
{
    public class clsConexion
    {
        /// <summary>
        /// Trata de obtener la conexion a la Base de Datos
        /// </summary>
        /// <returns>CADENA DE CONEXION</returns>
        public string getConexion()
        {
            return ConfigurationManager.ConnectionStrings["Cnx"].ToString();
        }
    }
}
