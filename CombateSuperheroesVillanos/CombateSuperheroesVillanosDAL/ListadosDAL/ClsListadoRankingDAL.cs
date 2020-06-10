using CombateSuperheroesVillanosDAL.Conexion;
using CombateSuperheroesVillanosUI.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombateSuperheroesVillanosDAL.ListadosDAL
{
    public class ClsListadoRankingDAL
    {
        /// <summary>
        /// prototipo:  public ObservableCollection<ClsRankingDTO> ObtenerListadoRankingDAL()
        /// comentarios: sirve para obtener el listado del ranking
        /// precondiciones: no hay
        /// </summary>
        /// <returns>ObservableCollection<ClsRankingDTO> rankings</returns>
        /// postcondiciones: asociado a nombre devuelve el listado del ranking o un null si no hay Ranking o un SQLException si no hay conexion
        public ObservableCollection<ClsRankingDTO> ObtenerListadoRankingDAL()
        {
            ObservableCollection<ClsRankingDTO> rankings = new ObservableCollection<ClsRankingDTO>();
            ClsRankingDTO ranking = null;

            ClsMyConnection miConexion = null;

            SqlCommand miComando = new SqlCommand();
            SqlConnection conexion = null;
            SqlDataReader miLector = null;
            miConexion = new ClsMyConnection();

            try
            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "select L.nombreLuchador,sum(LC.puntuacionLuchador) as puntuacion from SH_LuchadoresCombates as LC " +
                    "inner join SH_Luchadores as L on LC.idLuchador = L.idLuchador " +
                    "group by L.nombreLuchador " +
                    "order by puntuacion desc";

                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        ranking = new ClsRankingDTO();

                        if (!String.IsNullOrEmpty(miLector["nombreLuchador"].ToString()))
                        {
                            ranking.NombreLuchadorDTO = miLector["nombreLuchador"].ToString();
                        }

                        ranking.PuntuacionLuchadorDTO = (int)miLector["puntuacion"];

                        rankings.Add(ranking);
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

            return rankings;
        }
    }
}
