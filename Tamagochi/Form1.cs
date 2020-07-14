using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tamagochi
{
    public partial class Form1 : Form
    {
        Stopwatch sWach = new Stopwatch();
        public Form1()
        {
            InitializeComponent();
        }
        Pet Kim = new Pet();

        int feedCount = 0;
        int healCount = 0;
        int playCount = 0;

        List<string> petLifeTime = new List<string>();

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = Kim.checkState();
            progressBarHealth.Value = Kim.pHealth();
            progressBarHunger.Value = Kim.pFullness();
            progressBarHappyness.Value = Kim.pHappyness();
            label3.Text = $"Playes with Kim : {playCount}\n" +
                $"Kim's feeding : {feedCount}\n" +
                $"Kim's treatment : {healCount}";

            if (label1.Text == "Kim is Healthy")
            {
                pictureBox1.BackgroundImage = Tamagochi.Properties.Resources.Good;
                return;
            }
            if(label1.Text != "Kim is Dead" && label1.Text != "Kim is Healthy")
            {
                pictureBox1.BackgroundImage = Tamagochi.Properties.Resources.Bad;
                return;
            }
            if(label1.Text == "Kim is Dead")
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = true;
                pictureBox1.BackgroundImage = Tamagochi.Properties.Resources.Dead;
                sWach.Stop();
                timer1.Stop();
                DialogResult result = MessageBox.Show( "Do you want to resurect Kim?", "Kim is Dead", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                {
                    button4_Click(this,new EventArgs());
                }
                #region add to list
                petLifeTime.Add($"Kim's life total time :  + {sWach.Elapsed.ToString()}\n" +
                    $"Games played with Kim : {playCount.ToString()}\n" +
                    $"Treatments amount : {healCount.ToString()}\n" +
                    $"Feed amount : {feedCount.ToString()}");
                #endregion
                

            }
            
        }

      
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            sWach.Start();
            pictureBox1.BackgroundImage = Tamagochi.Properties.Resources.Good;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "Kim is full";
            feedCount++;
            if(Kim.pFullness() < 90)
            {
                Kim.feed();
                pictureBox2.BackgroundImage = Tamagochi.Properties.Resources.Feed;
                progressBarHunger.Value = Kim.pFullness();
            }
            else
            {
                label1.Text = "Kim is FAT enogth!!!";
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "Kim is happy";
            playCount++;
            if(Kim.pHappyness() < 90)
            {
                Kim.play();
                pictureBox2.BackgroundImage = Tamagochi.Properties.Resources.Play;
                progressBarHappyness.Value = Kim.pHappyness();
            }
            else
            {
                label1.Text = "Kim is HAPPY enogth!!!";

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = "Kim was treated";
            healCount++;
            if(Kim.pHealth() < 90)
            {
                Kim.treat();
                pictureBox2.BackgroundImage = Tamagochi.Properties.Resources.Treat;
                progressBarHealth.Value = Kim.pHealth();
            }
            else
            {
                label1.Text = "Kim is HEALTHY enogth!!!";

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Tamagochi.Properties.Resources.Risen;
            try
            {
                feedCount = 0;
                healCount = 0;
                playCount = 0;
                label1.Text = "The Kim was risen !!!";
                Kim.resurect();
                timer1.Start();
                sWach.Start();
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = false;
            }
           catch(Exception ex) { }
        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            timer1.Interval = trackBar1.Value;
            label2.Text = $"Time speed {trackBar1.Value.ToString()}ms";
        }
    }
}
