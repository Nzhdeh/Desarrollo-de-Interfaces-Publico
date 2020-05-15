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
    public class ClsListadoProgresosDAL
    {
        /// <summary>
        /// prototipo: public ObservableCollection<ClsParaListadoProgresos> ObtenerProgresosPorJugadorDAL(int id)
        /// comentarios: sirve para obtener el listado de progresos de un jugador 
        /// precondiciones: el id tiene que ser correcto
        /// </summary>
        /// <param name="id">entero </param>
        /// <returns>ObservableCollection<ClsParaListadoProgresos> progresos</returns>
        /// postcondiciones: asociado a nombre devuelve el listado de progresos de un jugador
        public ObservableCollection<ClsParaListadoProgresos> ObtenerProgresosPorJugadorDAL(int id)
        {
            ObservableCollection<ClsParaListadoProgresos> progresos = new ObservableCollection<ClsParaListadoProgresos>();
            ClsParaListadoProgresos progreso = null;
            int contadorProgresos = 0;

            ClsMyConnection miConexion = null;

            SqlCommand miComando = new SqlCommand();
            SqlConnection conexion = null;
            SqlDataReader miLector = null;
            miConexion = new ClsMyConnection();
            miComando.Parameters.Add("@idJugador", System.Data.SqlDbType.Int).Value = id;

            try
            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "select P.numeroPalabras,P.tiempoMaximo,PJ.tiemoJugador from CJ_Pruebas as P " +
                                        "inner join CJ_PruebasJugadores as PJ on P.idPrueba = PJ.idPrueba " +
                                        "where PJ.idJugador = @idJugador";

                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        progreso = new ClsParaListadoProgresos();
                        contadorProgresos++;
                        progreso.Prueba = contadorProgresos;

                        progreso.NumeroPalabras = (int)miLector["numeroPalabras"];

                        if (!String.IsNullOrEmpty(miLector["tiemoJugador"].ToString()))
                        {
                            progreso.TiempoJugador = miLector["tiemoJugador"].ToString();
                        }

                        if (!String.IsNullOrEmpty(miLector["tiempoMaximo"].ToString()))
                        {
                            progreso.TiempoMaximo = miLector["tiempoMaximo"].ToString();
                        }

                        progresos.Add(progreso);
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

            return progresos;
        }
    }
}
