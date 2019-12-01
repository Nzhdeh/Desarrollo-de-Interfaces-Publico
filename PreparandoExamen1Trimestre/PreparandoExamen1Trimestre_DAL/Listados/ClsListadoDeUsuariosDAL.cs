using PreparandoExamen1Trimestre_DAL.Conexion;
using PreparandoExamen1Trimestre_ENTITIES;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreparandoExamen1Trimestre_DAL.Listados
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
                miComando.CommandText = "SELECT * FROM Usuarios";

                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oUsuario = new ClsUsuario();
                        oUsuario.IdUsuario = (int)miLector["id"];
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


            //try
            //{
            //    SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-68D7LR4\\SQLEXPRESS;Initial Catalog=ApuestasDeportivas;Integrated Security=True");
            //    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Usuarios", sqlConnection);
            //    DataTable dataTable = new DataTable();
            //    sqlDataAdapter.Fill(dataTable);

            //    foreach (DataRow row in dataTable.Rows)
            //    {
            //        oUsuario = new ClsUsuario();
            //        oUsuario.IdUsuario = (int)row["id"];
            //        oUsuario.Saldo = (double)row["saldo"];
            //        oUsuario.Correo = (string)row["correo"];
            //        oUsuario.Contrasenia = (string)row["contraseña"];
            //        oUsuario.IsAdmin = (bool)row["isAdmin"];
            //        listado.Add(oUsuario);
            //    }
            //}catch(Exception e)
            //{
            //    throw e;
            //}


            return (listado);
        }


        #endregion
    }
}
