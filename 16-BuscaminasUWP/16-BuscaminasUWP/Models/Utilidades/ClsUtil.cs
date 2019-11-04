using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_BuscaminasUWP.Models.Utilidades
{
    class ClsUtil
    {
        public static List<ClsCasilla> generarTablero()
        {
            List<ClsCasilla> tablero = new List<ClsCasilla>();

            tablero.Add(new ClsCasilla());
            tablero.Add(new ClsCasilla());
            tablero.Add(new ClsCasilla());
            tablero.Add(new ClsCasilla());
            tablero.Add(new ClsCasilla());
            tablero.Add(new ClsCasilla());
            tablero.Add(new ClsCasilla());
            tablero.Add(new ClsCasilla());
            tablero.Add(new ClsCasilla());
            tablero.Add(new ClsCasilla());
            tablero.Add(new ClsCasilla());
            tablero.Add(new ClsCasilla());
            tablero.Add(new ClsCasilla());
            tablero.Add(new ClsCasilla());
            tablero.Add(new ClsCasilla());
            tablero.Add(new ClsCasilla());

            return tablero;
        }
    }
}
