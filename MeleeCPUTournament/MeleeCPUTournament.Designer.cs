namespace MeleeCPUTournament {
    partial class MeleeCPUTournament {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.button1 = new System.Windows.Forms.Button();
            this.startedTournamentsListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Create New Tournament";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // startedTournamentsListBox
            // 
            this.startedTournamentsListBox.FormattingEnabled = true;
            this.startedTournamentsListBox.Location = new System.Drawing.Point(225, 39);
            this.startedTournamentsListBox.Name = "startedTournamentsListBox";
            this.startedTournamentsListBox.Size = new System.Drawing.Size(414, 212);
            this.startedTournamentsListBox.TabIndex = 1;
            this.startedTournamentsListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.startedTournamentsListBox_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(225, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Resume by double clicking a tournament";
            // 
            // MeleeCPUTournament
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 268);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.startedTournamentsListBox);
            this.Controls.Add(this.button1);
            this.Name = "MeleeCPUTournament";
            this.Text = "Tester";
            this.Load += new System.EventHandler(this.MeleeCPUTournament_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox startedTournamentsListBox;
        private System.Windows.Forms.Label label1;
    }
}

