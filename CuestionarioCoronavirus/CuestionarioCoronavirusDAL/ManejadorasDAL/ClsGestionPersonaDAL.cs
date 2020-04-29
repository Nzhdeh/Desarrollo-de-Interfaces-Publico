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
        /// <summary>
        /// sirve para insertar una persona en la bbdd
        /// </summary>
        /// <param name="persona">la persona que vamos a guardar</param>
        /// <returns>un 0 si hay problemas de conexion, -1 si algun campo no esta rellenado y un numero mayor que 0 si todo va bien</returns>
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
                
                miComando.CommandText = "insert into CV_Personas(dniPersona,nombrePersona,apellidosPersona,telefono,direccion,diagnostico) " +
                                        "values(@dniPersona, @nombrePersona,@apellidosPersona,@telefono,@direccion,@diagnostico)";

                if(persona.DniPersona!="" && persona.NombrePersona!="" && persona.ApellidosPerson!="" && persona.Telefono!="" && persona.Direccion != "")
                {
                    miComando.Parameters.Add("@dniPersona", System.Data.SqlDbType.VarChar).Value=persona.DniPersona;
                    miComando.Parameters.Add("@nombrePersona", System.Data.SqlDbType.VarChar).Value = persona.NombrePersona;
                    miComando.Parameters.Add("@apellidosPersona", System.Data.SqlDbType.VarChar).Value = persona.ApellidosPerson;
                    miComando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = persona.Telefono;
                    miComando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = persona.Direccion;
                    miComando.Parameters.Add("@diagnostico", System.Data.SqlDbType.VarChar).Value = persona.Diagnostico;

                    conexion = miConexion.getConnection();
                    miComando.Connection = conexion;
                    resultado = miComando.ExecuteNonQuery();
                }
                else
                {
                    resultado = (-1);
                    //por si algun dato no se ha rellenado
                    var dlg = new MessageDialog("Rellena todos los campos por favor(El DNI tiene que tener 9 dígitos)");
                    var res = dlg.ShowAsync();
                }
            }
            catch (Exception exSql)
            {
                //if (resultado == 0)
                //{
                //    //por si hay algun problema con la contraseña o el enlace de la bbdd o el nombre de usuario
                //    var dlg = new MessageDialog("Problemas de conexión. Inténtalo más tarde por favor");
                //    var res = dlg.ShowAsync();
                //}
                throw exSql;
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
