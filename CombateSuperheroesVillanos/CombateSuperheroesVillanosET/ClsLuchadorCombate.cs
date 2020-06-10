using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombateSuperheroesVillanosET
{
    public class ClsLuchadorCombate
    {
        private int idCombate;
		private int idLuchador;
		private int puntuacionLuchador;

		public ClsLuchadorCombate()
		{
			this.idCombate = 0;
			this.idLuchador = 0;
			this.puntuacionLuchador = 0;
		}

		public ClsLuchadorCombate(int idCombate, int idLuchador, int puntuacionLuchador)
		{
			this.idCombate = idCombate;
			this.idLuchador = idLuchador;
			this.puntuacionLuchador = puntuacionLuchador;
		}

		public int IdCombate
		{
			get
			{
				return this.idCombate;
			}
			set
			{
				this.idCombate = value;
			}
		}

		public int IdLuchador
		{
			get
			{
				return this.idLuchador;
			}
			set
			{
				this.idLuchador = value;
			}
		}

		public int PuntuacionLuchador
		{
			get
			{
				return this.puntuacionLuchador;
			}
			set
			{
				this.puntuacionLuchador = value;
			}
		}
	}
}
