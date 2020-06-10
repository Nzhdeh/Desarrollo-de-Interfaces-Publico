using InsertarPruebasYPalabrasCamellosDAL.Conexion;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertarPruebasYPalabrasCamellosDAL.ListadosDAL
{
    public class ClsListadoUltimasNPalabrasDAL
    {
        /// <summary>
        /// prototipo: public List<int> ObtenerIdsDeUltimasNPalabrasDAL(int n)
        /// comentarios: sirve para obtener los n ultímos ids de la Tabla CJ_Palabras de la bbdd
        /// precondiciones: no hay
        /// </summary>
        /// <param name="n">entero</param>
        /// <returns>Lista de enteros</returns>
        /// postcondiciones: asociado a nombre devuelve la lista de los ids de los últimos n registros de la tabla CJ_Palabras o 
        /// un null si el dato de entrada no es válido
        public List<int> ObtenerIdsDeUltimasNPalabrasDAL(int n)
        {
            List<int> ids = null;

            ClsMyConnection miConexion = null;

            SqlCommand miComando = new SqlCommand();
            SqlConnection conexion = null;
            SqlDataReader miLector = null;
            miConexion = new ClsMyConnection();

            miComando.Parameters.Add("@n", System.Data.SqlDbType.Int).Value = n;
            

            if (n > 0)
            {
                try
                {
                    conexion = miConexion.getConnection();

                    miComando.CommandText = "select top (@n) idPalabra from CJ_Palabras order by idPalabra desc";

                    miComando.Connection = conexion;
                    miLector = miComando.ExecuteReader();

                    ids = new List<int>();

                    if (miLector.HasRows)
                    {
                        while (miLector.Read())
                        {
                            ids.Add((int)miLector["idPalabra"]);
                        }
                    }
                }
                catch (SqlException exSql)
                {
                    throw exSql;
                }
                finally
                {
                    if (conexion != null)
                        miConexion.closeConnection(ref conexion);
                }
            }

            return ids;
        }
    }
}
