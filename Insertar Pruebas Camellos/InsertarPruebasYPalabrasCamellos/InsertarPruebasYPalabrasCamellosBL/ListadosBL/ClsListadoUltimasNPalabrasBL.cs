using InsertarPruebasYPalabrasCamellosDAL.ListadosDAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertarPruebasYPalabrasCamellosBL.ListadosBL
{
    public class ClsListadoUltimasNPalabrasBL
    {
        /// <summary>
        /// prototipo: public List<int> ObtenerIdsDeUltimasNPalabrasBL(int n)
        /// comentarios: sirve para obtener los n ultímos ids de la Tabla CJ_Palabras de la bbdd
        /// precondiciones: no hay
        /// </summary>
        /// <param name="n">entero</param>
        /// <returns>Lista de enteros</returns>
        /// postcondiciones: asociado a nombre devuelve la lista de los ids de los últimos n registros de la tabla CJ_Palabras o 
        /// un null si el dato de entrada no es válido
        public List<int> ObtenerIdsDeUltimasNPalabrasBL(int n)
        {
            List<int> ids = null;

            try
            {
                ids = new ClsListadoUltimasNPalabrasDAL().ObtenerIdsDeUltimasNPalabrasDAL(n);
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }

            return ids;
        }
    }
}
