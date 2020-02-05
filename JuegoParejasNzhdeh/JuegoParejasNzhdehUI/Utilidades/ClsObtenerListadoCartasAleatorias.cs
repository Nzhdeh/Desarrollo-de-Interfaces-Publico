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
        /// <summary>
        /// sirve para obtener la lista de las cartas aleatorias
        /// </summary>
        /// <returns>Listado de cartas aleatorias</returns>
        public ObservableCollection<ClsCarta> obtenerListadoCartasAleatorias()
        {
            ObservableCollection<ClsCarta> listadoCartasAleatorias = null;
            listadoCartasAleatorias = new ObservableCollection<ClsCarta>();

            for (int i=0;i<6; i++)
            {
               
                listadoCartasAleatorias.Add(new ClsCarta(i+1, new Uri($"ms-appx:///Assets/Imagenes/Volteada{(i+1)}.jpg")));
                listadoCartasAleatorias.Add(new ClsCarta(i+1, new Uri($"ms-appx:///Assets/Imagenes/Volteada{(i+1)}.jpg")));
            }

            //a continuacion se barajan las cartas
            ObservableCollection<ClsCarta> arrDesordenado = new ObservableCollection<ClsCarta>();

            Random randNum = new Random();
            while (listadoCartasAleatorias.Count > 0)
            {
                int val = randNum.Next(0, listadoCartasAleatorias.Count - 1);
                arrDesordenado.Add(listadoCartasAleatorias[val]);
                listadoCartasAleatorias.RemoveAt(val);//elimina el elemento para que no se repitan
            }

            return arrDesordenado;
        }
    }
}
