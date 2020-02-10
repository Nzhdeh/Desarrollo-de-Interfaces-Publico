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
    public class ClsListadoCiudadesDAL
    {
        /// <summary>
        /// esta funcion sirve para obtener el listado de todas las ciudades de la API
        /// </summary>
        /// <returns>Listado de ciudades ObservableCollection<ClsCiudad></returns>
        public async Task<ObservableCollection<ClsCiudad>> listadoCiudadesDAL()
        {
            ObservableCollection<ClsCiudad> listado = new ObservableCollection<ClsCiudad>();
            HttpClient miCliente = new HttpClient();

            Uri requestUri = new Uri(ClsMyConnection.getUriBase()+"ciudades");

            //Send the GET request asynchronously and retrieve the response as a string.
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            string httpResponseBody = "";

            try
            {

                httpResponse = await miCliente.GetAsync(requestUri);

                if (httpResponse.IsSuccessStatusCode)
                {
                    httpResponseBody = await miCliente.GetStringAsync(requestUri);
                    listado = JsonConvert.DeserializeObject<ObservableCollection<ClsCiudad>>(httpResponseBody);
                }


            }
            catch (Exception ex)
            {
                httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
            }

            return listado;

        }

        /// <summary>
        /// esta funcion sirve para obtener la ciudad por su id
        /// </summary>
        /// <returns>objeto ClsCiudad</returns>
        public async Task<ClsCiudad> obtenerCiudadePorIdDAL(int id)
        {
            ClsCiudad ciudad = new ClsCiudad();
            ObservableCollection<ClsCiudad> listado = new ObservableCollection<ClsCiudad>();
            bool encontrado = false;
            try
            {
                listado =await listadoCiudadesDAL();
               
                for(int i=0;i<listado.Count && encontrado==false;i++)
                {
                    if(listado[i].IdCiudad==id)
                    {
                        ciudad = listado[i];
                        encontrado = true;
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ciudad;

        }


        /// <summary>
        /// obtiene el listado de predicciones de una ciudad
        /// </summary>
        /// <param name="id"></param>
        /// <returns>listado de pronosticos</returns>
        public async Task<ObservableCollection<ClsPrediccion>> listadoPrediccionPorCiudadDAL(int id)
        {
            ObservableCollection<ClsPrediccion> listadoPrediccion = new ObservableCollection<ClsPrediccion>();
            HttpClient miCliente = new HttpClient();

            Uri requestUri = new Uri(ClsMyConnection.getUriBase() + "prediccion/"+id);

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
