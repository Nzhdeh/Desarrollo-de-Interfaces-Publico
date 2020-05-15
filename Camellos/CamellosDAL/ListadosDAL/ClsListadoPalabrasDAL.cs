using CamellosDAL.Conexion;
using CamellosET;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamellosDAL.ListadosDAL
{
    public class ClsListadoPalabrasDAL
    {
        /// <summary>
        /// prototipo: public ObservableCollection<ClsPalabras> ObtenerPalabrasPorIdPruebaDAL(int idPrueba)
        /// comentarios: sirve para obtener el listado de las palabras de una prueba
        /// precondiciones: el id tiene que ser válido
        /// </summary>
        /// <param name="idPrueba">entero </param>
        /// <returns>ObservableCollection<ClsPalabras> palabras</returns>
        /// postcondiciones: asociado a nombre devuelve el listado de palabras de una prueba o un null si la prueba no tine palabras
        public ObservableCollection<ClsPalabras> ObtenerPalabrasPorIdPruebaDAL(int idPrueba)
        {
            ObservableCollection<ClsPalabras> palabras = new ObservableCollection<ClsPalabras>();
            ClsPalabras palabra = null;

            ClsMyConnection miConexion = null;

            SqlCommand miComando = new SqlCommand();
            SqlConnection conexion = null;
            SqlDataReader miLector = null;
            miConexion = new ClsMyConnection();
            miComando.Parameters.Add("@idPrueba", System.Data.SqlDbType.Int).Value = idPrueba;

            try
            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "select P.idPalabra, P.palabra, P.dificultad from CJ_Palabras as P " +
                    "inner join CJ_PruebasPalabras as PP on P.idPalabra = PP.idPalabra " +
                    "where PP.idPrueba = @idPrueba";

                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        palabra = new ClsPalabras();

                        palabra.IdPalabra = (int)miLector["idPalabra"];

                        if (!String.IsNullOrEmpty(miLector["palabra"].ToString()))
                        {
                            palabra.Palabra = miLector["palabra"].ToString();
                        }

                        palabra.Dificultad = (Byte)miLector["dificultad"];

                        palabras.Add(palabra);
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

            return palabras;
        }
    }
}
