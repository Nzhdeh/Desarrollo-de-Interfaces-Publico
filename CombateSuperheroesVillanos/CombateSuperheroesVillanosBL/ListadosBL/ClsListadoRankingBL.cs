using CombateSuperheroesVillanosDAL.ListadosDAL;
using CombateSuperheroesVillanosUI.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombateSuperheroesVillanosBL.ListadosBL
{
    public class ClsListadoRankingBL
    {
        /// <summary>
        /// prototipo:  public ObservableCollection<ClsRankingDTO> ObtenerListadoRankingBL()
        /// comentarios: sirve para obtener el listado del ranking
        /// precondiciones: no hay
        /// </summary>
        /// <returns>ObservableCollection<ClsRankingDTO> rankings</returns>
        /// postcondiciones: asociado a nombre devuelve el listado del ranking o un null si no hay Ranking o SQLException si no hay conexion
        public ObservableCollection<ClsRankingDTO> ObtenerListadoRankingBL()
        {
            ObservableCollection<ClsRankingDTO> rankings = new ObservableCollection<ClsRankingDTO>();
            

            try
            {
                rankings = new ClsListadoRankingDAL().ObtenerListadoRankingDAL();
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }

            return rankings;
        }
    }
}
