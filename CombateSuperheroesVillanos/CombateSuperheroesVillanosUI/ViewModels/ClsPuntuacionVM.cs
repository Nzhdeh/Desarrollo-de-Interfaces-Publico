﻿using CombateSuperheroesVillanosBL.ListadosBL;
using CombateSuperheroesVillanosBL.ManejadorasBL;
using CombateSuperheroesVillanosDAL;
using CombateSuperheroesVillanosET;
using CombateSuperheroesVillanosUI.Utilidades;
using CombateSuperheroesVillanosUI.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace CombateSuperheroesVillanosUI.ViewModels
{
    public class ClsPuntuacionVM : ClsVMBase
    {
		private ObservableCollection<ClsLuchador> listadoTodosLosLuchadores;//para obtener el listado de todos los luchadores
		private ObservableCollection<ClsLuchador> listadoLuchadoresConLaImagenBitmapeada;//es para bindear
		private int ratingLuchador1;
		private int ratingLuchador2;
		private ClsLuchador luchadorSeleccionado1;
		private ClsLuchador luchadorSeleccionado2;
		private DelegateCommand enviarPuntuacionCommand;
		private string mensajeError;//para notificar los errores
		private string colorError;//para el color del texto de error
		private string visibilidadProgressBar;



		#region constructores
		public ClsPuntuacionVM()
		{
			try
			{
				this.listadoTodosLosLuchadores = new ClsListadoSuperheroesBL().ObtenerListadoLuchadoresBL();
				if (this.listadoTodosLosLuchadores.Count>0)
				{
					for (int i = 0; i < listadoTodosLosLuchadores.Count; i++)
					{
						listadoTodosLosLuchadores[i].ImagenBitmap = ArrayBytesToBitmapImage(listadoTodosLosLuchadores[i].FotoLuchador);//cambio de array de bites a BitmapImage
					}
					this.listadoLuchadoresConLaImagenBitmapeada = this.listadoTodosLosLuchadores;
				}
				else
				{
					var dlg = new MessageDialog("Listado no disponible");
					var res = dlg.ShowAsync();
				}
				
			}
			catch (Exception)
			{
				var dlg = new MessageDialog("Problemas de conexión. Inténtalo más tarde por favor");
				var res = dlg.ShowAsync();
			}

			this.ratingLuchador1 = (-1);//-1 porque si pongo 0 y ejecuto el rating sale con la primera estrella seleccionada
			this.ratingLuchador2 = (-1);
			this.mensajeError = "";
			this.colorError = "Yellow";
			this.visibilidadProgressBar = "Collapsed";
		}

		public ClsPuntuacionVM(ObservableCollection<ClsLuchador> listadoTodosLosLuchadores, ObservableCollection<ClsLuchador> listadoLuchadoresConLaImagenBitmapeada, 
			int ratingLuchador1, int ratingLuchador2, ClsLuchador luchadorSeleccionado1, ClsLuchador luchadorSeleccionado2, string mensajeError, string colorError)
		{
			this.listadoTodosLosLuchadores = listadoTodosLosLuchadores;
			this.listadoLuchadoresConLaImagenBitmapeada = listadoLuchadoresConLaImagenBitmapeada;
			this.ratingLuchador1 = ratingLuchador1;
			this.ratingLuchador2 = ratingLuchador2;
			this.luchadorSeleccionado1 = luchadorSeleccionado1;
			this.luchadorSeleccionado2 = luchadorSeleccionado2;
			this.mensajeError = mensajeError;
			this.colorError = colorError;
		}
		#endregion

		#region propiedades publicas

		public string VisibilidadProgressBar
		{
			get
			{
				return this.visibilidadProgressBar;
			}
			set
			{
				this.visibilidadProgressBar = value;
			}
		}

		public ObservableCollection<ClsLuchador> ListadoLuchadoresConLaImagenBitmapeada
		{
			get
			{
				return this.listadoLuchadoresConLaImagenBitmapeada;
			}
			set
			{
				this.listadoLuchadoresConLaImagenBitmapeada = value;
			}
		}

		public ClsLuchador LuchadorSeleccionado1
		{
			get
			{
				return this.luchadorSeleccionado1;
			}
			set
			{
				this.luchadorSeleccionado1 = value;
				if (this.luchadorSeleccionado1 != null)
				{
					this.mensajeError = "";//quito el mensaje de error
					NotifyPropertyChanged("MensajeError");

					this.ratingLuchador1 = (-1);//quito lo que había seleccionado en el rating
					NotifyPropertyChanged("RatingLuchador1");
				}
			}
		}

		public ClsLuchador LuchadorSeleccionado2
		{
			get
			{
				return this.luchadorSeleccionado2;
			}
			set
			{
				this.luchadorSeleccionado2 = value;
				if (this.luchadorSeleccionado2 != null)
				{
					this.mensajeError = "";//quito el mensaje de error
					NotifyPropertyChanged("MensajeError");

					this.ratingLuchador2 = (-1);//quito lo que había seleccionado en el rating
					NotifyPropertyChanged("RatingLuchador2");
				}
			}
		}

		public int RatingLuchador1
		{
			get
			{
				return this.ratingLuchador1;
			}
			set
			{
				this.ratingLuchador1 = value;
			}
		}

		public int RatingLuchador2
		{
			get
			{
				return this.ratingLuchador2;
			}
			set
			{
				this.ratingLuchador2 = value;
			}
		}

		public DelegateCommand EnviarPuntuacionCommand
		{
			get
			{
				enviarPuntuacionCommand = new DelegateCommand(enviar);
				return enviarPuntuacionCommand;
			}
			set
			{
				enviarPuntuacionCommand = value;
			}
		}

		public string MensajeError
		{
			get
			{
				return this.mensajeError;
			}
			set
			{
				this.mensajeError = value;
			}
		}

		public string ColorError
		{
			get
			{
				return this.colorError;
			}
			set
			{
				this.colorError = value;
			}
		}
		#endregion

		#region metodos privados
		/// <summary>
		/// sirve para enviar los datos a la capa BL o mostrar mensaje de error
		/// </summary>
		private void enviar()
		{
			this.visibilidadProgressBar = "Visible";
			NotifyPropertyChanged("VisibilidadProgressBar");
			if(this.listadoTodosLosLuchadores!= null)
			{
				if (this.luchadorSeleccionado1 == null || this.luchadorSeleccionado2 == null || this.ratingLuchador1 <= 0 || this.ratingLuchador2 <= 0)
				{
					this.colorError = "Yellow";
					NotifyPropertyChanged("ColorError");
					this.mensajeError = "Hay que seleccionar un luchador de cada lista y sus puntuaciones";
					NotifyPropertyChanged("MensajeError");

					this.visibilidadProgressBar = "Collapsed";
					NotifyPropertyChanged("VisibilidadProgressBar");
				}
				else if (this.luchadorSeleccionado1.IdLuchador == this.luchadorSeleccionado2.IdLuchador)
				{
					this.colorError = "Yellow";
					NotifyPropertyChanged("ColorError");
					this.mensajeError = "No puedo luchar conmigo mismo picha";
					NotifyPropertyChanged("MensajeError");

					this.visibilidadProgressBar = "Collapsed";
					NotifyPropertyChanged("VisibilidadProgressBar");
				}
				else
				{
                    try
                    {
						new ClsManejadoraCombatesBL().InsertarCombateOActualizarPuntuacionBL(this.luchadorSeleccionado1.IdLuchador, this.luchadorSeleccionado2.IdLuchador,
																								this.ratingLuchador1, this.ratingLuchador2);

						this.colorError = "Chartreuse";
						NotifyPropertyChanged("ColorError");

						mensajeError = "Se ha guardado correctamente";
						NotifyPropertyChanged("MensajeError");

						this.visibilidadProgressBar = "Collapsed";
						NotifyPropertyChanged("VisibilidadProgressBar");
					}
                    catch (Exception)
                    {
						var dlg = new MessageDialog("Error de conexion. Intentalo más tarde por favor");
						var res = dlg.ShowAsync();
					}

					//this.visibilidadProgressBar = "Collapsed";
					//NotifyPropertyChanged("VisibilidadProgressBar");

					this.luchadorSeleccionado1 = null;//para que deseleccione el luchador seleccionado para poder seleccionarlo otra vez
					NotifyPropertyChanged("LuchadorSeleccionado1");

					this.luchadorSeleccionado2 = null;
					NotifyPropertyChanged("LuchadorSeleccionado2");

					this.ratingLuchador1 = (-1);
					NotifyPropertyChanged("RatingLuchador1");

					this.ratingLuchador2 = (-1);
					NotifyPropertyChanged("RatingLuchador2");
				}
				//this.visibilidadProgressBar = "Collapsed";
				//NotifyPropertyChanged("VisibilidadProgressBar");
			}
		}


		/// <summary>
		/// sirve para bitmapear una imagen de array de bytes
		/// </summary>
		/// <param name="array">la imagen en array de bytes</param>
		/// <returns> una imagen de tipo BitmapImage</returns>
		private BitmapImage ArrayBytesToBitmapImage(byte [] array)
		{
			//Crea un nuevo stream de salida de acceso aleatorio.
			using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
			{
				//Crea un nuevo writer a partir del stream anterior.
				using (DataWriter writer = new DataWriter(stream.GetOutputStreamAt(0)))
				{
					//Escribe el aray de bytes en el stream con el writer.
					writer.WriteBytes(array);

					//Confirma los datos y los almacena en el stream.
					writer.StoreAsync().GetResults();
				}

				var imagen = new BitmapImage();
				//establezco la imagen
				imagen.SetSource(stream);
				return imagen;
			}
		}
		#endregion
	}
}
