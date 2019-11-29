using _19_CRUDPersonas_DAL.Conection;
using _19_CRUDPersonas_Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19_CRUDPersonas_DAL.Manejadoras
{
    class ClsGestoraDepartamentoDAL
    {

        /// <summary>
        /// sirve para buscar un departamento por su id
        /// </summary>
        /// <param name="id">id del departamento a buscar</param>
        /// <returns>
        /// objeto departamento
        /// </returns>
        public ClsDepartamento buscarDepartamentoPorID(int id)
        {

            ClsMyConnection miConexion=null;


            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector=null;

            ClsDepartamento oDepartamento = null;

            SqlConnection conexion=null;

            SqlParameter parameter;


            miConexion = new ClsMyConnection();
            try
            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "SELECT * FROM PD_Departamentos WHERE IdDepartamento = @id";
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
                    oDepartamento = new ClsDepartamento();
                    oDepartamento.IdDepartamentoa = (int)miLector["IdDepartamento"];
                    oDepartamento.NombreDepartamento = (string)miLector["NombreDepartamento"];
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

                if (miConexion != null)
                    miConexion.closeConnection(ref conexion);
            }

            return oDepartamento;

        }

        /// <summary>
        /// sirve para buscra un departamento por su nombre
        /// </summary>
        /// <param name="nombre">nombre del departamento</param>
        /// <returns>
        /// objeto departamento
        /// </returns>
        public ClsDepartamento buscarDepartamentoPorNombre(String nombre)
        {

            ClsMyConnection miConexion=null;


            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector=null;

            ClsDepartamento oDepartamento = null;

            SqlConnection conexion=null;

            SqlParameter parameter;


            miConexion = new ClsMyConnection();
            try
            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "SELECT * FROM PD_Departamentos WHERE NombreDepartamento = @nombre";
                parameter = new SqlParameter();
                parameter.ParameterName = "@nombre";
                parameter.SqlDbType = System.Data.SqlDbType.VarChar;
                parameter.Value = nombre;
                miComando.Parameters.Add(parameter);


                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    miLector.Read();
                    oDepartamento = new ClsDepartamento();
                    oDepartamento.IdDepartamentoa = (int)miLector["IdDepartamento"];
                    oDepartamento.NombreDepartamento = (string)miLector["NombreDepartamento"];
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

                if (miConexion != null)
                    miConexion.closeConnection(ref conexion);
            }

            return (oDepartamento);

        }
    }
}
