using JuegoParejasNzhdehET;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoParejasNzhdehUI.Utilidades
{
    public class ClsObtenerListadoCartasAleatorias
    {
        public ObservableCollection<ClsCarta> obtenerListadoCartasAleatorias()
        {
            ObservableCollection<ClsCarta> listadoCartasAleatorias = null;
            listadoCartasAleatorias = new ObservableCollection<ClsCarta>();

            for (int i=0;i<6; i++)
            {
               
                listadoCartasAleatorias.Add(new ClsCarta(i+1, new Uri($"ms-appx:///Assets/Imagenes/Volteada{(i+1)}.jpg")));
                listadoCartasAleatorias.Add(new ClsCarta(i+1, new Uri($"ms-appx:///Assets/Imagenes/Volteada{(i+1)}.jpg")));
            }

            //ObservableCollection<ClsCarta> arr = listadoCartasAleatorias;
            ObservableCollection<ClsCarta> arrDes = new ObservableCollection<ClsCarta>();

            Random randNum = new Random();
            while (listadoCartasAleatorias.Count > 0)
            {
                int val = randNum.Next(0, listadoCartasAleatorias.Count - 1);
                arrDes.Add(listadoCartasAleatorias[val]);
                listadoCartasAleatorias.RemoveAt(val);
            }

            return arrDes;
        }
    }
}
