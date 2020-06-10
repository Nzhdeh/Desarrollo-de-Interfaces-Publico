using InsertarPruebasYPalabrasCamellosDAL.ManejadorasDAL;
using InsertarPruebasYPalabrasCamellosET;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertarPruebasYPalabrasCamellosBL.ManejadorasBL
{
    public class ClsManejadoraPalabraBL
    {
        /// <summary>
        /// prototipo: public int InsertarPalabraBL(ClsPalabras palabra)
        /// comentarios: sirve para insertar un objeto palabra a la bbdd
        /// precondiciones: los datos de entrada tienen que ser correctos
        /// </summary>
        /// <param name="palabra">ClsPalabras</param>
        /// <returns>un entero</returns>
        /// postcondiciones: asociado a nombre devuelve un 1 si la palabra se ha insertado correctamente y un 0 si no
        public int InsertarPalabraBL(ClsPalabras palabra)
        {
            int exito = 0;

            try
            {
                exito = new ClsManejadoraPalabraDAL().InsertarPalabraDAL(palabra);
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }
            return exito;
        }
    }
}
