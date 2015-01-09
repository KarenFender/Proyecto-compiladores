using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoGambino1.CN
{
    class AFD
    {
        public AFDEstado inicio;
        public AFDEstado final;
        public String simbolo;

        public AFD(AFDEstado ini, String sim, AFDEstado fin)
        {
            inicio = ini;
            simbolo = sim;
            final = fin;
        }

        public String Descripcion()
        {
            //['A','a','B']
            return "['" + inicio.NombreChar + "' , '" + simbolo + "' , '" + final.NombreChar + "']";
        }

        public String Descripciongraphviz()
        {
            return inicio.NombreChar + "->" + final.NombreChar + " [label=\"" + simbolo + "\"];\n";
        }
    }
}
