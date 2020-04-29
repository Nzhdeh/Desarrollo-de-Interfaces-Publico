﻿using HospitalesSaturadosET;
using HospitalesSaturadosUI.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace HospitalesSaturadosUI.Views
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Acceso : Page
    {
        public Acceso()
        {
            this.InitializeComponent();
        }


        /// <summary>
        /// para que funcione el boton enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            var viewModel = (ClsAccesoVM)DataContext;
            
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                viewModel.EntrarCommand.Execute(null);//llamamos a la funcion sin parametro                
            }
        }
    }
}
