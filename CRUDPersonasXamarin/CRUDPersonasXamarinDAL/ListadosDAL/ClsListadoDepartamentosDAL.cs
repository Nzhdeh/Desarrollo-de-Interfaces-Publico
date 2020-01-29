
using CRUDPersonasXamarinDAL.Conexion;
using CRUDPersonasXamarinET;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDPersonasXamarinDAL.ListadosDAL
{
    public class ClsListadoDepartamentosDAL
    {
        public List<ClsDepartamento> getListadoDepartamentosDAL()
        {
            ClsMyConnection miConexion=null;

            List<ClsDepartamento> listadoDepartamentos = new List<ClsDepartamento>();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector=null;

            ClsDepartamento departamento=null;

            SqlConnection conexion=null;


            miConexion = new ClsMyConnection();
            try
            {
                //conexion = miConexion.getConnection();
                miComando.CommandText = "SELECT * FROM PD_Departamentos";

                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        departamento = new ClsDepartamento();
                        departamento.IdDepartamentoa = (int)miLector["ID"];
                        departamento.NombreDepartamento = (string)miLector["Nombre"];
                        listadoDepartamentos.Add(departamento);
                    }
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
                //    miConexion.closeConnection(ref conexion);
            }

            return (listadoDepartamentos);
        }
    }
}
