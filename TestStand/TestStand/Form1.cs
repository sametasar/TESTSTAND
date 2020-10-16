using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Yamaha;

namespace teststand
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!="")
            {
                MessageBox.Show("Barkod boş olamaz!");
            }
            else
            {
                Cls_Bilgi Bilgi = new Cls_Bilgi();
                YamahaHex hex = new YamahaHex();
                Bilgi = hex.GetHexFileName(textBox1.Text);


                label4.Text = Bilgi.Yol;
                label5.Text = Bilgi.Bin;


            }
        }
    }
}
