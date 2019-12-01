using PreparandoExamen02_12_2019_DAL.Conexion;
using PreparandoExamen02_12_2019_ENTITIES;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreparandoExamen02_12_2019_DAL.Listado
{
    public class ClsListadoDeUsuariosDAL
    {
        #region Metodos
        /// <summary>
        /// Metodo que nos devuelve el listado de todos los usuarios
        /// </summary>
        /// <returns>
        /// listado de usuarios
        /// </returns>
        public ObservableCollection<ClsUsuario> ObtenerListadoUsuariosDAL()
        {
            ClsMyConnection miConexion;

            ObservableCollection<ClsUsuario> listado = new ObservableCollection<ClsUsuario>();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            ClsUsuario oUsuario;

            SqlConnection conexion;


            miConexion = new ClsMyConnection();
            try
            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "SELECT * FROM casas";

                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oUsuario = new ClsUsuario();
                        oUsuario.IdUsuario= (int)miLector["id"];
                        oUsuario.Saldo = (double)miLector["saldo"];
                        oUsuario.Correo = (string)miLector["correo"];
                        oUsuario.Contrasenia = (string)miLector["contraseña"];
                        oUsuario.IsAdmin = (bool)miLector["isAdmin"];
                        listado.Add(oUsuario);
                    }
                }

                miLector.Close();
                miConexion.closeConnection(ref conexion);
            }

            catch (SqlException exSql)
            {
                throw exSql;
            }

            return (listado);
        }


        #endregion
    }
}
