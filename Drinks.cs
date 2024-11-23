using CoffeeShopManagement.DAO;
using CoffeeShopManagement.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CoffeeShopManagement
{
    public partial class Drinks : Form
    {
        BindingSource foodList = new BindingSource();
        public Drinks()
        {
            InitializeComponent();
            LoadInfo();
        }

        void LoadInfo()
        {
            LoadListDrinks();
            LoadCategoryIntoCombobox(cbDanhMuc);
            dtgvDrinks.DataSource = foodList;
            AddDrinksBinding();
            pnlAdmin.BackColor = Color.FromArgb(255, 102, 196);
            Account acc = UIHelper.userNameFromLogin;

            lblDisplayName.Text = acc.DisPlayName;
        }

        void LoadListDrinks()
        {
            foodList.DataSource = FoodDAO.Instance.GetListFood();
        }

        void LoadCategoryIntoCombobox(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "Name";
        }

        private void lblHiden_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        void AddDrinksBinding()
        {
            txbID.DataBindings.Add(new Binding("Text", dtgvDrinks.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txbTenMon.DataBindings.Add(new Binding("Text", dtgvDrinks.DataSource, "Name", true, DataSourceUpdateMode.Never));
            txbGia.DataBindings.Add(new Binding("Text", dtgvDrinks.DataSource, "Price", true, DataSourceUpdateMode.Never));
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

        private void txbID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtgvDrinks.SelectedCells.Count > 0)
                {
                    var selectedRow = dtgvDrinks.SelectedCells[0].OwningRow;
                    if (selectedRow.Cells["IDcategory"].Value != null)
                    {
                        int id = (int)selectedRow.Cells["IDcategory"].Value;

                        Category category = CategoryDAO.Instance.GetCategoryByID(id);
                        cbDanhMuc.SelectedItem = category;

                        int index = -1;
                        int i = 0;

                        foreach (Category item in cbDanhMuc.Items)
                        {
                            if (item.Id == category.Id)
                            {
                                index = i;
                                break;
                            }
                            i++;
                        }

                        cbDanhMuc.SelectedIndex = index;
                    }
                }
            }
            catch
            {
                return;
            }
        }

        private void txbFind_TextChanged(object sender, EventArgs e)
        {
            foodList.DataSource = SearchFoodByName(txbFind.Text);
        }

        List<Food> SearchFoodByName(string name)
        {
            List<Food> listFood = FoodDAO.Instance.SearchFoodByName(name);

            return listFood;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string name = txbTenMon.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Vui lòng nhập tên món!");
                return;
            }

            if (!(cbDanhMuc.SelectedItem is Category selectedCategory))
            {
                MessageBox.Show("Vui lòng chọn danh mục!");
                return;
            }

            if (!float.TryParse(txbGia.Text, out float price) || price < 0)
            {
                MessageBox.Show("Vui lòng nhập giá hợp lệ!");
                return;
            }

            int categoryID = selectedCategory.Id;

            if (FoodDAO.Instance.InsertFood(name, categoryID, price))
            {
                MessageBox.Show("Thêm món thành công!");
                LoadListDrinks();

                insertDrinks?.Invoke(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm món!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txbTenMon.Text.Trim();

                if (cbDanhMuc.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn danh mục!");
                    return;
                }

                int CategoryID = (cbDanhMuc.SelectedItem as Category).Id;

                if (!float.TryParse(txbGia.Text.Trim(), out float price))
                {
                    MessageBox.Show("Giá không hợp lệ. Vui lòng nhập số!");
                    return;
                }

                if (!int.TryParse(txbID.Text.Trim(), out int idFood))
                {
                    MessageBox.Show("ID không hợp lệ. Vui lòng kiểm tra lại!");
                    return;
                }

                if (FoodDAO.Instance.UpdateFood(idFood, name, CategoryID, price))
                {
                    MessageBox.Show("Sửa món thành công!");
                    LoadListDrinks();

                    if (updateDrinks != null)
                    {
                        updateDrinks(this, new EventArgs());
                    }
                }
                else
                {
                    MessageBox.Show("Có lỗi khi sửa thức ăn!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int idFood = Convert.ToInt32(txbID.Text);

            if (FoodDAO.Instance.DeleteFood(idFood))
            {
                MessageBox.Show("Xóa món thành công!");
                LoadListDrinks();
                if (deleteDrinks != null)
                {
                    deleteDrinks(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa thức ăn!");
            }
        }

        private event EventHandler insertDrinks;
        public event EventHandler InsertDrinks
        {
            add { insertDrinks += value; }
            remove { insertDrinks -= value; }
        }

        private event EventHandler deleteDrinks;
        public event EventHandler DeleteDrinks
        {
            add { deleteDrinks += value; }
            remove { deleteDrinks -= value; }
        }

        private event EventHandler updateDrinks;
        public event EventHandler UpdateDrinks
        {
            add { updateDrinks += value; }
            remove { updateDrinks -= value; }
        }
    }
}
