using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace CombateSuperheroesVillanosET
{
    public class ClsLuchador
    {
		private int idLuchador;
		private string nombreLuchador;
		private byte [] fotoLuchador;
		private BitmapImage imagenBitmap;//truco. Sería la imagen a mostrar

		public ClsLuchador()
		{
			this.idLuchador = 0;
			this.nombreLuchador = "";
			this.fotoLuchador = null;
			this.imagenBitmap = new BitmapImage();
		}

		public ClsLuchador(int idLuchador, string nombreLuchador, byte[] fotoLuchador, BitmapImage imagenBitmap)
		{
			this.idLuchador = idLuchador;
			this.nombreLuchador = nombreLuchador;
			this.fotoLuchador = fotoLuchador;
			this.imagenBitmap = imagenBitmap;
		}

		public BitmapImage ImagenBitmap
		{
			get
			{
				return this.imagenBitmap;
			}
			set
			{
				this.imagenBitmap = value;
			}
		}

		public int IdLuchador
		{
			get
			{
				return this.idLuchador;
			}
			set
			{
				this.idLuchador = value;
			}
		}

		public string NombreLuchador
		{
			get
			{
				return this.nombreLuchador;
			}
			set
			{
				this.nombreLuchador = value;
			}
		}

		public byte[] FotoLuchador
		{
			get
			{
				return this.fotoLuchador;
			}
			set
			{
				this.fotoLuchador = value;
			}
		}
	}
}
