using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoGambino1.CExt
{
    class Procesos
    {
        public static String EjecutarPython(String Script, String[] Args)
        {
            System.Diagnostics.ProcessStartInfo proceso = new System.Diagnostics.ProcessStartInfo();
            if (Variables.Default.Python != "")
            {
                proceso.FileName = Variables.Default.Python;
                proceso.RedirectStandardInput = false;
                proceso.RedirectStandardOutput = true;
                if (Args.Length == 1)
                {
                    proceso.Arguments = String.Format(@"{0} {1}", Script, Args[0]);
                }
                else
                {
                    proceso.Arguments = String.Format(@"{0} {1} {2} {3}", Script, Args[0], Args[1], Args[2]);
                }
                proceso.UseShellExecute = false;
                using (System.Diagnostics.Process process = System.Diagnostics.Process.Start(proceso))
                {
                    using (System.IO.StreamReader reader = process.StandardOutput)
                    {
                        string result = reader.ReadToEnd();
                        
                        return result;
                    }
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("No se ha seleccionado el archivo de Python.exe");
                return null;
            }
        }

        public static void EjecutaGraphviz(String Formato, String Entrada, String Salida)
        {
            System.Diagnostics.ProcessStartInfo proceso = new System.Diagnostics.ProcessStartInfo();
            if (Variables.Default.Graphviz != "")   
            {
                proceso.FileName = Variables.Default.Graphviz;
                proceso.RedirectStandardInput = false;
                proceso.RedirectStandardOutput = false;
                proceso.Arguments = String.Format(@"{0} {1} {2} {3}", Formato, @Entrada, "-o", @Salida);
                using (System.Diagnostics.Process process = System.Diagnostics.Process.Start(proceso))
                {
                    process.WaitForExit();
                    process.Close();
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("No se ha seleccionado el archivo de Graphviz (dot.exe)");
            }
        }
    }
}
