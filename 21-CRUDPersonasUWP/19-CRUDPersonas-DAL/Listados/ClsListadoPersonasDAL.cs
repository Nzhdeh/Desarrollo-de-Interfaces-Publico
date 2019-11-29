using _19_CRUDPersonas_DAL.Conection;
using _19_CRUDPersonas_Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace _19_CRUDPersonas_DAL.Listados
{
    public class ClsListadoPersonasDAL
    {
        /// <summary>
        /// sirve para obtener un listado de personas
        /// </summary>
        /// <returns>
        /// una lista de personas
        /// </returns>
        
        public async Task<List<ClsPersona>> ListadoCompletoPersonas()
        {
            List<ClsPersona> listadoPersonas = new List<ClsPersona>();
            HttpClient miCliente = new HttpClient();
            String cadena= ClsMyConnection.getUriBase()+"PersonaApi/";
            Uri uri = new Uri(cadena);

            //poner en try catch
            HttpResponseMessage response = new HttpResponseMessage();

            if (response.IsSuccessStatusCode)
            {
                string result = await miCliente.GetStringAsync(uri);
                listadoPersonas = JsonConvert.DeserializeObject<List<ClsPersona>>(result);
            }
            
            return listadoPersonas;
        }
    }
}
