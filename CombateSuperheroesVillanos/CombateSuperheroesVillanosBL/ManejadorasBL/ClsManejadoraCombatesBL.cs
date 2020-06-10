using CombateSuperheroesVillanosDAL.ManejadorasDAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombateSuperheroesVillanosBL.ManejadorasBL
{
    public class ClsManejadoraCombatesBL
    {
        /// <summary>
        /// prototipo: public void InsertarCombateOActualizarPuntuacionBL(int idLuchador1, int idLuchador2, int puntuacionLuchador1, int puntuacionLuchador2)
        /// comentarios: sirve para insertar un combate nuevo y los datos de la tabla intermedia o actualizar la puntuacion de los luchadoeres
        /// precondiciones: los datos de entrada tienen que ser correctos
        /// </summary>
        /// <param name="idLuchador1">entero</param>
        /// <param name="idLuchador2">entero</param>
        /// <param name="puntuacionLuchador1">entero</param>
        /// <param name="puntuacionLuchador2">entero</param>
        /// <returns>un entero</returns>
        /// postcondiciones: devuelve SQLException si no hay conexion a internet
        public void InsertarCombateOActualizarPuntuacionBL(int idLuchador1, int idLuchador2, int puntuacionLuchador1, int puntuacionLuchador2)
        {
            try
            {
                new ClsManejadoraCombatesDAL().InsertarCombateOActualizarPuntuacionDAL(idLuchador1, idLuchador2, puntuacionLuchador1, puntuacionLuchador2);
            }
            catch (SqlException e)
            {
                throw e;
            }
        }
    }
}
