namespace AlloCineClient
{
    partial class Form1
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonVariousCalls = new System.Windows.Forms.Button();
            this.buttonEvent = new System.Windows.Forms.Button();
            this.buttonAsync = new System.Windows.Forms.Button();
            this.buttonParallel = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(23, 60);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(675, 362);
            this.textBox1.TabIndex = 1;
            // 
            // buttonVariousCalls
            // 
            this.buttonVariousCalls.Location = new System.Drawing.Point(12, 10);
            this.buttonVariousCalls.Name = "buttonVariousCalls";
            this.buttonVariousCalls.Size = new System.Drawing.Size(75, 23);
            this.buttonVariousCalls.TabIndex = 7;
            this.buttonVariousCalls.Text = "Various calls";
            this.buttonVariousCalls.UseVisualStyleBackColor = true;
            this.buttonVariousCalls.Click += new System.EventHandler(this.buttonVariousCalls_Click);
            // 
            // buttonEvent
            // 
            this.buttonEvent.Location = new System.Drawing.Point(93, 10);
            this.buttonEvent.Name = "buttonEvent";
            this.buttonEvent.Size = new System.Drawing.Size(98, 23);
            this.buttonEvent.TabIndex = 8;
            this.buttonEvent.Text = "Event example";
            this.buttonEvent.UseVisualStyleBackColor = true;
            this.buttonEvent.Click += new System.EventHandler(this.buttonEvent_Click);
            // 
            // buttonAsync
            // 
            this.buttonAsync.Location = new System.Drawing.Point(197, 10);
            this.buttonAsync.Name = "buttonAsync";
            this.buttonAsync.Size = new System.Drawing.Size(92, 23);
            this.buttonAsync.TabIndex = 9;
            this.buttonAsync.Text = "Async example";
            this.buttonAsync.UseVisualStyleBackColor = true;
            this.buttonAsync.Click += new System.EventHandler(this.buttonAsync_Click);
            // 
            // buttonParallel
            // 
            this.buttonParallel.Location = new System.Drawing.Point(295, 9);
            this.buttonParallel.Name = "buttonParallel";
            this.buttonParallel.Size = new System.Drawing.Size(98, 23);
            this.buttonParallel.TabIndex = 10;
            this.buttonParallel.Text = "Parallel example";
            this.buttonParallel.UseVisualStyleBackColor = true;
            this.buttonParallel.Click += new System.EventHandler(this.buttonParallel_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(399, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "TheaterGetList";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(494, 10);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(132, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "TheaterGetShowtimeList";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(632, 9);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(142, 23);
            this.button3.TabIndex = 13;
            this.button3.Text = "MovieGetOnTheaterList";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 434);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonParallel);
            this.Controls.Add(this.buttonAsync);
            this.Controls.Add(this.buttonEvent);
            this.Controls.Add(this.buttonVariousCalls);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonVariousCalls;
        private System.Windows.Forms.Button buttonEvent;
        private System.Windows.Forms.Button buttonAsync;
        private System.Windows.Forms.Button buttonParallel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

