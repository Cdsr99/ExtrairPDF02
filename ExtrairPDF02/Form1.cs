using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExtrairPDF02
{
    public partial class Form1 : Form
    {
        String user = System.Environment.GetEnvironmentVariable("USERNAME");
        public Form1()
        {
            InitializeComponent();
            atributos();
            
        } 

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void test()
        {
            if (checkBox1.Checked && html.Checked)
            {
                MessageBox.Show("Boa garoto!");
            }
        }
        public void Abrir_html()
        {
            ofd.InitialDirectory = comboBox1.Text;
            ofd.FileName = "";
            ofd.Filter = "HTML (*.html)|*.html";
            //ofd.Filter = "Texto (*.txt)|*.txt";
            ofd.Title = "Select HTML File";
            ofd.ShowDialog();

            try
            {
                ler();
            }
            catch (Exception ex)
            {

               MessageBox.Show("Erro" + ex.ToString());
            }


        }
        #region atributos
        public void atributos()
        {

            
            comboBox1.Items.Add("C:\\");
            comboBox1.Items.Add("C:\\Users\\" + user + "\\desktop");
            comboBox1.Items.Add("C:\\Users\\"+ user + "\\Documents");
            comboBox1.Items.Add("C:\\Users\\"+ user +"\\Downloads");          
           
        }
        #endregion
        #region ler
        public void ler()
        {
            String caminho = ofd.FileName;
            String content;
            String extensão = ".pdf";
            String http = "http://";
            String href = "href=";
            String line;
            // String content2;

            int contline =0 ;
            try
            {
                StreamReader arq = new StreamReader(caminho);
                line = content;

                while ((content = arq.ReadLine()) != null)
                {
                   richTextBox1.AppendText(content);
                    richTextBox1.AppendText("\n");
                    contline++;
                    lblines.Text = Convert.ToString(contline);
                    if (richTextBox1.Text.Contains(href) && richTextBox1.Text.Contains(http) && richTextBox1.Text.Contains(extensão))
                    {
                        MessageBox.Show("Achei um link #eggs");
                    }
                }
               
               
                arq.Close();

            }
            catch (Exception ex)
            {

               // MessageBox.Show("Erro " + ex.ToString());
            }
            
            
        }
        #endregion
        #region Button
        private void button1_Click(object sender, EventArgs e)
        {

            Abrir_html();
            
        }
        #endregion
        #region limpar
        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            lblines.Text = "....";
            lbmp3.Text = "....";
            lbpdf.Text = "....";
            lbpng.Text = "....";
            comboBox1.Text = "";
        }
        #endregion
        #region caça_palavra
        public void caça_palavra()
        {
            
            try
            {
                String html = "html";
                String caminho = ofd.FileName;
                StreamReader arq = new StreamReader(caminho);
                //StreamReader ler_combobox = new StreamReader(comboBox1.Text);
                //ler_combobox.ReadToEnd();
                //Convert.ToString(content);
                String content;
                if (richTextBox1.Text.Contains("html"))
                {
                    richTextBox1.Find(html);
                    richTextBox1.SelectionColor = Color.Red;
                }
                arq.Close();
                
               // ler_combobox.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro:404 html not found! "/* + ex.ToString()*/);
                
            }
        }

        #endregion
        #region link
        public void link()
        {
            String caminho = ofd.FileName;

            StreamReader str = new StreamReader(caminho);

        }
        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            caça_palavra();
        }
    }
}
