using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ThreadSpy
{
    class DrawingRunnable
    {
        private TextBox tb;
        private char c;

        public DrawingRunnable(TextBox tb, char c)
        {
            this.tb = tb;
            this.c = c;
        }

        /// <summary>
        /// The method to be executed by the new thread
        /// It will print 20 times the character c into TextBox tb
        /// </summary>
        public void Run()
        {
            for (int i = 0; i < 20; i++)
            {
                Thread.Sleep(300);
                TextBoxHelper.AddChar(tb, c);
             }
        }
    }
}