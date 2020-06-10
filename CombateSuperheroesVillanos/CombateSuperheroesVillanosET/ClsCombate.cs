using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombateSuperheroesVillanosDAL
{
    public class ClsCombate
    {
		private int idCombate;
		private string fechaCombate;


		public ClsCombate()
		{
			this.idCombate = 0;
			this.fechaCombate = "";
		}

		public ClsCombate(int idCombate, string fechaCombate)
		{
			this.idCombate = idCombate;
			this.fechaCombate = fechaCombate;
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


		public string FechaCombate
		{
			get
			{
				return this.fechaCombate;
			}
			set
			{
				this.fechaCombate = value;
			}
		}
	}
}
