using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_Grid.Models
{
   public class ClsPersona
    {
        //atributos privados
        private string _nombre;//_ para todos los atributos privados
        private string _apellidos;
        private DateTime _fechaNacimiento;

        //const por defecto
        public ClsPersona()
        {
            this.nombre = "No hay nombre";
            this.apellidos = "No hay apellidos";
            this.fechaNacimiento = new DateTime();
        }

        //constr sobrecargado
        public ClsPersona(String nombre, String apellidos, int dia,int mes,int anio)
        {
            this._nombre = nombre;
            this._apellidos = apellidos;
            this._fechaNacimiento = new DateTime(dia,mes,anio);
        }

        //propiedades publicas
        public string nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                if (_nombre != "")
                    _nombre = value;
            }
        }

        public string apellidos
        {
            get
            {
                return _apellidos;
            }
            set
            {
                if(_apellidos!="")
                _apellidos = value;
            }
        }

        public DateTime fechaNacimiento
        {
            get
            {
                return _fechaNacimiento;
            }
            set
            {
                _fechaNacimiento = value;
            }
        }
    }
}
