using FaceRecognition;
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
    public partial class Form1 : Form
    {
        FaceRec faceRec = new FaceRec();

        public Form1()
        {
            InitializeComponent();
            faceRec.openCamera(pictureBox1, pictureBox2);
            this.WindowState = FormWindowState.Normal;
            Timer dispatcherTimer = new Timer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = 1000;
            dispatcherTimer.Start();
            faceRec.isTrained = true;
            label1.Text = "AKTİF DEĞİL";
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                if (frm.Name == "Lock")
                {
                    frm.WindowState = FormWindowState.Minimized;
                }
                else
                {
                    frm.WindowState = FormWindowState.Normal;
                }
            }
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (kapali)
            {
                return;
            }
            try
            {
             
                faceRec.isTrained = true;
                faceRec.getPersonName(label1);
                if (label1.Text == "ADMIN")
                {
                    FormCollection fc = Application.OpenForms;

                    foreach (Form frm in fc)
                    {
                        //iterate through
                        if (frm.Name == "Lock")
                        {
                            frm.WindowState = FormWindowState.Minimized;
                            break;

                        }
                    }
                }
                else if (label1.Text == "")
                {
                    faceRec.Save_IMAGE("YABANCI");
                    bool var = false;
                    FormCollection fc = Application.OpenForms;

                    foreach (Form frm in fc)
                    {
                        if (frm.Name == "Lock")
                        {
                            var = true;
                            Lock form = (Lock)frm;
                            form.Sakla();
                            frm.WindowState = FormWindowState.Maximized;

                        }
                    }
                    if (!var)
                    {
                        Lock objUI = new Lock();
                        objUI.Show();
                    }
                 

                }
                else if (label1.Text == "YABANCI")
                {
                    bool var = false;
                    FormCollection fc = Application.OpenForms;

                    foreach (Form frm in fc)
                    {
                        if (frm.Name == "Lock")
                        {
                            frm.WindowState = FormWindowState.Maximized;

                            var = true;
                            Lock form = (Lock)frm;
                            form.Goster();
                        }
                    }
                    if (!var)
                    {
                        Lock objUI = new Lock();
                        objUI.Show();
                    }

                }
            }
            catch
            {
                Application.Restart();
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            faceRec.Save_IMAGE("ADMIN");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            faceRec.isTrained = true;
            faceRec.getPersonName(label1);
            Console.WriteLine("deneme");
        }

        private bool kapali = true;
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (kapali)
            {

                kapali = false;
                button1.BackColor = Color.Green;
                button1.Text = "ÇALIŞIYOR";
            }
            else
            {
                kapali = true;
                button1.BackColor = Color.Red;
                button1.Text = "Şuan Aktif Değil";
            }
        }
        public void Kapat()
        {
            kapali = true;
            button1.BackColor = Color.Red;
            button1.Text = "Şuan Aktif Değil";
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                //iterate through
                if (frm.Name == "Lock")
                {
                    frm.WindowState = FormWindowState.Minimized;
                }
                else
                {
                    frm.WindowState = FormWindowState.Normal;
                }
            }

        }
  
    }
}
