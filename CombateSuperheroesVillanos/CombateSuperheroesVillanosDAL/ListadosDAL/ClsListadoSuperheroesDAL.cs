using CombateSuperheroesVillanosDAL.Conexion;
using CombateSuperheroesVillanosET;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace CombateSuperheroesVillanosDAL.ListadosDAL
{
    public class ClsListadoSuperheroesDAL
    {
        /// <summary>
        /// prototipo: public ObservableCollection<ClsLuchador> ObtenerListadoLuchadoresDAL()
        /// comentarios: sirve para obtener el listado de los todos los luchadores
        /// precondiciones: no hay
        /// </summary>
        /// <returns>ObservableCollection<ClsLuchador> luchadores</returns>
        /// postcondiciones: asociado a nombre devuelve el listado de todos los luchadores o un null si no hay Luchadores o SQLException si no hay conexion
        public ObservableCollection<ClsLuchador> ObtenerListadoLuchadoresDAL()
        {
            ObservableCollection<ClsLuchador> luchadores = new ObservableCollection<ClsLuchador>();
            ClsLuchador luchador = null;

            ClsMyConnection miConexion = null;

            SqlCommand miComando = new SqlCommand();
            SqlConnection conexion = null;
            SqlDataReader miLector = null;
            miConexion = new ClsMyConnection();

            try
            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "select * from SH_Luchadores";

                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        luchador = new ClsLuchador();

                        luchador.IdLuchador = (int)miLector["idLuchador"];

                        if (!String.IsNullOrEmpty(miLector["nombreLuchador"].ToString()))
                        {
                            luchador.NombreLuchador = miLector["nombreLuchador"].ToString();
                        }

                        luchador.FotoLuchador = (miLector["fotoLuchador"] is DBNull) ? new byte[1] : (Byte[])miLector["fotoLuchador"];

                        luchadores.Add(luchador);
                    }
                }
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }
            finally
            {
                if (conexion != null)
                    miConexion.closeConnection(ref conexion);
            }

            return luchadores;
        }

        public async Task<BitmapImage> ImageFromBytes(Byte[] bytes)
        {
            BitmapImage image = new BitmapImage();
            using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
            {
                await stream.WriteAsync(bytes.AsBuffer());
                stream.Seek(0);
                image.SetSource(stream);
            }
            return image;

        }
        //public string ObtenerString(byte[] text)
        //{
        //    System.Text.ASCIIEncoding codificador = new System.Text.ASCIIEncoding();
        //    return codificador.GetString(text);
        //}
    }
}
