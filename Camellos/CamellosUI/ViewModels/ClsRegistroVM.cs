using CamellosBL.ManejadorasBL;
using CamellosET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace CamellosUI.ViewModels
{
    /*poner el error de la contraseña no es valida*/
    public class ClsRegistroVM : ClsVMBase
    {
        //private ClsJugador jugador;   //se puede poner ClsJugador, pero cuando al registrarme pongo un nick que ya existe me salta un mensaje de error. 
                                        //Para poder quitar ese mensaje de erro necesito hacer uso de NotifyPropertyChanged que no está en la capa Entidades, 
                                        //por eso pongo nick y contraseña
        private string nick;
        private string contraseña;
        private DelegateCommand registrarCommand;
        private bool isCommandActivo;
        private string mensajeNickExiste;
        private string segundaContraseña;
        private string mensajeContraseñasNoCoinciden;// esto es cuando la segunda contraseña no coincide con la primera
        private string registradoCorrectamente;

        #region constructores
        public ClsRegistroVM()
        {
            this.mensajeContraseñasNoCoinciden = "";
            this.isCommandActivo = true;
            this.mensajeNickExiste = "";
        }

        #endregion

        #region propiedades publicas
        public string Nick
        {
            get
            {
                return this.nick;
            }
            set
            {
                this.nick = value;

                if (this.nick != null)
                {
                    this.mensajeNickExiste = "";
                    NotifyPropertyChanged("MensajeNickExiste");
                }
            }
        }

        public string Contraseña
        {
            get
            {
                return this.contraseña;
            }
            set
            {
                this.contraseña = value;

                if (this.contraseña != null)
                {
                    this.mensajeContraseñasNoCoinciden = "";
                    NotifyPropertyChanged("MensajeContraseñasNoCoinciden");
                }
            }
        }

        public string RegistradoCorrectamente
        {
            get
            {
                return this.registradoCorrectamente;
            }
            set
            {
                this.registradoCorrectamente = value;
            }
        }

        public string SegundaContraseña
        {
            get
            {
                return this.segundaContraseña;
            }
            set
            {
                this.segundaContraseña = value;

                if(this.segundaContraseña != null)
                {
                    this.mensajeContraseñasNoCoinciden = "";
                    NotifyPropertyChanged("MensajeContraseñasNoCoinciden");
                }
            }
        }

        public string MensajeContraseñasNoCoinciden
        {
            get
            {
                return this.mensajeContraseñasNoCoinciden;
            }
            set
            {
                this.mensajeContraseñasNoCoinciden = value;
            }
        }
        
        public string MensajeNickExiste
        {
            get
            {
                return this.mensajeNickExiste;
            }
            set
            {
                this.mensajeNickExiste = value;
            }
        }

        public DelegateCommand RegistrarCommand
        {
            get
            {
                this.registrarCommand = new DelegateCommand(registrar);
                return registrarCommand;
            }
            set
            {
                this.registrarCommand = value;
            }
        }

        public bool IsCommandActivo
        {
            get
            {
                return this.isCommandActivo;
            }
            set
            {
                this.isCommandActivo = value;
            }
        }
        #endregion

        #region metodos privados
        /// <summary>
        /// sirve para registrar a un jugador
        /// </summary>
        private void registrar()
        {
            int exito = 0;
            try
            {
                if(!new ClsManejadoraJugadorBL().ExisteNickDAL(this.nick) && this.nick != null)
                {
                    if (this.contraseña != null && this.segundaContraseña != null && this.contraseña.Equals(this.segundaContraseña))
                    {
                        exito = new ClsManejadoraJugadorBL().RegistrarJugadorBL(this.nick, this.contraseña);
                        this.registradoCorrectamente = "Se ha registrado correctamente";
                        NotifyPropertyChanged("RegistradoCorrectamente");
                        if (exito > 0)
                        {
                            this.nick = "";
                            this.contraseña = "";
                            this.segundaContraseña = "";
                            NotifyPropertyChanged("Nick");
                            NotifyPropertyChanged("Contraseña");
                            NotifyPropertyChanged("SegundaContraseña");
                        }
                    }
                    else if(this.contraseña == null || this.segundaContraseña == null)
                    {
                        this.mensajeContraseñasNoCoinciden = "Los campos de las contraseñas son obligatorios";
                        NotifyPropertyChanged("MensajeContraseñasNoCoinciden");
                    }
                    else
                    {
                        this.mensajeContraseñasNoCoinciden = "Las contraseñas no coinciden";
                        NotifyPropertyChanged("MensajeContraseñasNoCoinciden");
                    }
                }
                else if(this.nick == null)
                {
                    this.mensajeNickExiste = "El campo nick es obligatorio";
                    NotifyPropertyChanged("MensajeNickExiste");

                    if (this.contraseña == null || this.segundaContraseña == null)
                    {
                        this.mensajeContraseñasNoCoinciden = "Las contraseñas son obligatorios";
                        NotifyPropertyChanged("MensajeContraseñasNoCoinciden");
                    }
                }
                else
                {
                    this.mensajeNickExiste = "El nick ya exitse";
                    NotifyPropertyChanged("MensajeNickExiste");
                }
            }
            catch (Exception)
            {
                //por si no hay conexion o la cadena esta mal puesta
                var dlg = new MessageDialog("Problemas de conexión. Inténtalo más tarde por favor");
                var res = dlg.ShowAsync();
            }
        }

        #endregion
    }
}
