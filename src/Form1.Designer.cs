namespace PVA_Snake
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelPlayArea = new System.Windows.Forms.Panel();
            this.labelHelperGameOver = new System.Windows.Forms.Label();
            this.labelGameOver = new System.Windows.Forms.Label();
            this.labelScore = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.listBoxScores = new System.Windows.Forms.ListBox();
            this.panelPlayArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelPlayArea
            // 
            this.panelPlayArea.BackColor = System.Drawing.Color.YellowGreen;
            this.panelPlayArea.Controls.Add(this.labelHelperGameOver);
            this.panelPlayArea.Controls.Add(this.labelGameOver);
            this.panelPlayArea.Location = new System.Drawing.Point(11, 52);
            this.panelPlayArea.Name = "panelPlayArea";
            this.panelPlayArea.Size = new System.Drawing.Size(464, 464);
            this.panelPlayArea.TabIndex = 0;
            this.panelPlayArea.Paint += new System.Windows.Forms.PaintEventHandler(this.panelPlayArea_Paint);
            // 
            // labelHelperGameOver
            // 
            this.labelHelperGameOver.AutoSize = true;
            this.labelHelperGameOver.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHelperGameOver.Location = new System.Drawing.Point(67, 249);
            this.labelHelperGameOver.Name = "labelHelperGameOver";
            this.labelHelperGameOver.Size = new System.Drawing.Size(332, 33);
            this.labelHelperGameOver.TabIndex = 1;
            this.labelHelperGameOver.Text = "Press Space to try again";
            this.labelHelperGameOver.Visible = false;
            // 
            // labelGameOver
            // 
            this.labelGameOver.AutoSize = true;
            this.labelGameOver.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGameOver.Location = new System.Drawing.Point(147, 205);
            this.labelGameOver.Name = "labelGameOver";
            this.labelGameOver.Size = new System.Drawing.Size(167, 33);
            this.labelGameOver.TabIndex = 0;
            this.labelGameOver.Text = "Game Over";
            this.labelGameOver.Visible = false;
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScore.Location = new System.Drawing.Point(12, 9);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(31, 33);
            this.labelScore.TabIndex = 1;
            this.labelScore.Text = "0";
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            // 
            // listBoxScores
            // 
            this.listBoxScores.Enabled = false;
            this.listBoxScores.FormattingEnabled = true;
            this.listBoxScores.Location = new System.Drawing.Point(482, 52);
            this.listBoxScores.Name = "listBoxScores";
            this.listBoxScores.Size = new System.Drawing.Size(150, 459);
            this.listBoxScores.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 527);
            this.Controls.Add(this.listBoxScores);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.panelPlayArea);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Snake - PVA Project";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.panelPlayArea.ResumeLayout(false);
            this.panelPlayArea.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelPlayArea;
        private System.Windows.Forms.Label labelGameOver;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label labelHelperGameOver;
        private System.Windows.Forms.ListBox listBoxScores;
    }
}

