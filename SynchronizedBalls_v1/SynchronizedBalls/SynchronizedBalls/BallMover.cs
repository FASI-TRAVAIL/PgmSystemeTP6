using System;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;

namespace SynchronizedBalls
{

    /// <summary> 
    /// </summary>
    public class BallMover
    {
        private delegate void UpdatePictureBoxCallback(Point p);

        private PictureBox pb;
        private Semaphore sm;
        private Random rand = new Random();
        private int speed;

        public BallMover(PictureBox pb, Semaphore sm)
        {
            this.pb = pb;
            this.sm = sm;
        }

        //public BallMover(PictureBox pb)
        //{
        //    this.pb = pb;

        //}


        /// <summary> 
        /// Move ball over X axis, bouncing at the right border
        /// </summary>
        public void Run()
        {
            
            try
            {                   
                speed = rand.Next(5, 10);

                while (true)
                {
                    while (pb.Location.X < SynchronisationTestForm.CS_MINX)
                    {
                        MoveBall();
                        Thread.Sleep(speed);
                    }

                    sm.WaitOne();
                    while (pb.Location.X < SynchronisationTestForm.CS_MAXX)
                    {
                        MoveBall();
                        Thread.Sleep(speed);
                    }
                    sm.Release();   

                    while (pb.Location.X < SynchronisationTestForm.MAXX)
                    {
                        MoveBall();
                        Thread.Sleep(speed);
                    }
                    ResetBall();
                }
            }
            catch (ThreadInterruptedException)
            {
                ResetBall();
                return;
            }
           
        }

        public void InterruptBall()
        {
            if (pb.Location.X < SynchronisationTestForm.CS_MAXX && pb.Location.X > SynchronisationTestForm.CS_MINX)
            {
                sm.Release();
                ResetBall();
            }
            else
            {
                ResetBall();
            }

        }

        /// <summary>
        /// This method moves the ball and returns the new location
        /// </summary>
        private void MoveBall()
        {
            Point p = pb.Location;
            p.X++;
            pb.Invoke(new UpdatePictureBoxCallback(MovePictureBox), p);
        }

        /// <summary>
        ///  This method sets the ball back to the left hand side of the white area
        /// </summary>
        private void ResetBall()
        {
            Point p = pb.Location;
            p.X = SynchronisationTestForm.MINX;
            pb.Invoke(new UpdatePictureBoxCallback(MovePictureBox), p);
        }

        private void MovePictureBox(Point p)
        {
            pb.Location = p;
        }

    }
}