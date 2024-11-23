using CoffeeShopManagement.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CoffeeShopManagement
{
    public partial class ForgetPassword : Form
    {
        public ForgetPassword()
        {
            InitializeComponent();
        }

        private void btnCapLaiMatKhau_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string displayName = txbDisplayName.Text;

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(displayName))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            if (AccountDAO.Instance.ResetPassword(userName, displayName))
            {
                MessageBox.Show("Cấp lại mật khẩu thành công!\nMật khẩu mới là: 2024", "Thông báo");
                this.Close();
            }
            else
            {
                MessageBox.Show("Cấp lại mật khẩu thất bại!\nDo sai tên đăng nhập hoặc tên hiển thị!", "Thông báo");
                this.Close();
            }
        }
    }
}
