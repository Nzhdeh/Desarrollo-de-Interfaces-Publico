using CuestionarioCoronavirusDAL.Conexion;
using CuestionarioCoronavirusET;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace CuestionarioCoronavirusDAL.ManejadorasDAL
{
    public class ClsGestionPersonaDAL
    {
        public int InsertarPersonaDAL(ClsPersona persona)
        {
            int resultado = 0;

            SqlConnection conexion = null;
            SqlCommand miComando = null;
            ClsMyConnection miConexion = null;

            try
            {
                miComando = new SqlCommand();
                miConexion = new ClsMyConnection();
                
                miComando.CommandText = "insert into Personas (dniPersona,nombrePersona,apellidosPerson,telefono,direccion,diagnostico) " +
                    "values(@dniPersona, @nombrePersona,@apellidosPerson,@telefono,@direccion,@diagnostico)";

                miComando.Parameters.Add("@dniPersona", System.Data.SqlDbType.Char).Value = persona.DniPersona;
                miComando.Parameters.Add("@nombrePersona", System.Data.SqlDbType.VarChar).Value = persona.NombrePersona;
                miComando.Parameters.Add("@apellidosPerson", System.Data.SqlDbType.VarChar).Value = persona.ApellidosPerson;
                miComando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = persona.Telefono;
                miComando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = persona.Direccion;
                miComando.Parameters.Add("@diagnostico", System.Data.SqlDbType.Bit).Value = persona.Diagnostico;

                conexion = miConexion.getConnection();
                miComando.Connection = conexion;
                resultado = miComando.ExecuteNonQuery();
            }
            catch (Exception exSql)
            {
                if (resultado == 0)
                {
                    //por si ay algun problema con la contraseña o el enlace de la bbdd o el nombre de usuario
                    var dlg = new MessageDialog("Problemas de conexión. Inténtalo más tarde por favor");
                    var res = dlg.ShowAsync();
                }
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }

            return resultado;
        }
    }
}
