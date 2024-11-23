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
    public partial class Stats : Form
    {
        public Stats()
        {
            InitializeComponent();         
            LoadDateTimePickerBill();
            LoadInfo();
        }

        void LoadInfo()
        {
            int page = 1;
            double sumRecord = BillDAO.Instance.GetNumBillListByDate(dtpkFromDate.Value, dtpkToDate.Value);
            int lastPage = (int)Math.Ceiling(sumRecord / 5.0);

            txbNumPage.Text = $"{page}/{lastPage}";

            dtgvStats.DataSource = BillDAO.Instance.GetBillListByDateAndPage(dtpkFromDate.Value, dtpkToDate.Value, page);

            pnlUser.BackColor = Color.FromArgb(255, 102, 196);
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


        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtpkFromDate.Value = new DateTime(today.Year, today.Month, 1);
            dtpkToDate.Value = dtpkFromDate.Value.AddMonths(1).AddDays(-1);

            dtpkFromDate.Format = DateTimePickerFormat.Custom;
            dtpkFromDate.CustomFormat = "dddd dd/MM/yyyy";
            dtpkToDate.Format = DateTimePickerFormat.Custom;
            dtpkToDate.CustomFormat = "dddd dd/MM/yyyy";
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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Form admin = new Admin();
            admin.Show();
            this.Close();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            int page;
            string[] pageParts = txbNumPage.Text.Split('/');

            if (pageParts.Length > 0 && int.TryParse(pageParts[0], out page))
            {
                dtgvStats.DataSource = BillDAO.Instance.GetBillListByDateAndPage(dtpkFromDate.Value, dtpkToDate.Value, page);
                dtgvStats.Refresh();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng trang (ví dụ: 1/5)", "Lỗi định dạng trang", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Stats_Load(object sender, EventArgs e)
        {
            UIHelper.GlobalTimer.Tick += UpdateTimeLabel;
        }

        private void UpdateTimeLabel(object sender, EventArgs e)
        {
            lblTime.Text = UIHelper.CurrentTime;
        }

        private void dtpkFromDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                double sumRecord = BillDAO.Instance.GetNumBillListByDate(dtpkFromDate.Value, dtpkToDate.Value);
                int lastPage = (int)Math.Ceiling(sumRecord / 5.0);

                int page = 1;
                string[] pageInfo = txbNumPage.Text.Split('/');
                if (pageInfo.Length == 2 && int.TryParse(pageInfo[0], out page))
                {
                    if (page > lastPage)
                    {
                        page = lastPage;
                    }

                    txbNumPage.Text = $"{page}/{lastPage}";

                    dtgvStats.DataSource = BillDAO.Instance.GetBillListByDateAndPage(dtpkFromDate.Value, dtpkToDate.Value, page);
                }

                if (dtpkFromDate.Value > dtpkToDate.Value)
                {
                    dtpkToDate.Value = dtpkFromDate.Value.AddDays(1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnTrangDau_Click(object sender, EventArgs e)
        {
            txbNumPage.Text = "1";
        }

        private void btnTrangTiep_Click(object sender, EventArgs e)
        {
            string[] pageParts = txbNumPage.Text.Split('/');
            int page = Convert.ToInt32(pageParts[0]);

            double sumRecord = BillDAO.Instance.GetNumBillListByDate(dtpkFromDate.Value, dtpkToDate.Value);

            if (page < Math.Ceiling(sumRecord / 5.0))
            {
                page++;
            }

            txbNumPage.Text = $"{page}/{Math.Ceiling(sumRecord / 5.0)}";

            dtgvStats.DataSource = BillDAO.Instance.GetBillListByDateAndPage(dtpkFromDate.Value, dtpkToDate.Value, page);
        }


        private void btnTrangTruoc_Click(object sender, EventArgs e)
        {
            string[] pageParts = txbNumPage.Text.Split('/');
            int page = Convert.ToInt32(pageParts[0]);

            if (page > 1)
            {
                page--;
            }

            txbNumPage.Text = $"{page}/{Math.Ceiling(BillDAO.Instance.GetNumBillListByDate(dtpkFromDate.Value, dtpkToDate.Value) / 5.0)}";

            dtgvStats.DataSource = BillDAO.Instance.GetBillListByDateAndPage(dtpkFromDate.Value, dtpkToDate.Value, page);
        }


        private void btnTrangCuoi_Click(object sender, EventArgs e)
        {
            double sumRecord = BillDAO.Instance.GetNumBillListByDate(dtpkFromDate.Value, dtpkToDate.Value);
            int lastPage = (int)Math.Ceiling(sumRecord / 5.0);

            txbNumPage.Text = $"{lastPage}/{lastPage}";

            dtgvStats.DataSource = BillDAO.Instance.GetBillListByDateAndPage(dtpkFromDate.Value, dtpkToDate.Value, lastPage);
        }


        private void txbNumPage_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Tạm thời ngừng sự kiện để tránh đệ quy
                txbNumPage.TextChanged -= txbNumPage_TextChanged;

                int page;
                string[] pageParts = txbNumPage.Text.Split('/');

                if (pageParts.Length > 0 && int.TryParse(pageParts[0], out page))
                {
                    double sumRecord = BillDAO.Instance.GetNumBillListByDate(dtpkFromDate.Value, dtpkToDate.Value);
                    int lastPage = (int)Math.Ceiling(sumRecord / 5.0);

                    if (page < 1)
                    {
                        page = 1;
                    }
                    else if (page > lastPage)
                    {
                        page = lastPage;
                    }

                    string newPageText = $"{page}/{lastPage}";
                    if (txbNumPage.Text != newPageText)
                    {
                        txbNumPage.Text = newPageText;
                    }

                    dtgvStats.DataSource = BillDAO.Instance.GetBillListByDateAndPage(dtpkFromDate.Value, dtpkToDate.Value, page);
                }
            }
            catch (Exception ex)
            {
                // Log the error message or display an alert to the user
                MessageBox.Show($"Lỗi: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Kích hoạt lại sự kiện
                txbNumPage.TextChanged += txbNumPage_TextChanged;
            }
        }


    }
}