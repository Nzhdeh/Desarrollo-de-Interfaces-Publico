using JuegoParejasRecuperacion_DAL.Conexion;
using JuegoParejasRecuperacion_ET;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoParejasRecuperacion_DAL.ListadosDAL
{
    public class ClsListadoRanking
    {
        /// <summary>
        /// sirve para obtener el listado de ranking del juego
        /// </summary>
        /// <returns>Listado de ranking</returns>
        public ObservableCollection<ClsTopScore> obtenerRanking()
        {
            ObservableCollection<ClsTopScore> scores = new ObservableCollection<ClsTopScore>();
            SqlConnection connection;
            ClsMyConnection myConnection;

            try
            {
                myConnection = new ClsMyConnection();
                connection = new SqlConnection();
                SqlCommand command = new SqlCommand();
                SqlDataReader miLector=null;
                ClsTopScore score=null;

                connection = myConnection.getConnection();
                command.CommandText = "Select * from TopScore Order by Tiempo asc";
                command.Connection = connection;
                miLector = command.ExecuteReader();

                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        score = new ClsTopScore();

                        score.IdPersona = (int)miLector["ID"];

                        if (!String.IsNullOrEmpty(miLector["NombrePersona"].ToString()))
                        {
                            score.NombrePersona = (String)miLector["NombrePersona"];
                        }

                        if (!String.IsNullOrEmpty(miLector["Tiempo"].ToString()))
                        {
                            score.Tiempo = miLector["Tiempo"].ToString();
                        }

                        scores.Add(score);
                    }
                }

                miLector.Dispose();
                myConnection.closeConnection(ref connection);
            }
            catch (SqlException)
            {
                throw;
            }

            return scores;
        }
    }
}
