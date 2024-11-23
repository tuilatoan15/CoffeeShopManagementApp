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
    public partial class AccountForm : Form
    {
        BindingSource accountList = new BindingSource();
        public AccountForm()
        {
            InitializeComponent();
            LoadInfo();
        }

        void LoadInfo()
        {
            LoadListAccount();
            LoadTypeAccountIntoComboBox(cbLoaiTaiKhoan);
            dtgvAccount.DataSource = accountList;
            AddAccountBinding();
            pnlAdmin.BackColor = Color.FromArgb(255, 102, 196);

            Account acc = UIHelper.userNameFromLogin;
            lblDisplayName.Text = acc.DisPlayName;
            if (acc.Type == 0)
            {
                lblAdminName.Text = "Nhân viên";
                lblAdmin.Enabled = false;
                pnlAdmin.Enabled = false;
                pnlAdmin.BackColor = Color.DarkGray;
            }
            else
            {
                lblAdminName.Text = "Admin";
            }
            lblDisplayName.Text = acc.DisPlayName;
        }

        void LoadListAccount()
        {
            accountList.DataSource = AccountDAO.Instance.GetListAccount();
        }

        void LoadTypeAccountIntoComboBox(ComboBox cb)
        {
            cb.DataSource = AccountDAO.Instance.GetListAccountType();
            cb.DisplayMember = "Type";
        }

        void AddAccountBinding()
        {
            txbTenTaiKhoan.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            txbTenHienThi.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            txbMatKhau.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "Password", true, DataSourceUpdateMode.Never));
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Form admin = new Admin();
            admin.Show();
            this.Close();
        }

        private void lblHiden_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void pnlTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            UIHelper.MoveWindow(this, e);
        }

        private void ChangeForm_Click(object sender, EventArgs e)
        {
            List<Panel> panels = new List<Panel> { pnlHome, pnlAdmin, pnlUser, pnlOrder, pnlCheckOut, pnlHelp };

            UIHelper.ChangePanelColor(sender, panels, UIHelper.userNameFromLogin, this);
        }

        private void txbTenTaiKhoan_TextChanged(object sender, EventArgs e)
        {
            string userName = txbTenTaiKhoan.Text.Trim();

            Account account = AccountDAO.Instance.GetAccountByUserName(userName);
            if (account != null)
            {
                if (account.Type == 0)
                {
                    cbLoaiTaiKhoan.Text = "0";
                }
                else
                {
                    cbLoaiTaiKhoan.Text = "1";
                }
            }
            else
            {
                //MessageBox.Show("Tài khoản không tồn tại");
            }
        }

        private void txbFind_TextChanged(object sender, EventArgs e)
        {
            accountList.DataSource = SearchAccount(txbFind.Text);
        }

        List<Account> SearchAccount(string name)
        {
            List<Account> listAcccount = AccountDAO.Instance.SearchAccountByDisplayName(name);

            return listAcccount;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string userName = txbTenTaiKhoan.Text;
            string displayName = txbTenHienThi.Text;
            string password = txbMatKhau.Text;
            int type = (int)cbLoaiTaiKhoan.SelectedItem;

            AddAccount(userName, displayName, password, type);
        }

        void AddAccount(string userName, string displayName, string password, int type)
        {
            if (AccountDAO.Instance.CheckAccountExists(userName))
            {
                MessageBox.Show("Tên tài khoản đã tồn tại!");
                return;
            }

            if (AccountDAO.Instance.InsertAccount(userName, displayName, password, type))
            {
                MessageBox.Show("Thêm tài khoản thành công!");
            }
            else
            {
                MessageBox.Show("Thêm tài khỏan thất bại!");
            }
            LoadListAccount();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string userName = txbTenTaiKhoan.Text;
            string displayName = txbTenHienThi.Text;
            string password = txbMatKhau.Text;
            int type = (int)cbLoaiTaiKhoan.SelectedItem;

            EditAccount(userName, displayName, type);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string userName = txbTenTaiKhoan.Text;

            DeleteAccount(userName);
        }

        void DeleteAccount(string userName)
        {
            if (UIHelper.userNameFromLogin.UserName.Equals(userName))
            {
                MessageBox.Show("Không thể xóa tài khoản hiện đang đăng nhập!");

                return;
            }

            if (AccountDAO.Instance.DeleteAccount(userName))
            {
                MessageBox.Show("Xóa tài khoản thành công!");
            }
            else
            {
                MessageBox.Show("Xóa tài khỏan thất bại!");
            }
            LoadListAccount();
        }

        void EditAccount(string userName, string displayName, int type)
        {
            if (AccountDAO.Instance.UpdateAccount(userName, displayName, type))
            {
                MessageBox.Show("Cập nhật tài khoản thành công!");
            }
            else
            {
                MessageBox.Show("Cập nhật tài khỏan thất bại!");
            }
            LoadListAccount();
        }
    }
}
