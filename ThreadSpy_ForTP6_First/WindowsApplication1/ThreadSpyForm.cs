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
        private readonly object sharedVariableLock = new object();
        private readonly object textBoxLock = new object();
        private TextBox tb;

        private int NrOfChars = 1;

        private int max = 26;

        private Thread [] threads;

        private char[] tab = {
            'a', 'b', 'c', 'd', 'e', 'f', 'g',
            'h', 'i', 'j', 'k', 'l', 'm',
            'n', 'o', 'p', 'q', 'r', 's',
            't', 'u', 'v', 'w', 'x', 'y',
            'z'
        };

        private int threadCount = 0;

        public ThreadSpyForm()
        {
            InitializeComponent();
            tb = this.TextBoxOutput;

            threads = new Thread[max];

            for (int i = 0; i<tab.Length; i++)
            {
                threads[i] = new Thread(Run)
                {
                    IsBackground = true
                };
            }
        }

        private void Run(Object obj)
        {
            if (obj != null)
            {
                lock (textBoxLock)
                    for (int i = 0; i < NrOfChars; i++)
                    {
                        Thread.Sleep(300);
                        TextBoxHelper.AddChar(tb, (char) obj);
               
                    }
                NrOfChars++;
            }
        }

        /// <summary>
        /// This method is called when the user clicks the button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonStartThread_Click(object sender, EventArgs e)
        {
            lock (sharedVariableLock)
                if (threadCount < max)
                {
                    threads[threadCount].Start((char)tab[threadCount]);
                }
            threadCount++;
        }

        /// <summary>
        /// This method is called 10 times per second by the timer 
        /// to show the current status of the thread
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (threadCount <= max )
            {
                if(threadCount==0)
                   this.TextBoxStatus.Text = threads[threadCount].ThreadState.ToString();
                else
                   this.TextBoxStatus.Text = threads[threadCount-1].ThreadState.ToString();
                // threadCount++;
            }
        }
        
        private void ThreadSpyForm_Load(object sender, EventArgs e)
        {

        }

        private void ThreadSpyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Check the thread state before closing
            //if (drawingThread.ThreadState == ThreadState.Running || drawingThread.ThreadState == ThreadState.WaitSleepJoin)
            //{
            //    drawingThread.Abort();
            //}
                // Check the thread state before closing
            //if (drawingThread.ThreadState == ThreadState.Running || drawingThread.ThreadState == ThreadState.WaitSleepJoin)
            //{
            //    drawingThread.Suspend();
            //    if (MessageBox.Show("Un thread est en cours exécution, voulez-vous l'arrêter?", "Infos",
            //       MessageBoxButtons.YesNo) == DialogResult.Yes)
            //    {
            //        // Stop thread before closing
            //        if (drawingThread.ThreadState == ThreadState.Suspended)
            //        {
            //            drawingThread.Resume();
            //            drawingThread.Abort();
            //        }
            //        else
            //        {
            //            drawingThread.Abort();
            //        }
            //    }
            //    else
            //    {
            //        // Cancel the Closing event from closing the form.
            //        e.Cancel = true;
            //        drawingThread.Resume();
            //    }
            //}
        }
    }
}