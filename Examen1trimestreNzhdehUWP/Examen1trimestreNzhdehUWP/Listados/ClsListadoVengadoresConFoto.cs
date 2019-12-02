using Examen1trimestreNzhdehUWP.Conexion;
using Examen1trimestreNzhdehUWP.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1trimestreNzhdehUWP.Listados
{
    public class ClsListadoVengadoresConFoto
    {
        /// <summary>
        /// sirve para devolver el listado de todos los vengadores con sus fotos incluidos
        /// </summary>
        /// <returns>
        /// asociado al nombre devuelve la lista de los vengadores con sus fotos
        /// </returns>
        public List<ClsVengadorConFoto> ListadoCompletoVengadoresConFoto()
        {
            ClsMyConnection miConexion = null;

            List<ClsVengadorConFoto> listadoVengadoresConFoto = new List<ClsVengadorConFoto>();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector = null;

            ClsVengadorConFoto oVengadores = null;

            SqlConnection conexion = null;


            miConexion = new ClsMyConnection();
            try
            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "SELECT * FROM superheroes";

                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oVengadores = new ClsVengadorConFoto();
                        oVengadores.IdSuperheroe = (int)miLector["idSuperheroe"];
                        oVengadores.NombreSuperheroe = (string)miLector["nombreSuperheroe"];
                        oVengadores.asignarImagen();
                        listadoVengadoresConFoto.Add(oVengadores);
                    }
                }
            }

            catch (SqlException exSql)
            {
                throw exSql;
            }
            finally
            {
                if (miLector != null)
                    miLector.Close();

                if (miConexion != null)
                    miConexion.closeConnection(ref conexion);
            }

            return listadoVengadoresConFoto;
        }
    }
}
