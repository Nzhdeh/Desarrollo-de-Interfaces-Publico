using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenAnimacionesUWPDAL.ListadosDAL
{
    public class ClsListadoDAL
    {
        /// <summary>
        /// Se conecta a la BBDD y devuelve el listado de las personas
        /// </summary>
        /// <returns>Listado de personas List<clsPersona></returns>
      /*  public async Task<List<clsPersona>> listadoPersona()
        {
            List<clsPersona> listado = new List<clsPersona>();
            HttpClient miCliente = new HttpClient();

            Uri requestUri = new Uri(clsMyConnection.getUriBase() + "/Persona");

            //Send the GET request asynchronously and retrieve the response as a string.
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            string httpResponseBody = "";

            try
            {

                httpResponse = await miCliente.GetAsync(requestUri);

                if (httpResponse.IsSuccessStatusCode)
                {
                    httpResponseBody = await miCliente.GetStringAsync(requestUri);
                    listado = JsonConvert.DeserializeObject<List<clsPersona>>(httpResponseBody);
                }


            }
            catch (Exception ex)
            {
                httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
            }

            return listado;

        }*/

        /// <summary>
        /// Se conecta a la BBDD y devuelve el listado de los departamentos
        /// </summary>
        /// <returns>Listado de departamentos List<clsDepartamento></returns>
/*public List<clsDepartamento> listadoDpto()
{
    List<clsDepartamento> listado = new List<clsDepartamento>();
    clsMyConnection connection = new clsMyConnection();
    SqlConnection conn = connection.getConnection();
    SqlCommand miComando = new SqlCommand();
    SqlDataReader miLector;
    clsDepartamento oDpto;
    try
    {
        miComando.CommandText = "SELECT * FROM dbo.PD_Departamentos";
        miComando.Connection = conn;
        miLector = miComando.ExecuteReader();
        //Si hay lineas en el lector
        if (miLector.HasRows)
        {
            while (miLector.Read())
            {
                oDpto = new clsDepartamento();
                oDpto.ID = (int)miLector["IDDepartamento"];
                oDpto.Nombre = (string)miLector["NombreDepartamento"];
                listado.Add(oDpto);
            }
        }
        miLector.Close();
        connection.closeConnection(ref conn);
    }
    catch (SqlException exSql)
    {
        throw exSql;
    }
    return listado;
}
/// <summary>
/// Se conecta a la BBDD y devuelve la persona que tiene esa ID
/// </summary>
/// <param name="id">El id que tenemos que buscar</param>
/// <returns>Devolvemos la persona que tiene esa ID</returns>
public clsPersona personaporID(int id)
{
    clsPersona oPersona = new clsPersona();
    clsMyConnection connection = new clsMyConnection();
    SqlConnection conn = connection.getConnection();
    SqlCommand miComando = new SqlCommand();
    SqlDataReader miLector;
    try
    {
        miComando.CommandText = "SELECT * FROM dbo.PD_Personas WHERE idPersona = " + id;
        miComando.Connection = conn;
        miLector = miComando.ExecuteReader();
        //Si hay lineas en el lector
        if (miLector.HasRows)
        {
            while (miLector.Read())
            {
                oPersona.IDPersona = (int)miLector["IdPersona"];
                oPersona.Nombre = (miLector["NombrePersona"] is DBNull) ? "NULL" : (string)miLector["NombrePersona"];
                oPersona.Apellidos = (miLector["ApellidosPersona"] is DBNull) ? "NULL" : (string)miLector["ApellidosPersona"];
                oPersona.FechaNacimiento = (miLector["FechaNacimientoPersona"] is DBNull) ? new DateTime() : (DateTime)miLector["FechaNacimientoPersona"];
                //oPersona.Direccion = ((string)miLector["direccion"] != null) ? (string)miLector["direccion"] : null;
                oPersona.Telefono = (miLector["TelefonoPersona"] is DBNull) ? "NULL" : (string)miLector["TelefonoPersona"];
                oPersona.Foto = (miLector["FotoPersona"] is DBNull) ? new byte[1] : (Byte[])miLector["FotoPersona"];
                oPersona.IDDepartamento = (int)miLector["IDDepartamento"];
            }
        }
        miLector.Close();
        connection.closeConnection(ref conn);
    }
    catch (SqlException exSql)
    {
        throw exSql;
    }
    return oPersona;
}*/
    }
}
