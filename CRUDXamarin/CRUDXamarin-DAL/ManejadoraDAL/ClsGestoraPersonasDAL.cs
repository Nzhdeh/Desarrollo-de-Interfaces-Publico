using CRUDXamarin_DAL.Conexion;
using CRUDXamarin_ET;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDXamarin_DAL.ManejadoraDAL
{
    public class ClsGestoraPersonasDAL
    {
        #region Metodos
        /// <summary>
        /// devuelve una persona segun su id
        /// </summary>
        /// <param name="id">id de la persona</param>
        /// <returns>
        /// objeto persona
        /// </returns>
        public ClsPersona BuscarPersonaPorId(int id)
        {

            ClsMyConnection miConexion;


            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector = null;

            ClsPersona oPersona = null;

            SqlConnection conexion = null;

            SqlParameter parameter;


            //miConexion = new ClsMyConnection();
            try
            {
                //conexion = miConexion.getConnection();
                miComando.CommandText = "SELECT * FROM PD_Personas WHERE IDPersona = @id";
                parameter = new SqlParameter();
                parameter.ParameterName = "@id";
                parameter.SqlDbType = System.Data.SqlDbType.Int;
                parameter.Value = id;
                miComando.Parameters.Add(parameter);


                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    miLector.Read();
                    oPersona = new ClsPersona();
                    oPersona.IdPersona = (int)miLector["IDPersona"];
                    oPersona.NombrePersona = (string)miLector["NombrePersona"];
                    oPersona.ApellidosPersona = (string)miLector["ApellidosPersona"];
                    oPersona.FechaNacimientoPersona = (DateTime)miLector["FechaNacimientoPersona"];
                    oPersona.TelefonoPersona = (string)miLector["TelefonoPersona"];
                    oPersona.FotoPersona = null;//hay que recuperar la imagen
                    oPersona.IDDEpartamento = (int) miLector["IDDepartamento"];
                }
            }

            catch (SqlException exSql)
            {
                throw exSql;
            }
            finally
            {
                if(miLector!=null)
                    miLector.Close();

                //if(miConexion!=null)
                //miConexion.closeConnection(ref conexion);
            }

            return (oPersona);

        }

        /// <summary>
        /// actualiza una persona
        /// </summary>
        /// precondiciones: no hay
        /// postcondiciones: devuelve un numero mayor que cero si todo ha ido bien y 0 si no
        /// <param name="persona"> objeto persona a actualizar</param>
        /// <returns>
        /// un entero
        /// </returns>
        public int updatePersonaDAL(ClsPersona persona)
        {

            SqlConnection conexion=null;
            SqlCommand miComando = new SqlCommand();
            ClsMyConnection miConexion = new ClsMyConnection(); ;
            int resultado = 0;


            miComando.CommandText = "UPDATE personas SET NombrePersona=@nombre, ApellidosPersona=@apellidos, FechaNacimientoPersona=@fechaNac, " +
                "Telefono=@telefono, IDDepartamento=@idDepartamento, FotoPersona=@fotoPersona WHERE IdPersona = @idPersona";
            miComando.Parameters.Add("@idPersona", System.Data.SqlDbType.Int).Value = persona.IdPersona;
            miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = persona.NombrePersona;
            miComando.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = persona.ApellidosPersona;
            miComando.Parameters.Add("@fechaNac", System.Data.SqlDbType.DateTime).Value = persona.FechaNacimientoPersona;
            miComando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = persona.TelefonoPersona;
            miComando.Parameters.Add("@fotoPersona", System.Data.SqlDbType.VarBinary).Value = persona.FotoPersona;
            miComando.Parameters.Add("@idDepartamento", System.Data.SqlDbType.Int).Value = persona.IDDEpartamento;

            try
            {
                //conexion = miConexion.getConnection();
                miComando.Connection = conexion;
                resultado = miComando.ExecuteNonQuery();
            }

            catch (Exception exSql)
            {
                throw exSql;
            }
            finally
            {
                if(conexion!=null)
                    conexion.Close();
            }


            return resultado;
        }


        /// <summary>
        /// elimina una persona por su id
        /// </summary>
        /// <param name="id">id de la persona a eliminar</param>
        /// <returns>
        /// un entero mayor que cero si ha ido todo bien y 0 si no
        /// </returns>
        public int deletePersona(int id)
        {
            SqlConnection conexion=null;
            SqlCommand miComando = new SqlCommand();
            ClsMyConnection miConexion = new ClsMyConnection(); ;
            int resultado = 0;
            miComando.CommandText = "DELETE FROM PD_Personas WHERE IDPersona = @idPersona";
            miComando.Parameters.Add("@idPersona", System.Data.SqlDbType.Int).Value = id;

            try
            {
                //conexion = miConexion.getConnection();
                miComando.Connection = conexion;
                resultado = miComando.ExecuteNonQuery();
            }

            catch (Exception exSql)
            {
                throw exSql;
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }


            return resultado;
        }

        /// <summary>
        /// incerta una persona en la bbdd
        /// </summary>
        /// <param name="persona"> objeto persona a incertar</param>
        /// <returns>
        /// un entero mayor que cero si ha ido todo bien y 0 si no
        /// </returns>
        public int addPersonaDAL(ClsPersona persona)
        {
            int resultado = 0;

            SqlConnection conexion=null;
            SqlCommand miComando = new SqlCommand();
            ClsMyConnection miConexion = new ClsMyConnection(); ;
            miComando.CommandText = "INSERT INTO PD_Personas (NombrePersona, ApellidosPersona, FechaNacimientoPersona,Telefono, IDDepartamento, FotoPersona) " +
                                    "VALUES @nombre, @apellidos, @fechaNac,@telefono, @idDepartamento,@fotoPersona)";
            
            miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = persona.NombrePersona;
            miComando.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = persona.ApellidosPersona;
            miComando.Parameters.Add("@fechaNac", System.Data.SqlDbType.DateTime).Value = persona.FechaNacimientoPersona;
            miComando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = persona.TelefonoPersona;
            miComando.Parameters.Add("@fotoPersona", System.Data.SqlDbType.VarBinary).Value = persona.FotoPersona;
            miComando.Parameters.Add("@idDepartamento", System.Data.SqlDbType.Int).Value = persona.IDDEpartamento;


            try
            {
                //conexion = miConexion.getConnection();
                miComando.Connection = conexion;
                resultado = miComando.ExecuteNonQuery();
            }

            catch (Exception exSql)
            {
                throw exSql;
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }

            return resultado;
        }

        #endregion
    }
}
