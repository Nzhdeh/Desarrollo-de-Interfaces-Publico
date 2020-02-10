using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenAnimacionesUWPET
{
    public class ClsPrediccion
    {
        private int idCiudad;
        private DateTime fecha;
        private double temperaturaMaxima;
        private double temperaturaMinima;
        private double humedad;
        private string pronostico;

        public ClsPrediccion()
        {
            this.idCiudad=0;
            this.fecha = new DateTime();
            this.temperaturaMaxima=0.0;
            this.temperaturaMinima=0.0;
            this.humedad=0.0;
            this.pronostico = "default";
        }
        public ClsPrediccion(int idCiudad,DateTime fecha, double temperaturaMaxima, 
            double temperaturaMinima, double humedad,string pronostico)
        {
            this.idCiudad = idCiudad;
            this.fecha = fecha.Date;
            this.temperaturaMaxima = temperaturaMaxima;
            this.temperaturaMinima = temperaturaMinima;
            this.humedad = humedad;
            this.pronostico = pronostico;
        }

        public int IdCiudad
        {
            get
            {
                return idCiudad;
            }
            set
            {
                idCiudad = value;
            }
        }

        public DateTime Fecha
        {
            get
            {
                return fecha;
            }
            set
            {
                fecha = value;
            }
        }

        public double TemperaturaMaxima
        {
            get
            {
                return temperaturaMaxima;
            }
            set
            {
                temperaturaMaxima = value;
            }
        }


        public double TemperaturaMinima
        {
            get
            {
                return temperaturaMinima;
            }
            set
            {
                temperaturaMinima = value;
            }
        }

        public double Humedad
        {
            get
            {
                return humedad;
            }
            set
            {
                humedad = value;
            }
        }

        public string Pronostico
        {
            get
            {
                return pronostico;
            }
            set
            {
                pronostico = value;
            }
        }
    }
}
