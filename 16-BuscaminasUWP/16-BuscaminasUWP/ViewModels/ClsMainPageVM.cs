using _16_BuscaminasUWP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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



        //atributos publicos
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
