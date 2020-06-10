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

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace CombateSuperheroesVillanosUI.Views
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Hamburguesa : Page
    {
        public Hamburguesa()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// sirve para expandir y encoger el menu hamburguesa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (hamburger.IsPaneOpen == true)
            {
                hamburger.IsPaneOpen = false;
            }
            else if (hamburger.IsPaneOpen == false)
            {
                hamburger.IsPaneOpen = true;
            }
        }

        /// <summary>
        /// sirve para navegar a la vista de Ranking cuando pulsa al icono correspondiente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            (hamburger.Content as Frame).Navigate(typeof(Ranking));
        }

        /// <summary>
        /// sirve para navegar a la vista de Puntuacion cuando pulsa al icono correspondiente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {
            (hamburger.Content as Frame).Navigate(typeof(Puntuacion));
        }

        /// <summary>
        /// sirve para ir a la vista de Puntuacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contenido_Loaded(object sender, RoutedEventArgs e)
        {
            contenido.Navigate(typeof(Puntuacion));
        }
    }
}
