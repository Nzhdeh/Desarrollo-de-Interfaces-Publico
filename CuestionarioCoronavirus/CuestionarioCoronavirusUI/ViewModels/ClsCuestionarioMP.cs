using CuestionarioCoronavirusBL.ManejadorasBL;
using CuestionarioCoronavirusET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuestionarioCoronavirusUI.ViewModels
{
    public class ClsCuestionarioMP:ClsVMBase
    {
        private ClsPersona persona;
        private string diagnostico;
        private bool isCuestionarioLleno;
        private DelegateCommand enviarCommand;

        #region constructores
        public ClsCuestionarioMP()
        {
            persona = new ClsPersona();
            this.isCuestionarioLleno = true;
        }

        #endregion

        #region propiedades publicas
        public bool IsCuestionarioLleno
        {
            get { return this.isCuestionarioLleno; }
            set { this.isCuestionarioLleno = value; }
        }


        public ClsPersona Persona
        {
            get { return this.persona; }
            set 
            { 
                this.persona = value;
                //NotifyPropertyChanged("Persona");
            }
        }


        public string Diagnostico
        {
            get { return this.diagnostico; }
            set 
            { 
                this.diagnostico = value;
            }
        }

        public DelegateCommand EnviarCommand
        {
            get
            {
                enviarCommand = new DelegateCommand(enviar);
                return enviarCommand;
            }
            set
            {
                enviarCommand = value;
            }
        }
        #endregion

        #region metodos
        private void comprobar()
        {
            //TODO la persona tiene que ser diferente de null
        }

        private void enviar()
        {
            ClsGestionPersonaBL gestora = new ClsGestionPersonaBL();
            gestora.InsertarPersonaBL(Persona);
        }
        #endregion
    }
}
