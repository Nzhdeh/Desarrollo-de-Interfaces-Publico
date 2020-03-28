using CuestionarioCoronavirusBL.ListadosBL;
using CuestionarioCoronavirusET;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuestionarioCoronavirusUI.ViewModels
{
    public class ClsPreguntasVM
    {
        private ObservableCollection<ClsPregunta> listadoPreguntas;

        public ClsPreguntasVM()
        {
            ClsListadoPreguntasBL l=new ClsListadoPreguntasBL();

            this.listadoPreguntas = l.ListadoPreguntasBL();
        }

        public ObservableCollection<ClsPregunta> ListadoPreguntas
        {
            get
            {
                return listadoPreguntas;
            }
            set
            {
                listadoPreguntas = value;
            }
        }
    }
}
