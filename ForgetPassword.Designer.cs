namespace CoffeeShopManagement
{
    partial class ForgetPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForgetPassword));
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblDisplayName = new System.Windows.Forms.Label();
            this.txbUserName = new System.Windows.Forms.TextBox();
            this.txbDisplayName = new System.Windows.Forms.TextBox();
            this.btnCapLaiMatKhau = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblUserName
            // 
            this.lblUserName.Font = new System.Drawing.Font("Paytone One", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(12, 21);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(86, 19);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "User name: ";
            // 
            // lblDisplayName
            // 
            this.lblDisplayName.Font = new System.Drawing.Font("Paytone One", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplayName.Location = new System.Drawing.Point(12, 64);
            this.lblDisplayName.Name = "lblDisplayName";
            this.lblDisplayName.Size = new System.Drawing.Size(118, 19);
            this.lblDisplayName.TabIndex = 1;
            this.lblDisplayName.Text = "Display name:";
            // 
            // txbUserName
            // 
            this.txbUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbUserName.Location = new System.Drawing.Point(123, 23);
            this.txbUserName.Name = "txbUserName";
            this.txbUserName.Size = new System.Drawing.Size(160, 20);
            this.txbUserName.TabIndex = 2;
            // 
            // txbDisplayName
            // 
            this.txbDisplayName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbDisplayName.Location = new System.Drawing.Point(123, 66);
            this.txbDisplayName.Name = "txbDisplayName";
            this.txbDisplayName.Size = new System.Drawing.Size(160, 20);
            this.txbDisplayName.TabIndex = 3;
            // 
            // btnCapLaiMatKhau
            // 
            this.btnCapLaiMatKhau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCapLaiMatKhau.Font = new System.Drawing.Font("Paytone One", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapLaiMatKhau.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCapLaiMatKhau.Location = new System.Drawing.Point(72, 106);
            this.btnCapLaiMatKhau.Name = "btnCapLaiMatKhau";
            this.btnCapLaiMatKhau.Size = new System.Drawing.Size(147, 29);
            this.btnCapLaiMatKhau.TabIndex = 4;
            this.btnCapLaiMatKhau.Text = "Cấp lại mật khẩu";
            this.btnCapLaiMatKhau.UseVisualStyleBackColor = false;
            this.btnCapLaiMatKhau.Click += new System.EventHandler(this.btnCapLaiMatKhau_Click);
            // 
            // ForgetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 147);
            this.Controls.Add(this.btnCapLaiMatKhau);
            this.Controls.Add(this.txbDisplayName);
            this.Controls.Add(this.txbUserName);
            this.Controls.Add(this.lblDisplayName);
            this.Controls.Add(this.lblUserName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ForgetPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cấp lại mật khẩu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblDisplayName;
        private System.Windows.Forms.TextBox txbUserName;
        private System.Windows.Forms.TextBox txbDisplayName;
        private System.Windows.Forms.Button btnCapLaiMatKhau;
    }
}