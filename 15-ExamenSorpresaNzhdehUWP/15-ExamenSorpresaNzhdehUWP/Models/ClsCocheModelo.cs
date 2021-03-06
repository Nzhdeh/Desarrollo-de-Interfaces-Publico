﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_ExamenSorpresaNzhdehUWP.Models
{
    public class ClsCocheModelo
    {
        //las privadas en minuscula y las publicas en mayuscula
        private int id;
        private string modelo;
        private int idCocheMarca;

        public ClsCocheModelo()
        {
            this.id = 0;
            this.modelo = "";
            this.idCocheMarca = 0;
        }

        public ClsCocheModelo(int id, String marca,int idCocheMarca)
        {
            this.id = id;
            this.modelo = marca;
            this.idCocheMarca = idCocheMarca;
        }

        //propiedades publicas
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public String Modelo
        {
            get
            {
                return modelo;
            }
            set
            {
                modelo = value;
            }
        }

        public int IdCocheMarca
        {
            get
            {
                return idCocheMarca;
            }
            set
            {
                idCocheMarca = value;
            }
        }
    }
}
