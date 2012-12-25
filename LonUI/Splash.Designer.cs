namespace Lon.UI
{
    partial class Splash
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
            this.lblMess = new System.Windows.Forms.Label();
            this.lblProgName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMess
            // 
            this.lblMess.AutoSize = true;
            this.lblMess.ForeColor = System.Drawing.Color.Gold;
            this.lblMess.Location = new System.Drawing.Point(72, 249);
            this.lblMess.Name = "lblMess";
            this.lblMess.Size = new System.Drawing.Size(41, 12);
            this.lblMess.TabIndex = 0;
            this.lblMess.Text = "label1";
            // 
            // lblProgName
            // 
            this.lblProgName.AutoSize = true;
            this.lblProgName.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblProgName.ForeColor = System.Drawing.Color.Gold;
            this.lblProgName.Location = new System.Drawing.Point(70, 35);
            this.lblProgName.Name = "lblProgName";
            this.lblProgName.Size = new System.Drawing.Size(111, 33);
            this.lblProgName.TabIndex = 1;
            this.lblProgName.Text = "label2";
            // 
            // Splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(552, 315);
            this.Controls.Add(this.lblProgName);
            this.Controls.Add(this.lblMess);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Splash";
            this.Text = "Splash";
            this.Load += new System.EventHandler(this.Splash_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMess;
        private System.Windows.Forms.Label lblProgName;
    }
}