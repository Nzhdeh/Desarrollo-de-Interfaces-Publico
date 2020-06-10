using InsertarPruebasYPalabrasCamellosDAL.ManejadorasDAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertarPruebasYPalabrasCamellosBL.ManejadorasBL
{
    public class ClsManejadoraPruebaPalabraBL
    {
        /// <summary>
        /// prototipo: public int InsertarPruebaPalabrasDAL(int idPrueba,int idPalabra)
        /// comentarios: sirve para insertar en la tabla intermedia de CJ_Palabras y CJ_Prueba
        /// precondiciones: los datos de entrada tienen que ser correctos
        /// </summary>
        /// <param name="idPrueba">entero</param>
        /// <param name="idPalabra">entero</param>
        /// <returns>un entero</returns>
        /// postcondiciones: asociado a nombre devuelve un 1 si los datos se han insertado correctamente y un 0 si no
        public int InsertarPruebaPalabrasDAL(int idPrueba, int idPalabra)
        {
            int exito = 0;

            try
            {
                exito = new ClsManejadoraPruebaPalabraDAL().InsertarPruebaPalabrasDAL(idPrueba, idPalabra);
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }
            return exito;
        }
    }
}
