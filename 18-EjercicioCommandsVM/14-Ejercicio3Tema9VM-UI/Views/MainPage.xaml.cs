using _14_Ejercicio3Tema9VM_UI.ViewModels;
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

namespace _14_Ejercicio3Tema9VM_UI
{
    

    public sealed partial class MainPage : Page
    {
        //public ClsMainPageVM ViewModel { get; } = new ClsMainPageVM();
        public MainPage()
        {
            this.InitializeComponent();
            //this.ViewModel = new ClsMainPageVM();
        }
    }
}
