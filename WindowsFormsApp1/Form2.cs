using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Lock : Form
    {
        public Lock()
        {
            InitializeComponent();
        }
        public void Sakla()
        {
            pictureBox1.Visible = false;
        }
        public void Goster()
        {
            pictureBox1.Visible = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.ToString() == "4242")
            {

                FormCollection fc = Application.OpenForms;

                foreach (Form frm in fc)
                {
                    Console.WriteLine(frm.Name.ToString());

                    //iterate through
                    if (frm.Name == "Form1")
                    {
                        Form1 form = (Form1)frm;
                        form.Kapat();
                        break;

                    }
                }
            }
        }
    }
}
