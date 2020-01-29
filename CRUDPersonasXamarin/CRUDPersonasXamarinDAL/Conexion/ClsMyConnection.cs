using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// Esta clase contiene los métodos necesarios para trabajar con el acceso a una base de datos SQL Server
//PROPIEDADES
//   _server: cadena 
//   _database: cadena, básica. Consultable/modificable.
//   _user: cadena, básica. Consultable/modificable.
//   _pass: cadena, básica. Consultable/modificable.

// MÉTODOS
//   Function getConnection() As SqlConnection
//       Este método abre una conexión con la base de datos. Lanza excepciones de tipo: SqlExcepion, InvalidOperationException y Exception.
//   
//   Sub closeConnection(ByRef connection As SqlConnection)
//       Este método cierra una conexión con la base de datos. Lanza excepciones de tipo: SqlExcepion, InvalidOperationException y Exception.
//


namespace CRUDPersonasXamarinDAL.Conexion
{
    public class ClsMyConnection
    {
        /// <summary>
        /// esta funcion nos permite devolver la url de la api base
        /// </summary>
        /// <returns></returns>
        public static String getUriBase()
        {
            string uriBase;
            uriBase= "https://personasapi-avazquez.azurewebsites.net";

            return uriBase;
        }
    }

}
