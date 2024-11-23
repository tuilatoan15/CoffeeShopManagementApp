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
    public partial class Table : Form
    {
        BindingSource tableList = new BindingSource();
        public Table()
        {
            InitializeComponent();
            LoadInfo();
        }

        void LoadInfo()
        {
            loadListTable();
            dtgvTable.DataSource = tableList;
            AddTableBinding();
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

        void loadListTable()
        {
            tableList.DataSource = TableDAO.Instance.LoadTableList();
        }

        void AddTableBinding()
        {
            txbID.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txbTenBan.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "Name", true, DataSourceUpdateMode.Never));
            cbTrangThai.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "Status", true, DataSourceUpdateMode.Never));
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

        private event EventHandler insertTable;
        public event EventHandler InsertTable
        {
            add { insertTable += value; }
            remove { insertTable -= value; }
        }

        private event EventHandler deleteTable;
        public event EventHandler DeleteTable
        {
            add { deleteTable += value; }
            remove { deleteTable -= value; }
        }

        private event EventHandler updateTable;
        public event EventHandler UpdateTable
        {
            add { updateTable += value; }
            remove { updateTable -= value; }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string name = txbTenBan.Text;
            string status = "Trống";

            if (TableDAO.Instance.InsertTable(name, status))
            {
                MessageBox.Show("Thêm bàn thành công!");
                loadListTable();
                if (insertTable != null)
                {
                    insertTable(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm bàn!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string name = txbTenBan.Text;
            int idTable = Convert.ToInt32(txbID.Text);

            if (TableDAO.Instance.UpdateTable(name, idTable))
            {
                MessageBox.Show("Sửa bàn thành công!");
                loadListTable();
                if (updateTable != null)
                {
                    updateTable(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa bàn!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int idTable = Convert.ToInt32(txbID.Text);

            if (TableDAO.Instance.DeleteTable(idTable))
            {
                MessageBox.Show("Xóa bàn thành công!");
                loadListTable();
                //LoadListBillByDate(dtpkFromDate.Value, dtpkToDate.Value);
                if (deleteTable != null)
                {
                    deleteTable(this, new EventArgs());
                }
            }
            else
            {
                //MessageBox.Show("Có lỗi khi xóa bàn!");
            }
        }
    }
}
