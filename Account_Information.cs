using CoffeeShopManagement.DAO;
using CoffeeShopManagement.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShopManagement
{
    public partial class Account_Information : Form
    {
        public static Account userName;
        public string SelectedImagePath { get; private set; }
        public Account_Information(Account userNameLogin)
        {
            InitializeComponent();
            userName = userNameLogin;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            UpdateAccount();
        }

        void UpdateAccount()
        {
            string displayName = txbDisplayName.Text;
            string password = txbPassword.Text;
            string newpass = txbNewPassword.Text;
            string reenterPass = txbRePassword.Text;
            string userName = txbUserName.Text;

            if (!newpass.Equals(reenterPass))
            {
                MessageBox.Show("Mật khẩu mới không trùng khớp!");
            }
            else
            {
                if (password == reenterPass && password == newpass && password != "")
                {
                    MessageBox.Show("Mật khẩu mới trùng với mật khẩu cũ!");
                    return;
                }
                bool result = AccountDAO.Instance.UpdateAccount(userName, displayName, password, newpass);
                if (result)
                {
                    MessageBox.Show("Cập nhật thành công!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Vui lòng điền đúng mật khẩu!");
                }
            }
        }

        private void Account_Information_Load(object sender, EventArgs e)
        {
            Account acc = UIHelper.userNameFromLogin;
            txbUserName.Text = acc.UserName;
            txbDisplayName.Text = acc.DisPlayName;            
        }

        private void btnChangeAvatar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    SelectedImagePath = openFileDialog.FileName;
                    pictureBox1.Image = Image.FromFile(SelectedImagePath);
                }
            }
        }
    }
}
