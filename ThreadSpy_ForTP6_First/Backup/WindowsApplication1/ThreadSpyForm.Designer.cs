namespace ThreadSpy
{
    partial class ThreadSpyForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ButtonStartThread = new System.Windows.Forms.Button();
            this.TextBoxStatus = new System.Windows.Forms.TextBox();
            this.jLabel1 = new System.Windows.Forms.Label();
            this.TextBoxOutput = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ButtonStartThread
            // 
            this.ButtonStartThread.Location = new System.Drawing.Point(12, 45);
            this.ButtonStartThread.Name = "ButtonStartThread";
            this.ButtonStartThread.Size = new System.Drawing.Size(339, 41);
            this.ButtonStartThread.TabIndex = 0;
            this.ButtonStartThread.Text = "Start thread";
            this.ButtonStartThread.Click += new System.EventHandler(this.ButtonStartThread_Click);
            // 
            // TextBoxStatus
            // 
            this.TextBoxStatus.Location = new System.Drawing.Point(90, 16);
            this.TextBoxStatus.Name = "TextBoxStatus";
            this.TextBoxStatus.Size = new System.Drawing.Size(171, 20);
            this.TextBoxStatus.TabIndex = 0;
            // 
            // jLabel1
            // 
            this.jLabel1.AutoSize = true;
            this.jLabel1.Location = new System.Drawing.Point(12, 19);
            this.jLabel1.Name = "jLabel1";
            this.jLabel1.Size = new System.Drawing.Size(72, 13);
            this.jLabel1.TabIndex = 0;
            this.jLabel1.Text = "Thread status";
            // 
            // TextBoxOutput
            // 
            this.TextBoxOutput.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxOutput.Location = new System.Drawing.Point(11, 116);
            this.TextBoxOutput.Multiline = true;
            this.TextBoxOutput.Name = "TextBoxOutput";
            this.TextBoxOutput.ReadOnly = true;
            this.TextBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextBoxOutput.Size = new System.Drawing.Size(339, 81);
            this.TextBoxOutput.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Output";
            // 
            // ThreadSpyForm
            // 
            this.ClientSize = new System.Drawing.Size(363, 209);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.jLabel1);
            this.Controls.Add(this.ButtonStartThread);
            this.Controls.Add(this.TextBoxStatus);
            this.Controls.Add(this.TextBoxOutput);
            this.Name = "ThreadSpyForm";
            this.Text = "ThreadSpy";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonStartThread;
        private System.Windows.Forms.TextBox TextBoxStatus;
        private System.Windows.Forms.Label jLabel1;
        private System.Windows.Forms.TextBox TextBoxOutput;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
    }
}

