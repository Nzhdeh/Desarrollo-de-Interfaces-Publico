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
    public class ClsGestionMedicoDAL
    {
        /// <summary>
        /// sirve para obtener un medico por su codigo
        /// </summary>
        /// <param name="codigoMedico">codigo del médico que queremos obtener</param>
        /// <returns>médicos</returns>
        public ClsMedico ObtenerMedicoDAL(string codigoMedico)
        {
            ClsMyConnection miConexion = null;

            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector = null;
            ClsMedico oMedico = null;
            SqlConnection conexion = null;
            miConexion = new ClsMyConnection();
            miComando.Parameters.Add("@codigo", System.Data.SqlDbType.Char).Value = codigoMedico;

            try
            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "select * from HO_Medicos where codigoMedico = @codigo";

                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    miLector.Read();

                    oMedico = new ClsMedico();

                    if (!String.IsNullOrEmpty(miLector["codigoMedico"].ToString()))
                    {
                        oMedico.CodigoMedico = (string)miLector["codigoMedico"];
                    }

                    if (!String.IsNullOrEmpty(miLector["nombreMedico"].ToString()))
                    {
                        oMedico.NombreMedico = (string)miLector["nombreMedico"];
                    }

                    if (!String.IsNullOrEmpty(miLector["apellidosMedico"].ToString()))
                    {
                        oMedico.ApellidosMedico = (string)miLector["apellidosMedico"];
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

            return oMedico;
        }

        /// <summary>
        /// sirve para ver si el codigo introducido pertenece a algún médico
        /// </summary>
        /// <param name="codigo">cogigo del medico que queremos ver si existe o no</param>
        /// <returns>true si el codigo corresponde a algún médico y false si no</returns>
        public bool ExisteMedicoDAL(string codigo)
        {
            ClsMyConnection miConexion = null;

            SqlCommand miComando = new SqlCommand();
            SqlConnection conexion = null;
            miConexion = new ClsMyConnection();
            miComando.Parameters.Add("@codigo", System.Data.SqlDbType.Char).Value = codigo;
            bool existe = false;
            int hayCosas = 0;

            try
            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "select count(*) from HO_Medicos where codigoMedico = @codigo";

                miComando.Connection = conexion;
                hayCosas = (int) miComando.ExecuteScalar();

                if (hayCosas != 0)
                {
                    existe = true;
                }
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }
            finally
            {
                if (conexion != null)
                    miConexion.closeConnection(ref conexion);
            }

            return existe;
        }
    }
}
