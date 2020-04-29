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
    public class ClsListadoRespuestasDAL
    {
        /// <summary>
        /// sirve para obtener las respuestas de una pregunta por su id
        /// </summary>
        /// <param name="id">id de la pregunta</param>
        /// <returns>listasdo de respuestas de una pregunta</returns>
        
        public ObservableCollection<ClsRespuesta> ListadoRespuestasPorPreguntaDAL(int id)
        {
            ClsMyConnection miConexion = null;

            ObservableCollection<ClsRespuesta> listadoRespuestas = new ObservableCollection<ClsRespuesta>();

            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector = null;
            ClsRespuesta oRespuesta = null;
            SqlConnection conexion = null;
            miConexion = new ClsMyConnection();

            try
            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "select * from CV_Respuestas where idPregunta = "+id;

                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {

                        oRespuesta = new ClsRespuesta();

                        oRespuesta.IdRespuesta = (int)miLector["idRespuesta"];
                        oRespuesta.IdPregunta = (int)miLector["idPregunta"];

                        if (!String.IsNullOrEmpty(miLector["respuesta"].ToString()))
                        {
                            oRespuesta.Respuesta = (string)miLector["respuesta"];
                        }

                        oRespuesta.PosibleCaso = bool.Parse((String)miLector["posibleCaso"]);
                        

                        listadoRespuestas.Add(oRespuesta);
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

            return listadoRespuestas;
        }
    }
}
