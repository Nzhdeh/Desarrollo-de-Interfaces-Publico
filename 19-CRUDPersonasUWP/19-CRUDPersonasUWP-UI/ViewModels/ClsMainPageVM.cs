using _19_CRUDPersonas_BL.Listados;
using _19_CRUDPersonas_BL.Manejadoras;
using _19_CRUDPersonas_Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;

namespace _19_CRUDPersonasUWP_UI.ViewModels
{
    public class ClsMainPageVM : ClsVMBase
    {
        #region "Atributos"
        private ObservableCollection<ClsPersona> listadoPersonas;
        private ObservableCollection<ClsPersona> listadoPersonaAuxiliar;
        private ObservableCollection<ClsPersona> listadoDepartamentos;
        private ClsDepartamento departamentoSeleccionado;
        private ClsPersona personaSeleccionada;
        private String textoBusqueda;
        private ClsDelegateCommand borrarCommand;
        private ClsDelegateCommand saveCommand;
        private ClsDelegateCommand addCommand;
        private ClsDelegateCommand buscarCommand;
        private ClsDelegateCommand updateCommand;

        #endregion

        #region "Constructores"
        public ClsMainPageVM()
        {
            ClsListadoPersonasBL listadoPersonasBL = new ClsListadoPersonasBL();
            listadoPersonas = new ObservableCollection<ClsPersona>(listadoPersonasBL.getListadoPersonasBL());
            listadoPersonaAuxiliar = listadoPersonas;
            textoBusqueda = "";
            DispatcherTimerSample();
        }
        #endregion

        #region "Propiedades"

        public ObservableCollection<ClsPersona> ListadoPersona
        {
            get
            {
                return listadoPersonas;
            }
        }

        public ObservableCollection<ClsPersona> ListadoPersonaAuxiliar
        {
            get
            {
                return listadoPersonaAuxiliar;
            }

            set
            {
                listadoPersonaAuxiliar = value;
                NotifyPropertyChanged("listadoPersonaAuxiliar");
            }
        }
        public ObservableCollection<ClsPersona> ListadoDepartamentos
        {
            get
            {
                return listadoDepartamentos;
            }
        }

        public ClsPersona PersonaSeleccionada
        {
            get
            {
                return personaSeleccionada;
            }

            set
            {
                personaSeleccionada = value;
                borrarCommand.RaiseCanExecuteChanged();
                saveCommand.RaiseCanExecuteChanged();
                NotifyPropertyChanged("personaSeleccionada");
            }
        }

        public ClsDepartamento DepartamentoSeleccionado
        {
            get
            {
                return departamentoSeleccionado;
            }

            set
            {
                departamentoSeleccionado = value;
                NotifyPropertyChanged("departamentoSeleccionado");
            }
        }

        public String TextoBusqueda
        {
            get
            {
                return textoBusqueda;
            }

            set
            {
                textoBusqueda = value;
                buscarCommand.RaiseCanExecuteChanged();
                //NotifyPropertyChanged("textoBusqueda");
            }
        }

        public ClsDelegateCommand UpdateCommand
        {
            get
            {
                updateCommand = new ClsDelegateCommand(Update);
                return updateCommand;
            }

            set
            {
                updateCommand = value;
            }
        }

        public ClsDelegateCommand BorrarCommand
        {
            get
            {
                borrarCommand = new ClsDelegateCommand(Borrar, PuedeBorrar);
                return borrarCommand;
            }

            set
            {
               borrarCommand = value;
            }
        }

        public ClsDelegateCommand SaveCommand
        {
            get
            {
                saveCommand = new ClsDelegateCommand(Save, CanSave);
                return saveCommand;
            }

            set
            {
                saveCommand = value;
            }
        }

        public ClsDelegateCommand AddCommand
        {
            get
            {
                addCommand = new ClsDelegateCommand(Add);
                return addCommand;
            }

            set
            {
                addCommand = value;
            }
        }

        public ClsDelegateCommand BuscarCommand
        {
            get
            {
                buscarCommand = new ClsDelegateCommand(Buscar, PuedeBuscar);
                return buscarCommand;
            }

            set
            {
                buscarCommand = value;
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo que comprueba si se puede borrar un item
        /// </summary>
        /// <returns>boolean</returns>
        public bool PuedeBorrar()
        {
            bool puede = false;

            if (personaSeleccionada != null)
            {
                puede = true;
            }

            return puede;
        }

        /// <summary>
        /// Metodo que lanza el dialogo de seguridad
        /// </summary>
        public void Borrar()
        {

            String titulo, content;
            titulo = "Borrar una persona";
            content = "¿Estas seguro de que quieres borrar?";

            DisplayDialog(titulo, content);
        }

        /// <summary>
        /// Metodo que comprueba si se puede guardar
        /// </summary>
        /// <returns>boolean</returns>
        public bool CanSave()
        {
            bool puede = false;

            if (personaSeleccionada != null)
            {
                puede = true;
            }

            return puede;
        }

        /// <summary>
        /// Metodo dedicado a guardar una nueva persona creada
        /// </summary>
        public void Save()
        {
            if (personaSeleccionada.IdPersona == 0)
            {
                ClsGestoraPersonasBL gestoraPersonaBL = new ClsGestoraPersonasBL();
                ClsListadoPersonasBL listadoPersonasBL = new ClsListadoPersonasBL();
                gestoraPersonaBL.getAddPersona(personaSeleccionada);
                listadoPersonaAuxiliar = new ObservableCollection<ClsPersona>(listadoPersonasBL.getListadoPersonasBL());
                NotifyPropertyChanged("listadoPersonaAuxiliar");
            }
        }

        /// <summary>
        /// Metodo que crea una persona nueva
        /// </summary>
        public void Add()
        {
            personaSeleccionada = new ClsPersona();
            NotifyPropertyChanged("personaSeleccionada");
        }

        /// <summary>
        /// Metodo que actualiza la lista
        /// </summary>
        public void Update()
        {
            ClsListadoPersonasBL listadoPersonasBL = new ClsListadoPersonasBL();
            listadoPersonaAuxiliar = new ObservableCollection<ClsPersona>(listadoPersonasBL.getListadoPersonasBL());
            NotifyPropertyChanged("listadoPersonaAuxiliar");
        }

        public void Buscar()
        {
            ListadoPersonaAuxiliar = new ObservableCollection<ClsPersona>();

            for (int i = 0; i < ListadoPersona.Count; i++)
            {
                if (ListadoPersona[i].NombrePersona.ToLower().Contains(textoBusqueda.ToLower()))
                {
                    ListadoPersonaAuxiliar.Add(ListadoPersona[i]);
                    NotifyPropertyChanged("listadoPersonaAuxiliar");
                }
            }
        }

        public bool PuedeBuscar()
        {
            bool puede = false;

            if (textoBusqueda.Length > 0)
            {
                puede = true;
            }

            else
            {
                listadoPersonaAuxiliar = ListadoPersona;
                NotifyPropertyChanged("listadoPersonaAuxiliar");
            }

            return puede;
        }

        public void DispatcherTimerSample()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(30);
            timer.Tick += Timer_tick;
            timer.Start();
        }

        private void Timer_tick(Object sender, object e)
        {
            Update();
        }

        private async void DisplayDialog(String titulo, String nombre)
        {
            ClsGestoraPersonasBL gestoraPersonaBL = new ClsGestoraPersonasBL();
            ClsListadoPersonasBL listadoPersonasBL = new ClsListadoPersonasBL();

            MessageDialog showDialog = new MessageDialog(titulo);
            showDialog.Content = titulo + "\n" + nombre;
            showDialog.Commands.Add(new UICommand("Si") { Id = 0 });
            showDialog.Commands.Add(new UICommand("No") { Id = 1 });
            showDialog.DefaultCommandIndex = 0;
            showDialog.DefaultCommandIndex = 1;
            var result = await showDialog.ShowAsync();

            if ((int)result.Id == 0)
            {

                gestoraPersonaBL.getBorrarPersona(personaSeleccionada.IdPersona);
                listadoPersonaAuxiliar = new ObservableCollection<ClsPersona>(listadoPersonasBL.getListadoPersonasBL());
                NotifyPropertyChanged("listadoAuxiliar");
            }

            else
            {
                
            }
        }
        #endregion
    }
}
