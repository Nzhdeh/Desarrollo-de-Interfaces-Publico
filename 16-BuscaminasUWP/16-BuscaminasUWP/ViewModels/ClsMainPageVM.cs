using _16_BuscaminasUWP.Models;
using _16_BuscaminasUWP.Models.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _16_BuscaminasUWP.ViewModels
{
    public class ClsMainPageVM : INotifyPropertyChanged
    {
        //atributos privados
        private ClsCasilla casillaSeleccionada;
        private List<ClsCasilla> tablero;
        private int contAciertos;
        private String notificarGanadorPerdedor;


        public ClsMainPageVM()
        {
            this.tablero = ClsUtil.generarTablero()
;       }

        public ClsCasilla CasillaSeleccionada 
        {
            get 
            { 
                return casillaSeleccionada; 
            } 
            set 
            { 
                value = casillaSeleccionada;

                if (casillaSeleccionada != null)
                {
                    casillaSeleccionada.YaPulsada = true;
                }
            } 
        }

        public List<ClsCasilla> Tablero
        {
            get
            {
                return tablero;
            }
            //set
            //{
            //    value = tablero;
            //}
        }

        public int ContAciertis
        {
            get
            {
                return contAciertos;
            }
            set
            {
                value = contAciertos;
            }
        }

        public String NotificarGanadorPerdedor
        {
            get
            {
                return notificarGanadorPerdedor;
            }
            set
            {
                value = notificarGanadorPerdedor;
            }
        }
        //atributos publicos
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotificarCambioDePropiedad([CallerMemberName] string nombrePropiedad = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombrePropiedad));
        }
    }
}
