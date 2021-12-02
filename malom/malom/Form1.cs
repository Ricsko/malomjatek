using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace malom
{
    public partial class Form1 : Form
    {
        static PictureBox[,] babuk = new PictureBox[2, 9];
        static PictureBox[,] jatekTer = new PictureBox[7, 7];
        static List<string> feherbabuk = new List<string>();
        static int feherSzamlalo = 0;
        static List<string> feketebabuk = new List<string>();
        static int feketeSzamlalo = 0;
        static int aktSzin = 0;
        static int babuIndex = 0;
        static int segedSzamlalo = 0;
        static PictureBox aktBabu = new PictureBox();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            nevellenorzes();
            keszitoklbl.Visible = false;
            
            button2.Visible = false;
        }

        private void nevellenorzes()
        {
            string nev1 = jatekos1_TBOX.Text;
            string nev2 = jatekos2_TBOX.Text;

            /*if(nev1 == "" || nev2 == "")
            {
                MessageBox.Show($"Adj meg mindkét játékosnak nevet!");
            }
            else
            {
             labelek, textboxok, buttonok eltüntetése   
            }*/

            palyaelhelyezes();
            gombeltuntetes();
            babugeneralas();
        }

        private void palyaelhelyezes()
        {
            int x = -30;
            int y = 0;
            string[] palyaGeneraloSeged = { "0_0", "0_3", "0_6", "1_1", "1_3", "1_5", "2_2", "2_3", "2_4", "3_0", "3_1", "3_2", "3_4", "3_5", "3_6", "4_2", "4_3", "4_4", "5_1", "5_3", "5_5", "6_0", "6_3", "6_6" };

            pictureBox1.Size = new Size(530, 530);
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(this.ClientSize.Width / 2 - pictureBox1.Size.Width / 2, 200);
            pictureBox1.Anchor = AnchorStyles.None;


            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    PictureBox kep = new PictureBox();
                    kep.BackColor = Color.Transparent;
                    kep.Size = new Size(50, 50);
                    kep.BackgroundImageLayout = ImageLayout.Zoom;
                    kep.Location = new Point(x + 30, y);
                    kep.Name = $"{i}_{j}";
                    kep.Tag = "1";
                    kep.MouseClick += new MouseEventHandler(jatekTerklikk);
                    jatekTer[i, j] = kep;

                    if (!palyaGeneraloSeged.Contains(kep.Name))
                    {
                        kep.Visible = false;
                        kep.Tag = "0";
                    }

                    kep.BringToFront();
                    pictureBox1.Controls.Add(kep);
                    x += 80;
                }
                x = -30;
                y += 80;
            }
        }
        private void jatekTerklikk(object sender, EventArgs e)
        {
            PictureBox klikkelt = sender as PictureBox;

            if (feherSzamlalo != 9 && feketeSzamlalo != 9)
            {
                lerak(klikkelt);
            }
            else if (klikkelt.BackgroundImage != null && feherSzamlalo == 9 && feketeSzamlalo == 9)
            {
                MessageBox.Show("asd");
                csusztatas(klikkelt);
            }
        }

        private void csusztatas(PictureBox klikkelt)
        {
            
        }

        private void lerak(PictureBox klikkelt)
        {
            int seged = aktSzin % 2;

            for (int i = 0; i < 8; i++)
            {
                aktBabu.Name = babuk[seged, i].Name;
                aktBabu.BackgroundImage = babuk[seged, i].BackgroundImage;
            }
            klikkelt.Name += $"_{aktBabu.Name}";
            klikkelt.BackgroundImage = aktBabu.BackgroundImage;

            if(Convert.ToInt32(klikkelt.Name.Split('_')[2]) == 0)
            {
                feherbabuk.Add(klikkelt.Name);
                feherSzamlalo++;
            }
            else
            {
                feketebabuk.Add(klikkelt.Name);
                feketeSzamlalo++;
            }
            MessageBox.Show(klikkelt.Name);
            aktSzin++;
        }

        private void babugeneralas()
        {
            int x = this.Width / 2 - 290;
            int y = 800;
            int szin = 0;

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    PictureBox babu = new PictureBox();
                    babu.Size = new Size(50, 50);
                    babu.Name = $"{szin}";
                    babu.BackgroundImage = keplista.Images[szin];
                    babu.Location = new Point(x + 6, y);
                    babu.BackgroundImageLayout = ImageLayout.Zoom;
                    babu.BackColor = Color.Transparent;
                    babuk[i, j] = babu;
                    this.Controls.Add(babu);

                    x += 55;
                }
                szin++;
                x = this.Width / 2 - 290;
                y += 55;
            }
        }

        private void gombeltuntetes()
        {
            jatekos1_TBOX.Visible = false;
            jatekos2_TBOX.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            button1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gombeltuntetes();
            richTextBox1.Visible = true;
            Xbutton.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            gombvisszahozas();
        }

        private void gombvisszahozas()
        {
            jatekos1_TBOX.Visible = true;
            jatekos2_TBOX.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            button1.Visible = true;
            richTextBox1.Visible = false;
            Xbutton.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void újraindításToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void alapértelmezettToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.hatter;
            pictureBox1.BackgroundImage = Properties.Resources.tablaaa;
            button1.BackColor = Color.Black;
            button2.BackColor = Color.Black;
            label1.ForeColor = Color.White;
            label2.ForeColor = Color.White;
            keszitoklbl.ForeColor = Color.White;
            jatekos1_TBOX.BackColor = Color.White;
            jatekos2_TBOX.BackColor = Color.White;
        }

        private void sötétToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.fekete;
            pictureBox1.BackgroundImage = Properties.Resources.tablaa;
            button1.BackColor = Color.Black;
            button2.BackColor = Color.Black;
            label1.ForeColor = Color.White;
            label2.ForeColor = Color.White;
            keszitoklbl.ForeColor = Color.White;
            jatekos1_TBOX.BackColor = Color.White;
            jatekos2_TBOX.BackColor = Color.White;
        }

        private void lilaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.lila;
            pictureBox1.BackgroundImage = Properties.Resources.rozsaszin;
            button1.BackColor = Color.Purple;
            button2.BackColor = Color.Purple;
            label1.ForeColor = Color.White;
            label2.ForeColor = Color.White;
            keszitoklbl.ForeColor = Color.White;
            jatekos1_TBOX.BackColor = Color.White;
            jatekos2_TBOX.BackColor = Color.White;
        }
    }
}
