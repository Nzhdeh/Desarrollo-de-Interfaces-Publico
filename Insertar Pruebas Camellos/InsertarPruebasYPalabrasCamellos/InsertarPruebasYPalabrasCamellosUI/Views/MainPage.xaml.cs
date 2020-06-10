﻿using InsertarPruebasYPalabrasCamellosET;
using InsertarPruebasYPalabrasCamellosUI.ViewModels;
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

namespace InsertarPruebasYPalabrasCamellosUI
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
        /// <summary>
        /// sirve para mostrar el menú cuando se pulsa el botón derecho del ratón
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            ListView listView = (ListView)sender;
            if (this.listView.SelectedItem != null)//para cuando no haya nada seleccionado
            {
                menuFlyout.ShowAt(listView, e.GetPosition(listView));
                ClsPalabras palabra = (ClsPalabras)((FrameworkElement)e.OriginalSource).DataContext;//Recoge el contexto de datos de su fuente, en este caso el listview.
                this.listView.SelectedItem = palabra;
            }            
        }
    }
}
