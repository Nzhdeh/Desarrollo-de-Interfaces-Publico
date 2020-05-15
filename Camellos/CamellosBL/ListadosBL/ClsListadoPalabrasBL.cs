using CamellosDAL.ListadosDAL;
using CamellosET;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamellosBL.ListadosBL
{
    public class ClsListadoPalabrasBL
    {
        /// <summary>
        /// prototipo: public ObservableCollection<ClsPalabras> ObtenerPalabrasPorIdPruebaBL(int idPrueba)
        /// comentarios: sirve para obtener el listado de las palabras de una prueba
        /// precondiciones: no hay
        /// </summary>
        /// <param name="idPrueba">entero </param>
        /// <returns>ObservableCollection<ClsPalabras> palabras</returns>
        /// postcondiciones: asociado a nombre devuelve el listado de palabras de una prueba o un null si la prueba no tine palabras
        public ObservableCollection<ClsPalabras> ObtenerPalabrasPorIdPruebaBL(int idPrueba)
        {
            ObservableCollection<ClsPalabras> palabras = null;

            try
            {
                palabras = new ClsListadoPalabrasDAL().ObtenerPalabrasPorIdPruebaDAL(idPrueba);
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }

            return palabras;
        }
    }
}
