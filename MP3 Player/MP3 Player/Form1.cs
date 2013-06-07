using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace MP3_Player
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
        }

        string[] files, paths;
        List<EffectNode> Effectcollection = new List<EffectNode>();
        

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (0 <= listBox1.SelectedIndex && listBox1.SelectedIndex <= paths.Length - 1)
            {
                
                axWindowsMediaPlayer1.URL = paths[listBox1.SelectedIndex];
            }

            
            timer2.Start();
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            float scale_w = panel1.Width / 100;
            float scale_h = panel1.Height / 100;

            panel1.Refresh();

            using (Graphics g = panel1.CreateGraphics())
            {

                for (int i = 0; i < Effectcollection.Count; i++)
                {
                    if (i == listBox2.SelectedIndex)
                    {
                        g.FillEllipse(Brushes.Red, Effectcollection[i].Effect_p.X * scale_w, Effectcollection[i].Effect_p.Y * scale_h, 10, 10);
                    }
                    else
                    {
                        g.FillEllipse(Brushes.DarkRed, Effectcollection[i].Effect_p.X * scale_w, Effectcollection[i].Effect_p.Y * scale_h, 7, 7);
                    }
                }



            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                files = openFileDialog1.SafeFileNames;
                paths = openFileDialog1.FileNames;
                for (int i = 0; i < files.Length; i++)
                {
                    listBox1.Items.Add(files[i]);
                }
            }
           
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            using (Graphics g = panel1.CreateGraphics())
            {
                //g.FillRectangle(Brushes.Black, new Rectangle(0, 0, 5, Math.Abs(panel1.Top - panel1.Bottom)));


                double progress = 0;
                
                if (axWindowsMediaPlayer1.currentMedia.duration > 0)
                {
                    
                    progress =  (axWindowsMediaPlayer1.Ctlcontrols.currentPosition / axWindowsMediaPlayer1.currentMedia.duration);
                }
                panel1.Refresh();

                

                g.DrawLine(Pens.Black, (int)(progress * panel1.Width), 0, (int)(progress * panel1.Width), Math.Abs(panel1.Top - panel1.Bottom));
            }

            
            
            
        }

        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           /* Graphics g = e.Graphics;
           
            //g.DrawLine(Pens.Black, 0, panel1.Top, 100, panel1.Bottom);
            foreach (EffectNode item in Effectcollection)
	{
		using (Graphics pg = panel1.CreateGraphics())
            {
                pg.DrawEllipse(Pens.BlueViolet, item.Effect_p.X, item.Effect_p.Y, 5, 5);
            }
	}*/
            
            
        }

       

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EffectNode.CreateNew = true;
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (EffectNode.CreateNew == true)
            {
                EffectNode.CreateNew = false;
                Point temp_p = panel1.PointToClient(Cursor.Position);
                EffectNode n = new EffectNode(temp_p);
                n.Effect_p.X = (temp_p.X * 100 / panel1.Width);
                n.Effect_p.Y = (temp_p.Y * 100 / panel1.Height); ;
                
                listBox2.Items.Add("["+n.Effect_p.X.ToString() + "," + n.Effect_p.Y.ToString()+ "]");

                //textBox1.Enabled = true;


                Effectcollection.Add(n);

            }
            

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            EffectNode.CreateNew = true;

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            Effectcollection[listBox2.SelectedIndex].Effect_describe = textBox1.Text;
            listBox2.Enabled = true;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
           textBox1.Text = Effectcollection[listBox2.SelectedIndex].Effect_describe;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox2.Enabled = false;
            textBox1.Enabled = true;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox2.Enabled = true;
            textBox1.Text = null;
        }
    }
}
