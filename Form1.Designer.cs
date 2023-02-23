namespace Joc
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DiceBox = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.rollBtn = new System.Windows.Forms.Button();
            this.playBtn = new System.Windows.Forms.Button();
            this.resultText2 = new System.Windows.Forms.Label();
            this.resultTextEqual = new System.Windows.Forms.Label();
            this.resultText1 = new System.Windows.Forms.Label();
            this.picDie2 = new System.Windows.Forms.PictureBox();
            this.picDie1 = new System.Windows.Forms.PictureBox();
            this.exitBtn = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.readyBtn = new System.Windows.Forms.Button();
            this.imagineOrientare = new System.Windows.Forms.PictureBox();
            this.rotateBtn = new System.Windows.Forms.Button();
            this.imagineOrientare2 = new System.Windows.Forms.PictureBox();
            this.DiceBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDie2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDie1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagineOrientare)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagineOrientare2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Snap ITC", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(102, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Player 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Snap ITC", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(404, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 27);
            this.label2.TabIndex = 1;
            this.label2.Text = "Player 2";
            // 
            // DiceBox
            // 
            this.DiceBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.DiceBox.Controls.Add(this.progressBar1);
            this.DiceBox.Controls.Add(this.rollBtn);
            this.DiceBox.Controls.Add(this.playBtn);
            this.DiceBox.Controls.Add(this.resultText2);
            this.DiceBox.Controls.Add(this.resultTextEqual);
            this.DiceBox.Controls.Add(this.resultText1);
            this.DiceBox.Controls.Add(this.picDie2);
            this.DiceBox.Controls.Add(this.picDie1);
            this.DiceBox.Controls.Add(this.label1);
            this.DiceBox.Controls.Add(this.label2);
            this.DiceBox.Location = new System.Drawing.Point(955, 148);
            this.DiceBox.Name = "DiceBox";
            this.DiceBox.Size = new System.Drawing.Size(620, 508);
            this.DiceBox.TabIndex = 2;
            this.DiceBox.TabStop = false;
            this.DiceBox.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(6, 479);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(608, 23);
            this.progressBar1.TabIndex = 9;
            // 
            // rollBtn
            // 
            this.rollBtn.Location = new System.Drawing.Point(355, 424);
            this.rollBtn.Name = "rollBtn";
            this.rollBtn.Size = new System.Drawing.Size(210, 50);
            this.rollBtn.TabIndex = 8;
            this.rollBtn.Text = "Roll";
            this.rollBtn.UseVisualStyleBackColor = true;
            this.rollBtn.Click += new System.EventHandler(this.rollBtn_Click);
            // 
            // playBtn
            // 
            this.playBtn.Enabled = false;
            this.playBtn.Location = new System.Drawing.Point(48, 424);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(210, 50);
            this.playBtn.TabIndex = 7;
            this.playBtn.Text = "Play";
            this.playBtn.UseVisualStyleBackColor = true;
            this.playBtn.Click += new System.EventHandler(this.playBtn_Click);
            // 
            // resultText2
            // 
            this.resultText2.AutoSize = true;
            this.resultText2.Font = new System.Drawing.Font("Snap ITC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.resultText2.Location = new System.Drawing.Point(205, 369);
            this.resultText2.Name = "resultText2";
            this.resultText2.Size = new System.Drawing.Size(210, 22);
            this.resultText2.TabIndex = 6;
            this.resultText2.Text = "Player 2 moves first.";
            this.resultText2.Visible = false;
            // 
            // resultTextEqual
            // 
            this.resultTextEqual.AutoSize = true;
            this.resultTextEqual.Font = new System.Drawing.Font("Snap ITC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.resultTextEqual.Location = new System.Drawing.Point(255, 369);
            this.resultTextEqual.Name = "resultTextEqual";
            this.resultTextEqual.Size = new System.Drawing.Size(113, 22);
            this.resultTextEqual.TabIndex = 5;
            this.resultTextEqual.Text = "Roll Again!";
            this.resultTextEqual.Visible = false;
            // 
            // resultText1
            // 
            this.resultText1.AutoSize = true;
            this.resultText1.Font = new System.Drawing.Font("Snap ITC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.resultText1.Location = new System.Drawing.Point(210, 369);
            this.resultText1.Name = "resultText1";
            this.resultText1.Size = new System.Drawing.Size(205, 22);
            this.resultText1.TabIndex = 4;
            this.resultText1.Text = "Player 1 moves first.";
            this.resultText1.Visible = false;
            // 
            // picDie2
            // 
            this.picDie2.Location = new System.Drawing.Point(326, 71);
            this.picDie2.Name = "picDie2";
            this.picDie2.Size = new System.Drawing.Size(260, 260);
            this.picDie2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDie2.TabIndex = 3;
            this.picDie2.TabStop = false;
            // 
            // picDie1
            // 
            this.picDie1.InitialImage = global::Joc.Properties.Resources.Die_1;
            this.picDie1.Location = new System.Drawing.Point(27, 71);
            this.picDie1.Name = "picDie1";
            this.picDie1.Size = new System.Drawing.Size(260, 260);
            this.picDie1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDie1.TabIndex = 2;
            this.picDie1.TabStop = false;
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(1700, 980);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(150, 50);
            this.exitBtn.TabIndex = 3;
            this.exitBtn.Text = "Exit";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.mainMenuButton_Click);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // readyBtn
            // 
            this.readyBtn.Location = new System.Drawing.Point(780, 825);
            this.readyBtn.Name = "readyBtn";
            this.readyBtn.Size = new System.Drawing.Size(166, 64);
            this.readyBtn.TabIndex = 4;
            this.readyBtn.Text = "Ready!";
            this.readyBtn.UseVisualStyleBackColor = true;
            this.readyBtn.Click += new System.EventHandler(this.readyBtn_Click);
            // 
            // imagineOrientare
            // 
            this.imagineOrientare.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.imagineOrientare.Image = global::Joc.Properties.Resources.Orientare_01;
            this.imagineOrientare.Location = new System.Drawing.Point(1540, 603);
            this.imagineOrientare.Name = "imagineOrientare";
            this.imagineOrientare.Size = new System.Drawing.Size(310, 220);
            this.imagineOrientare.TabIndex = 5;
            this.imagineOrientare.TabStop = false;
            this.imagineOrientare.Visible = false;
            // 
            // rotateBtn
            // 
            this.rotateBtn.Location = new System.Drawing.Point(1029, 825);
            this.rotateBtn.Name = "rotateBtn";
            this.rotateBtn.Size = new System.Drawing.Size(168, 64);
            this.rotateBtn.TabIndex = 6;
            this.rotateBtn.Text = "Rotate";
            this.rotateBtn.UseVisualStyleBackColor = true;
            this.rotateBtn.Click += new System.EventHandler(this.rotateBtn_Click);
            // 
            // imagineOrientare2
            // 
            this.imagineOrientare2.Image = global::Joc.Properties.Resources.Orientare_1;
            this.imagineOrientare2.Location = new System.Drawing.Point(1539, 517);
            this.imagineOrientare2.Name = "imagineOrientare2";
            this.imagineOrientare2.Size = new System.Drawing.Size(310, 439);
            this.imagineOrientare2.TabIndex = 7;
            this.imagineOrientare2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Joc.Properties.Resources.finalbackgroundFullHD;
            this.ClientSize = new System.Drawing.Size(1861, 1061);
            this.Controls.Add(this.imagineOrientare2);
            this.Controls.Add(this.rotateBtn);
            this.Controls.Add(this.readyBtn);
            this.Controls.Add(this.imagineOrientare);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.DiceBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.DiceBox.ResumeLayout(false);
            this.DiceBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDie2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDie1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagineOrientare)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagineOrientare2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Label label1;
        private Label label2;
        private GroupBox DiceBox;
        private Button rollBtn;
        private Button playBtn;
        private Label resultText2;
        private Label resultTextEqual;
        private Label resultText1;
        private PictureBox picDie2;
        private PictureBox picDie1;
        private Button exitBtn;
        private ProgressBar progressBar1;
        private Button readyBtn;
        private PictureBox imagineOrientare;
        private Button rotateBtn;
        private PictureBox imagineOrientare2;
    }
}