using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace syntiks
{
    public partial class Form1 : Form
    {

        List<int> ghost_tilalista = new List<int> { 1, 1, 1 };
        List<int> tilalista = new List<int> { 0, 0, 0 };
        List<int> volalist = new List<int> { 0, 0, 0 };
        List<int> lfo_freq = new List<int> { 0, 0, 0 };
        List<int> lfo_amount = new List<int> { 0, 0, 0 };
        List<int> pitchboost = new List<int> { 5, 5, 5 };
        float taajuus = 0;
        


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ghost_tilalista[0] = 1;
            if (checkBox1.CheckState == CheckState.Checked)
            {
                tilalista[0] = ghost_tilalista[0];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ghost_tilalista[0] = 2;
            if (checkBox1.CheckState == CheckState.Checked)
            {
                tilalista[0] = ghost_tilalista[0];
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            taajuus = 130.8128f;
            makesound.OSC(taajuus,tilalista,volalist,lfo_freq,lfo_amount,pitchboost);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ghost_tilalista[1] = 1;
            if (checkBox2.CheckState == CheckState.Checked)
            {
                tilalista[1] = ghost_tilalista[1];
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ghost_tilalista[1] = 2;
            if (checkBox2.CheckState == CheckState.Checked)
            {
                tilalista[1] = ghost_tilalista[1];
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
            {
                tilalista[0] = ghost_tilalista[0];
            }
            else
            {
                tilalista[0] = 0;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.CheckState == CheckState.Checked)
            {
                tilalista[1] = ghost_tilalista[1];
            }
            else
            {
                tilalista[1] = 0;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            volalist[0] = trackBar1.Value;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            volalist[1] = trackBar2.Value;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            taajuus = 146.8324f;
            makesound.OSC(taajuus, tilalista, volalist, lfo_freq, lfo_amount, pitchboost);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ghost_tilalista[0] = 3;
            if (checkBox1.CheckState == CheckState.Checked)
            {
                tilalista[0] = ghost_tilalista[0];
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ghost_tilalista[0] = 4;
            if (checkBox1.CheckState == CheckState.Checked)
            {
                tilalista[0] = ghost_tilalista[0];
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ghost_tilalista[1] = 3;
            if (checkBox2.CheckState == CheckState.Checked)
            {
                tilalista[1] = ghost_tilalista[1];
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ghost_tilalista[1] = 4;
            if (checkBox2.CheckState == CheckState.Checked)
            {
                tilalista[1] = ghost_tilalista[1];
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            ghost_tilalista[2] = 1;
            if (checkBox3.CheckState == CheckState.Checked)
            {
                tilalista[2] = ghost_tilalista[2];
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            ghost_tilalista[2] = 2;
            if (checkBox3.CheckState == CheckState.Checked)
            {
                tilalista[2] = ghost_tilalista[2];
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ghost_tilalista[2] = 3;
            if (checkBox3.CheckState == CheckState.Checked)
            {
                tilalista[2] = ghost_tilalista[2];
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            ghost_tilalista[2] = 4;
            if (checkBox3.CheckState == CheckState.Checked)
            {
                tilalista[2] = ghost_tilalista[2];
            }
        }

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            volalist[2] = trackBar6.Value;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.CheckState == CheckState.Checked)
            {
                tilalista[2] = ghost_tilalista[2];
            }
            else
            {
                tilalista[2] = 0;
            }
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            lfo_freq[0] = trackBar3.Value;
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            lfo_freq[1] = trackBar4.Value;
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            lfo_freq[2] = trackBar5.Value;
        }

        private void trackBar9_Scroll(object sender, EventArgs e)
        {
            lfo_amount[0] = trackBar9.Value;
        }

        private void trackBar8_Scroll(object sender, EventArgs e)
        {
            lfo_amount[1] = trackBar8.Value;
        }

        private void trackBar7_Scroll(object sender, EventArgs e)
        {
            lfo_amount[2] = trackBar7.Value;
        }

        private void trackBar12_Scroll(object sender, EventArgs e)
        {
            pitchboost[0] = trackBar12.Value;
        }

        private void trackBar11_Scroll(object sender, EventArgs e)
        {
            pitchboost[1] = trackBar11.Value;
        }

        private void trackBar10_Scroll(object sender, EventArgs e)
        {
            pitchboost[2] = trackBar10.Value;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {
            taajuus = 138.5913f;
            makesound.OSC(taajuus, tilalista, volalist, lfo_freq, lfo_amount, pitchboost);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            taajuus = 155.5635f;
            makesound.OSC(taajuus, tilalista, volalist, lfo_freq, lfo_amount, pitchboost);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            taajuus = 164.8138f;
            makesound.OSC(taajuus, tilalista, volalist, lfo_freq, lfo_amount, pitchboost);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            taajuus = 174.6141f;
            makesound.OSC(taajuus, tilalista, volalist, lfo_freq, lfo_amount, pitchboost);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            taajuus = 184.9972f;
            makesound.OSC(taajuus, tilalista, volalist, lfo_freq, lfo_amount, pitchboost);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            taajuus = 195.9977f;
            makesound.OSC(taajuus, tilalista, volalist, lfo_freq, lfo_amount, pitchboost);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            taajuus = 207.6523f;
            makesound.OSC(taajuus, tilalista, volalist, lfo_freq, lfo_amount, pitchboost);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            taajuus = 220.0000f;
            makesound.OSC(taajuus, tilalista, volalist, lfo_freq, lfo_amount, pitchboost);
        }

        private void button25_Click(object sender, EventArgs e)
        {
            taajuus = 233.0819f;
            makesound.OSC(taajuus, tilalista, volalist, lfo_freq, lfo_amount, pitchboost);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            taajuus = 246.9417f;
            makesound.OSC(taajuus, tilalista, volalist, lfo_freq, lfo_amount, pitchboost);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            taajuus = 261.6256f;
            makesound.OSC(taajuus, tilalista, volalist, lfo_freq, lfo_amount, pitchboost);
        }

        private void button26_Click(object sender, EventArgs e)
        {
            taajuus = 440f;
        }
    }
}
