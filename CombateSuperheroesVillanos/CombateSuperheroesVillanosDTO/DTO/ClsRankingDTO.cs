using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombateSuperheroesVillanosUI.DTO
{
    public class ClsRankingDTO
    {
        private string nombreLuchadorDTO;
        private int puntuacionLuchadorDTO;

        public ClsRankingDTO()
        {
            this.nombreLuchadorDTO = "";
            this.puntuacionLuchadorDTO = 0;
        }

        public ClsRankingDTO(string nombreLuchadorDTO, int puntuacionLuchadorDTO)
        {
            this.nombreLuchadorDTO = nombreLuchadorDTO;
            this.puntuacionLuchadorDTO = puntuacionLuchadorDTO;
        }

        public string NombreLuchadorDTO
        {
            get
            {
                return this.nombreLuchadorDTO;
            }
            set
            {
                this.nombreLuchadorDTO = value;
            }
        }

        public int PuntuacionLuchadorDTO
        {
            get
            {
                return this.puntuacionLuchadorDTO;
            }
            set
            {
                this.puntuacionLuchadorDTO = value;
            }
        }
    }
}
