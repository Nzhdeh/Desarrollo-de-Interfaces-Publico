using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;


namespace JuegoParejasNzhdehUI.Views
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Juego : Page
    {
        private Storyboard rotation = new Storyboard();

        public Juego()
        {
            this.InitializeComponent();
            
        }

        /// <summary>
        /// metodo queejecuta la animacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Carta_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //sender eser mi mejor amigo
            Storyboard sb = (sender as Image).Resources["sbImagenes"] as Storyboard;
            sb.Begin();
        }



        //public void Rotate(string axis)
        //{
        //    DoubleAnimation animation = new DoubleAnimation();
        //    animation.From = 0.0;
        //    animation.To = 180.0;
        //    animation.BeginTime = TimeSpan.FromSeconds(0);
        //    //animation.RepeatBehavior = RepeatBehavior.Forever;
        //    //Storyboard.SetTarget(animation, Display);
        //    Storyboard.SetTargetProperty(animation, "(UIElement.Projection).(PlaneProjection.Rotation" + "Y" + ")");
        //    rotation.Children.Clear();
        //    rotation.Children.Add(animation);
        //    rotation.Begin();
        //}

        //private void spinme_PointerPressed(object sender, PointerRoutedEventArgs e)
        //{
        //    sbImagenes.Begin();
        //}

        //private void Pitch_Click(object sender, RoutedEventArgs e)
        //{
        //Rotate("X", ref Display);
        //}

        //private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        //{
        //    Rotate("X");
        //}

        //private void AtrasCommand_Click(object sender, RoutedEventArgs e)
        //{
        //    this.Frame.Navigate(typeof(Menu));
        //}
        //para meter animaciones
        //private void Grid_Loaded(object sender, RoutedEventArgs e)
        //{
        //    Storyboard sb = ((StackPanel)sender).Resources["LoadedStoryboard"] as Storyboard;
        //    sb.Begin();
        //    Rotate("X", ref gwImagenes);
        //}        
    }
}
