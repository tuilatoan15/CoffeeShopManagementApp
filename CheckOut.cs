using CoffeeShopManagement.DAO;
using CoffeeShopManagement.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Menu = CoffeeShopManagement.DTO.Menu;

namespace CoffeeShopManagement
{
    public partial class CheckOut : Form
    {
        public CheckOut()
        {
            InitializeComponent();
            LoadInfo();
            LoadTable();
        }

        void LoadTable()
        {
            flpTable.Controls.Clear();
            List<TableFood> tableList = TableDAO.Instance.LoadTableList();

            foreach (TableFood item in tableList)
            {
                Button btn = new Button() { Width = TableDAO.tableWidth, Height = TableDAO.tableHeight };

                btn.Text = item.Name + Environment.NewLine + item.Status;

                btn.Click += Btn_Click;
                btn.Tag = item;

                if (item.Status == "Trống")
                {
                    btn.BackColor = Color.FromArgb(195, 202, 209);
                }
                else
                {
                    btn.BackColor = Color.FromArgb(232, 145, 157);
                }

                btn.Font = new Font("Paytone One", 10, FontStyle.Regular);
                flpTable.Controls.Add(btn);
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            TableFood selectedTable = clickedButton.Tag as TableFood;
            if (clickedButton.Text.Contains("Có khách"))
            {
                
                if (selectedTable != null)
                {
                    int tableID = selectedTable.ID;
                    lsvBill.Tag = selectedTable;

                    ShowBill(tableID);
                }
            }
            else
            {
                ShowBill(selectedTable.ID);
            }
        }

        void ShowBill(int id)
        {
            lsvBill.Items.Clear();
            float totalPrice = 0;
            List<Menu> listBillInfo = MenuDAO.Instance.GetListMenuByTable(id);
            foreach (Menu item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.FoodName.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.TotalPrice.ToString());

                totalPrice += item.TotalPrice;

                lsvBill.Items.Add(lsvItem);

            }
            CultureInfo culture = new CultureInfo("vi-VN");

            lblTotalPrice.Text = totalPrice.ToString("c", culture);
        }

        void LoadInfo()
        {
            Account acc = UIHelper.userNameFromLogin;
            lblDisplayName.Text = acc.DisPlayName.ToString();
            pnlCheckOut.BackColor = Color.FromArgb(255, 102, 196);
            if (acc.Type == 0)
            {
                lblTypeName.Text = "Nhân viên";
                lblAdmin.Enabled = false;
                pnlAdmin.Enabled = false;
                pnlAdmin.BackColor = Color.DarkGray;
            }
            else
            {
                lblTypeName.Text = "Admin";
            }
        }

        private void ChangeForm_Click(object sender, EventArgs e)
        {
            List<Panel> panels = new List<Panel> { pnlHome, pnlAdmin, pnlUser, pnlOrder, pnlCheckOut, pnlHelp };

            UIHelper.ChangePanelColor(sender, panels, UIHelper.userNameFromLogin, this);
        }

        private void CheckOut_Load(object sender, EventArgs e)
        {
            UIHelper.GlobalTimer.Tick += UpdateTimeLabel;
        }

        private void UpdateTimeLabel(object sender, EventArgs e)
        {
            lblTime.Text = UIHelper.CurrentTime;
        }

        private void CheckOut_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            TableFood table = lsvBill.Tag as TableFood;

            if (table == null)
            {
                MessageBox.Show("Vui lòng chọn bàn có khách để thanh toán.", "Thông báo");
                return;
            }
            UIHelper.tableIDCheckOut = table.ID;
            CheckOutAndPrintBill f = new CheckOutAndPrintBill();
            f.Show();
            this.Close();
        }
    }
}
