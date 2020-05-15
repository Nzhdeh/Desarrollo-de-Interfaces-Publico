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
    public class ClsManejadoraJugadorDAL
    {
        /// <summary>
        /// prototipo: public int RegistrarJugadorDAL(string nick, string contraseña)
        /// comentarios: sirve para insertar a un jugador nuevo
        /// precondiciones: no hay
        /// </summary>
        /// <param name="nick">cadena</param>
        /// <param name="contraseña">cadena</param>
        /// <returns>un entero</returns>
        /// postcondiciones:  asociado a nombre devuelve un 1 si el jugador se ha insertado correctamente y un 0 si no
        public int RegistrarJugadorDAL(string nick, string contraseña)
        {
            ClsMyConnection miConexion = null;

            int exito = 0;
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector = null;
            SqlConnection conexion = null;
            miConexion = new ClsMyConnection();

            //miComando.Parameters.Add("@idJugador", System.Data.SqlDbType.Int).Value = jugador.IdJugador;
            miComando.Parameters.Add("@nick", System.Data.SqlDbType.VarChar).Value = nick;
            
            miComando.Parameters.Add("@contraseña", System.Data.SqlDbType.VarChar).Value = contraseña;

            miComando.CommandText = "INSERT INTO CJ_Jugadores (nick, contraseña) " +
                                    "VALUES (@nick, @contraseña)";

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
        /// prototipo: public bool ComprobarNickYContraseñaCorrectosDAL(string nick,string contraseña)
        /// comentarios: sirve para comprobar si los datos que el usuario introduce para acceder al juego son correctos
        /// precondiciones: no hay
        /// </summary>
        /// <param name="nick">cadena </param>
        /// <param name="contraseña">cadena</param>
        /// <returns>un boolean</returns>
        /// postcondiciones: asociado a nombre devuelve true si el usuario es correcto y un false en caso contrario
        public bool ComprobarNickYContraseñaCorrectosDAL(string nick,string contraseña)
        {
            bool correcto = false;

            ClsMyConnection miConexion = null;

            SqlCommand miComando = new SqlCommand();
            SqlConnection conexion = null;
            miConexion = new ClsMyConnection();
            miComando.Parameters.Add("@nick", System.Data.SqlDbType.VarChar).Value = nick;
            miComando.Parameters.Add("@contraseña", System.Data.SqlDbType.VarChar).Value = contraseña;
            int hayCosas = 0;

            try
            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "select count(*) from CJ_Jugadores where nick = @nick and contraseña = @contraseña";

                miComando.Connection = conexion;
                if (nick != null && contraseña != null)
                {
                    hayCosas = (int)miComando.ExecuteScalar();
                }
                    
                if (hayCosas != 0)
                {
                    correcto = true;
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

            return correcto;
        }

        /// <summary>
        /// prototipo: public bool ExisteNickDAL(string nick)
        /// comentarios: sirve para comprobar si el nick ya existe
        /// precondiciones: no hay
        /// </summary>
        /// <param name="nick">cadena </param>
        /// <returns>un boolean</returns>
        /// postcondiciones:  asociado a nombre devuelve true si el nick existe y false si no
        public bool ExisteNickDAL(string nick)
        {
            bool correcto = false;

            ClsMyConnection miConexion = null;

            SqlCommand miComando = new SqlCommand();
            SqlConnection conexion = null;
            miConexion = new ClsMyConnection();
            miComando.Parameters.Add("@nick", System.Data.SqlDbType.VarChar).Value = nick;
            int hayCosas = 0;

            try
            {
                conexion = miConexion.getConnection();
                
                if (nick != null)
                {
                    miComando.CommandText = "select count(*) from CJ_Jugadores where nick = @nick";
                    miComando.Connection = conexion;

                    hayCosas = (int)miComando.ExecuteScalar();
                }

                if (hayCosas != 0)
                {
                    correcto = true;
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

            return correcto;
        }

        /// <summary>
        /// prototipo: public int ObtenerIdJugadorPorNickDAL(string nick)
        /// comentarios: sirve para obtener el id de un jugador por su nick
        /// precondiciones: no hay
        /// </summary>
        /// <param name="nick">cadena </param>
        /// <returns>un entero</returns>
        /// postcondiciones:  asociado a nombre devuelve el id de un jugador o un cero si el nick no es válido
        public int ObtenerIdJugadorPorNickDAL(string nick)
        {
            int id = 0;

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

                    miComando.CommandText = "select idJugador from CJ_Jugadores where nick = @nick";

                    miComando.Connection = conexion;
                    miLector = miComando.ExecuteReader();

                    //Si hay lineas en el lector
                    if (miLector.HasRows)
                    {
                        miLector.Read();

                        id = (int)miLector["idJugador"];
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
            return id;
        }
    }
}
