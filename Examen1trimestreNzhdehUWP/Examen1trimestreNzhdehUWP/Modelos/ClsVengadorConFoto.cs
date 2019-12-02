using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Nzhdeh*/
namespace Examen1trimestreNzhdehUWP.Modelos
{
    public class ClsVengadorConFoto: ClsSuperheroe
    {
        private Uri imagen;

        public ClsVengadorConFoto() : base()
        {
            this.imagen = new Uri("ms-appx:///Assets/Imagenes/1.jpg");//por defecto es el primero
        }

        public ClsVengadorConFoto(Uri imagen,int idSuperheroe,string nombreSuperheroe) : base(idSuperheroe, nombreSuperheroe)
        {
            this.imagen= imagen;
        }


        public Uri Imagen
        {
            get
            {
                return imagen;
            }
            set
            {
                imagen = value;
                //NotifyPropertyChanged("imagen");
            }
        }

        //la imagen se asigna en  el set del idUsuario
        public void asignarImagen()
        {
            this.imagen = new Uri("ms-appx:///Assets/Imagenes/" + IdSuperheroe + ".jpg");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Metodo dedicado a notificar el cambio de una propiedad a la vista.
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void NotifyPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
