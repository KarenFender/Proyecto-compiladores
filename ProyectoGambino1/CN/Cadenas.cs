using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoGambino1.CN
{
    class Cadenas
    {
        //Se recibe la cadena a analizar y la definicion del AFD
        public static bool Cadena(String cadena, List<CN.AFD> AFD)
        {
            //Se utilizan 2 variables
            //cont define el caracter en el que vamos
            //basecont es una variable de seguridad para detectar cuando una estado no tiene transiciones
            int cont = 0, basecont = AFD.Count;

            //obtenemos el estado inicial del AFD
            AFDEstado actual = AFD.ElementAt(0).inicio;            
            
            //analizamos para cada caracter en la cadena
            while (cont < cadena.Length)
            {
                basecont = AFD.Count;
                //analizamos para cada transicion en el AFD
                for (int i = 0; i < AFD.Count; i++)
                {
                    //obtenemos el caracter a analizar
                    char c = cadena[cont];

                    //Checa si el estado y el simbolo actual coincide con el AFD
                    if (AFD.ElementAt(i).inicio == actual && AFD.ElementAt(i).simbolo == c.ToString())
                    {
                        actual = AFD.ElementAt(i).final;
                        cont++;
                        basecont = AFD.Count;
                        if (cont == cadena.Length)
                        {
                            return actual.final;
                        }
                    }
                    basecont--;
                    if (basecont == 0)
                    {
                        return false;
                    }
                }
            }
            return false;
        }
    }
}
