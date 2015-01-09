using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoGambino1.CN
{
    class Subconjuntos
    {
        char[] alfabeto;
        int inicial, final;

        //PILAS Y ARREGLOS PARA EL MANEJO DE DATOS
        List<Estado> estados = new List<Estado>();
        Stack<Estado> estados_pendientes = new Stack<Estado>();
        List<AFDEstado> tablaDeEstados = new List<AFDEstado>();
        Queue<AFDEstado> AFDpendientes = new Queue<AFDEstado>();
        public List<AFD> DescripcionDelAFD = new List<AFD>();


        //CONTRUCTOR DE LA CLASE
        //EJECUTA LA CONVERSION DEL AFN AL AFD POR EL METODO DE SUBCONJUNTOS
        public Subconjuntos(char[] alf, List<String> s, int i, int f)
        {
            alfabeto = alf;
            AdaptaEstados(s);
            inicial = i;
            final = f;
            Calculo();
        }


        //ADAPTA EL FORMATO DE LOS ESTADOS DESDE UNA LISTA DE CADENAS
        private void AdaptaEstados(List<String> s)
        {
            for(int i = 0; i < s.Count; i++)
            {
                int ini = Convert.ToInt32(s.ElementAt(i).Substring(1, s.ElementAt(i).IndexOf(",")-1));
                String ch = s.ElementAt(i).Substring(s.ElementAt(i).IndexOf(" ") + 1,1);
                int fin = Convert.ToInt32(s.ElementAt(i).Substring(s.ElementAt(i).IndexOf(ch) + 2, s.ElementAt(i).IndexOf("]") - s.ElementAt(i).IndexOf(ch)-2));
                estados.Add(new Estado(ini, fin, ch));
            }
        }


        //REALIZA EL ALGORITMO DESUBCONJUNTOS
        private void Calculo()
        {
            //CERRADURA EPSILON AL ESTADO INICIAL
            Cerradura(null, inicial, "@", 1);

            //CALCULAMOS LOS DISTINTOS ESTADOS
            while (AFDpendientes.Count > 0)
            {
                AFDEstado estado1 = Mover(AFDpendientes.Peek(), "a");
                AFDEstado estado2 = Mover(AFDpendientes.Peek(), "b");
                //SE VERIFICA QUE EL RESULTADO DE MOVER DIERA UN ESTADO VALIDO (NO POZO)
                if (estado1.llave.Count > 0)
                {
                    //VERIFICA SI EL ESTADO YA EXISTE
                    if (EstadoPrevio(estado1) == false)
                    {
                        AFDEstado resultA = null;
                        
                        //SI LA LLAVE DEL ESTADO NO EXISTE PREVIAMENTE
                        for (int i = 0; i < estado1.intestado.Count; i++)
                        {
                            resultA = Cerradura(estado1, estado1.intestado.ElementAt(i), "@", estado1.nombre);
                        }
                        if (resultA != null)
                        {
                            //SE ASIGNA UN NOMBRE UNICO
                            resultA.nombre = tablaDeEstados.Count + 1;

                            //SE AGREGA EL ESTADO A LA TABLA
                            tablaDeEstados.Add(resultA);

                            //SE GUARDA SI EL ESTADO ES FINAL O NO
                            esFinal(resultA);
                            
                            //SE AGREGA EL ESTADO A LA DESCRIPCION DE ESTADOS
                            DescripcionDelAFD.Add(new AFD(AFDpendientes.Peek(), "a", resultA));
                        }
                    }
                    else
                    {
                        //SI LA LLAVE DEL ESTADO YA SE HABIA CALCULADO EN UN ESTADO PREVIO
                        DescripcionDelAFD.Add(new AFD(AFDpendientes.Peek(), "a", NombrePrevio(estado1)));
                    }
                }
                if (estado2.llave.Count > 0)
                {
                    if (EstadoPrevio(estado2) == false)
                    {
                        AFDEstado resultB = null;
                        for (int i = 0; i < estado2.intestado.Count; i++)
                        {
                            resultB = Cerradura(estado2, estado2.intestado.ElementAt(i), "@", estado2.nombre);
                        }
                        
                        resultB.nombre = tablaDeEstados.Count + 1;
                        tablaDeEstados.Add(resultB);
                        
                        //SE GUARDA SI EL ESTADO ES FINAL O NO
                        esFinal(resultB);

                        if (resultB != null)
                        {
                            
                            DescripcionDelAFD.Add(new AFD(AFDpendientes.Dequeue(), "b", resultB));
                        }
                    }
                    else
                    {
                        //SI LA LLAVE DEL ESTADO YA SE HABIA CALCULADO EN UN ESTADO PREVIO
                        DescripcionDelAFD.Add(new AFD(AFDpendientes.Dequeue(), "b", NombrePrevio(estado2)));
                    }
                }
            }
                //ImprimeAFD();
            
        }

        //RETORNA LA REFERENCIA DEL ESTADO PREVIAMENTE CREADO
        private AFDEstado NombrePrevio(AFDEstado estadoactual)
        {
            //REVISAR IMPLEMENTACCION
            for (int i = 0; i < tablaDeEstados.Count; i++)
            {
                if(Igual(tablaDeEstados.ElementAt(i).llave,estadoactual.llave))
                {
                    return tablaDeEstados.ElementAt(i);
                }
            }
            return null;
        }

        //APLUICA LA FUNCION MOVER A UN ESTADO CON UN SIMBOLO DADO
        private AFDEstado Mover(AFDEstado estado, String simbolo)
        {
            AFDEstado temp = new AFDEstado(tablaDeEstados.Count + 1);
            for (int i = 0; i < estado.intestado.Count; i++)
            {
                for (int j = 0; j < estados.Count; j++)
                {
                    if (estado.intestado.ElementAt(i) == estados.ElementAt(j).inicial)
                    {
                        if (estados.ElementAt(j).simbolo == simbolo)
                        {
                            if (!temp.intestado.Contains(estados.ElementAt(j).final))
                            {
                                temp.intestado.Add(estados.ElementAt(j).final);
                                temp.llave.Add(estados.ElementAt(j).final);
                            }
                        }
                    }
                }
            }
            temp.llave.Sort();
            return temp;
        }

        //INDICA SI UN ESTADO DADO YA HABIA SIDO CREADO CON ANTERIORIDAD
        private bool EstadoPrevio(AFDEstado estadoactual)
        {
            bool existe = false;
            for (int i = 0; i < tablaDeEstados.Count; i++)
            {
                if (Igual(tablaDeEstados.ElementAt(i).llave,estadoactual.llave))
                {
                    existe = true;
                    break;
                }
            }
            return existe;
        }
        
        //COMPARA LAS LLAVES DE 2 ESTADOS PARA SABER SI SON EL MISMO
        private bool Igual(List<int> a, List<int> b)
        {
            bool res = false;
            int sum = 0;
            if (a.Count == b.Count)
            {
                for (int i = 0; i < a.Count; i++)
                {
                    if (a.ElementAt(i) == b.ElementAt(i))
                    {
                        sum++;
                    }
                }
                if (sum == a.Count)
                {
                    res = true;
                }
            }
            return res;
        }

        //APLICA CERRADURA EPSILON A UN ESTADO DADO.
        private AFDEstado Cerradura(AFDEstado estadoactual,int inicio, String simbolo, int Nombre)
        {
            AFDEstado estado;
            if (estadoactual == null)
            {
                //CREAR UN NUEVO ESTADO AFD
                estado = new AFDEstado(Nombre);
                estado.intestado.Add(inicio);
                estado.llave.Add(inicio);
                tablaDeEstados.Add(estado);
            }
            else
            {
                estado = estadoactual;
                if (!estado.intestado.Contains(inicio))
                {
                    estado.intestado.Add(inicio);
                }
            }
                        
            for (int i = 0; i < estados.Count; i++)
            {
                if (estados.ElementAt(i).inicial == inicio)
                {
                    if (estados.ElementAt(i).simbolo == simbolo)
                    {
                        if(!estados_pendientes.Contains(estados.ElementAt(i)))
                        {
                            estados_pendientes.Push(estados.ElementAt(i));
                        }
                    }
                }
            }
            while (estados_pendientes.Count > 0)
            {
                Cerradura(estado,estados_pendientes.Pop().final, simbolo,estado.nombre);
            }
            if(!AFDpendientes.Contains(estado))
            {
                AFDpendientes.Enqueue(estado);
            }
            return estado;
        }

        
        #region Finales
        //GUARDA EN EL ESTADO SI ESTE ES FINAL
        private void esFinal(AFDEstado estado)
        {
            estado.final = false;
            for (int i = 0; i < estado.intestado.Count; i++)
            {
                if (estado.intestado.ElementAt(i) == final)
                {
                    estado.final = true;
                }
            }
        }

        //IMPRIME UNA LISTA CON LOS ESTADOS FINALES
        public String ImprimeFinales()
        {
            String str = "[";
            for (int i = 0; i < tablaDeEstados.Count; i++)
            {
                if (tablaDeEstados.ElementAt(i).final == true)
                {
                    str = str + "'"+tablaDeEstados.ElementAt(i).NombreChar+"'";
                }
            }
            if (str.EndsWith(","))
            {
                str = str.Substring(0, str.Length - 1);
            }
            return str + "]";

        }
        #endregion

        #region Pruebas
        //IMPRIME LA DESCRIPCION DEL AFD
        private void ImprimeAFD()
        {
            for (int i = 0; i < DescripcionDelAFD.Count; i++)
            {
                System.Windows.Forms.MessageBox.Show(DescripcionDelAFD.ElementAt(i).Descripcion());
            }
        }
        #endregion
    }
}
