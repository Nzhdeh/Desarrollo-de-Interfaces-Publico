using HospitalesSaturadosDAL.Conexion;
using HospitalesSaturadosDAL.ManejadorasDAL;
using HospitalesSaturadosET;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace HospitalesSaturadosBL.ManejadorasBL
{
    public class ClsGestionTareasBL
    {
        /// <summary>
        /// sirve para obtener las tareas de hoy de un medico 
        /// </summary>
        /// <param name="codigoMedico">el código del médico</param>
        /// <returns>ClsControlDiario que es la tarea del médico</returns>
        public ClsControlDiario TareasPorCodigoMedicoYFechaDeHoyDAL(string codigoMedico)
        {
            ClsControlDiario oControlDiario = null;

            try
            {
                oControlDiario = new ClsGestionTareasDAL().TareasPorCodigoMedicoYFechaDeHoyDAL(codigoMedico);
            }
            catch (SqlException ex)
            {
                throw ex;              
            }

            return oControlDiario;
        }
    }
}
