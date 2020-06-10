using CombateSuperheroesVillanosDAL.Conexion;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombateSuperheroesVillanosDAL.ManejadorasDAL
{
    public class ClsManejadoraCombatesDAL
    {
        /// <summary>
        /// prototipo: public int InsertarCombateDAL()
        /// comentarios: sirve para insertar un objeto combate a la bbdd
        /// precondiciones: no hay
        /// </summary>
        /// <returns>un entero</returns>
        /// postcondiciones: asociado a nombre devuelve un 1 si la palabra se ha insertado correctamente y un 0 si no o un SQLException si no hay conexion a internet 
        public int InsertarCombateDAL()
        {
            ClsMyConnection miConexion = null;
            
            int exito = 0;

            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector = null;
            SqlConnection conexion = null;
            miConexion = new ClsMyConnection();

            miComando.CommandText = "insert into SH_Combates(fechaCombate) values(cast(getdate() as date))";

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

        /// <summary>
        /// prototipo: public int InsertarLuchadorCombateDAL(int idCombate, int idLuchador, int puntuacionLuchador)
        /// comentarios: sirve para insertar los datos en la tabla intermedia SH_LuchadoresCombates
        /// precondiciones: los datos de entrada tienen que ser correctos
        /// </summary>
        /// <param name="idCombate">entero</param>
        /// <param name="idLuchador">entero</param>
        /// <param name="puntuacionLuchador">entero</param>
        /// <returns>un entero</returns>
        /// postcondiciones: asociado a nombre devuelve un 1 si los datos se han insertado correctamente y un 0 si no o un SQLException si no hay conexion a internet
        public int InsertarLuchadorCombateDAL(int idCombate, int idLuchador, int puntuacionLuchador)
        {
            ClsMyConnection miConexion = null;

            int exito = 0;

            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector = null;
            SqlConnection conexion = null;
            miConexion = new ClsMyConnection();

            miComando.Parameters.Add("@idCombate", System.Data.SqlDbType.Int).Value = idCombate;
            miComando.Parameters.Add("@idLuchador", System.Data.SqlDbType.Int).Value = idLuchador;
            miComando.Parameters.Add("@puntuacionLuchador", System.Data.SqlDbType.Int).Value = puntuacionLuchador;

            miComando.CommandText = "insert into SH_LuchadoresCombates(idCombate,idLuchador,puntuacionLuchador) values(@idCombate, @idLuchador, @puntuacionLuchador)";

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

        /// <summary>
        /// prototipo: public int ActualizarCombateDAL(int idLuchador, int puntuacion)
        /// comentarios: sirve para actualizar la puntuacion de un luchador
        /// precondiciones: los datos de entrada tienen que ser correctos
        /// </summary>
        /// <param name="idLuchador">entero</param>
        /// <param name="puntuacionLuchador">entero</param>
        /// <returns>un entero</returns>
        /// postcondiciones: asociado a nombre devuelve un 1 si se ha actualizado correctamente y un 0 si no o un SQLException si no hay conexion a internet
        public int ActualizarCombateDAL(int idLuchador, int puntuacionLuchador)
        {
            ClsMyConnection miConexion = null;

            int exito = 0;

            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector = null;
            SqlConnection conexion = null;
            miConexion = new ClsMyConnection();

            miComando.Parameters.Add("@idLuchador", System.Data.SqlDbType.Int).Value = idLuchador;
            miComando.Parameters.Add("@puntuacion", System.Data.SqlDbType.Int).Value = puntuacionLuchador;

            miComando.CommandText = "update SH_LuchadoresCombates " +
                                        "set puntuacionLuchador += @puntuacion " +
                                        "from SH_LuchadoresCombates as LC "+
                                        "inner join SH_Combates as C on LC.idCombate = C.idCombate " +
                                        "where LC.idLuchador = @idLuchador and C.fechaCombate = cast(getdate() as date) ";

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

        /// <summary>
        /// prototipo: public int ExisteCombateDAL(int idLuchador1,int idLuchador2)
        /// comentarios: sirve para ver si en un mismo día dos luchadores han tenido combate
        /// precondiciones: los datos de entrada tienen que ser correctos
        /// </summary>
        /// <param name="idLuchador1">entero</param>
        /// <param name="idLuchador2">entero</param>
        /// <returns>un entero</returns>
        /// postcondiciones: asociado a nombre devuelve el id del combate y un 0 si no o ha habido combate o un SQLException si no hay conexion a internet
        public int ExisteCombateDAL(int idLuchador1,int idLuchador2)
        {
            int idCombate = 0;
            ClsMyConnection miConexion = null;

            SqlCommand miComando = new SqlCommand();
            SqlConnection conexion = null;
            SqlDataReader miLector = null;
            miConexion = new ClsMyConnection();
            miComando.Parameters.Add("@idLuchador1", System.Data.SqlDbType.Int).Value = idLuchador1;
            miComando.Parameters.Add("@idLuchador2", System.Data.SqlDbType.Int).Value = idLuchador2;
           
            try
            {
                conexion = miConexion.getConnection();

                miComando.CommandText = "select C.idCombate from SH_Combates as C " +
                                        "inner join SH_LuchadoresCombates as LC on C.idCombate = LC.idCombate " +
                                        "inner join " +
                                                "( " +
                                                    "select C.idCombate from SH_Combates as C " +
                                                    "inner join SH_LuchadoresCombates as LC on C.idCombate = LC.idCombate " +
                                                    "where LC.idLuchador = @idLuchador1 and C.fechaCombate = cast(getdate() as date) " +
		                                        ") as idCombateLichador1 on LC.idCombate = idCombateLichador1.idCombate " +
                                        "where LC.idLuchador = @idLuchador2 and C.fechaCombate = cast(getdate() as date)";

                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    miLector.Read();

                    idCombate = (int)miLector["idCombate"];
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
            return idCombate;
        }

        /// <summary>
        /// prototipo: public int ObtenerUltimoIdCombateDAL()
        /// comentarios: sirve para obtener el id del último combate insertado
        /// precondiciones: no hay
        /// </summary>
        /// <returns>un entero</returns>
        /// postcondiciones: asociado a nombre devuelve el id del último combate o un 0 si no hay ningún combate o un SQLException si no hay conexion a internet
        public int ObtenerUltimoIdCombateDAL()
        {
            int idCombate = 0;

            ClsMyConnection miConexion = null;

            SqlCommand miComando = new SqlCommand();
            SqlConnection conexion = null;
            SqlDataReader miLector = null;
            miConexion = new ClsMyConnection();

            try
            {
                conexion = miConexion.getConnection();

                miComando.CommandText = "select top 1 idCombate from SH_Combates " +
                                        "order by idCombate desc";

                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    miLector.Read();

                    idCombate = (int)miLector["idCombate"];
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
            
            return idCombate;
        }

        /// <summary>
        /// prototipo: public void InsertarCombateOActualizarPuntuacionDAL(int idLuchador1, int idLuchador2, int puntuacionLuchador1, int puntuacionLuchador2)
        /// comentarios: sirve para insertar un combate nuevo y los datos de la tabla intermedia o actualizar la puntuacion de los luchadoeres
        /// precondiciones: los datos de entrada tienen que ser correctos
        /// </summary>
        /// <param name="idLuchador1">entero</param>
        /// <param name="idLuchador2">entero</param>
        /// <param name="puntuacionLuchador1">entero</param>
        /// <param name="puntuacionLuchador2">entero</param>
        /// <returns>un entero</returns>
        /// postcondiciones: devuelve SQLException si no hay conexion a internet
        public void InsertarCombateOActualizarPuntuacionDAL(int idLuchador1, int idLuchador2, int puntuacionLuchador1, int puntuacionLuchador2)
        {
            int idCombate = 0;

            try
            {
                idCombate = ExisteCombateDAL(idLuchador1, idLuchador2);

                if (idCombate > 0)
                {
                    ActualizarCombateDAL(idLuchador1, puntuacionLuchador1);
                    ActualizarCombateDAL(idLuchador2, puntuacionLuchador2);
                }
                else
                {
                    int insertar = InsertarCombateDAL();
                    if(insertar > 0)
                    {
                        idCombate = ObtenerUltimoIdCombateDAL();
                        InsertarLuchadorCombateDAL(idCombate, idLuchador1, puntuacionLuchador1);
                        InsertarLuchadorCombateDAL(idCombate, idLuchador2, puntuacionLuchador2);
                    }
                }
            }catch(SqlException e)
            {
                throw e;
            }            
        }
    }
}
