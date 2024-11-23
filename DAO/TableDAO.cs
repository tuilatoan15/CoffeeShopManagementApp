using CoffeeShopManagement.DTO;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace CoffeeShopManagement.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;

        public static int tableWidth = 106;
        public static int tableHeight = 106;

        public static TableDAO Instance
        {
            get { if (instance == null) instance = new TableDAO(); return instance; }
            private set => instance = value;
        }

        public TableDAO() { }

        // Hàm đổi bàn
        public void SwitchTable(int id1, int id2)
        {
            DataProvider.Instance.ExecuteQuery("USP_SwitchTable @idTable1 , @idTable2 ", new object[] { id1, id2 });
        }

        // Lấy ra danh sách bàn 
        public List<TableFood> LoadTableList()
        {
            List<TableFood> tableList = new List<TableFood>();

            DataTable dataTable = DataProvider.Instance.ExecuteQuery("USP_GetTableList");

            foreach (DataRow item in dataTable.Rows)
            {
                TableFood table = new TableFood(item);
                tableList.Add(table);
            }

            return tableList;
        }

        public int GetTableCount()
        {
            return (int)DataProvider.Instance.ExecuteScalar("SELECT COUNT(*) FROM TableFood");
        }

        // Lấy ra bàn có id trùng với idTable truyền vào
        public TableFood GetTableByID(int idTable)
        {
            TableFood table = null;

            string query = "SELECT * FROM TableFood WHERE id = " + idTable;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                table = new TableFood(item);
                return table;
            }

            return table;
        }

        // Các hàm thêm, sửa, xóa bàn 
        public bool InsertTable(string name, string status)
        {
            string query = string.Format("INSERT TableFood (name, status) VALUES (N'{0}', N'{1}')", name, status);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool UpdateTable(string name, int id)
        {
            string query = string.Format("UPDATE TableFood SET name = N'{0}' WHERE id = {1} ", name, id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteTable(int idTable)
        {
            TableFood table = GetTableByID(idTable);
            if (table == null || table.Status == "Co nguoi")
            {
                MessageBox.Show("Không thể xóa bàn đang có người!");
                return false;
            }

            DataProvider.Instance.ExecuteNonQuery(string.Format("DELETE FROM BillInfo WHERE idBill IN (SELECT id FROM Bill WHERE idTable = {0})", idTable));
            DataProvider.Instance.ExecuteNonQuery(string.Format("DELETE FROM Bill WHERE idTable = {0}", idTable));
            int result = DataProvider.Instance.ExecuteNonQuery(string.Format("DELETE FROM TableFood WHERE id = {0}", idTable));

            return result > 0;
        }

    }
}
