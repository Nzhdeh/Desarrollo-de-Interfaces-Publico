using CRUDPersonasXamarinDAL.Conexion;
using CRUDPersonasXamarinET;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CRUDPersonasXamarinDAL.ListadosDAL
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
