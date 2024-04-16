namespace Supervisório_PCA_2023
{
    partial class SubFormGraficos
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
            this.tempPlot = new ScottPlot.FormsPlot();
            this.flowPlot = new ScottPlot.FormsPlot();
            this.SuspendLayout();
            // 
            // tempPlot
            // 
            this.tempPlot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tempPlot.Location = new System.Drawing.Point(438, 6);
            this.tempPlot.Margin = new System.Windows.Forms.Padding(14, 21, 14, 21);
            this.tempPlot.Name = "tempPlot";
            this.tempPlot.Size = new System.Drawing.Size(539, 385);
            this.tempPlot.TabIndex = 4;
            // 
            // flowPlot
            // 
            this.flowPlot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flowPlot.AutoSize = true;
            this.flowPlot.Location = new System.Drawing.Point(18, 6);
            this.flowPlot.Margin = new System.Windows.Forms.Padding(9, 13, 9, 13);
            this.flowPlot.Name = "flowPlot";
            this.flowPlot.Size = new System.Drawing.Size(412, 385);
            this.flowPlot.TabIndex = 3;
            // 
            // SubFormGraficos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1015, 394);
            this.Controls.Add(this.tempPlot);
            this.Controls.Add(this.flowPlot);
            this.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SubFormGraficos";
            this.Text = "SubFormGraficos";
            this.Load += new System.EventHandler(this.SubFormGraficos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ScottPlot.FormsPlot tempPlot;
        private ScottPlot.FormsPlot flowPlot;
    }
}