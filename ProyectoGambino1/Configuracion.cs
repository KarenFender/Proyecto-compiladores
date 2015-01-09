using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProyectoGambino1
{
    public partial class Configuracion : Form
    {
        OpenFileDialog py = new OpenFileDialog();
        
        public Configuracion()
        {
            InitializeComponent();
        }


        private void Configuracion_FormClosing(object sender, FormClosingEventArgs e)
        {
            Variables.Default.FirstTiime = false;
            Variables.Default.Save();
        }

        private void Configuracion_Load(object sender, EventArgs e)
        {
            Py_Python.Text = Variables.Default.Python;
            Py_Thomson.Text = Variables.Default.Script;
            Gv_Dot.Text = Variables.Default.Graphviz;
            AFN_Pic.Text = Variables.Default.AFN_Imagen;
            AFN_Text.Text = Variables.Default.AFN_Archivo;
            AFD_Pic.Text = Variables.Default.AFD_Imagen;
            AFD_Text.Text = Variables.Default.AFD_Archivo;
        }

        private void textBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (System.IO.Directory.Exists(@"C:\Python27"))
            {
                py.InitialDirectory = @"C:\Python27";
            }
            py.Filter = "Ejecutable de python|python.exe";
            if (py.ShowDialog() == DialogResult.OK)
            {
                Variables.Default.Python = py.FileName;
                Py_Python.Text = Variables.Default.Python;

            }
            py = new OpenFileDialog();
        }

        private void textBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            py.InitialDirectory = Application.StartupPath;
            py.Filter = "Archivo de Python|*.py";
            if (py.ShowDialog() == DialogResult.OK)
            {
                Variables.Default.Script = py.FileName;
                Py_Thomson.Text = Variables.Default.Script;

            }
            py = new OpenFileDialog();
        }

        private void textBox6_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (System.IO.Directory.Exists(@"C:\Program Files (x86)\Graphviz2.38\bin"))
            {
                py.InitialDirectory = @"C:\Program Files (x86)\Graphviz2.38\bin";
            }
            py.Filter = "Ejecutable de Graphviz|dot.exe";
            if (py.ShowDialog() == DialogResult.OK)
            {
                Variables.Default.Graphviz = py.FileName;
                Gv_Dot.Text = Variables.Default.Graphviz;

            }
            py = new OpenFileDialog();
        }

        private void AFN_Pic_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SaveFileDialog save1 = new SaveFileDialog();
            save1.Filter = "Imagen PNG|*.png";
            save1.RestoreDirectory = true;
            if (save1.ShowDialog() == DialogResult.OK)
            {
                Variables.Default.AFN_Imagen = save1.FileName;
                AFN_Pic.Text = Variables.Default.AFN_Imagen;
            }
        }

        private void AFD_Text_MouseDoubleClick(object sender, MouseEventArgs e)
        {            
            SaveFileDialog save1 = new SaveFileDialog();
            save1.Filter = "Archivo de Texto|*.txt";
            save1.RestoreDirectory = true;
            if (save1.ShowDialog() == DialogResult.OK)
            {
                Variables.Default.AFD_Archivo = save1.FileName;
                AFD_Text.Text = Variables.Default.AFD_Archivo;
            }
        }

        private void AFD_Pic_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SaveFileDialog save1 = new SaveFileDialog();
            save1.Filter = "Imagen PNG|*.png";
            save1.RestoreDirectory = true;
            if (save1.ShowDialog() == DialogResult.OK)
            {
                Variables.Default.AFD_Imagen = save1.FileName;
                AFD_Pic.Text = Variables.Default.AFD_Imagen;
            }
        }

        private void AFN_Text_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SaveFileDialog save1 = new SaveFileDialog();
            save1.Filter = "Archivo de Texto|*.txt";            
            save1.RestoreDirectory = true;
            if (save1.ShowDialog() == DialogResult.OK)
            {
                Variables.Default.AFN_Archivo = save1.FileName;
                AFN_Text.Text = Variables.Default.AFN_Archivo;
            }
        }

    }
}
