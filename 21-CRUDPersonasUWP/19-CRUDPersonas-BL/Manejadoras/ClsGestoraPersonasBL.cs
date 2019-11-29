using _19_CRUDPersonas_DAL.Manejadoras;
using _19_CRUDPersonas_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19_CRUDPersonas_BL.Manejadoras
{
    public class ClsGestoraPersonasBL
    {
        /// <summary>
        /// buscar una  persona por su id
        /// </summary>
        /// <param name="id"> id de la persona a buscar </param>
        /// <returns>
        /// objeto persona
        /// </returns>
        public ClsPersona getPersonaEditar(int id)
        {
            ClsPersona persona;
            ClsGestoraPersonasDAL gestoraPersonaDAL = new ClsGestoraPersonasDAL();
            persona = gestoraPersonaDAL.BuscarPersonaPorId(id);

            return persona;
        }

        /// <summary>
        /// actualizar una persona
        /// </summary>
        /// <param name="persona">persona a actualizar</param>
        /// <returns>
        /// AN devuelve un entero mayor que cero si ha ido todo bien y 0 si no
        /// </returns>
        public int getGuardarPersona(ClsPersona persona)
        {
            int resultado = 0;
            ClsGestoraPersonasDAL gestoraPersonaDAL = new ClsGestoraPersonasDAL();
            resultado = gestoraPersonaDAL.updatePersonaDAL(persona);

            return resultado;
        }

        /// <summary>
        /// sirve para borrar una persona por su id
        /// </summary>
        /// <param name="id">id de la persona a borrar</param>
        /// <returns>
        /// AN devuelve un entero mayor que cero si ha ido todo bien y 0 si no
        /// </returns>
        public int getBorrarPersona(int id)
        {
            int resultado = 0;
            ClsGestoraPersonasDAL gestoraPersonaDAL = new ClsGestoraPersonasDAL();
            resultado = gestoraPersonaDAL.deletePersona(id);

            return resultado;
        }

        /// <summary>
        /// incerta una persona
        /// </summary>
        /// <param name="persona">la persona a incertar en la bbdd</param>
        /// <returns>
        /// AN devuelve un entero mayor que cero si ha ido todo bien y 0 si no
        /// </returns>
        public int getAddPersona(ClsPersona persona)
        {
            int resultado = 0;

            ClsGestoraPersonasDAL gestoraPersonaDAL = new ClsGestoraPersonasDAL();
            resultado = gestoraPersonaDAL.addPersonaDAL(persona);

            return resultado;
        }
    }
}
