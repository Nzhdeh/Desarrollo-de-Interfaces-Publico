using CamellosDAL.ManejadorasDAL;
using CamellosET;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamellosBL.ManejadorasBL
{
    public class ClsManejadoraJugadorBL
    {
        /// <summary>
        /// prototipo: public int RegistrarJugadorDAL(string nick, string contraseña)
        /// comentarios: sirve para insertar a un jugador nuevo
        /// precondiciones: no hay
        /// </summary>
        /// <param name="nick">cadena</param>
        /// <param name="contraseña">cadena</param>
        /// <returns>un entero</returns>
        /// postcondiciones: asociado a nombre devuelve un 1 si el jugador se ha insertado correctamente y un 0 si no
        public int RegistrarJugadorBL(string nick, string contraseña)
        {
            int exito = 0;

            try
            {
                exito = new ClsManejadoraJugadorDAL().RegistrarJugadorDAL(nick, contraseña);
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }
            return exito;
        }

        /// <summary>
        /// prototipo: public bool ExisteNickDAL(string nick)
        /// comentarios: sirve para comprobar si el nick ya existe
        /// precondiciones: no hay
        /// </summary>
        /// <param name="nick">cadena </param>
        /// <returns>un boolean</returns>
        /// postcondiciones: asociado a nombre devuelve true si el nick existe y false si no
        public bool ExisteNickDAL(string nick)
        {
            bool correcto = false;

            try
            {
                correcto = new ClsManejadoraJugadorDAL().ExisteNickDAL(nick);
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }

            return correcto;
        }

        /// <summary>
        /// prototipo: public bool ComprobarNickYContraseñaCorrectosBL(string nick,string contraseña)
        /// comentarios: sirve para comprobar si los datos que el usuario introduce para acceder al juego son correctos
        /// precondiciones: no hay
        /// </summary>
        /// <param name="nick">cadena </param>
        /// <param name="contraseña">cadena</param>
        /// <returns>un boolean</returns>
        /// postcondiciones: asociado a nombre devuelve true si el usuario es correcto y un false en caso contrario
        public bool ComprobarNickYContraseñaCorrectosBL(string nick, string contraseña)
        {
            bool correcto = false;

            try
            {
                correcto = new ClsManejadoraJugadorDAL().ComprobarNickYContraseñaCorrectosDAL(nick,contraseña);
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }

            return correcto;
        }

        /// <summary>
        /// prototipo: public int ObtenerIdJugadorPorNickDAL(string nick)
        /// comentarios: sirve para obtener el id de un jugador por su nick
        /// precondiciones: no hay
        /// </summary>
        /// <param name="nick">cadena </param>
        /// <returns>un entero</returns>
        /// postcondiciones: asociado a nombre devuelve el id de un jugador o un cero si el nick no es válido
        public int ObtenerIdJugadorPorNickDAL(string nick)
        {
            int id = 0;

            try
            {
                id = new ClsManejadoraJugadorDAL().ObtenerIdJugadorPorNickDAL(nick);                
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }

            return id;
        }
    }
}
