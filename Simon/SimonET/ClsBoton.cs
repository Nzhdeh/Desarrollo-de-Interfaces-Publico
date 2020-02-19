using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimonET
{
    public class ClsBoton
    {
        private int id;
        private string sonido;
        private string color;

        public ClsBoton()
        {
            this.id = 0;
            this.sonido = "";
            this.color = "";
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Sonido
        {
            get { return sonido; }
            set { sonido = value; }
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }
    }
}
