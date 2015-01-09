using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoGambino1.CN
{
    class Estado
    {
        public int inicial;
        public int final;
        public String simbolo;

        public Estado(int i, int f, String s)
        {
            inicial = i;
            final = f;
            simbolo = s;
        }
    }
}
