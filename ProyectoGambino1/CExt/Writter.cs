using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoGambino1.CExt
{
    class Writter
    {
        #region Cadena AFD

        //GENERA EL ARCHIVO DE TEXTO DEL AFD
        public static void EscribirArchivo(List<CN.AFD> estados, String archivo)
        {

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@archivo))
            {
                String str = "digraph G {"  + AFD(estados)+ "}";
                file.WriteLine(str);
                file.Close();
            }
        }

        //AGREGA AL ARCHIVO LA CADENA CON LA DEFINICION DEL AFD SEGUN GRAPHVIZ
        private static String AFD(List<CN.AFD> a)
        {
            String str = "";
            str = str + InicioFin(a, "A");
            for (int i = 0; i < a.Count; i++)
            {
                str = str + a.ElementAt(i).Descripciongraphviz();
            }
            return str;
        }

        //AGREGA AL ARCHIVO LA DEFINICION DE NODO INICIAL Y FINAL
        private static String InicioFin(List<CN.AFD> a, String ini)
        {
            String str = "{\n";
            for (int i = 0; i < a.Count; i++)
            {
                if (a.ElementAt(i).final.final)
                {
                    str = str + a.ElementAt(i).final.NombreChar + " [label=\"" + a.ElementAt(i).final.NombreChar + "\" shape=doublecircle];\n";
                }
                if (a.ElementAt(i).inicio.NombreChar == ini)
                {
                    str = str + a.ElementAt(i).inicio.NombreChar + " [label=\"" + a.ElementAt(i).inicio.NombreChar + "\" style=filled fillcolor=cyan];\n";
                }
            }
            return str + "}\n";
        }
        #endregion

        #region Cadena AFN

        //GENERA EL ARCHIVO DE TEXTO DEL AFN
        public static void EscribirArchivo(List<CN.Estado> estados, String archivo, int inicio, int final)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@archivo))
            {
                String str = "digraph G {" + FormatearCadena(estados, inicio, final) + "}";
                file.WriteLine(str);
                file.Close();
            }
        }

        //AGREGA AL ARCHIVO LA CADENA CON LA DEFINICION DEL AFN SEGUN GRAPHVIZ
        private static String FormatearCadena(List<CN.Estado> a, int ini, int fin)
        {

            String str = "";
            str = str + InicioFin(a, ini, fin);
            for (int i = 0; i < a.Count; i++)
            {
                str = str + a.ElementAt(i).inicial + "->" + a.ElementAt(i).final + " [label=\"" + a.ElementAt(i).simbolo + "\"];\n";
            }
            return str;
        }

        //AGREGA AL ARCHIVO LA DEFINICION DE NODO INICIAL Y FINAL
        private static String InicioFin(List<CN.Estado> a, int ini, int fin)
        {
            String str = "{\n";
            for (int i = 0; i < a.Count; i++)
            {
                if (a.ElementAt(i).final == fin)
                {
                    str = str + a.ElementAt(i).final + " [label=\"" + a.ElementAt(i).final + "\" shape=doublecircle];\n";
                }
                if (a.ElementAt(i).inicial == ini)
                {
                    str = str + a.ElementAt(i).inicial + " [label=\"" + a.ElementAt(i).inicial + "\" style=filled fillcolor=cyan];\n";
                }
            }
            return str + "}\n";
        }
        #endregion
    }
}
