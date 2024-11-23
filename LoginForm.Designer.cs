using System.Windows.Forms;

namespace CoffeeShopManagement
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.lblQuanCaPheLeVanViet = new System.Windows.Forms.Label();
            this.pbBacground = new System.Windows.Forms.PictureBox();
            this.lblLogin = new System.Windows.Forms.Label();
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.txbPassword = new System.Windows.Forms.TextBox();
            this.txbUserName = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.lblExit = new System.Windows.Forms.Label();
            this.lblHiden = new System.Windows.Forms.Label();
            this.lblFogetPassword = new System.Windows.Forms.Label();
            this.lblSDT = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblOpen = new System.Windows.Forms.Label();
            this.lblGreeting = new System.Windows.Forms.Label();
            this.pbHeart = new System.Windows.Forms.PictureBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbBacground)).BeginInit();
            this.pnlLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHeart)).BeginInit();
            this.SuspendLayout();
            // 
            // lblQuanCaPheLeVanViet
            // 
            this.lblQuanCaPheLeVanViet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(27)))), ((int)(((byte)(25)))));
            this.lblQuanCaPheLeVanViet.Font = new System.Drawing.Font("Paytone One", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuanCaPheLeVanViet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(222)))), ((int)(((byte)(89)))));
            this.lblQuanCaPheLeVanViet.Location = new System.Drawing.Point(236, 9);
            this.lblQuanCaPheLeVanViet.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblQuanCaPheLeVanViet.Name = "lblQuanCaPheLeVanViet";
            this.lblQuanCaPheLeVanViet.Size = new System.Drawing.Size(261, 113);
            this.lblQuanCaPheLeVanViet.TabIndex = 3;
            this.lblQuanCaPheLeVanViet.Text = "Quán Cà Phê Lê Văn Việt";
            this.lblQuanCaPheLeVanViet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbBacground
            // 
            this.pbBacground.Image = ((System.Drawing.Image)(resources.GetObject("pbBacground.Image")));
            this.pbBacground.Location = new System.Drawing.Point(-4, 0);
            this.pbBacground.Margin = new System.Windows.Forms.Padding(2);
            this.pbBacground.Name = "pbBacground";
            this.pbBacground.Size = new System.Drawing.Size(593, 643);
            this.pbBacground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBacground.TabIndex = 0;
            this.pbBacground.TabStop = false;
            // 
            // lblLogin
            // 
            this.lblLogin.Font = new System.Drawing.Font("Paytone One", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(222)))), ((int)(((byte)(89)))));
            this.lblLogin.Location = new System.Drawing.Point(147, 184);
            this.lblLogin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(307, 71);
            this.lblLogin.TabIndex = 2;
            this.lblLogin.Text = "Đăng nhập";
            this.lblLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlLogin
            // 
            this.pnlLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(38)))), ((int)(((byte)(37)))));
            this.pnlLogin.Controls.Add(this.lblPassword);
            this.pnlLogin.Controls.Add(this.lblUserName);
            this.pnlLogin.Controls.Add(this.txbPassword);
            this.pnlLogin.Controls.Add(this.txbUserName);
            this.pnlLogin.Controls.Add(this.btnLogin);
            this.pnlLogin.Controls.Add(this.pbLogo);
            this.pnlLogin.Controls.Add(this.lblExit);
            this.pnlLogin.Controls.Add(this.lblHiden);
            this.pnlLogin.Controls.Add(this.lblFogetPassword);
            this.pnlLogin.Controls.Add(this.lblLogin);
            this.pnlLogin.Location = new System.Drawing.Point(582, 0);
            this.pnlLogin.Margin = new System.Windows.Forms.Padding(2);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(594, 643);
            this.pnlLogin.TabIndex = 1;
            // 
            // txbPassword
            // 
            this.txbPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.txbPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbPassword.Font = new System.Drawing.Font("Paytone One", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPassword.ForeColor = System.Drawing.Color.Yellow;
            this.txbPassword.Location = new System.Drawing.Point(157, 367);
            this.txbPassword.Multiline = true;
            this.txbPassword.Name = "txbPassword";
            this.txbPassword.PasswordChar = '*';
            this.txbPassword.Size = new System.Drawing.Size(314, 40);
            this.txbPassword.TabIndex = 25;
            this.txbPassword.Text = "2024";
            // 
            // txbUserName
            // 
            this.txbUserName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.txbUserName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbUserName.Font = new System.Drawing.Font("Paytone One", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbUserName.ForeColor = System.Drawing.Color.Yellow;
            this.txbUserName.Location = new System.Drawing.Point(157, 310);
            this.txbUserName.Multiline = true;
            this.txbUserName.Name = "txbUserName";
            this.txbUserName.Size = new System.Drawing.Size(314, 40);
            this.txbUserName.TabIndex = 24;
            this.txbUserName.Text = "admin1";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(222)))), ((int)(((byte)(89)))));
            this.btnLogin.Font = new System.Drawing.Font("Paytone One", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(107)))), ((int)(((byte)(191)))));
            this.btnLogin.Location = new System.Drawing.Point(217, 570);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(165, 42);
            this.btnLogin.TabIndex = 21;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // pbLogo
            // 
            this.pbLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(40)))), ((int)(((byte)(38)))));
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(217, 31);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(154, 140);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 20;
            this.pbLogo.TabStop = false;
            // 
            // lblExit
            // 
            this.lblExit.Font = new System.Drawing.Font("Paytone One", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExit.ForeColor = System.Drawing.Color.White;
            this.lblExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblExit.Location = new System.Drawing.Point(553, -14);
            this.lblExit.Name = "lblExit";
            this.lblExit.Size = new System.Drawing.Size(31, 48);
            this.lblExit.TabIndex = 15;
            this.lblExit.Text = "x";
            this.lblExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblExit.Click += new System.EventHandler(this.lblExit_Click);
            // 
            // lblHiden
            // 
            this.lblHiden.Font = new System.Drawing.Font("Paytone One", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHiden.ForeColor = System.Drawing.Color.White;
            this.lblHiden.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHiden.Location = new System.Drawing.Point(505, -10);
            this.lblHiden.Name = "lblHiden";
            this.lblHiden.Size = new System.Drawing.Size(42, 39);
            this.lblHiden.TabIndex = 14;
            this.lblHiden.Text = "—";
            this.lblHiden.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblHiden.Click += new System.EventHandler(this.lblHiden_Click);
            // 
            // lblFogetPassword
            // 
            this.lblFogetPassword.AutoSize = true;
            this.lblFogetPassword.Font = new System.Drawing.Font("Paytone One", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblFogetPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(113)))), ((int)(((byte)(255)))));
            this.lblFogetPassword.Location = new System.Drawing.Point(326, 422);
            this.lblFogetPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFogetPassword.Name = "lblFogetPassword";
            this.lblFogetPassword.Size = new System.Drawing.Size(145, 26);
            this.lblFogetPassword.TabIndex = 4;
            this.lblFogetPassword.Text = "Quên mật khẩu?";
            this.lblFogetPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFogetPassword.Click += new System.EventHandler(this.lblFogetPassword_Click);
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(27)))), ((int)(((byte)(25)))));
            this.lblSDT.Font = new System.Drawing.Font("Paytone One", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblSDT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.lblSDT.Location = new System.Drawing.Point(288, 122);
            this.lblSDT.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(144, 26);
            this.lblSDT.TabIndex = 4;
            this.lblSDT.Text = "SDT: 0867 654 123";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(27)))), ((int)(((byte)(25)))));
            this.lblAddress.Font = new System.Drawing.Font("Paytone One", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(190)))), ((int)(((byte)(194)))));
            this.lblAddress.Location = new System.Drawing.Point(222, 153);
            this.lblAddress.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(326, 26);
            this.lblAddress.TabIndex = 5;
            this.lblAddress.Text = "Địa chỉ: 69 Lê Văn Việt, Thủ Đức, Tp.HCM";
            this.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOpen
            // 
            this.lblOpen.AutoSize = true;
            this.lblOpen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(27)))), ((int)(((byte)(25)))));
            this.lblOpen.Font = new System.Drawing.Font("Paytone One", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblOpen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(102)))), ((int)(((byte)(196)))));
            this.lblOpen.Location = new System.Drawing.Point(257, 255);
            this.lblOpen.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOpen.Name = "lblOpen";
            this.lblOpen.Size = new System.Drawing.Size(291, 78);
            this.lblOpen.TabIndex = 6;
            this.lblOpen.Text = "Mở cửa: Thứ 2 - Thứ 7\r\nTừ 5h30 Sáng - 22h Đêm";
            this.lblOpen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGreeting
            // 
            this.lblGreeting.AutoSize = true;
            this.lblGreeting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(33)))), ((int)(((byte)(31)))));
            this.lblGreeting.Font = new System.Drawing.Font("Paytone One", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblGreeting.ForeColor = System.Drawing.Color.Lime;
            this.lblGreeting.Location = new System.Drawing.Point(221, 354);
            this.lblGreeting.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGreeting.Name = "lblGreeting";
            this.lblGreeting.Size = new System.Drawing.Size(357, 31);
            this.lblGreeting.TabIndex = 7;
            this.lblGreeting.Text = "Hân hạnh phục vụ quý khách hàng!";
            // 
            // pbHeart
            // 
            this.pbHeart.Image = ((System.Drawing.Image)(resources.GetObject("pbHeart.Image")));
            this.pbHeart.Location = new System.Drawing.Point(386, 388);
            this.pbHeart.Name = "pbHeart";
            this.pbHeart.Size = new System.Drawing.Size(72, 62);
            this.pbHeart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbHeart.TabIndex = 8;
            this.pbHeart.TabStop = false;
            // 
            // lblUserName
            // 
            this.lblUserName.Font = new System.Drawing.Font("Paytone One", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.Color.Yellow;
            this.lblUserName.Location = new System.Drawing.Point(22, 306);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(129, 40);
            this.lblUserName.TabIndex = 26;
            this.lblUserName.Text = "User Name : ";
            // 
            // lblPassword
            // 
            this.lblPassword.Font = new System.Drawing.Font("Paytone One", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.Color.Yellow;
            this.lblPassword.Location = new System.Drawing.Point(22, 367);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(129, 40);
            this.lblPassword.TabIndex = 27;
            this.lblPassword.Text = "Password :";
            // 
            // Form01
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 639);
            this.Controls.Add(this.pbHeart);
            this.Controls.Add(this.lblGreeting);
            this.Controls.Add(this.lblOpen);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblSDT);
            this.Controls.Add(this.lblQuanCaPheLeVanViet);
            this.Controls.Add(this.pnlLogin);
            this.Controls.Add(this.pbBacground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form01";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pbBacground)).EndInit();
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHeart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblQuanCaPheLeVanViet;
        private System.Windows.Forms.PictureBox pbBacground;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblOpen;
        private System.Windows.Forms.Label lblGreeting;
        private System.Windows.Forms.Label lblFogetPassword;
        private System.Windows.Forms.Label lblExit;
        private System.Windows.Forms.Label lblHiden;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.PictureBox pbHeart;
        private TextBox txbUserName;
        private TextBox txbPassword;
        private Label lblPassword;
        private Label lblUserName;
    }
}