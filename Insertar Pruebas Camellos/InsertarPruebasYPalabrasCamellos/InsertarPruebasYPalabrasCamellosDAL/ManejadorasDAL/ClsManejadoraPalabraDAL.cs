using InsertarPruebasYPalabrasCamellosDAL.Conexion;
using InsertarPruebasYPalabrasCamellosET;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertarPruebasYPalabrasCamellosDAL.ManejadorasDAL
{
    public class ClsManejadoraPalabraDAL
    {
        /// <summary>
        /// prototipo: public int InsertarPalabraDAL(ClsPalabras palabra)
        /// comentarios: sirve para insertar un objeto palabra a la bbdd
        /// precondiciones: los datos de entrada tienen que ser correctos
        /// </summary>
        /// <param name="palabra">ClsPalabras</param>
        /// <returns>un entero</returns>
        /// postcondiciones: asociado a nombre devuelve un 1 si la palabra se ha insertado correctamente y un 0 si no
        public int InsertarPalabraDAL(ClsPalabras palabra)
        {
            ClsMyConnection miConexion = null;

            int exito = 0;

            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector = null;
            SqlConnection conexion = null;
            miConexion = new ClsMyConnection();

            miComando.Parameters.Add("@palabra", System.Data.SqlDbType.VarChar).Value = palabra.Palabra;
            miComando.Parameters.Add("@dificultad", System.Data.SqlDbType.Int).Value = palabra.Dificultad;

            miComando.CommandText = "insert into CJ_Palabras (palabra,dificultad) " +
                "values(@palabra, @dificultad)";

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
