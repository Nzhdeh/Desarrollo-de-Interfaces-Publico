using CuestionarioCoronavirusDAL.ListadosDAL;
using CuestionarioCoronavirusET;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuestionarioCoronavirusBL.ListadosBL
{
    public class ClsListadoPreguntasBL
    {
        public ObservableCollection<ClsPregunta> ListadoPreguntasBL()
        {
            ClsListadoPreguntasDAL l = new ClsListadoPreguntasDAL();
            return l.ListadoCompletoPreguntasDAL();
        }        
    }
}
