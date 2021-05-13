using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntidadesCompilador;
using ManejadorCompilador;
using System.IO.Ports;

namespace splash_scrren_2._0
{
    public partial class FrmCompiler : Form
    {
        string[] port;
        //variable global
        int caracter;
        //Inizializamos las clases
        public List<EntidadLexico> el;
        ManejadorLexicos ma;
        ManejadorSintactico ms;
        ManejadorSemantico me;
        ManejadorTraduccion mt;
        public FrmCompiler()
        {
            InitializeComponent();
            var name = new ToolTip();
            port = SerialPort.GetPortNames();
            name.SetToolTip(PicSalir,"CLOSE");
            name.SetToolTip(PicStart,"START");
            el = new List<EntidadLexico>();
            ma = new ManejadorLexicos();
            ms = new ManejadorSintactico();
            me = new ManejadorSemantico();
            mt = new ManejadorTraduccion();
        }
        //Botón de Analizar, analiza el código de forma lexica y sintactica
        private void PicStart_Click(object sender, EventArgs e)
        {
            if (ma.AnalisisLexico(dtgTokens, PanelCodigo.Text))
            {
                Sintactico();
                Semantico();
                Traductor();
            }
        }
        //Método de analisis sintactico
        void Sintactico()
        {
            string answer = ms.Metodos(dtgTokens);
            if (answer.Length > 0)
            {
                MessageBox.Show(answer, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //Método de analisis sémantico
        void Semantico()
        {
            string answer = me.Semantico(dtgTokens);
            if (answer.Length > 0)
            {
                MessageBox.Show(answer, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                answer = me.SemanticoA(dtgTokens);
                if (answer.Length > 0)
                {
                    MessageBox.Show(answer, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } 
            }
        }
        void Traductor()
        {
            string answer = mt.Traduction(dtgTokens);
            if (answer.Length > 0)
            {
                txtTraduccion.Text = answer;
            }
        }
        //Load del formulario
        private void FrmCompiler_Load(object sender, EventArgs e)
        {
            PanelCodigo.Focus();
            Code();
            Unabled(true, false, false);
            timer1.Interval = 10;
            timer1.Start();
            for (int i = 0; i < port.Length; i++)
            {
                cmbPuertos.Items.Add(port[i].ToString());
            }
        }
        //Método para activar o desactivar los botones del Form
        private void Unabled(Boolean txt, Boolean analizar, Boolean clear)
        {
            PicStart.Enabled = analizar;
            PanelCodigo.Enabled = txt;
            PicCodigo.Enabled = clear;
        }
        //Botón o Picture para salir
        private void PicSalir_Click(object sender, EventArgs e)
        {
            FrmLoad f = new FrmLoad();
            f.Close();
            Application.Exit();
        }
        
        private void PanelCodigo_TextChanged(object sender, EventArgs e)
        {
            Unabled(true, true, true);
            dtgTokens.Columns.Clear();
            txtTraduccion.Clear();
        }
        //Picture para mostrar una linea de números por renglon
        private void PicCodigo_Paint(object sender, PaintEventArgs e)
        {
            caracter = 0;

            int altura = PanelCodigo.GetPositionFromCharIndex(0).Y;

            if (PanelCodigo.Lines.Length > 0)
            {
                for (int i = 0; i < PanelCodigo.Lines.Length; i++)
                {
                    e.Graphics.DrawString((i + 1).ToString(), PanelCodigo.Font, Brushes.LightCyan, PicCodigo.Width - 
                        (e.Graphics.MeasureString((i + 1).ToString(), PanelCodigo.Font).Width + 10), altura);
                    caracter += PanelCodigo.Lines[i].Length + 1;
                    altura = PanelCodigo.GetPositionFromCharIndex(caracter).Y;
                }
            }
            else
            {
                e.Graphics.DrawString("1", PanelCodigo.Font, Brushes.LightCyan, PicCodigo.Width - 
                    (e.Graphics.MeasureString((1).ToString(), PanelCodigo.Font).Width + 10), altura);
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            PicCodigo.Refresh();
        }
        private void Code()
        {
            string[] code = new string[]
            {
                "Begin",
                "{",
                "   $BienvenidoAquí$",
                "   ",
                "}",
                "End"
            };
            PanelCodigo.Lines = code;
        }
        //Timer del PicCodigo
        
        private void PicCodigo_Click(object sender, EventArgs e)
        {

        }
        private void PicClear_Click(object sender, EventArgs e)
        {
            PanelCodigo.Clear();
            dtgTokens.Columns.Clear();
        }
        //Botón para crear el documento
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string[] text = { txtTraduccion.Text };
                using (StreamWriter outputFile = new StreamWriter(@"D:\Documents\Lenguajes y automatas\Proyecto\Compilador_DianaTorresRea\splash scrren 2.0\splash scrren 2.0\bin\Debug\SSWL.ino"))
                {
                    foreach (string linea in text)
                    {
                        outputFile.WriteLine(linea);
                        MessageBox.Show("Archivo guardado con exito:)");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR");
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Run(cmbPuertos.Text);
        }
        private void Run(string puertos)
        {
            try
            {
                StreamWriter traduction = File.CreateText("SSWL.ino");
                String trad = txtTraduccion.Text;
                traduction.WriteLine(trad.ToString());
                traduction.Flush();
                traduction.Close();
                StreamWriter write = File.CreateText("SSWL.bat");
                write.WriteLine("ArduinoUploader SSWL.ino 1 "+puertos);
                write.Close();
                Process.Start("SSWL.bat");
                MessageBox.Show("Exito");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }

        private void cmbPuertos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPuertos.Text=="")
            {
                MessageBox.Show("Error, seleccione un puerto", "ERROR");
                pictureBox1.Enabled = false;
            }
            else
            {
                pictureBox1.Enabled = true;
            }
        }
    }
}
