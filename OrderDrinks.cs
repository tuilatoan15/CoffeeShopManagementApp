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
    public partial class OrderDrinks : Form
    {
        public List<Food> dinrksList;
        public OrderDrinks()
        {
            InitializeComponent();
            LoadInfo();
        }

        void LoadInfo()
        {
            lblTenBanDatMon.Text = TableDAO.Instance.GetTableByID(UIHelper.tableIDDatMon).Name;
            ShowBill();
            LoadDrinks();
            pnlOrder.BackColor = Color.FromArgb(255, 102, 196);
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
        }

        void LoadDrinks()
        {
            dtgvDrinks.DataSource = FoodDAO.Instance.GetListFood();
        }

        private void ChangeForm_Click(object sender, EventArgs e)
        {
            List<Panel> panels = new List<Panel> { pnlHome, pnlAdmin, pnlUser, pnlOrder, pnlCheckOut, pnlHelp };

            UIHelper.ChangePanelColor(sender, panels, UIHelper.userNameFromLogin, this);
        }

        private void txbSearch_TextChanged(object sender, EventArgs e)
        {
            dtgvDrinks.DataSource = SearchDrinksByName(txbSearch.Text);
        }

        List<Food> SearchDrinksByName(string name)
        {
            List<Food> listFood = FoodDAO.Instance.SearchFoodByName(name);

            return listFood;
        }

        private void dtgvDatMon_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            TinhTongTien();
        }

        private void dtgvDatMon_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            TinhTongTien();
        }

        private void dtgvDatMon_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            TinhTongTien();
        }


        private void TinhTongTien()
        {
            decimal tongTien = 0;

            foreach (DataGridViewRow row in dtgvDatMon.Rows)
            {
                if (row.Cells["ThanhTien"].Value != null) 
                {
                    tongTien += Convert.ToDecimal(row.Cells["ThanhTien"].Value);
                }
            }
            CultureInfo culture = new CultureInfo("vi-VN");

            lblTongTienVND.Text = tongTien.ToString("c", culture);
        }

        void ShowBill()
        {
            dtgvDatMon.Rows.Clear();
            float totalPrice = 0;

            List<Menu> listBillInfo = MenuDAO.Instance.GetListMenuByTable(UIHelper.tableIDDatMon);

            foreach (Menu item in listBillInfo)
            {
                int rowIndex = dtgvDatMon.Rows.Add();

                DataGridViewRow row = dtgvDatMon.Rows[rowIndex];

                row.Cells["TenMon"].Value = item.FoodName;
                row.Cells["SoLuong"].Value = item.Count;
                row.Cells["DonGia"].Value = item.Price;
                row.Cells["ThanhTien"].Value = item.TotalPrice;

                totalPrice += item.TotalPrice;
            }

            CultureInfo culture = new CultureInfo("vi-VN");
            lblTongTienVND.Text = totalPrice.ToString("c", culture);
        }


        private void btnDatMon_Click(object sender, EventArgs e)
        {
            Form f = new Order();
            f.Show();
            this.Close();
        }

        private void OrderDrinks_Load(object sender, EventArgs e)
        {
            UIHelper.GlobalTimer.Tick += UpdateTimeLabel;
        }

        private void UpdateTimeLabel(object sender, EventArgs e)
        {
            lblTime.Text = UIHelper.CurrentTime;
        }

        private void dtgvDrinks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string tenMon = dtgvDrinks.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                decimal donGia = Convert.ToDecimal(dtgvDrinks.Rows[e.RowIndex].Cells["Price"].Value);

                bool isExists = false;

                foreach (DataGridViewRow row in dtgvDatMon.Rows)
                {
                    if (row.Cells["TenMon"].Value.ToString() == tenMon)
                    {
                        int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);
                        soLuong++;
                        row.Cells["SoLuong"].Value = soLuong;
                        row.Cells["ThanhTien"].Value = soLuong * donGia;
                        isExists = true;
                        break;
                    }
                }

                if (!isExists)
                {
                    int soLuong = 1;
                    dtgvDatMon.Rows.Add(tenMon, soLuong, donGia, soLuong * donGia);
                }
            }

            TableFood table = TableDAO.Instance.GetTableByID(UIHelper.tableIDDatMon);
            string foodName = dtgvDrinks.Rows[e.RowIndex].Cells["Name"].Value.ToString();

            int idBill = BillDAO.Instance.GetUnCheckBillIDByTableID(table.ID);
            int foodID = FoodDAO.Instance.GetFoodByName(foodName).ID;
            int count = 0;

            foreach (DataGridViewRow row in dtgvDatMon.Rows)
            {
                if (row.Cells["TenMon"].Value.ToString() == foodName)
                {
                    count = Convert.ToInt32(row.Cells["SoLuong"].Value);
                    break;
                }
            }

            bool foodExistsInBill = BillInfoDAO.Instance.IsFoodExistsInBill(idBill, foodID);

            if (foodExistsInBill)
            {
                BillInfoDAO.Instance.UpdateFoodCountInBill(idBill, foodID, count);
            }
            else
            {
                if (idBill == -1)
                {
                    BillDAO.Instance.InsertBill(table.ID);
                    BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(), foodID, count);
                }
                else
                {
                    BillInfoDAO.Instance.InsertBillInfo(idBill, foodID, count);
                }
            }
        }
    }
}
