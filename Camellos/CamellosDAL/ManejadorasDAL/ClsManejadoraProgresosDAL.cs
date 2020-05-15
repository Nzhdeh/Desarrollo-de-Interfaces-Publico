using CamellosDAL.Conexion;
using CamellosET;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamellosBL.ManejadorasBL
{
    public class ClsManejadoraProgresosDAL
    {
        /// <summary>
        /// prototipo: public int ObtenerUltimoProgresoDAL(string nick)
        /// comentarios: sirve para obtener el último progreso de un jugador
        /// precondiciones: no hay
        /// </summary>
        /// <param name="nick">cadena</param>
        /// <returns>un entero</returns>
        /// postcondiciones: asociado a nombre devuelve el id de la última prueba o un 0 si no ha hecho ningún progreso aún
        public int ObtenerUltimoProgresoDAL(string nick)
        {
            int idPrueba = 0;

            ClsMyConnection miConexion = null;

            SqlCommand miComando = new SqlCommand();
            SqlConnection conexion = null;
            SqlDataReader miLector = null;
            miConexion = new ClsMyConnection();
            miComando.Parameters.Add("@nick", System.Data.SqlDbType.VarChar).Value = nick;

            if (nick != null)
            {
                try
                {
                    conexion = miConexion.getConnection();

                    miComando.CommandText = "select top 1 PJ.idPrueba from CJ_Jugadores as J " +
                        "inner join CJ_PruebasJugadores as PJ on J.idJugador=PJ.idJugador " +
                        "where J.nick=@nick " +
                        "order by PJ.idPrueba desc";

                    //miComando.CommandText = "select top 1 * from CJ_Jugadores";

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
            }

           
            return idPrueba;
        }

        /// <summary>
        /// prototipo: public int InsertarProgresoDAL(ClsPruebaJugador clsPruebaJugador)
        /// comentarios: sirve para insertar un progreso
        /// precondiciones: los datos de entrada tienen que ser correctos
        /// </summary>
        /// <param name="clsPruebaJugador">ClsPruebaJugador</param>
        /// <returns>un entero</returns>
        /// postcondiciones: asociado a nombre devuelve un 1 si el progreso se ha insertado correctamente y un 0 si no
        public int InsertarProgresoDAL(ClsPruebaJugador clsPruebaJugador)
        {
            ClsMyConnection miConexion = null;

            int exito = 0;
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector = null;
            SqlConnection conexion = null;
            miConexion = new ClsMyConnection();

            miComando.Parameters.Add("@idJugador", System.Data.SqlDbType.Int).Value = clsPruebaJugador.IdJugador;
            miComando.Parameters.Add("@idPrueba", System.Data.SqlDbType.Int).Value = clsPruebaJugador.IdPrueba;
            miComando.Parameters.Add("@tiempo", System.Data.SqlDbType.VarChar).Value = clsPruebaJugador.TiemoJugador;

            miComando.CommandText = "INSERT INTO CJ_PruebasJugadores (idJugador,idPrueba,tiemoJugador) " +
                "VALUES (@idJugador, @idPrueba, @tiempo)";

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
