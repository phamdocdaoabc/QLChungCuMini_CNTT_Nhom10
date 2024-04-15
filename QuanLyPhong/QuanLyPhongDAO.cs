using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace QLChungCuMini
{
    internal class QuanLyPhongDAO
    {
        // Khởi tạo kết nối
        //private static string stringConnection = fLogin.GlobalVariables.MyGlobalStringSQL;
        private static string stringConnection = @"Data Source=MANHCAO\SQLEXPRESS;Initial Catalog=QLChungCuMini;Integrated Security=True";
        //data đức dz
        //private static string stringConnection = "Data Source=LAPTOP-ACERI5\\SQLEXPRESS;Initial Catalog=QLChungCuMini;Integrated Security=True;"; 

        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(stringConnection);
        }

        public QuanLyPhongDAO()
        {
        }

        // Bảng dữ liệu
        SqlDataAdapter dataAdapter;
        public DataTable Table(string query)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection sqlConnection = GetSqlConnection())
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(query, sqlConnection);
                dataAdapter.Fill(dataTable);
                sqlConnection.Close();
            }
                return dataTable;
        }

        // Hàm truy xuất

        SqlCommand sqlCommand;
        public void Comand(string query)
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
