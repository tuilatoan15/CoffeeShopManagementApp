﻿using CoffeeShopManagement.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoffeeShopManagement.DAO;

namespace CoffeeShopManagement
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            LoadInfo();
        }

        void LoadInfo()
        {
            Account acc = UIHelper.userNameFromLogin;
            pnlHome.BackColor = Color.FromArgb(255, 102, 196);
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

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            UIHelper.MoveWindow(this, e);
        }

        private void Form02_Load(object sender, EventArgs e)
        {
            lblNumOfNhanVien.Text = AccountDAO.Instance.GetAccountCount().ToString();
            lblNumOfBan.Text = TableDAO.Instance.GetTableCount().ToString();
            lblNumOfThucUong.Text = FoodDAO.Instance.GetFoodCount().ToString();
            lblNumOfPhanLoai.Text = CategoryDAO.Instance.GetCategoryCount().ToString();
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

        private void lblLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();

            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void lblAcountInfo_Click(object sender, EventArgs e)
        {
            Account_Information f = new Account_Information(UIHelper.userNameFromLogin);
            f.ShowDialog();
        }

        private void ChangeForm_Click(object sender, EventArgs e)
        {
            List<Panel> panels = new List<Panel> { pnlHome, pnlAdmin, pnlUser, pnlOrder, pnlCheckOut, pnlHelp };

            UIHelper.ChangePanelColor(sender, panels, UIHelper.userNameFromLogin, this);
        }
    }
}