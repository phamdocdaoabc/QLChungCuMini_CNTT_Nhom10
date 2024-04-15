using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QLChungCuMini
{
    internal class TaiKhoanAdminDAO
    {
        // Khởi tạo kết nối
        //private static string stringConnection = fLogin.GlobalVariables.MyGlobalStringSQL;
        private static string stringConnection = @"Data Source=MANHCAO\SQLEXPRESS;Initial Catalog=QLChungCuMini;Integrated Security=True";

        // data đức dz
        //   private static string stringConnection = "Data Source=LAPTOP-ACERI5\\SQLEXPRESS;Initial Catalog=QLChungCuMini;Integrated Security=True;";

        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(stringConnection);
        }

        public TaiKhoanAdminDAO()
        {
        }

        
        SqlCommand sqlCommand; // dùng truy vấn các câu lệnh Insert, Update, Delete, ...
        SqlDataReader dataReader; // dùng đọc dl trong bảng

        // Hàm dùng để tìm kiếm kiểm tra dữ liệu bảng
        public List<TaiKhoanAdmin> TaiKhoan(string query)
        {
            List<TaiKhoanAdmin> taiKhoan = new List<TaiKhoanAdmin>();
            using (SqlConnection sqlConnection = GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                dataReader = sqlCommand.ExecuteReader(); // Đọc dl
                while (dataReader.Read())
                {
                    taiKhoan.Add(new TaiKhoanAdmin(dataReader.GetString(0), dataReader.GetString(1)));
                }
                sqlConnection.Close();
            }
            return taiKhoan;
        }

        // Hàm dùng để insert dl
        public void Command(string query)
        {
            using (SqlConnection sqlConnection = GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.ExecuteNonQuery(); // truy vấn
                sqlConnection.Close();
            }
        }
    }
}
