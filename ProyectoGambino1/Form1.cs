using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace ProyectoGambino1
{
    public partial class Form1 : Form
    {

        #region Filtros de caracteres para python
        bool lalala = Variables.Default.lalala;
        char[] filtro1 = { '[', ']', ',', ' ', (char)39, (char)13, (char)10 };
        char[] filtro2 = { (char)39, (char)13, (char)10 };
        char[] filtro3 = { '[', ']', ',', (char)39, (char)13, (char)10 };
        char[] REGEX = { '(', ')', '*', '+', '-', '/', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
        String[] cadenas = { "(a/b)*-a-b-b", "(a/b*-c)/(a-b/c+)", "a-b*/(c/d)+-a*", "a/((a/b)-c)*-d+" };
        #endregion

        char[] alfabeto;
        List<String> AFN = new List<string>();
        CN.Subconjuntos sub;
        List<CN.Estado> estados = new List<CN.Estado>();
        int inicio, final;
        String[] validarCadenaParametros;

        public Form1()
        {
            InitializeComponent();
        }
        #region Metodos Generales
        //DETECTA CUANDO SE PRESIONA ALGUNA TECLA ESPECIAL
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (textBox1.Text != "")
                    {
                        InfijaPosfijaThomson();
                    }
                    break;
                case Keys.F1:
                    Limpiar();
                    textBox1.Text = cadenas[0];
                    break;
                case Keys.F2:
                    Limpiar();
                    textBox1.Text = cadenas[1];
                    break;
                case Keys.F3:
                    Limpiar();
                    textBox1.Text = cadenas[2];
                    break;
                case Keys.F4:
                    Limpiar();
                    textBox1.Text = cadenas[3];
                    break;
                case Keys.F8:
                    Configuracion cof = new Configuracion();
                    cof.ShowDialog();
                    break;
                case Keys.F11:
                    if (lalala == true)
                    {
                        lalala = false;
                        MessageBox.Show("Tiempo desactivado :'(");
                    }
                    else
                    {
                        lalala = true;
                        MessageBox.Show("Tiempo activado xP");
                    }
                    Variables.Default.Save();
                    break;
                case Keys.Back:
                    Limpiar();
                    break;
            }
        }

        //LIMPIA LA APLICACION
        private void Limpiar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            AFN.Clear();
            estados.Clear();
            richTextBox1.Clear();
            richTextBox2.Clear();
            sub = null;
            if (Pic_AFD.Image != null)
            {
                Pic_AFD.Image.Dispose();
            }
            Pic_AFD.Image = null;
            if (Pic_AFN.Image != null)
            {
                Pic_AFN.Image.Dispose();
            }
            Pic_AFN.Image = null;
            groupBox3.Enabled = false;
            label5.ForeColor = Color.Black;
            label5.BackColor = SystemColors.Control;
            ValidaCadena.Text = "";
        }
        #endregion

        private void Analizador(String str)
        {

            #region Sufijos
            string ini = DateTime.UtcNow.ToString("m:ss.fff");
            //MUESTRA LA CADENA SUFIJA
            textBox2.Text = FiltrarCadenas(Subcadena(str, "p", "a"), filtro1);

            //GUADA EL ALFABETO
            alfabeto = FiltrarCadenas(Subcadena(str, "a", "t"), filtro1).ToCharArray();

            //IMPRIME EL ALFABETO
            textBox3.Text = Imprime(alfabeto);
            #endregion

            #region AFN
            //GUARDA THOMPSON
            ExtraeAFN(Subcadena(str, "t", "f"));

            //IMPRIME THOMPSON
            richTextBox1.AppendText(Imprime(AFN));

            //OBTIENE INICIO Y FIN DEL AFN
            InicioFin(Subcadena(str, "f", "e"));

            //IMPRIME INICIO Y FINAL DE THOMPSON
            richTextBox1.AppendText("\n\nInicio: " + inicio + "\nFinal: " + final);

            //CONVIERTE LOS ESTADOS DEL AFN (EN CADENAS) A ESTADOS AFN (OBJETOS)
            AdaptaEstados(AFN);

            //GUARDA EL AFN EN UN ARCHIVO PARA GENERAR LA IMAGEN
            CExt.Writter.EscribirArchivo(estados, Variables.Default.AFN_Archivo,inicio,final);

            //CREA LA IMAGEN DEL AFN
            CExt.Procesos.EjecutaGraphviz("-Tpng", Variables.Default.AFN_Archivo, Variables.Default.AFN_Imagen);

            //MUESTRA LA IMAGEN DEL AFN
            if (Pic_AFN.Image != null)
            {
                Pic_AFN.Image.Dispose();
            }
            Pic_AFD.Image = null;
            Pic_AFN.Image = new Bitmap(Variables.Default.AFN_Imagen);
            #endregion

            #region AFD

            //CONVIERTE A AFD
            sub = new CN.Subconjuntos(alfabeto, AFN, inicio, final);

            //IMPRIME EL AFD
            richTextBox2.AppendText(Imprime(sub.DescripcionDelAFD));

            //INCLUYE EL INICIAL
            richTextBox2.AppendText("\n\nInicio: ['" + sub.DescripcionDelAFD.ElementAt(0).inicio.NombreChar + "']");

            //INCLUYE EL FINAL
            richTextBox2.AppendText("\n\nFinales: " + sub.ImprimeFinales());

            //GUARDA EL AFD EN UN ARCHIVO PARA GENERAR LA IMAGEN
            CExt.Writter.EscribirArchivo(sub.DescripcionDelAFD, Variables.Default.AFD_Archivo);

            //CREA LA IMAGEN DEL AFD
            CExt.Procesos.EjecutaGraphviz("-Tpng", Variables.Default.AFD_Archivo, Variables.Default.AFD_Imagen);

            //MUESTRA LA IMAGEN DEL AFD
            if (Pic_AFD.Image != null)
            {
                Pic_AFD.Image.Dispose();
            }
            Pic_AFD.Image = null;
            Pic_AFD.Image = new Bitmap(Variables.Default.AFD_Imagen);
            #endregion

            #region Cadenas
            //SE CARGA LA VALIDACION DE LA CADENA
            /*------------------------------------En proceso------------------------------------*/

            //SE ADAPTA LA DESCRIPCION PARA ENVIAR COMO PARAMETRO A PYTHON
            validarCadenaParametros = AdaptaEstados(sub.DescripcionDelAFD);
            validarCadenaParametros[2] = ValidaCadena.Text;

            groupBox3.Enabled = true;
            string fin = DateTime.UtcNow.ToString("m:ss.fff");
            if (lalala == true)
            {
                Resta(ini, fin);
            }
            #endregion
        }

        #region Metodos de Operacion
        private String FiltrarCadenas(String str, char[] filtro)
        {
            String res = "";
            for (int i = 0; i < str.Length; i++)
            {
                for (int j = 0; j < filtro.Length; j++)
                {
                    if (str[i] == filtro[j])
                    {
                        break;
                    }
                    if (j + 1 == filtro.Length)
                    {
                        res = res + str[i];
                    }
                }
            }
            return res;
        }

        private void InfijaPosfijaThomson()
        {
            try
            {
                if (Cadenas(textBox1.Text,REGEX))
                {
                    if (Variables.Default.Script == "")
                    {
                        OpenFileDialog open = new OpenFileDialog();
                        if (open.ShowDialog() == DialogResult.OK)
                        {
                            String[] a = { textBox1.Text };
                            String posfija = CExt.Procesos.EjecutarPython(Variables.Default.Script, a);
                            if (posfija != null)
                            {
                                Analizador(posfija);
                            }
                        }
                    }
                    else
                    {
                        String[] a = { textBox1.Text };
                        String posfija = CExt.Procesos.EjecutarPython(Variables.Default.Script, a);
                        if (posfija != null)
                        {
                            Analizador(posfija);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("La Expresion regular tiene caracteres erroneos.");
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex + "");
            }
        }

        private void InicioFin(String str)
        {
            str = FiltrarCadenas(str,filtro2);
            try
            {
                inicio = Convert.ToInt32(str.Substring(str.IndexOf(",") + 1, str.IndexOf("]") - str.IndexOf(",") - 1));
                str = str.Substring(str.IndexOf("]")+1);
                final = Convert.ToInt32(str.Substring(str.IndexOf(",") + 1, str.IndexOf("]") - str.IndexOf(",") - 1));
            }
            catch { }
        }

        private void ExtraeAFN(String str)
        {
            
            str = FiltrarCadenas(str, filtro2);
            str = str.Substring(1, str.Length - 1);
            while (str.Length > 1)
            {
                AFN.Add(str.Substring(str.IndexOf("["),str.IndexOf("]")-str.IndexOf("[") + 1));
                str = str.Substring(str.IndexOf("]")+1);
            }
        }

        private String Imprime(char[] conjunto)
        {
            String str = "";
            for (int i = 0; i < conjunto.Length;i++ )
            {
                str = str + conjunto[i] + ",";
            }
            return str.Substring(0, str.Length - 1) ;
        }

        private String Imprime(List<String> a)
        {
            String str = "";
            for (int i = 0; i < a.Count; i++)
            {
                if (i == a.Count - 1)
                {
                    str = str + FiltrarCadenas(a.ElementAt(i), filtro3);
                }
                else
                {
                    str = str + FiltrarCadenas(a.ElementAt(i), filtro3) + "\n";
                }
            }
            return str;
        }

        private String Imprime(List<CN.AFD> a)
        {
            String str = "";
            for (int i = 0; i < a.Count; i++)
            {
                if (i == a.Count - 1)
                {
                    str = str + FiltrarCadenas(a.ElementAt(i).Descripcion(),filtro3);
                }
                else
                {
                    str = str + FiltrarCadenas(a.ElementAt(i).Descripcion(),filtro3) + "\n";
                }
            }
            return str;
        }

        private String Subcadena(String cadena, String inicio, String fin)
        {
            return cadena.Substring(cadena.IndexOf(":"+inicio+":")+3,cadena.IndexOf(":"+fin+":")-cadena.IndexOf(":"+inicio+":")-3);
        }

        private void AdaptaEstados(List<String> s)
        {
            for (int i = 0; i < s.Count; i++)
            {
                int ini = Convert.ToInt32(s.ElementAt(i).Substring(1, s.ElementAt(i).IndexOf(",") - 1));
                String ch = s.ElementAt(i).Substring(s.ElementAt(i).IndexOf(" ") + 1, 1);
                int fin = Convert.ToInt32(s.ElementAt(i).Substring(s.ElementAt(i).IndexOf(ch) + 2, s.ElementAt(i).IndexOf("]") - s.ElementAt(i).IndexOf(ch) - 2));
                estados.Add(new CN.Estado(ini, fin, ch));
            }
        }

        private String[] AdaptaEstados(List<CN.AFD> AFD)
        {
            String[] str = {"[","",""};

            //CADENA DE AFD
            for (int i = 0; i < AFD.Count; i++)
            {
                if (i == AFD.Count - 1)
                {
                    str[0] = str[0] + AFD.ElementAt(i).Descripcion();
                }
                else
                {
                    str[0] = str[0] + AFD.ElementAt(i).Descripcion() + ",";
                }

            }
            str[0] = str[0] + "]";

            //CADENA DE AFD FINAL
            str[1] = sub.ImprimeFinales();

            return str;
        }
        #endregion

        #region Apertura de Imagenes
        private void Pic_AFN_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Process.Start(@Variables.Default.AFN_Imagen);
        }

        private void Pic_AFD_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Process.Start(@Variables.Default.AFD_Imagen);
        }
        #endregion

        private void ValidaCadena_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (Cadenas(ValidaCadena.Text, alfabeto))
                {
                    if (CN.Cadenas.Cadena(ValidaCadena.Text, sub.DescripcionDelAFD) == true)
                    {
                        label5.Text = "VALIDA";
                        label5.BackColor = Color.Green;
                        label5.ForeColor = Color.Black;
                    }
                    else
                    {
                        label5.Text = "INVALIDA";
                        label5.BackColor = Color.Red;
                        label5.ForeColor= Color.White;
                    }
                }
                else
                {
                    MessageBox.Show("La cadena contiene caracteres invalidos.");
                    ValidaCadena.Text = "";
                }
            }
        }

        private bool Cadenas(String text, char[] c)
        {
            bool b = true;
            for (int i = 0; i < c.Length; i++)
            {
                text = text.Replace(c[i].ToString(), "");
            }
            if (text.Length > 0)
            {
                b = false;
            }
            return b;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Variables.Default.FirstTiime)
            {
                MessageBox.Show("Se ha detectado que esta es la primera ejecucion del programa, por favor configura los parametros que se te piden para poder utilizar el programa.\nUna Vez configurado puedes cargar tu expresion regular, o Ingresar alguna de las predeterminadas:\n\nF1: " + cadenas[0] + "\nF2: " + cadenas[1] + "\nF3: " + cadenas[2] + "\nF4: " + cadenas[3] + "");
                Configuracion cof = new Configuracion();
                cof.ShowDialog();
            }
            else
            {
                if (Variables.Default.AFD_Archivo == "" || Variables.Default.AFD_Imagen == "" || Variables.Default.AFN_Archivo == "" || Variables.Default.AFN_Imagen == "" || Variables.Default.Script == "" || Variables.Default.Python == "" || Variables.Default.Graphviz == "")
                {
                    Configuracion cof = new Configuracion();
                    cof.ShowDialog();
                }
            }
            if (Variables.Default.AFD_Archivo == "" || Variables.Default.AFD_Imagen == "" || Variables.Default.AFN_Archivo == "" || Variables.Default.AFN_Imagen == "" || Variables.Default.Script == "" || Variables.Default.Python == "" || Variables.Default.Graphviz == "")
            {
                this.Close();
            }
            Limpiar();
        }

        private void Resta(string i, string f)
        {
            int min = 60000*(Convert.ToInt32(f.Substring(0, f.IndexOf(":"))) - Convert.ToInt32(i.Substring(0, i.IndexOf(":"))));
            i = i.Substring(i.IndexOf(":")+1);
            f = f.Substring(f.IndexOf(":")+1);
            int sec = 1000*(Convert.ToInt32(f.Substring(0, f.IndexOf("."))) - Convert.ToInt32(i.Substring(0, i.IndexOf("."))));
            i = i.Substring(i.IndexOf(".") + 1);
            f = f.Substring(f.IndexOf(".") + 1);
            int msec = (Convert.ToInt32(f) - Convert.ToInt32(i));
                MessageBox.Show(min + sec + msec + " milisegundos.");
        }
    }
}
