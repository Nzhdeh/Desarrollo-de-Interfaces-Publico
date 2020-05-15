using CamellosDAL.ManejadorasDAL;
using CamellosET;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamellosBL.ManejadorasBL
{
    public class ClsManejadoraPruebaBL
    {
        /// <summary>
        /// prototipo: public ClsPrueba ObtenerPrimeraPruebaBL()
        /// comentarios: sirve para obtener la primera prueba
        /// precondiciones: no hay
        /// </summary>
        /// <returns>ClsPrueba</returns>
        /// postcondiciones: asociado a nombre devuelve un objeto prueba o un null si la prueba no existe
        public ClsPrueba ObtenerPrimeraPruebaBL()
        {
            ClsPrueba prueba = null;

            try
            {
                prueba = new ClsManejadoraPruebaDAL().ObtenerPrimeraPruebaDAL();
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }
            return prueba;
        }

        /// <summary>
        /// prototipo: public ClsPrueba ObtenerSiguentePruebaBL(int idPruebaAnterior)
        /// comentarios: sirve para obtener la siguente prueba 
        /// precondiciones: no hay
        /// </summary>
        /// <param name="idPruebaAnterior">entero</param>
        /// <returns>ClsPrueba</returns>
        /// postcondiciones: asociado a nombre devuelve un objeto prueba o un null si la prueba no existe
        public ClsPrueba ObtenerSiguentePruebaBL(int idPruebaAnterior)
        {
            ClsPrueba prueba = null;

            try
            {
                prueba = new ClsManejadoraPruebaDAL().ObtenerSiguentePruebaDAL(idPruebaAnterior);
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }
            
            return prueba;
        }
    }
}
