namespace Supervisório_PCA_2._0
{
    partial class SubFormLimitsResPump
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
            this.txtLowerPump = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtLowerRes = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtUpperRes = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblUnitInterval = new System.Windows.Forms.Label();
            this.lblUpperPump = new System.Windows.Forms.Label();
            this.txtUpperPump = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtLowerPump
            // 
            this.txtLowerPump.AcceptsReturn = true;
            this.txtLowerPump.Location = new System.Drawing.Point(248, 48);
            this.txtLowerPump.MaxLength = 3;
            this.txtLowerPump.Name = "txtLowerPump";
            this.txtLowerPump.Size = new System.Drawing.Size(110, 29);
            this.txtLowerPump.TabIndex = 1;
            this.txtLowerPump.Text = "0";
            this.txtLowerPump.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            this.txtUpperPump.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUpperPump_KeyDown);

            this.txtLowerPump.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLowerPump_KeyDown);

            this.txtUpperRes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUpperRes_KeyDown);

            this.txtLowerRes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLowerRes_KeyDown);

            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(12, 56);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(182, 21);
            this.label21.TabIndex = 36;
            this.label21.Text = "Limite Inferior da Bomba";
            // 
            // txtLowerRes
            // 
            this.txtLowerRes.AcceptsReturn = true;
            this.txtLowerRes.Location = new System.Drawing.Point(248, 118);
            this.txtLowerRes.MaxLength = 5;
            this.txtLowerRes.Name = "txtLowerRes";
            this.txtLowerRes.Size = new System.Drawing.Size(110, 29);
            this.txtLowerRes.TabIndex = 3;
            this.txtLowerRes.Text = "0";
            this.txtLowerRes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 126);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(210, 21);
            this.label9.TabIndex = 34;
            this.label9.Text = "Limite Inferior da Resistência";
            // 
            // txtUpperRes
            // 
            this.txtUpperRes.AcceptsReturn = true;
            this.txtUpperRes.Location = new System.Drawing.Point(248, 83);
            this.txtUpperRes.MaxLength = 4;
            this.txtUpperRes.Name = "txtUpperRes";
            this.txtUpperRes.Size = new System.Drawing.Size(110, 29);
            this.txtUpperRes.TabIndex = 2;
            this.txtUpperRes.Text = "0";
            this.txtUpperRes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(219, 21);
            this.label7.TabIndex = 32;
            this.label7.Text = "Limite Superior da Resistência";
            // 
            // lblUnitInterval
            // 
            this.lblUnitInterval.AutoSize = true;
            this.lblUnitInterval.Location = new System.Drawing.Point(360, 17);
            this.lblUnitInterval.Name = "lblUnitInterval";
            this.lblUnitInterval.Size = new System.Drawing.Size(23, 21);
            this.lblUnitInterval.TabIndex = 25;
            this.lblUnitInterval.Text = "%";
            // 
            // lblUpperPump
            // 
            this.lblUpperPump.AutoSize = true;
            this.lblUpperPump.Location = new System.Drawing.Point(12, 21);
            this.lblUpperPump.Name = "lblUpperPump";
            this.lblUpperPump.Size = new System.Drawing.Size(191, 21);
            this.lblUpperPump.TabIndex = 28;
            this.lblUpperPump.Text = "Limite Superior da Bomba";
            // 
            // txtUpperPump
            // 
            this.txtUpperPump.AcceptsReturn = true;
            this.txtUpperPump.Location = new System.Drawing.Point(248, 13);
            this.txtUpperPump.MaxLength = 3;
            this.txtUpperPump.Name = "txtUpperPump";
            this.txtUpperPump.Size = new System.Drawing.Size(110, 29);
            this.txtUpperPump.TabIndex = 0;
            this.txtUpperPump.Text = "0";
            this.txtUpperPump.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtUpperPump.TextChanged += new System.EventHandler(this.txtUpperPump_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(360, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 21);
            this.label1.TabIndex = 38;
            this.label1.Text = "%";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(360, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 21);
            this.label2.TabIndex = 39;
            this.label2.Text = "%";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(360, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 21);
            this.label3.TabIndex = 40;
            this.label3.Text = "%";
            // 
            // SubFormLimitsResPump
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(414, 166);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUpperPump);
            this.Controls.Add(this.txtLowerPump);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.txtLowerRes);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtUpperRes);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblUnitInterval);
            this.Controls.Add(this.lblUpperPump);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SubFormLimitsResPump";
            this.Text = "Configurar Limites de Atuação da Bomba e da Resistência";
            this.Load += new System.EventHandler(this.SubFormLimitsResPump_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLowerPump;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtLowerRes;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtUpperRes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblUnitInterval;
        private System.Windows.Forms.Label lblUpperPump;
        private System.Windows.Forms.TextBox txtUpperPump;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}