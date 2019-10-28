using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _14_Ejercicio3Tema9_Entities
{
   public class ClsPersona : INotifyPropertyChange
    {
        //atributos privados
        private string _nombre;//_ para todos los atributos privados
        private string _apellidos;
        //private DateTime _fechaNacimiento;

        //const por defecto
        public ClsPersona()
        {
            this._nombre = "No hay nombre";
            this._apellidos = "No hay apellidos";
            //this.fechaNacimiento = new DateTime();
        }

        //constr sobrecargado
        public ClsPersona(String nombre,String _apellidos)
        {
            this._nombre = nombre;
            this._apellidos = _apellidos;
            //this._fechaNacimiento = new DateTime(dia,mes,anio);
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
                _nombre = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("Nombre"));
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
                if (_apellidos != "")
                    _apellidos = value;
            }
        }

        //public DateTime fechaNacimiento
        //{
        //    get
        //    {
        //        return _fechaNacimiento;
        //    }
        //    set
        //    {
        //        _fechaNacimiento = value;
        //    }
        //}
    }

    //public event PropertyChangedEventHandler PropertyChanged;

    /// <summary>
    /// no funcionaaaaa
    /// </summary>
    public interface INotifyPropertyChange
    {

    }

    /// <summary>
    /// PropertyChanged no funciona
    /// </summary>
    /// <param name="propertyName"></param>
    //protected virtual void OnPropertyChanged(string propertyName)
    //{
    //    if (PropertyChanged != null)
    //    {
    //        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    //    }
    //}
}
