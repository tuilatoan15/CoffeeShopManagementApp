using CoffeeShopManagement.DAO;
using CoffeeShopManagement.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Menu = CoffeeShopManagement.DTO.Menu;

namespace CoffeeShopManagement
{
    public partial class CheckOutAndPrintBill : Form
    {
        public CheckOutAndPrintBill()
        {
            InitializeComponent();
            LoadInfo();
            ShowBillCheckOut();
        }

        void LoadInfo()
        {
            pnlCheckOut.BackColor = Color.FromArgb(255, 102, 196);
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

        void ShowBillCheckOut()
        {
            lsvBill.Items.Clear();
            float totalPrice = 0;
            List<Menu> listBillInfo = MenuDAO.Instance.GetListMenuByTable(UIHelper.tableIDCheckOut);
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

        private void ChangeForm_Click(object sender, EventArgs e)
        {
            List<Panel> panels = new List<Panel> { pnlHome, pnlAdmin, pnlUser, pnlOrder, pnlCheckOut, pnlHelp };

            UIHelper.ChangePanelColor(sender, panels, UIHelper.userNameFromLogin, this);
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            TableFood table = TableDAO.Instance.GetTableByID(UIHelper.tableIDCheckOut);

            if (lblTotalPrice.Text == "0,00 ₫")
                return;

            if (table == null)
                return;

            int iddBill = BillDAO.Instance.GetUnCheckBillIDByTableID(table.ID);
            int discount = (int)nmGiamGia.Value;
            string priceText = lblTotalPrice.Text;
            string cleanedText = priceText.Replace(" ₫", "").Replace(".", "").Replace(",", ".");
            double totalPrice = Convert.ToDouble(cleanedText);
            double discountPrice = totalPrice * discount / 100;
            bool boolDiscount = (discount != 0) ? true : false;
            double finalTotalPrice = (totalPrice - discountPrice);

            if (iddBill != -1)
            {
                if (boolDiscount)
                {
                    if (MessageBox.Show(string.Format("Bạn có chắc thanh toán hóa đơn cho bàn: " + table.Name + "\nTổng tiền cần trả: {0} - {1} = {2}", totalPrice, discountPrice, finalTotalPrice + ",00 đ"),
                                    "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        BillDAO.Instance.CheckOut(iddBill, discount, (float)finalTotalPrice);
                        ShowBillCheckOut();
                        Form f = new CheckOut();
                        f.Show();
                        this.Close();
                    }
                }
                else if (MessageBox.Show(string.Format("Bạn có chắc thanh toán hóa đơn cho bàn: " + table.Name + "\nTổng tiền cần trả: {0}", totalPrice + ",00 đ"),
                                    "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    BillDAO.Instance.CheckOut(iddBill, discount, (float)finalTotalPrice);
                    ShowBillCheckOut();
                    Form f = new CheckOut();
                    f.Show();
                    this.Close();
                }
                nmGiamGia.Value = 0;
            }
        }

        private void CheckOutAndPrintBill_Load(object sender, EventArgs e)
        {
            UIHelper.GlobalTimer.Tick += UpdateTimeLabel;
        }

        private void UpdateTimeLabel(object sender, EventArgs e)
        {
            lblTime.Text = UIHelper.CurrentTime;
        }
    }
}
