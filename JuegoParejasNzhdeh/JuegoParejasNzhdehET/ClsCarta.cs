using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoParejasNzhdehET
{
    public class ClsCarta : ClsVMBase
    {
        private int idCarta;
        private Uri imagenNoVolteada;
        private Uri imagenVolteada;
        private Uri imagenAMostrar;
        private bool descubierta;
        //private bool isBloqueada; //cuando hay mas de una pareja de cartas abiertas se puede cerrarlas dando clic en dos de ellas


        public ClsCarta()
        {
            this.idCarta = 0;
            this.imagenNoVolteada = new Uri("ms-appx:///Assets/Imagenes/NoVolteada.jpg");
            this.imagenVolteada = new Uri("");
            this.imagenAMostrar = new Uri("");
            this.descubierta = false;
        }

        public ClsCarta(int idCarta,Uri imagenNoVolteada,Uri imagenVolteada, Uri imagenAMostrar)
        {
            this.idCarta = idCarta;
            this.imagenNoVolteada = imagenNoVolteada;
            this.imagenVolteada = imagenVolteada;
            this.imagenAMostrar = imagenAMostrar;
            this.descubierta = false;
        }

        public ClsCarta(int idCarta, Uri imagenVolteada)
        {
            this.idCarta = idCarta;
            this.imagenVolteada = imagenVolteada;
            this.imagenNoVolteada = new Uri("ms-appx:///Assets/Imagenes/NoVolteada.jpg");
            this.imagenAMostrar = ImagenNoVolteada;
            
            this.descubierta = false;
        }

        public Uri ImagenNoVolteada
        {
            get
            {
                return imagenNoVolteada;
            }
            set
            {
                imagenNoVolteada = value;
                //NotifyPropertyChanged("imagen");
            }
        }

        public Uri ImagenVolteada
        {
            get
            {
                if(!Descubierta)
                {
                    return ImagenNoVolteada;
                }
                else
                {
                    return imagenVolteada;
                }
            }
            set
            {
                imagenVolteada = value;
                //NotifyPropertyChanged("imagen");
            }
        }

        public Uri ImagenAMostrar
        {
            get
            {
                return imagenAMostrar;
            }
            set
            {
                imagenAMostrar = value;
                //NotifyPropertyChanged("imagen");
            }
        }

        public int IdCarta
        {
            get { return idCarta; }
            set { idCarta = value; }
        }

        public bool Descubierta
        {
            get { return descubierta; }

            set
            {
                descubierta = value;

                if(descubierta)
                {
                    imagenAMostrar = imagenVolteada;
                }
                else
                {
                    imagenAMostrar = imagenNoVolteada;
                }
                NotifyPropertyChanged("ImagenAMostrar");
            }
        }

        //public bool IsBloqueada
        //{
        //    get { return isBloqueada; }

        //    set
        //    {
        //        if (descubierta)
        //        {
        //            isBloqueada = value;
        //        }
        //    }
        //}
    }
}
