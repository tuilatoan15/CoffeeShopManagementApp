using CoffeeShopManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Xml.Linq;

namespace CoffeeShopManagement.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        private AccountDAO() { }

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set { instance = value; }
        }

        public List<int> GetListAccountType()
        {
            List<int> list = new List<int>();

            string query = "SELECT DISTINCT type FROM Account";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                int accountType = Convert.ToInt32(row["type"]);
                list.Add(accountType);
            }

            return list;
        }

        public List<Account> SearchAccountByDisplayName(string displayName)
        {
            List<Account> list = new List<Account>();

            string query = string.Format("SELECT * FROM Account WHERE [dbo].[fuConvertToUnsign1] (displayName) LIKE N'%' + [dbo].[fuConvertToUnsign1](N'{0}') + '%'", displayName);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Account acc = new Account(item);
                list.Add(acc);
            }

            return list;
        }

        // Kiểm tra tài khoản, mật khẩu nhập vào
        public bool Login(string userName, string passWord)
        {
            //byte[] temp = Encoding.ASCII.GetBytes(passWord);
            //byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);

            //string hasPass = "";

            //foreach (byte item in hasData)
            //{
            //    hasPass += item;
            //}

            //Mã hóa đảo ngược code (nếu muốn)
            //var list = hasData.ToString();
            //list.Reverse();


            string query = "USP_Login @userName , @passWord";

            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { userName, passWord /**/});

            return result.Rows.Count > 0;
        }

        // Hàm Update Account dùng cho - Thông tin tài khoản
        public bool UpdateAccount(string userName, string displayName, string pass, string newPass)
        {
            string query = "EXEC USP_UpdateAccount @userName , @displayName , @password , @newPassword ";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { userName, displayName, pass, newPass });

            return result > 0;
        }

        public bool CheckAccountExists(string userName)
        {
            string query = "SELECT COUNT(*) FROM Account WHERE UserName = @userName";
            int result = (int)DataProvider.Instance.ExecuteScalar(query, new object[] { userName });
            return result > 0;
        }


        // Lấy danh sách tài khoản 
        public DataTable GetListAccount()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT UserName, DisplayName, Password, Type FROM Account");
        }

        public int GetAccountCount()
        {
            return (int)DataProvider.Instance.ExecuteScalar("SELECT COUNT(*) FROM Account WHERE type = 0");
        }

        // Lấy ra tài khoản từ UserName 
        public Account GetAccountByUserName(string userName)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM ACCOUNT WHERE userName = '" + userName + "'");

            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }

            return null;
        }

        // Các hàm thêm, sửa, xóa Account dùng cho - Tài khoản
        public bool InsertAccount(string userName, string displayName, string password, int type)
        {
            string query = string.Format("INSERT Account (userName, displayName, type, passWord) VALUES (N'{0}', N'{1}', {2}, N'{3}')", userName, displayName, type, password);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool UpdateAccount(string userName, string displayName, int type)
        {
            string query = string.Format("UPDATE Account SET displayName = N'{1}', type = {2} WHERE UserName = N'{0}' ", userName, displayName, type);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool DeleteAccount(string name)
        {
            string query = string.Format("DELETE Account WHERE UserName = N'{0}'", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        // Reset passWord về 1
        public bool ResetPassword(string name, string displayName)
        {
            string query = string.Format("Update Account SET passWord = N'2024' WHERE userName = N'{0}' AND displayName = N'{1}'", name, displayName);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

    }
}
