using System.Data;

namespace CoffeeShopManagement.DTO
{
    public class TableFood
    {
        private int iD;
        private string name;
        private string status;

        public TableFood() { }

        public TableFood(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["name"].ToString();
            this.Status = row["status"].ToString();
        }

        public TableFood(int iD, string name, string status)
        {
            this.ID = iD;
            this.Name = name;
            this.Status = status;
        }

        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public string Status { get => status; set => status = value; }
    }
}
