using InsertarPruebasYPalabrasCamellosDAL.Conexion;
using InsertarPruebasYPalabrasCamellosET;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertarPruebasYPalabrasCamellosDAL.ManejadorasDAL
{
    public class ClsManejadoraPruebaDAL
    {
        /// <summary>
        /// prototipo: public int ObtenerIdUltimaPruebaDAL()
        /// comentarios: sirve para obtener el id de la última prueba insertada
        /// precondiciones: no hay
        /// </summary>
        /// <returns>entero</returns>
        /// postcondiciones: asociado a nombre devuelve el id de la última prueba
        public int ObtenerIdUltimaPruebaDAL()
        {
            int idPrueba = 0;

            ClsMyConnection miConexion = null;

            SqlCommand miComando = new SqlCommand();
            SqlConnection conexion = null;
            SqlDataReader miLector = null;
            miConexion = new ClsMyConnection();

            try
            {
                conexion = miConexion.getConnection();

                miComando.CommandText = "select top 1 idPrueba from CJ_Pruebas order by idPrueba desc";

                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    miLector.Read();

                    idPrueba = (int)miLector["idPrueba"];
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
            return idPrueba;
        }


        /// <summary>
        /// prototipo: public int InsertarPruebaDAL(ClsPrueba prueba)
        /// comentarios: sirve para insertar una prueba a la bbdd
        /// precondiciones: los datos de entrada tienen que ser correctos
        /// </summary>
        /// <param name="prueba">ClsPrueba</param>
        /// <returns>un entero</returns>
        /// postcondiciones: asociado a nombre devuelve un 1 si la prueba se ha insertado correctamente y un 0 si no
        public int InsertarPruebaDAL(ClsPrueba prueba)
        {
            ClsMyConnection miConexion = null;

            int exito = 0;

            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector = null;
            SqlConnection conexion = null;
            miConexion = new ClsMyConnection();

            miComando.Parameters.Add("@numeroPalabras", System.Data.SqlDbType.Int).Value = prueba.NumeroPalabras;
            miComando.Parameters.Add("@tiempoMaximo", System.Data.SqlDbType.VarChar).Value = prueba.TiempoMaximo;

            miComando.CommandText = "insert into CJ_Pruebas (numeroPalabras,tiempoMaximo) " +
                "values(@numeroPalabras, @tiempoMaximo)";

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
