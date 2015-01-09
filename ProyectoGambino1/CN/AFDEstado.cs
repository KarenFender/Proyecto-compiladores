using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoGambino1.CN
{
    class AFDEstado
    {
        public int nombre;
        public List<Estado> estados = new List<Estado>();
        public List<int> intestado = new List<int>();
        public List<int> llave = new List<int>();
        public bool final;

        public AFDEstado(int nombre)
        {
            this.nombre = nombre;
        }

        public String NombreChar
        {
            get { return ((char)(nombre + 64)).ToString(); }
        }
    }
}
