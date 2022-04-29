using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArabaYarisUygulamasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int kazanilanpuan = 0;
        int yolhizi = 35;
        int arabahizi = 35; //benim arabanın hızı

        bool solyon = false;
        bool sağyon = false;

        int digerarabahizi = 35;

        Random rnd = new Random();

        public void oyunubaslat()
        {
            btn_oyunubaslat.Enabled = false;
            carpma.Visible = false;

            arabahizi = 5;
            digerarabahizi = 5;
            kazanilanpuan = 0;

            // bizim arabanın koordinatları

            bizimaraba.Left = 160;
            bizimaraba.Top = 300;

            // başka arabaların koordinatları

            araba1.Left = 30;
            araba1.Top = 50;

            araba2.Left = 320;
            araba2.Top = 50;

            carpma.Left = 165;
            carpma.Top = 294;

            solyon = false;
            sağyon = false;

            timer1.Start();

        }
            

            

    private void Form1_Load(object sender, EventArgs e)
        {
            oyunubaslat();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            kazanilanpuan++;
            lbl_puan.Text = kazanilanpuan.ToString();

            yol.Top += yolhizi;
            if (yol.Top>400)
            {
                yol.Top = -100;
            }
            if (solyon)
            {
                bizimaraba.Left -= arabahizi;
            }
            if (sağyon)
            {
                bizimaraba.Left += arabahizi;
            }
            if (bizimaraba.Left<1)
            {
                solyon = false;
            }
            else if (bizimaraba.Left+bizimaraba.Width>510)
            {
                sağyon = false;
            }
            araba1.Top += arabahizi;
            araba2.Top += arabahizi;

            if (araba1.Top>panel1.Height)
            {
                araba1degistir();
                araba1.Left = rnd.Next(20,50);
                araba1.Top = rnd.Next(40, 140) * -1;
            }
            if (araba2.Top>panel1.Height)
            {
                araba2degistir();
                araba2.Left = rnd.Next(20, 50);
                araba2.Top = rnd.Next(40, 140) * -1;
            }
            if (bizimaraba.Bounds.IntersectsWith(araba1.Bounds) || bizimaraba.Bounds.IntersectsWith(araba2.Bounds))
            {
                oyunbitti();      
            }
        }
        private void araba2degistir()
        {
            int sira = rnd.Next(1, 7);

            switch (sira)
            {
                case 1:
                    araba2.Image = Properties.Resources.araba5;
                    break;
                case 2:
                    araba2.Image = Properties.Resources.araba7;
                    break;
                case 3:
                    araba2.Image = Properties.Resources.araba3;
                    break;
                case 4:
                    araba2.Image = Properties.Resources.araba4;
                    break;
                case 5:
                    araba2.Image = Properties.Resources.araba5;
                    break;
                case 6:
                    araba2.Image = Properties.Resources.araba6;
                    break;
                case 7:
                    araba2.Image = Properties.Resources.araba7;
                    break;
            }

        }
        private void araba1degistir()
        {
            int sira = rnd.Next(1, 7);


            switch (sira)
            {
                case 1:
                    araba1.Image = Properties.Resources.araba5;
                    break;
                case 2:
                    araba1.Image = Properties.Resources.araba7;
                    break;
                case 3:
                    araba1.Image = Properties.Resources.araba3;
                    break;
                case 4:
                    araba1.Image = Properties.Resources.araba4;
                    break;
                case 5:
                    araba1.Image = Properties.Resources.araba5;
                    break;
                case 6:
                    araba1.Image = Properties.Resources.araba6;
                    break;
                case 7:
                    araba1.Image = Properties.Resources.araba7;
                    break;
            }
        }
        private void oyunbitti()
        {
            timer1.Stop();
            btn_oyunubaslat.Enabled = true;
            carpma.Visible = true;
            bizimaraba.Controls.Add(carpma);
            carpma.Location = new Point(7, -5);
            carpma.BringToFront();
            carpma.BackColor = Color.Transparent;
            MessageBox.Show("SKOR :"+lbl_puan.Text,"Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Information);
                
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && bizimaraba.Left > 0)  { solyon = true; }
            if (e.KeyCode == Keys.Right && bizimaraba.Left+bizimaraba.Width < panel1.Width) { sağyon = true; }                

            
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Left) { solyon = false; }
            if (e.KeyCode==Keys.Right) { sağyon = false; }
            

            
        }
    }
}
