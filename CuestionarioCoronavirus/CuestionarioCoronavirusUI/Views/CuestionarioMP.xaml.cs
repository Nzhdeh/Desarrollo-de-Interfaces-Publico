using CuestionarioCoronavirusUI.ViewModels;
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

namespace CuestionarioCoronavirusUI.Views
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class CuestionarioMP : Page
    {
        //public static bool dato = false;
        //public ClsPreguntasVM ViewModel { get; set; } = new ClsPreguntasVM();
        public ClsCuestionarioVM ViewModel2 { get; set; } = new ClsCuestionarioVM();

        /// <summary>
        /// recibe el diagnostico de la otra vista
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //diagnosticoPersona.Text = e.Parameter.ToString().ToLower();
            //dato = diagnosticoPersona.Text;
            //this.ViewModel = new ClsPreguntasVM(Convert.ToBoolean(diagnosticoPersona.Text.ToLower()));
            this.ViewModel2 = new ClsCuestionarioVM(Convert.ToBoolean(e.Parameter.ToString().ToLower()));
            base.OnNavigatedTo(e);
        }

        public CuestionarioMP()
        {
            this.InitializeComponent();
        }
    }
}
