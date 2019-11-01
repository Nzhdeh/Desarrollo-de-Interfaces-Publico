using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_ExamenSorpresaNzhdehUWP.Models.Utilidades
{
    class ClsUtilListados
    {
        /// <summary>
        /// me da el listado de todas las marcas
        /// </summary>
        /// <returns></returns>
        public static List<ClsCocheMarca> listadoCompletoMarcas()
        {
            List<ClsCocheMarca> listado = new List<ClsCocheMarca>();

            listado.Add(new ClsCocheMarca(1,"Ford"));
            listado.Add(new ClsCocheMarca(2,"Renault"));
            listado.Add(new ClsCocheMarca(3,"Seat"));

            return listado;
        }

        /// <summary>
        /// me da el listado de todos los modelos de un coche 
        /// entradas: id da la marca
        /// </summary>
        /// <returns></returns>
        public static List<ClsCocheModelo> listadoCompletoModelos(int idMarca)
        {
            List<ClsCocheModelo> listado = new List<ClsCocheModelo>();

            switch(idMarca)
            {
                case 1:

                    listado.Add(new ClsCocheModelo(1, "Fiesta",idMarca));
                    listado.Add(new ClsCocheModelo(2, "Focus",idMarca));
                    listado.Add(new ClsCocheModelo(3, "Kuga",idMarca));

                    break;

                case 2:

                    listado.Add(new ClsCocheModelo(1, "Clio", idMarca));
                    listado.Add(new ClsCocheModelo(2, "Megane", idMarca));
                    listado.Add(new ClsCocheModelo(3, "Scenic", idMarca));

                    break;

                case 3:

                    listado.Add(new ClsCocheModelo(1, "Ibiza", idMarca));
                    listado.Add(new ClsCocheModelo(2, "Leon", idMarca));
                    listado.Add(new ClsCocheModelo(3, "Tarranco", idMarca));

                    break;
            }

            return listado;
        }
    }
}
