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
    public class ClsGestionMedicoBL
    {
        /// <summary>
        /// sirve para obtener un medico por su codigo
        /// </summary>
        /// <param name="codigoMedico">codigo del médico que queremos obtener</param>
        /// <returns>médicos</returns>
        public ClsMedico ObtenerMedicoBL(string codigoMedico)
        {
            ClsMedico oMedico = null;

            try
            {
                oMedico = new ClsGestionMedicoDAL().ObtenerMedicoDAL(codigoMedico);
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return oMedico;
        }

        /// <summary>
        /// sirve para ver si el codigo introducido pertenece a algún médico
        /// </summary>
        /// <param name="codigo">cogigo del medico que queremos ver si existe o no</param>
        /// <returns>true si el codigo corresponde a algún médico y false si no</returns>
        public bool ExisteMedicoBL(string codigoMedico)
        {
            bool existe = false;

            try
            {
                existe = new ClsGestionMedicoDAL().ExisteMedicoDAL(codigoMedico);
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return existe;
        }
    }
}
