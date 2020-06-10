using InsertarPruebasYPalabrasCamellosDAL.Conexion;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertarPruebasYPalabrasCamellosDAL.ManejadorasDAL
{
    public class ClsManejadoraPruebaPalabraDAL
    {
        /// <summary>
        /// prototipo: public int InsertarPruebaPalabrasDAL(int idPrueba,int idPalabra)
        /// comentarios: sirve para insertar en la tabla intermedia de CJ_Palabras y CJ_Prueba
        /// precondiciones: los datos de entrada tienen que ser correctos
        /// </summary>
        /// <param name="idPrueba">entero</param>
        /// <param name="idPalabra">entero</param>
        /// <returns>un entero</returns>
        /// postcondiciones: asociado a nombre devuelve un 1 si los datos se han insertado correctamente y un 0 si no
        public int InsertarPruebaPalabrasDAL(int idPrueba,int idPalabra)
        {
            ClsMyConnection miConexion = null;

            int exito = 0;

            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector = null;
            SqlConnection conexion = null;
            miConexion = new ClsMyConnection();

            miComando.Parameters.Add("@idPrueba", System.Data.SqlDbType.Int).Value = idPrueba;
            miComando.Parameters.Add("@idPalabra", System.Data.SqlDbType.Int).Value = idPalabra;

            miComando.CommandText = "insert into CJ_PruebasPalabras (idPrueba,idPalabra) " +
                                        " VALUES (@idPrueba, @idPalabra)";

            try
            {
                conexion = miConexion.getConnection();
                miComando.Connection = conexion;
                exito = miComando.ExecuteNonQuery();
            }

            catch (SqlException exSql)
            {
                throw exSql;
            }
            finally
            {
                if (miLector != null)
                    miLector.Close();

                if (conexion != null)
                    miConexion.closeConnection(ref conexion);
            }
            return exito;
        }
    }
}
