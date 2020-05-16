namespace SensingMyself
{
    partial class Today
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
            this.summaryLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.minHeartRateLabel = new System.Windows.Forms.Label();
            this.minO2Label = new System.Windows.Forms.Label();
            this.maxHeartRateLabel = new System.Windows.Forms.Label();
            this.maxO2Label = new System.Windows.Forms.Label();
            this.recentlabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // summaryLabel
            // 
            this.summaryLabel.AutoSize = true;
            this.summaryLabel.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.summaryLabel.Location = new System.Drawing.Point(12, 9);
            this.summaryLabel.Name = "summaryLabel";
            this.summaryLabel.Size = new System.Drawing.Size(425, 23);
            this.summaryLabel.TabIndex = 0;
            this.summaryLabel.Text = "You have taken 0 readings for  01 Jan 2000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Heart rate";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(271, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Maximum";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(54, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Oxygen saturation";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(426, 135);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 5;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // minHeartRateLabel
            // 
            this.minHeartRateLabel.AutoSize = true;
            this.minHeartRateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minHeartRateLabel.Location = new System.Drawing.Point(175, 92);
            this.minHeartRateLabel.Name = "minHeartRateLabel";
            this.minHeartRateLabel.Size = new System.Drawing.Size(58, 16);
            this.minHeartRateLabel.TabIndex = 6;
            this.minHeartRateLabel.Text = "60 bpm";
            // 
            // minO2Label
            // 
            this.minO2Label.AutoSize = true;
            this.minO2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minO2Label.Location = new System.Drawing.Point(175, 114);
            this.minO2Label.Name = "minO2Label";
            this.minO2Label.Size = new System.Drawing.Size(57, 16);
            this.minO2Label.TabIndex = 7;
            this.minO2Label.Text = "95.00%";
            // 
            // maxHeartRateLabel
            // 
            this.maxHeartRateLabel.AutoSize = true;
            this.maxHeartRateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxHeartRateLabel.Location = new System.Drawing.Point(271, 92);
            this.maxHeartRateLabel.Name = "maxHeartRateLabel";
            this.maxHeartRateLabel.Size = new System.Drawing.Size(58, 16);
            this.maxHeartRateLabel.TabIndex = 8;
            this.maxHeartRateLabel.Text = "80 bpm";
            // 
            // maxO2Label
            // 
            this.maxO2Label.AutoSize = true;
            this.maxO2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxO2Label.Location = new System.Drawing.Point(271, 114);
            this.maxO2Label.Name = "maxO2Label";
            this.maxO2Label.Size = new System.Drawing.Size(57, 16);
            this.maxO2Label.TabIndex = 9;
            this.maxO2Label.Text = "99.00%";
            // 
            // recentlabel
            // 
            this.recentlabel.AutoSize = true;
            this.recentlabel.Location = new System.Drawing.Point(54, 32);
            this.recentlabel.Name = "recentlabel";
            this.recentlabel.Size = new System.Drawing.Size(219, 13);
            this.recentlabel.TabIndex = 10;
            this.recentlabel.Text = "Your most recent reading was taken at 12:00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(175, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Minimum";
            // 
            // Today
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 170);
            this.Controls.Add(this.recentlabel);
            this.Controls.Add(this.maxO2Label);
            this.Controls.Add(this.maxHeartRateLabel);
            this.Controls.Add(this.minO2Label);
            this.Controls.Add(this.minHeartRateLabel);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.summaryLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Today";
            this.Text = "Today\'s readings";
            this.Load += new System.EventHandler(this.Today_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label summaryLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label minHeartRateLabel;
        private System.Windows.Forms.Label minO2Label;
        private System.Windows.Forms.Label maxHeartRateLabel;
        private System.Windows.Forms.Label maxO2Label;
        private System.Windows.Forms.Label recentlabel;
        private System.Windows.Forms.Label label6;
    }
}

