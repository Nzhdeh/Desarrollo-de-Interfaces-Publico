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
using Windows.Devices.Geolocation;
using Windows.UI.Xaml.Controls.Maps;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace SolarizrApp
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Map.Loaded += Mapsample_Loaded;
        }

        /// <summary>
        /// este método nos muestra el mapa de Sevilla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Mapsample_Loaded(object sender, RoutedEventArgs e)
        {

            var center =
                new Geopoint(new BasicGeoposition()
                {
                    //latitud y longitud de la capital de armenia y los que estan en comentario son de sevilla
                    Latitude = 40.1811104 /*37.3828300*/,
                    Longitude = 44.5136108//-5.9731700

                });
            await Map.TrySetSceneAsync(MapScene.CreateFromLocationAndRadius(center, 3000));
        }
        
        /// <summary>
        /// sirve para volver a la pantalla anterior
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));//hay que poner lo de Rafa
        }

        /// <summary>
        /// sirve para ir a la pantalla de notas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PantallaAngela_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));//esto va a la pantalla siguentee
        }
    }
}
