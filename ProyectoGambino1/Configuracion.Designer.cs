namespace ProyectoGambino1
{
    partial class Configuracion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.Py_Python = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Py_Thomson = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Gv_Dot = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.AFD_Pic = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.AFD_Text = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.AFN_Pic = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.AFN_Text = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Python.exe";
            // 
            // Py_Python
            // 
            this.Py_Python.Location = new System.Drawing.Point(117, 36);
            this.Py_Python.Name = "Py_Python";
            this.Py_Python.Size = new System.Drawing.Size(240, 29);
            this.Py_Python.TabIndex = 1;
            this.Py_Python.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Py_Thomson);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Py_Python);
            this.groupBox1.Location = new System.Drawing.Point(3, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(363, 113);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Python";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Script Infijo-Posfijo";
            // 
            // Py_Thomson
            // 
            this.Py_Thomson.Location = new System.Drawing.Point(173, 71);
            this.Py_Thomson.Name = "Py_Thomson";
            this.Py_Thomson.Size = new System.Drawing.Size(184, 29);
            this.Py_Thomson.TabIndex = 3;
            this.Py_Thomson.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBox2_MouseDoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.Gv_Dot);
            this.groupBox2.Location = new System.Drawing.Point(3, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(363, 117);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Graphviz";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 24);
            this.label6.TabIndex = 0;
            this.label6.Text = "dot.exe";
            // 
            // Gv_Dot
            // 
            this.Gv_Dot.Location = new System.Drawing.Point(85, 30);
            this.Gv_Dot.Name = "Gv_Dot";
            this.Gv_Dot.Size = new System.Drawing.Size(272, 29);
            this.Gv_Dot.TabIndex = 1;
            this.Gv_Dot.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBox6_MouseDoubleClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(380, 273);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 33);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(372, 236);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Python";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 33);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(372, 236);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Graphviz";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Controls.Add(this.groupBox5);
            this.tabPage3.Location = new System.Drawing.Point(4, 33);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(372, 236);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Archivos";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.AFD_Pic);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.AFD_Text);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(8, 120);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(358, 111);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "AFD";
            // 
            // AFD_Pic
            // 
            this.AFD_Pic.Location = new System.Drawing.Point(101, 68);
            this.AFD_Pic.Name = "AFD_Pic";
            this.AFD_Pic.Size = new System.Drawing.Size(251, 29);
            this.AFD_Pic.TabIndex = 5;
            this.AFD_Pic.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.AFD_Pic_MouseDoubleClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 24);
            this.label7.TabIndex = 4;
            this.label7.Text = "Imagen:";
            // 
            // AFD_Text
            // 
            this.AFD_Text.Location = new System.Drawing.Point(86, 33);
            this.AFD_Text.Name = "AFD_Text";
            this.AFD_Text.Size = new System.Drawing.Size(266, 29);
            this.AFD_Text.TabIndex = 3;
            this.AFD_Text.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.AFD_Text_MouseDoubleClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 24);
            this.label8.TabIndex = 2;
            this.label8.Text = "Texto:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.AFN_Pic);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.AFN_Text);
            this.groupBox5.Location = new System.Drawing.Point(8, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(358, 111);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "AFN";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 24);
            this.label5.TabIndex = 6;
            this.label5.Text = "Texto:";
            // 
            // AFN_Pic
            // 
            this.AFN_Pic.Location = new System.Drawing.Point(101, 68);
            this.AFN_Pic.Name = "AFN_Pic";
            this.AFN_Pic.Size = new System.Drawing.Size(251, 29);
            this.AFN_Pic.TabIndex = 5;
            this.AFN_Pic.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.AFN_Pic_MouseDoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 24);
            this.label4.TabIndex = 4;
            this.label4.Text = "Imagen:";
            // 
            // AFN_Text
            // 
            this.AFN_Text.Location = new System.Drawing.Point(86, 33);
            this.AFN_Text.Name = "AFN_Text";
            this.AFN_Text.Size = new System.Drawing.Size(266, 29);
            this.AFN_Text.TabIndex = 3;
            this.AFN_Text.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.AFN_Text_MouseDoubleClick);
            // 
            // Configuracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 274);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Configuracion";
            this.Text = "Configuracion";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Configuracion_FormClosing);
            this.Load += new System.EventHandler(this.Configuracion_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Py_Python;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Py_Thomson;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Gv_Dot;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox AFD_Pic;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox AFD_Text;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox AFN_Pic;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox AFN_Text;
        private System.Windows.Forms.Label label5;
    }
}