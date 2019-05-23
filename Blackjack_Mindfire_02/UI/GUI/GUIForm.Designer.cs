namespace Blackjack_Mindfire_02.UI.GUI
{
    partial class GUIForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUIForm));
            this.label1 = new System.Windows.Forms.Label();
            this.amtPlayersTextBox = new System.Windows.Forms.TextBox();
            this.startGameButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dealersHandTextBox = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dealersScoreTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.playersComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.playersHandTextBox = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.playersScoreTextBox = new System.Windows.Forms.TextBox();
            this.hitButton = new System.Windows.Forms.Button();
            this.holdButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.participantsPointsTextBox = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.participantsWinTextBox = new System.Windows.Forms.RichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(102, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Amount of Players: ";
            // 
            // amtPlayersTextBox
            // 
            this.amtPlayersTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(73)))), ((int)(((byte)(15)))));
            this.amtPlayersTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amtPlayersTextBox.ForeColor = System.Drawing.Color.Yellow;
            this.amtPlayersTextBox.Location = new System.Drawing.Point(326, 19);
            this.amtPlayersTextBox.Name = "amtPlayersTextBox";
            this.amtPlayersTextBox.Size = new System.Drawing.Size(200, 41);
            this.amtPlayersTextBox.TabIndex = 1;
            // 
            // startGameButton
            // 
            this.startGameButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(86)))), ((int)(((byte)(25)))));
            this.startGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startGameButton.ForeColor = System.Drawing.Color.Yellow;
            this.startGameButton.Location = new System.Drawing.Point(533, 11);
            this.startGameButton.Name = "startGameButton";
            this.startGameButton.Size = new System.Drawing.Size(215, 57);
            this.startGameButton.TabIndex = 2;
            this.startGameButton.Text = "Start Game";
            this.startGameButton.UseVisualStyleBackColor = false;
            this.startGameButton.Click += new System.EventHandler(this.startGameButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(48, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(226, 39);
            this.label2.TabIndex = 3;
            this.label2.Text = "Dealers Hand";
            // 
            // dealersHandTextBox
            // 
            this.dealersHandTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(73)))), ((int)(((byte)(15)))));
            this.dealersHandTextBox.ForeColor = System.Drawing.Color.Yellow;
            this.dealersHandTextBox.Location = new System.Drawing.Point(41, 150);
            this.dealersHandTextBox.Name = "dealersHandTextBox";
            this.dealersHandTextBox.Size = new System.Drawing.Size(243, 133);
            this.dealersHandTextBox.TabIndex = 4;
            this.dealersHandTextBox.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Yellow;
            this.label3.Location = new System.Drawing.Point(37, 302);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Dealers Hand Value";
            // 
            // dealersScoreTextBox
            // 
            this.dealersScoreTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(73)))), ((int)(((byte)(15)))));
            this.dealersScoreTextBox.ForeColor = System.Drawing.Color.Yellow;
            this.dealersScoreTextBox.Location = new System.Drawing.Point(195, 299);
            this.dealersScoreTextBox.Name = "dealersScoreTextBox";
            this.dealersScoreTextBox.ReadOnly = true;
            this.dealersScoreTextBox.Size = new System.Drawing.Size(89, 26);
            this.dealersScoreTextBox.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Yellow;
            this.label4.Location = new System.Drawing.Point(434, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 29);
            this.label4.TabIndex = 7;
            this.label4.Text = "Player: ";
            // 
            // playersComboBox
            // 
            this.playersComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(86)))), ((int)(((byte)(25)))));
            this.playersComboBox.ForeColor = System.Drawing.Color.Yellow;
            this.playersComboBox.FormattingEnabled = true;
            this.playersComboBox.Location = new System.Drawing.Point(533, 111);
            this.playersComboBox.Name = "playersComboBox";
            this.playersComboBox.Size = new System.Drawing.Size(190, 28);
            this.playersComboBox.TabIndex = 8;
            this.playersComboBox.SelectedIndexChanged += new System.EventHandler(this.playersComboBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Yellow;
            this.label5.Location = new System.Drawing.Point(729, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 29);
            this.label5.TabIndex = 9;
            this.label5.Text = "Hand";
            // 
            // playersHandTextBox
            // 
            this.playersHandTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(73)))), ((int)(((byte)(15)))));
            this.playersHandTextBox.ForeColor = System.Drawing.Color.Yellow;
            this.playersHandTextBox.Location = new System.Drawing.Point(448, 150);
            this.playersHandTextBox.Name = "playersHandTextBox";
            this.playersHandTextBox.Size = new System.Drawing.Size(337, 125);
            this.playersHandTextBox.TabIndex = 10;
            this.playersHandTextBox.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Yellow;
            this.label6.Location = new System.Drawing.Point(444, 291);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(156, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Players Hand Value: ";
            // 
            // playersScoreTextBox
            // 
            this.playersScoreTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(73)))), ((int)(((byte)(15)))));
            this.playersScoreTextBox.ForeColor = System.Drawing.Color.Yellow;
            this.playersScoreTextBox.Location = new System.Drawing.Point(606, 288);
            this.playersScoreTextBox.Name = "playersScoreTextBox";
            this.playersScoreTextBox.ReadOnly = true;
            this.playersScoreTextBox.Size = new System.Drawing.Size(175, 26);
            this.playersScoreTextBox.TabIndex = 12;
            // 
            // hitButton
            // 
            this.hitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(86)))), ((int)(((byte)(25)))));
            this.hitButton.ForeColor = System.Drawing.Color.Yellow;
            this.hitButton.Location = new System.Drawing.Point(444, 324);
            this.hitButton.Name = "hitButton";
            this.hitButton.Size = new System.Drawing.Size(159, 34);
            this.hitButton.TabIndex = 13;
            this.hitButton.Text = "HIT";
            this.hitButton.UseVisualStyleBackColor = false;
            this.hitButton.Click += new System.EventHandler(this.hitButton_Click);
            // 
            // holdButton
            // 
            this.holdButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(86)))), ((int)(((byte)(25)))));
            this.holdButton.ForeColor = System.Drawing.Color.Yellow;
            this.holdButton.Location = new System.Drawing.Point(622, 324);
            this.holdButton.Name = "holdButton";
            this.holdButton.Size = new System.Drawing.Size(159, 34);
            this.holdButton.TabIndex = 14;
            this.holdButton.Text = "HOLD";
            this.holdButton.UseVisualStyleBackColor = false;
            this.holdButton.Click += new System.EventHandler(this.holdButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Yellow;
            this.label7.Location = new System.Drawing.Point(42, 710);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(299, 39);
            this.label7.TabIndex = 15;
            this.label7.Text = "Participants Points";
            // 
            // participantsPointsTextBox
            // 
            this.participantsPointsTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(73)))), ((int)(((byte)(15)))));
            this.participantsPointsTextBox.ForeColor = System.Drawing.Color.Yellow;
            this.participantsPointsTextBox.Location = new System.Drawing.Point(41, 762);
            this.participantsPointsTextBox.Name = "participantsPointsTextBox";
            this.participantsPointsTextBox.Size = new System.Drawing.Size(300, 150);
            this.participantsPointsTextBox.TabIndex = 16;
            this.participantsPointsTextBox.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Yellow;
            this.label8.Location = new System.Drawing.Point(518, 710);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(264, 39);
            this.label8.TabIndex = 17;
            this.label8.Text = "Winning Players";
            // 
            // participantsWinTextBox
            // 
            this.participantsWinTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(73)))), ((int)(((byte)(15)))));
            this.participantsWinTextBox.ForeColor = System.Drawing.Color.Yellow;
            this.participantsWinTextBox.Location = new System.Drawing.Point(499, 762);
            this.participantsWinTextBox.Name = "participantsWinTextBox";
            this.participantsWinTextBox.Size = new System.Drawing.Size(300, 150);
            this.participantsWinTextBox.TabIndex = 18;
            this.participantsWinTextBox.Text = "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(261, 391);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 293);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // GUIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(86)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(832, 942);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.participantsWinTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.participantsPointsTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.holdButton);
            this.Controls.Add(this.hitButton);
            this.Controls.Add(this.playersScoreTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.playersHandTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.playersComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dealersScoreTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dealersHandTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.startGameButton);
            this.Controls.Add(this.amtPlayersTextBox);
            this.Controls.Add(this.label1);
            this.Name = "GUIForm";
            this.Text = "GUIForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox amtPlayersTextBox;
        private System.Windows.Forms.Button startGameButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox dealersHandTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox dealersScoreTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox playersComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox playersHandTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox playersScoreTextBox;
        private System.Windows.Forms.Button hitButton;
        private System.Windows.Forms.Button holdButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox participantsPointsTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox participantsWinTextBox;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}