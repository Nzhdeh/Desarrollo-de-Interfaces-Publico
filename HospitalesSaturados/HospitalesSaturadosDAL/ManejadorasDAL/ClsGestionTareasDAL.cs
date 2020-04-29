using HospitalesSaturadosDAL.Conexion;
using HospitalesSaturadosET;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalesSaturadosDAL.ManejadorasDAL
{
    public class ClsGestionTareasDAL
    {
        /// <summary>
        /// sirve para obtener las tareas de hoy de un medico 
        /// </summary>
        /// <param name="codigoMedico">el codigo del médico</param>
        /// <returns>tareas</returns>
        public ClsControlDiario TareasPorCodigoMedicoYFechaDeHoyDAL(string codigoMedico)
        {
            ClsMyConnection miConexion = null;

            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector = null;
            ClsControlDiario oControlDiario = null;
            SqlConnection conexion = null;
            miComando.Parameters.Add("@codigo", System.Data.SqlDbType.Char).Value = codigoMedico;
            miConexion = new ClsMyConnection();

            try
            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "select * from HO_ControlDiario where fecha = cast(getdate() as date) and codigoMedico = @codigo";

                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    miLector.Read();

                    oControlDiario = new ClsControlDiario();

                    oControlDiario.CodigoMedico = (string)miLector["codigoMedico"];
                    oControlDiario.Fecha = Convert.ToString(((DateTime)miLector["fecha"]).ToShortDateString());

                    if (!String.IsNullOrEmpty(miLector["primeraSesion"].ToString()))
                    {
                        oControlDiario.PrimeraSesion = (string)miLector["primeraSesion"];
                    }
                    else
                    {
                        oControlDiario.PrimeraSesion = "En esta sesión no tiene tareas";
                    }

                    if (!String.IsNullOrEmpty(miLector["segundaSesion"].ToString()))
                    {
                        oControlDiario.SegundaSesion = (string)miLector["segundaSesion"];
                    }
                    else
                    {
                        oControlDiario.SegundaSesion = "En esta sesión no tiene tareas";
                    }

                    if (!String.IsNullOrEmpty(miLector["terceraSesion"].ToString()))
                    {
                        oControlDiario.TerceraSesion = (string)miLector["terceraSesion"];
                    }
                    else
                    {
                        oControlDiario.TerceraSesion = "En esta sesión no tiene tareas";
                    }

                    if (!String.IsNullOrEmpty(miLector["cuartaSesion"].ToString()))
                    {
                        oControlDiario.CuartaSesion = (string)miLector["cuartaSesion"];
                    }
                    else
                    {
                        oControlDiario.CuartaSesion = "En esta sesión no tiene tareas";
                    }
                }
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }
            finally
            {
                if (miLector != null)
                    miLector.Close();

                if (conexion != null)
                    miConexion.closeConnection(ref conexion);
            }

            return oControlDiario;
        }
    }
}
