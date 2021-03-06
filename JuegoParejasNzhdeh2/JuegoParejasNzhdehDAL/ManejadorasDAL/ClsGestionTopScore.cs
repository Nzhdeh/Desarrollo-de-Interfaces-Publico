﻿using JuegoParejasNzhdehDAL.Conexion;
using JuegoParejasNzhdehET;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace JuegoParejasNzhdehDAL.ManejadorasDAL
{
    public class ClsGestionTopScore
    {
        /// <summary>
        /// este metodo sirve para insertar el resultado de la partida en la base de datos
        /// </summary>
        /// <param name="score"></param>
        /// <returns>devuelve un entero si todo va bien y un cero si no</returns>
        public int InsertarPuntuacionDAL(ClsTopScore score) 
        {
            int resultado = 0;

            SqlConnection conexion = null;
            SqlCommand miComando = null;
            ClsMyConnection miConexion=null; 
           
            try
            {
                miComando = new SqlCommand();
                miConexion = new ClsMyConnection();

                miComando.CommandText = "insert into TopScore (NombrePersona,Tiempo) values(@NombrePersona, @tiempo)";

                miComando.Parameters.Add("@NombrePersona", System.Data.SqlDbType.VarChar).Value = score.NombrePersona;
                miComando.Parameters.Add("@tiempo", System.Data.SqlDbType.Time).Value = score.Tiempo; 

                conexion = miConexion.getConnection();
                miComando.Connection = conexion;
                resultado = miComando.ExecuteNonQuery();
                
            }
            catch (Exception exSql)
            {
               if(resultado==0)
                {
                    //por si ay algun problema con la contraseña o el enlace de la bbdd o el nombre de usuario
                    var dlg = new MessageDialog("Problemas de conexión. Inténtalo más tarde por favor");
                    var res =  dlg.ShowAsync();
                }
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }

            return resultado;
        }
    }
}
