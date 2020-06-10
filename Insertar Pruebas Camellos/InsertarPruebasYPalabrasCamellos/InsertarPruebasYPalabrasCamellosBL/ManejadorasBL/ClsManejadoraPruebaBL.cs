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
    public class ClsManejadoraPruebaBL
    {
        /// <summary>
        /// prototipo: public int ObtenerIdUltimaPruebaBL()
        /// comentarios: sirve para obtener el id de la última prueba insertada
        /// precondiciones: no hay
        /// </summary>
        /// <returns>entero</returns>
        /// postcondiciones: asociado a nombre devuelve el id de la última prueba
        public int ObtenerIdUltimaPruebaBL()
        {
            int idPrueba = 0;

            try
            {
                idPrueba = new ClsManejadoraPruebaDAL().ObtenerIdUltimaPruebaDAL();
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }
            return idPrueba;
        }

        /// <summary>
        /// prototipo: public int InsertarPruebaBL(ClsPrueba prueba)
        /// comentarios: sirve para insertar una prueba a la bbdd
        /// precondiciones: los datos de entrada tienen que ser correctos
        /// </summary>
        /// <param name="prueba">ClsPrueba</param>
        /// <returns>un entero</returns>
        /// postcondiciones: asociado a nombre devuelve un 1 si la prueba se ha insertado correctamente y un 0 si no
        public int InsertarPruebaBL(ClsPrueba prueba)
        {
            int exito = 0;
            try
            {
                exito = new ClsManejadoraPruebaDAL().InsertarPruebaDAL(prueba);
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }
            return exito;
        }
    }
}
