﻿using _19_CRUDPersonas_DAL.Conection;
using _19_CRUDPersonas_Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19_CRUDPersonas_DAL.Listados
{
    public class ClsListadoPersonasDAL
    {
        //TODO funcion que devuelve un listado completo de personas
        public List<ClsPersona> ListadoCompletoPersonas()
        {
            ClsMyConnection miConexion=null;

            List<ClsPersona> listadoPersonas = new List<ClsPersona>();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector=null;

            ClsPersona oPersona=null;

            SqlConnection conexion=null;


            miConexion = new ClsMyConnection();
            try
            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "SELECT * FROM PD_Personas";

                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                //Si hay lineas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oPersona = new ClsPersona();
                        oPersona.IdPersona = (int)miLector["IDPersona"];
                        oPersona.NombrePersona = (string)miLector["NombrePersona"];
                        oPersona.ApellidosPersona = (string)miLector["ApellidosPersona"];
                        oPersona.FechaNacimientoPersona = (DateTime)miLector["FechaNacimientoPersona"];
                        oPersona.TelefonoPersona = (string)miLector["TelefonoPersona"];
                        oPersona.FotoPersona = null;//hay que recuperar la imagen
                        oPersona.IDDEpartamento = (int)miLector["IDDepartamento"];
                        listadoPersonas.Add(oPersona);
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

                if(miConexion!=null)
                    miConexion.closeConnection(ref conexion);
            }

            return listadoPersonas;
        }
    }
}
