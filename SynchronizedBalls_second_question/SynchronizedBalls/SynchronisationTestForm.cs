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

        private static Semaphore wrt_sem = new Semaphore(1, 1);
        private static Semaphore rdr_sem = new Semaphore(5, 5);


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

            BallMover readerBall = new BallMover(pb, wrt_sem, rdr_sem);
            BallMover writerBall = new BallMover(pb, wrt_sem, rdr_sem);

            if (((CheckBox)sender).Checked)
            // The CheckBox was checked, so
            // pb must get a red background color and
            // a new thread, that will move pb, must be created and put into ta[index]
            {
                //the first 5 balls are red, and the last 5 balls are blue
                // red balls execute RunReader
                if (index <= 4)
                {                  
                    pb.BackColor = Color.Red;
                    ta[index] = new Thread(readerBall.RunReader);

                }
                // blue balls execute RunWriter
                else if (index > 4)
                {                   
                    pb.BackColor = Color.Blue;
                    ta[index] = new Thread(writerBall.RunWriter);
                }
                ta[index].IsBackground = true;
                ta[index].Start();
                
                // TODO create thread
            }
            else
            // The CheckBox was unchecked, so
            // the corresponding thread must be interrupted and 
            // pb must get transparant background color 
            {
                if(pb.BackColor == Color.Red)
                {
                    pb.BackColor = Color.Transparent;
                    readerBall.InterruptBall();
                    ta[index].Interrupt();
                }
                else
                {
                    pb.BackColor = Color.Transparent;
                    writerBall.InterruptBall();
                    ta[index].Interrupt();
                }
                //pb.BackColor = Color.Transparent;
                //ball.InterruptBall();
                //ta[index].Interrupt();

                // TODO interrupt thread
            }
        }

        private void SynchronisationTestForm_Load(object sender, EventArgs e)
        {

        }

        private void greenPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}