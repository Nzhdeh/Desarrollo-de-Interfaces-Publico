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

using Windows.UI.Xaml.Media.Animation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace ImagenRotacionAnimacion
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Storyboard rotation = new Storyboard();
        private bool rotating = false;

        public MainPage()
        {
            this.InitializeComponent();
        }

        public void Rotate(string axis, ref Image target)
        {
            if (rotating)
            {
                rotation.Stop();
                rotating = false;
            }
            else
            {
                DoubleAnimation animation = new DoubleAnimation();
                animation.From = 0.0;
                animation.To = 180.0;
                animation.BeginTime = TimeSpan.FromSeconds(0);
                //animation.RepeatBehavior = RepeatBehavior.Forever;
                Storyboard.SetTarget(animation, Display);
                Storyboard.SetTargetProperty(animation, "(UIElement.Projection).(PlaneProjection.Rotation" + "Y" + ")");
                rotation.Children.Clear();
                rotation.Children.Add(animation);
                rotation.Begin();
                rotating = true;
            }
        }

        private void Pitch_Click(object sender, RoutedEventArgs e)
        {
            Rotate("X", ref Display);
        }
        private void Flip_Click(object sender, RoutedEventArgs e)
        {
            ScaleTransform transform = new ScaleTransform();
            transform.ScaleY = -1;
            Display.RenderTransform = transform;
        }
    }
}
