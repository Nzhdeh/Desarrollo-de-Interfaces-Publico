using CamellosDAL.Conexion;
using CamellosET;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamellosDAL.ManejadorasDAL
{
    public class ClsManejadoraPruebaDAL
    {
        /// <summary>
        /// prototipo: public ClsPrueba ObtenerPrimeraPruebaDAL()
        /// comentarios: sirve para obtener la primera prueba
        /// precondiciones: no hay
        /// </summary>
        /// <returns>ClsPrueba</returns>
        /// postcondiciones: asociado a nombre devuelve un objeto prueba o un null si la prueba no existe
        public ClsPrueba ObtenerPrimeraPruebaDAL()
        {
            ClsPrueba prueba = null;

            ClsMyConnection miConexion = null;

            SqlCommand miComando = new SqlCommand();
            SqlConnection conexion = null;
            SqlDataReader miLector = null;
            miConexion = new ClsMyConnection();

            try
            {
                conexion = miConexion.getConnection();

                miComando.CommandText = "select top 1 * from CJ_Pruebas";

                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    miLector.Read();

                    prueba = new ClsPrueba();

                    prueba.IdPrueba = (int)miLector["idPrueba"];
                    prueba.NumeroPalabras = (int)miLector["numeroPalabras"];
                    prueba.TiempoMaximo = miLector["tiempoMaximo"].ToString();
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
            return prueba;
        }

        /// <summary>
        /// prototipo: public ClsPrueba ObtenerSiguentePruebaDAL(int idPruebaAnterior)
        /// comentarios: sirve para obtener la siguente prueba 
        /// precondiciones: no hay
        /// </summary>
        /// <param name="idPruebaAnterior">entero</param>
        /// <returns>ClsPrueba</returns>
        /// postcondiciones: asociado a nombre devuelve un objeto prueba o un null si la prueba no existe
        public ClsPrueba ObtenerSiguentePruebaDAL(int idPruebaAnterior)
        {
            ClsPrueba prueba = null;

            ClsMyConnection miConexion = null;

            SqlCommand miComando = new SqlCommand();
            SqlConnection conexion = null;
            SqlDataReader miLector = null;
            miConexion = new ClsMyConnection();
            miComando.Parameters.Add("@idPrueba", System.Data.SqlDbType.Int).Value = idPruebaAnterior;

            try
            {
                conexion = miConexion.getConnection();

                miComando.CommandText = "select top 1 * from CJ_Pruebas where idPrueba > @idPrueba";

                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    miLector.Read();

                    prueba = new ClsPrueba();

                    prueba.IdPrueba = (int)miLector["idPrueba"];
                    prueba.NumeroPalabras = (int)miLector["numeroPalabras"];
                    prueba.TiempoMaximo = miLector["tiempoMaximo"].ToString();
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
            return prueba;
        }
    }
}
