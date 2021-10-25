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

namespace WindowsFormsApp5
{
    

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Button[] dugmici;
        TextBox[] tbovi;
        int x;
        int y;
        int sirina;
        int visina;
        int j;
        int n;

        Stream fajl;
        string putanja = @"C:\Users\KN\Desktop\asocijacije.txt";
        List<string> linije;
        string[] kombinacija;
        Random r;
        int count;

    private void button1_Click(object sender, EventArgs e)
        {
            dugmici = new Button[16];
            tbovi = new TextBox[5];
            x = 20;
            y = 20;
            j = 0;

            for (int i = 0; i < 16; i++)
            {
                dugmici[i] = new Button();
                dugmici[i].Size = new Size(120, 25);
                dugmici[i].Click += new EventHandler(button_Click);
               
                if (i < 4)
                {
                    dugmici[i].Location = new Point(x + (i % 4 * 30), y + (i % 4 * 30));
                    dugmici[i].Text = "A" + (i%4+1);                   
                }

                if (i >= 4 && i < 8)
                {
                    dugmici[i].Location = new Point(sirina- 140 - (x + (i % 4 * 30)), y + (i % 4 * 30));
                    dugmici[i].Text = "B" + (i % 4 + 1);
                }

                if (i >= 8 && i < 12) {
                    dugmici[i].Location = new Point(x + (i % 4 * 30), visina - 60 - (y + (i % 4 * 30)));
                    dugmici[i].Text = "C" + (i % 4 + 1);
                }

                if (i >= 12 && i < 16)
                {
                    dugmici[i].Location = new Point(sirina-140-(x + (i % 4 * 30)), visina - 60 - (y + (i % 4 * 30)));
                    dugmici[i].Text = "D" + (i % 4 + 1);
                }

                if (i % 4 == 3)
                {
                    tbovi[j] = new TextBox();
                    tbovi[j].Size = new Size(120, 25);
                    
                    if (i < 4)
                    {                        
                        tbovi[j].Location = new Point(x + (4 * 30), y + (4 * 30));
                                               
                    }

                    if (i >= 4 && i < 8)
                    {
                      tbovi[j].Location = new Point(sirina - 140 - (x + (4 * 30)), y + (4 * 30));
                        
                    }

                    if (i >= 8 && i < 12)
                    {
                        tbovi[j].Location = new Point(x + (4 * 30), visina - 60 - (y + (4 * 30)));
                    }

                    if (i >= 12 && i < 16)
                    {
                        tbovi[j].Location = new Point(sirina - 140 - (x + (4 * 30)), visina - 60 - (y + (4 * 30)));
                        
                    }
                    this.Controls.Add(tbovi[j]);
                    j++;
                }
                this.Controls.Add(dugmici[i]);               
            }

            tbovi[j] = new TextBox();
            tbovi[j].Size = new Size((int)tbovi[1].Location.X - (int)tbovi[0].Location.X - (int)tbovi[0].Width, 25);
            tbovi[j].Location = new Point((int)tbovi[0].Location.X + (int)tbovi[0].Width, ((int)tbovi[0].Location.Y + (int)tbovi[2].Location.Y)/2);
            this.Controls.Add(tbovi[j]);

            for (int p = 0; p < 5; p++)
            {
                tbovi[p].Multiline = true;
                tbovi[p].TextAlign = HorizontalAlignment.Center;
                tbovi[p].TextChanged += new EventHandler(provera_resenja);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sirina = this.Width;
            visina = this.Height;
            count = 0;

            StreamReader fajl = new StreamReader(putanja);
            linije = File.ReadAllLines(putanja).ToList();

            while (fajl.ReadLine() != null)
                {
                    count++;
                }

            r = new Random();
            kombinacija = linije[r.Next(count)].Split(',');
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button dugme = (Button)sender;
            for (int i = 0; i < 16; i++)
                if(dugmici[i].Equals(dugme))
                    dugmici[i].Text = kombinacija[i];
        }


        protected void provera_resenja(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;

            for (int i = 0; i < 5; i++)
                if (tbovi[i].Equals(tb))
                {
                    n = tbovi[i].Text.Length;

                    if (tbovi[i].Text.LastIndexOf('\n') == n - 1)
                    {
                        if (n >= 2 && tbovi[i].Text.Substring(0, n - 2).ToLower() == kombinacija[16+i].Trim().ToLower())
                        {
                            tbovi[i].Text = kombinacija[16+i];
                            tbovi[i].Enabled = false;
                            tbovi[i].BackColor = Color.Aqua;
                            if (i == 0)
                            {
                                for (int k = 0; k < 4; k++)
                                {
                                    dugmici[k].Text = kombinacija[k];
                                    dugmici[k].BackColor = Color.Aqua;
                                }
                            }
                            if (i == 1)
                            {
                                for (int k = 4; k < 8; k++)
                                {
                                    dugmici[k].Text = kombinacija[k];
                                    dugmici[k].BackColor = Color.Aqua;
                                }
                            }
                            if (i == 2)
                            {
                                for (int k = 8; k < 12; k++)
                                {
                                    dugmici[k].Text = kombinacija[k];
                                    dugmici[k].BackColor = Color.Aqua;
                                }
                            }
                            if (i == 3)
                            {
                                for (int k = 12; k < 16; k++)
                                {
                                    dugmici[k].Text = kombinacija[k];
                                    dugmici[k].BackColor = Color.Aqua;
                                }
                            }
                            if (i == 4)
                            {
                                for (int k = 0; k < 16; k++)
                                {
                                    dugmici[k].Text = kombinacija[k];
                                    dugmici[k].BackColor = Color.Aqua;
                                }
                                for(int l=0; l<4 ; l++)
                                {
                                    tbovi[l].Text = kombinacija[16 + l];
                                    tbovi[l].BackColor = Color.Aqua;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Netacno!");
                            tbovi[i].Text = "";
                        }
                    }
                }
           }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
