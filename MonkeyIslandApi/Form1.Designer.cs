namespace MonkeyIslandApi
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.listAction = new System.Windows.Forms.ListBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.startButton = new System.Windows.Forms.Button();
            this.breakButton = new System.Windows.Forms.Button();
            this.messageLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // listAction
            // 
            this.listAction.BackColor = System.Drawing.Color.Black;
            this.listAction.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listAction.ForeColor = System.Drawing.Color.LawnGreen;
            this.listAction.FormattingEnabled = true;
            this.listAction.ItemHeight = 16;
            this.listAction.Location = new System.Drawing.Point(0, 455);
            this.listAction.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listAction.Name = "listAction";
            this.listAction.Size = new System.Drawing.Size(830, 132);
            this.listAction.TabIndex = 3;
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.PowderBlue;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(830, 455);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 4;
            this.pictureBox.TabStop = false;
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.Gold;
            this.startButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.startButton.FlatAppearance.BorderSize = 2;
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.Location = new System.Drawing.Point(699, 38);
            this.startButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.startButton.Name = "startButton";
            this.startButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.startButton.Size = new System.Drawing.Size(91, 32);
            this.startButton.TabIndex = 5;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // breakButton
            // 
            this.breakButton.BackColor = System.Drawing.Color.Gold;
            this.breakButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.breakButton.FlatAppearance.BorderSize = 2;
            this.breakButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.breakButton.Location = new System.Drawing.Point(687, 21);
            this.breakButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.breakButton.Name = "breakButton";
            this.breakButton.Size = new System.Drawing.Size(114, 66);
            this.breakButton.TabIndex = 6;
            this.breakButton.Text = "Break the box";
            this.breakButton.UseVisualStyleBackColor = false;
            this.breakButton.Click += new System.EventHandler(this.breakButton_Click);
            // 
            // messageLabel
            // 
            this.messageLabel.BackColor = System.Drawing.Color.Azure;
            this.messageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.messageLabel.Location = new System.Drawing.Point(26, 27);
            this.messageLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(351, 55);
            this.messageLabel.TabIndex = 7;
            this.messageLabel.Text = "label1";
            this.messageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(830, 587);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.breakButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.listAction);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Monkey Island";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox listAction;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button breakButton;
        private System.Windows.Forms.Label messageLabel;
    }
}

