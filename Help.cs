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
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
            LoadInfo();
        }

        void LoadInfo()
        {
            Account acc = UIHelper.userNameFromLogin;
            lblDisplayName.Text = acc.DisPlayName.ToString();
            pnlHelp.BackColor = Color.FromArgb(255, 102, 196);
            if (acc.Type == 0)
            {
                lblTypeName.Text = "Nhân viên";
                lblAdmin.Enabled = false;
                pnlAdmin.Enabled = false;
                pnlAdmin.BackColor = Color.DarkGray;
            }
            {
                lblTypeName.Text = "Admin";
            }
        }

        private void ChangeForm_Click(object sender, EventArgs e)
        {
            List<Panel> panels = new List<Panel> { pnlHome, pnlAdmin, pnlUser, pnlOrder, pnlCheckOut, pnlHelp };

            UIHelper.ChangePanelColor(sender, panels, UIHelper.userNameFromLogin, this);
        }

        private void Help_Load(object sender, EventArgs e)
        {
            UIHelper.GlobalTimer.Tick += UpdateTimeLabel;
        }

        private void UpdateTimeLabel(object sender, EventArgs e)
        {
            lblTime.Text = UIHelper.CurrentTime;
        }

        private void Help_FormClosing(object sender, FormClosingEventArgs e)
        {
            UIHelper.GlobalTimer.Tick -= UpdateTimeLabel;
        }

        private void panel9_MouseDown(object sender, MouseEventArgs e)
        {
            UIHelper.MoveWindow(this, e);
        }

        private void label16_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label15_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
