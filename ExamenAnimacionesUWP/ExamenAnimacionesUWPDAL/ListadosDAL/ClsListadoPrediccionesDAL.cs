using ExamenAnimacionesUWPDAL.Conexion;
using ExamenAnimacionesUWPET;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ExamenAnimacionesUWPDAL.ListadosDAL
{
    public class ClsListadoPrediccionesDAL
    {
        /// <summary>
        /// obtiene el listado de predicciones de una ciudad
        /// </summary>
        /// <param name="id"></param>
        /// <returns>listado de pronosticos</returns>
        public async Task<ObservableCollection<ClsPrediccion>> listadoPrediccionPorCiudadDAL(int id)
        {
            ObservableCollection<ClsPrediccion> listadoPrediccion = new ObservableCollection<ClsPrediccion>();
            HttpClient miCliente = new HttpClient();

            Uri requestUri = new Uri(ClsMyConnection.getUriBase() + "prediccion/" + id);

            //Send the GET request asynchronously and retrieve the response as a string.
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            string httpResponseBody = "";

            try
            {

                httpResponse = await miCliente.GetAsync(requestUri);

                if (httpResponse.IsSuccessStatusCode)
                {
                    httpResponseBody = await miCliente.GetStringAsync(requestUri);
                    listadoPrediccion = JsonConvert.DeserializeObject<ObservableCollection<ClsPrediccion>>(httpResponseBody);
                }

            }
            catch (Exception ex)
            {
                httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
            }

            return listadoPrediccion;

        }
    }
}
