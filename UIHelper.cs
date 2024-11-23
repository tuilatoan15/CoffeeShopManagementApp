using CoffeeShopManagement.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShopManagement
{

    public static class UIHelper
    {
        public static Account userNameFromLogin;
        public static int tableIDCheckOut;
        public static int tableIDDatMon;
        public static string panelClicked;
        public static System.Windows.Forms.Timer GlobalTimer { get; private set; }
        public static string CurrentTime { get; private set; }

        static UIHelper()
        {
            // Khởi tạo Timer để cập nhật thời gian
            GlobalTimer = new System.Windows.Forms.Timer();
            GlobalTimer.Interval = 1000; // 1 giây
            GlobalTimer.Tick += (s, e) =>
            {
                CurrentTime = DateTime.Now.ToString("hh:mm:ss") + "\n" + DateTime.Now.ToString("dd/MM/yyyy");
            };
            GlobalTimer.Start();
        }

        // Phương thức thay đổi màu cho Panel khi click vào các Label, Panel, hoặc PictureBox
        public static async void ChangePanelColor(object sender, List<Panel> panels, Account userNameLogin, Form currentForm)
        {
            Panel clickedPanel = null;

            if (sender is Label clickedLabel)
            {
                clickedPanel = (Panel)clickedLabel.Parent; 
            }
            else if (sender is Panel panel)
            {
                clickedPanel = panel; 
            }
            else if (sender is PictureBox clickedPicture)
            {
                clickedPanel = (Panel)clickedPicture.Parent; 
            }

            if (clickedPanel != null)
            {
                string panelName = clickedPanel.Name;
                Form newForm = null;

                switch (panelName)
                {
                    case "pnlHome":
                        newForm = new Home();
                        break;
                    case "pnlAdmin":
                        newForm = new Admin();
                        break;
                    case "pnlUser":
                        newForm = new Stats();
                        break;
                    case "pnlOrder":
                        newForm = new Order();
                        break;
                    case "pnlCheckOut":
                        newForm = new CheckOut();
                        break;
                    case "pnlHelp":
                        newForm = new Help();
                        break;
                    case "pnlDoUong":
                        newForm = new Drinks();
                        break;
                    case "pnlDanhMuc":
                        newForm = new CategoryForm();
                        break;
                    case "pnlBan":
                        newForm = new Table();
                        break;
                    case "pnlTaiKhoan":
                        newForm = new AccountForm();
                        break;
                    default:
                        break;
                }

                if (newForm != null)
                {
                    newForm.Show();
                    await Task.Delay(50);
                    currentForm.Close();
                }
            }

            panelClicked = clickedPanel.Name.ToString();
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public static void MoveWindow(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(((Control)sender).Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
