using CuestionarioCoronavirusDAL.Conexion;
using CuestionarioCoronavirusET;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace CuestionarioCoronavirusDAL.ListadosDAL
{
    public class ClsListadoPreguntasDAL
    {
        /// <summary>
        /// sirve para obtener el listado de las preguntas
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<ClsPregunta> ListadoCompletoPreguntasDAL()
        {
            ClsMyConnection miConexion = null;

            ObservableCollection<ClsPregunta> listadoPreguntas = new ObservableCollection<ClsPregunta>();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector = null;
            ClsPregunta oPregunta = null;
            SqlConnection conexion = null;
            miConexion = new ClsMyConnection();

            try
            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "select * from CV_Preguntas";

                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {

                        oPregunta = new ClsPregunta();

                        oPregunta.IdPregunta = (int)miLector["idPregunta"];

                        if (!String.IsNullOrEmpty(miLector["pregunta"].ToString()))
                        {
                            oPregunta.Pregunta = (string)miLector["pregunta"];
                        }

                        listadoPreguntas.Add(oPregunta);
                    }
                }
            }
            catch (SqlException exSql)
            {
                //if (miLector != null)
                //{
                //    //por si ay algun problema con la contraseña o el enlace de la bbdd o el nombre de usuario
                //    var dlg = new MessageDialog("Problemas de conexión. Inténtalo más tarde por favor");
                //    var res = dlg.ShowAsync();
                //}
                
                throw exSql;
            }
            finally
            {
                if (miLector != null)
                    miLector.Close();

                if (miConexion != null)
                    miConexion.closeConnection(ref conexion);
            }

            return listadoPreguntas;
        }
    }
}
