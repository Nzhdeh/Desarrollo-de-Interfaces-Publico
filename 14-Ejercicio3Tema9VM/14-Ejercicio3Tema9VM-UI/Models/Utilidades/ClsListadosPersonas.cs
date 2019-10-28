using _14_Ejercicio3Tema9_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_Ejercicio3Tema9VM_UI.Models.Utilidades
{
    class ClsListadosPersonas
    {
        public static List<ClsPersona> listadoCompletoDePersonas()
        {
            List<ClsPersona> listado = new List<ClsPersona>();

            listado.Add(new ClsPersona("Nzhdeh", "Yeghiazaryan"));
            listado.Add(new ClsPersona("Dani", "Gordillo"));
            listado.Add(new ClsPersona("Angela", "Vazquez"));

            return listado;
        }
    }
}
