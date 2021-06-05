using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace SynchronizedBalls
{
    public partial class SynchronisationTestForm : Form
    {
        public const int MINX = 0;
        public const int MAXX = 750;

        public const int CS_MINX = 200;
        public const int CS_MAXX = 450;

        private PictureBox[] pba = new PictureBox[10];
        private Thread[] ta = new Thread[10];

        public SynchronisationTestForm()
        {
            InitializeComponent();
            pba[0] = pictureBox1;
            pba[1] = pictureBox2;
            pba[2] = pictureBox3;
            pba[3] = pictureBox4;
            pba[4] = pictureBox5;
            pba[5] = pictureBox6;
            pba[6] = pictureBox7;
            pba[7] = pictureBox8;
            pba[8] = pictureBox9;
            pba[9] = pictureBox10;
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            // index is the number of the CheckBox that was clicked
            // This index is derived from the y-position of the CheckBox
            int index = (((CheckBox)sender).Location.Y - 25) / 65;
            
            // pb is the PictureBox that belongs to this CheckBox
            PictureBox pb = pba[index];

            if (((CheckBox)sender).Checked)
            // The CheckBox was checked, so
            // pb must get a red background color and
            // a new thread, that will move pb, must be created and put into ta[index]
            {  
                // TODO create thread
            }
            else
            // The CheckBox was unchecked, so
            // the corresponding thread must be interrupted and 
            // pb must get transparant background color 
            {
                // TODO interrupt thread
            }
        }
    }
}