using _08_Grid.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace _08_Grid
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        //Se programa el boton Send

        public void Send_Click(Object sender, RoutedEventArgs r)
        {
            Boolean hacerlo = true;
            ClsPersona p = new ClsPersona();

            if (String.IsNullOrWhiteSpace(nombre.Text))
            {
                nombreError.Text = "El nombre no debe estar vacio";
                hacerlo = false;
            }
            else
            {
                nombreError.Text = "";
            }
            if (String.IsNullOrWhiteSpace(apellidos.Text))
            {
                apellidosError.Text = "Los apellidos no deben estar vacio";
                hacerlo = false;
            }
            else
            {
                apellidosError.Text = "";
            }

            //if (!IsDate(fecha.Text))
            DateTime temp;
            DateTime fechaHoy = DateTime.Now;
            if (!DateTime.TryParse(data.Text, out temp))
            {
                fechaNacimientoError.Text = "La fecha es erronea";
                hacerlo = false;
            }
            else
            {
                if (fechaHoy.CompareTo(temp) < 0)
                {
                    fechaNacimientoError.Text = "Fecha posterior a la fecha actual";
                    hacerlo = false;
                }
                else
                {
                    fechaNacimientoError.Text = "";
                }
            }

            if (hacerlo)
            {
                p.nombre = nombre.Text;
                p.apellidos = apellidos.Text;
                p.fechaNacimiento = temp;
            }
        }
    }
}
