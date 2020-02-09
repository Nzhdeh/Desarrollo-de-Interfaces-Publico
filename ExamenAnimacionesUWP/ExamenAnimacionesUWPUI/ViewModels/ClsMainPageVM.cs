using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenAnimacionesUWPUI.ViewModels
{
    public class ClsMainPageVM
    {
        private clsPersona personaSeleccionada;
        private ObservableCollection<clsPersona> listadoPersonaCompleta;
        private DelegateCommand eliminarComando;
        private DelegateCommand filtrarComando;
        private DelegateCommand newCommand;
        private DelegateCommand recargarComando;
        private DelegateCommand guardarComando;
        private ObservableCollection<clsPersona> listadoPersonaFiltrada;
        private String textoBuscado;
        private ObservableCollection<clsDepartamento> dpto;
        private clsDepartamento dptoSeleccionado;
        private BitmapImage imagen;
        private clsListadoPersonaBL bbdd = new clsListadoPersonaBL();

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainPageVM()
        {
            try
            {
                cargarListado();
                //this.listadoPersonaCompleta = new ObservableCollection<clsPersona>(bbdd.listadoPersonas());
                //this.dpto = new ObservableCollection<clsDepartamento>(bbdd.listadoDepartamentos());
            }

            catch (SqlException e)
            {
                mostrarMensajeError();
            }/*
            catch(Exception)
            {
                mostrarMensajeError();
            }
            */

            this.listadoPersonaFiltrada = this.listadoPersonaCompleta;
            eliminarComando = new DelegateCommand(Eliminar, () => personaSeleccionada != null);
            filtrarComando = new DelegateCommand(Filtrar, () => !String.IsNullOrEmpty(textoBuscado));
            recargarComando = new DelegateCommand(Recargar);
            newCommand = new DelegateCommand(Nuevo);
            //guardarComando = new DelegateCommand(Guardar, () => personaSeleccionada != null);
            //this.dpto = new ObservableCollection<clsDepartamento>(bbdd.listadoDepartamentos());
        }

        public clsPersona PersonaSeleccionada
        {
            get
            {
                //eliminarComando.CanExecute(personaSeleccionada != null);
                return personaSeleccionada;
            }
            set
            {
                this.personaSeleccionada = value;
                if (personaSeleccionada != null)
                {
                    cargarImagenPersona();
                }

                eliminarComando.RaiseCanExecuteChanged();
                eliminarComando.CanExecute(personaSeleccionada);
                guardarComando.RaiseCanExecuteChanged();
                guardarComando.CanExecute(personaSeleccionada);
                NotifyPropertyChanged("PersonaSeleccionada");

            }
        }


        public ObservableCollection<clsPersona> ListadoPersonaCompleta
        {
            get
            {
                return listadoPersonaCompleta;
                //return listadoPersonaCompleta = new ObservableCollection<clsPersona>(bbdd.listadoPersonas());
            }
            set
            {
                listadoPersonaCompleta = value;
            }

        }


        public DelegateCommand EliminarComando
        {
            get
            {
                return eliminarComando;
            }
        }

        public DelegateCommand FiltrarComando
        {
            get
            {
                return filtrarComando;
            }
        }


        public async void Eliminar()
        {
            ContentDialog subscribeDialog = new ContentDialog
            {
                Title = "¿Estas seguro que quiere eliminar?",
                PrimaryButtonText = "Aceptar",
                SecondaryButtonText = "Cancelar",
                DefaultButton = ContentDialogButton.Secondary
            };

            ContentDialogResult result = await subscribeDialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                //No estoy seguro, pero o llamamos de nuevo a la BBDD o se lo borramos a los dos
                //listadoPersonaFiltrada.Remove(personaSeleccionada);
                //bbdd.borrarPersona(personaSeleccionada.IDPersona);
                //NotifyPropertyChanged("ListadoPersonaCompleta");
                // listadoPersonaFiltrada = new ObservableCollection<clsPersona>(bbdd.listadoPersonas());
                NotifyPropertyChanged("ListadoPersonaFiltrada");
            }
        }

        public void Filtrar()
        {
            if (String.IsNullOrWhiteSpace(TextoBuscado))
            {
                ListadoPersonaFiltrada = ListadoPersonaCompleta;
                NotifyPropertyChanged("ListadoPersonaFiltrada");
            }
            else
            {
                ObservableCollection<clsPersona> list = new ObservableCollection<clsPersona>(ListadoPersonaCompleta.ToList().FindAll(a => a.Nombre.Contains(TextoBuscado)).ToList<clsPersona>());
                //ListadoPersonaFiltrada = ListadoPersonaFiltrada.ToList().FindAll(a => a.Nombre.Contains(TextoBuscado));
                ListadoPersonaFiltrada = list;
            }
        }

        public String TextoBuscado
        {
            get
            {
                return textoBuscado;
            }

            set
            {
                this.textoBuscado = value;
                filtrarComando.Execute(null);
                filtrarComando.RaiseCanExecuteChanged();
                NotifyPropertyChanged("ListadoPersonaFiltrada");
            }
        }

        public ObservableCollection<clsPersona> ListadoPersonaFiltrada
        {
            get
            {
                return listadoPersonaFiltrada;
            }
            set
            {
                listadoPersonaFiltrada = value;
            }

        }

        public DelegateCommand NewCommand
        {
            get
            {
                return newCommand;
            }
        }

        public void Nuevo()
        {
            personaSeleccionada = new clsPersona();
            eliminarComando.RaiseCanExecuteChanged();
            eliminarComando.CanExecute(personaSeleccionada);
            guardarComando.RaiseCanExecuteChanged();
            guardarComando.CanExecute(personaSeleccionada);
            NotifyPropertyChanged("PersonaSeleccionada");
        }

        public DelegateCommand RecargarCommand
        {
            get
            {
                return recargarComando;
            }
        }

        public void Recargar()
        {
            ListadoPersonaFiltrada = ListadoPersonaCompleta;
            NotifyPropertyChanged("ListadoPersonaFiltrada");
        }

        public DelegateCommand GuardarComando
        {
            get
            {
                return guardarComando;
            }
        }
        /*
        public async void Guardar()
        {
            if (bbdd.estoyEnBBDD(personaSeleccionada))
            {
                ContentDialog subscribeDialog = new ContentDialog
                {
                    Title = "Actualizado correctamente en la BBDD",
                    PrimaryButtonText = "Perfecto",
                    DefaultButton = ContentDialogButton.Primary
                };
                ContentDialogResult result = await subscribeDialog.ShowAsync();
                bbdd.actualizarPersona(personaSeleccionada);
                Recargar();
            }
            else
            {
                ContentDialog subscribeDialog = new ContentDialog
                {
                    Title = "Creado correctamente en la BBDD",
                    PrimaryButtonText = "Perfecto",
                    DefaultButton = ContentDialogButton.Primary
                };
                ContentDialogResult result = await subscribeDialog.ShowAsync();
                bbdd.crearPersona(personaSeleccionada);
                Recargar();
            }
        }
        */
        public ObservableCollection<clsDepartamento> ListadoDepartamentos
        {
            get
            {
                return dpto;
            }
            set
            {
                dpto = value;
            }

        }

        public clsDepartamento DptoSeleccionado
        {
            get
            {
                return dptoSeleccionado;
            }
            set
            {
                dptoSeleccionado = value;
            }
        }

        /// <summary>
        /// Es para cuando se pulsa la imagen pueda cambiar su Source
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Imagencita_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Image imagencita = (Image)sender;
            var fileOpenPicker = new FileOpenPicker();
            fileOpenPicker.ViewMode = PickerViewMode.Thumbnail;
            fileOpenPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            fileOpenPicker.FileTypeFilter.Add(".png");
            fileOpenPicker.FileTypeFilter.Add(".jpg");
            fileOpenPicker.FileTypeFilter.Add(".jpeg");
            fileOpenPicker.FileTypeFilter.Add(".bmp");

            var storageFile = await fileOpenPicker.PickSingleFileAsync();

            if (storageFile != null)
            {
                // Ensure the stream is disposed once the image is loaded
                using (IRandomAccessStream fileStream = await storageFile.OpenAsync(Windows.Storage.FileAccessMode.Read))
                {
                    // Set the image source to the selected bitmap
                    BitmapImage bitmapImage = new BitmapImage();

                    await bitmapImage.SetSourceAsync(fileStream);
                    imagencita.Source = bitmapImage;

                    clsConversorBytes conversor = new clsConversorBytes();
                    personaSeleccionada.Foto = await conversor.StorageFileToByteArray(storageFile);
                }
            }
        }

        /// <summary>
        /// Muestra un dialogo en caso de que la conexion sea erroneo
        /// </summary>
        private async void mostrarMensajeError()
        {
            ContentDialog noWifiDialog = new ContentDialog()
            {
                Title = "Error",
                Content = "Reintentelo mas tarde",
                CloseButtonText = "Vale"
            };

            await noWifiDialog.ShowAsync();
            CoreApplication.Exit();

        }

        public BitmapImage Imagen
        {
            get
            {
                return imagen;
            }
            set
            {
                imagen = value;
                NotifyPropertyChanged("Imagen");
            }
        }

        public void cargarImagenPersona()
        {
            using (InMemoryRandomAccessStream ms = new InMemoryRandomAccessStream())
            {
                // Writes the image byte array in an InMemoryRandomAccessStream
                // that is needed to set the source of BitmapImage.
                using (DataWriter writer = new DataWriter(ms.GetOutputStreamAt(0)))
                {
                    writer.WriteBytes((byte[])personaSeleccionada.Foto);

                    // The GetResults here forces to wait until the operation completes
                    // (i.e., it is executed synchronously), so this call can block the UI.
                    writer.StoreAsync().GetResults();
                }

                var image = new BitmapImage();
                image.SetSource(ms);
                Imagen = image;
            }
        }

        private async void cargarListado()
        {
            this.listadoPersonaFiltrada = new ObservableCollection<clsPersona>();
            Task<List<clsPersona>> l = bbdd.listadoPersonas();
            List<clsPersona> list = await l;
            NotifyPropertyChanged("ListadoPersonaFiltrada");



        }
    }
}
