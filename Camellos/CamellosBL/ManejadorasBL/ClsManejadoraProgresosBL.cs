using CamellosDAL.Conexion;
using CamellosET;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamellosBL.ManejadorasBL
{
    public class ClsManejadoraProgresosBL
    {
        /// <summary>
        /// prototipo: public int ObtenerUltimoProgresoBL(string nick)
        /// comentarios: sirve para obtener la último progreso de  un jugador
        /// precondiciones: no hay
        /// </summary>
        /// <param name="nick">cadena</param>
        /// <returns>un entero</returns>
        /// postcondiciones: asociado a nombre devuelve un el id de la última prueba o un 0 si no ha hecho ningún progreso aún
        public int ObtenerUltimoProgresoBL(string nick)
        {
            int idPrueba = 0;
            try
            {
                idPrueba = new ClsManejadoraProgresosDAL().ObtenerUltimoProgresoDAL(nick);
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }
            return idPrueba;
        }

        /// <summary>
        /// prototipo: public int InsertarProgresoBL(ClsPruebaJugador clsPruebaJugador)
        /// comentarios: sirve para insertar un progreso
        /// precondiciones: los datos de entrada tienen que ser correctos
        /// </summary>
        /// <param name="clsPruebaJugador">ClsPruebaJugador</param>
        /// <returns>un entero</returns>
        /// postcondiciones:  asociado a nombre devuelve un 1 si el progreso se ha insertado correctamente y un 0 si no
        public int InsertarProgresoBL(ClsPruebaJugador clsPruebaJugador)
        {
            int exito = 0;
            try
            {
                exito = new ClsManejadoraProgresosDAL().InsertarProgresoDAL(clsPruebaJugador);
            }

            catch (SqlException exSql)
            {
                throw exSql;
            }
            return exito;
        }
    }
}
