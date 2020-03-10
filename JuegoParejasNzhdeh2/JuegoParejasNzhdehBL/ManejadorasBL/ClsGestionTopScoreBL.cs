using JuegoParejasNzhdehDAL.ManejadorasDAL;
using JuegoParejasNzhdehET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoParejasNzhdehBL.ManejadorasBL
{
    public class ClsGestionTopScoreBL
    {
        /// <summary>
        /// este metodo sirve para insertar el resultado de la partida en la base de datos
        /// </summary>
        /// <param name="score"></param>
        /// <returns>devuelve un entero si todo va bien y un cero si no</returns>
        public int InsertarPuntuacionBL(ClsTopScore score)
        {
            int resultado = 0;

            ClsGestionTopScore gestoraDal = new ClsGestionTopScore();
            gestoraDal.InsertarPuntuacionDAL(score);

            return resultado;
        }
    }
}
