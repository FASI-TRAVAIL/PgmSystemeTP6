using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ThreadSpy
{
    public partial class ThreadSpyForm : Form
    {
        private Thread drawingThread;

        private char c = 'a';
        
        public ThreadSpyForm()
        {
            InitializeComponent();
            DrawingRunnable dr = new DrawingRunnable(this.TextBoxOutput, c);
            ThreadStart ts = new ThreadStart(dr.Run);
            drawingThread = new Thread(ts);
        }

        /// <summary>
        /// This method is called when the user clicks the button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonStartThread_Click(object sender, EventArgs e)
        {
            drawingThread.Start();
        }

        /// <summary>
        /// This method is called 10 times per second by the timer 
        /// to show the current status of the thread
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (drawingThread != null)
                this.TextBoxStatus.Text = drawingThread.ThreadState.ToString();
        }

    }
}