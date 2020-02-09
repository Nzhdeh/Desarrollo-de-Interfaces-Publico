using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenAnimacionesUWPDAL.ManejadorasDAL
{
    public class ClsManejadoraDAL
    {
        /// <summary>
        /// Metodo que borra una persona por su ID de la BBDD
        /// </summary>
        /// <param name="id">El ID de la persona a eliminar</param>
        /*public void borrarPersona(int id)
        {
            int resultado = 0;
            clsMyConnection connection = new clsMyConnection();
            SqlConnection conn = connection.getConnection();
            SqlCommand miComando = new SqlCommand();
            miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
            try
            {
                miComando.CommandText = "DELETE FROM dbo.PD_Personas WHERE IdPersona = @id";
                miComando.Connection = conn;
                resultado = miComando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Creamos la persona y la introducimos en la BBDD
        /// </summary>
        /// <param name="persona">Este es el objeto que tiene que introducir en la BBDD</param>
        public void crearPersona(clsPersona persona)
        {
            int resultado = 0;
            clsMyConnection connection = new clsMyConnection();
            SqlConnection conn = connection.getConnection();
            SqlCommand miComando = new SqlCommand();
            miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = persona.Nombre;
            miComando.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = persona.Apellidos;
            miComando.Parameters.Add("@idDpto", System.Data.SqlDbType.Int).Value = persona.IDDepartamento;
            miComando.Parameters.Add("@fechaNacimiento", System.Data.SqlDbType.Date).Value = persona.FechaNacimiento;
            miComando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = persona.Telefono;
            miComando.Parameters.Add("@foto", System.Data.SqlDbType.VarBinary).Value = persona.Foto;
            try
            {
                miComando.CommandText = "INSERT INTO dbo.PD_Personas VALUES (@nombre, @apellidos, @idDpto, @fechaNacimiento, @telefono, @foto)";
                miComando.Connection = conn;
                resultado = miComando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Actualizamos la persona de la BBDD
        /// </summary>
        /// <param name="persona">Este es el objeto que tiene que actualizar en la BBDD</param>
        public void actualizarPersona(clsPersona persona)
        {
            int resultado = 0;
            clsMyConnection connection = new clsMyConnection();
            SqlConnection conn = connection.getConnection();
            SqlCommand miComando = new SqlCommand();
            miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = persona.IDPersona;
            miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = persona.Nombre;
            miComando.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = persona.Apellidos;
            miComando.Parameters.Add("@idDpto", System.Data.SqlDbType.Int).Value = persona.IDDepartamento;
            miComando.Parameters.Add("@fechaNacimiento", System.Data.SqlDbType.Date).Value = persona.FechaNacimiento;
            miComando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = persona.Telefono;
            miComando.Parameters.Add("@foto", System.Data.SqlDbType.VarBinary).Value = persona.Foto;
            try
            {
                miComando.CommandText = "UPDATE dbo.PD_Personas SET NombrePersona = @nombre, ApellidosPersona = @apellidos, IDDepartamento = @idDpto, FechaNacimientoPersona =  @fechaNacimiento, TelefonoPersona = @telefono, FotoPersona = @foto WHERE IdPersona = @id";
                miComando.Connection = conn;
                resultado = miComando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Con este metodo comprobamos si la persona introducida esta en la BBDD
        /// </summary>
        /// <param name="persona">La persona introducida</param>
        /// <returns>Si es true, la persona es una actualizacion, si es false la persona es una creacion</returns>
        public bool estoyEnBBDD(clsPersona persona)
        {
            bool estoy = false;
            clsPersona oPersona = new clsPersona();
            clsMyConnection connection = new clsMyConnection();
            SqlConnection conn = connection.getConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            try
            {
                miComando.CommandText = "SELECT * FROM dbo.PD_Personas WHERE idPersona = " + persona.IDPersona;
                miComando.Connection = conn;
                miLector = miComando.ExecuteReader();
                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    estoy = true;
                }
                miLector.Close();
                connection.closeConnection(ref conn);
            }
            catch
            {
                throw;
            }
            return estoy;
        }
        */
    }
}
