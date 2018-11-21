using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mangukool;

namespace MangukoolVisual
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Console.Beep(200,500);
            string vastus = this.textBox1.Text.Trim();

                Inimene kasutaja = Inimene.Inimesed
                    .Where(x => x.Isikukood == vastus)
                .FirstOrDefault();

            if (kasutaja != null)
            {
                this.label3.Text = $"Tere {kasutaja.Nimi}!";

            }
            else
            {
                this.label3.Text = "Teid ei ole systeemis!";
            }



            //this.label3.Text = $"Tsau {this.textBox1.Text}!";
        }
    }
}
