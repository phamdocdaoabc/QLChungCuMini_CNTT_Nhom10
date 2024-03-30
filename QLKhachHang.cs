using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLChungCuMini
{
    public partial class QLKhachHang : Form
    {

        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=DESKTOP-0HMGH3I;Initial Catalog=QLChungCuMini;Integrated Security=True;Encrypt=False";

        //data đức dz
        // String str = "Data Source=LAPTOP-ACERI5\\SQLEXPRESS;Initial Catalog=QLChungCuMini;Integrated Security=True;";

        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();


        void loadData()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from KhachHang";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dg_khachhang.DataSource = table;
        }


        public QLKhachHang()
        {
            InitializeComponent();
        }



        private void QLKhachHang_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loadData();
            load_cbbox();

        }

        private void dg_khachhang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int i;
            i = dg_khachhang.CurrentRow.Index;
            txt_id.Text = dg_khachhang.Rows[i].Cells[0].Value.ToString();
            txt_hoTen.Text = dg_khachhang.Rows[i].Cells[1].Value.ToString();
            txt_cmnd.Text = dg_khachhang.Rows[i].Cells[2].Value.ToString();
            txt_dienThoai.Text = dg_khachhang.Rows[i].Cells[3].Value.ToString();
            txt_queQuan.Text = dg_khachhang.Rows[i].Cells[4].Value.ToString();
            txt_hktt.Text = dg_khachhang.Rows[i].Cells[5].Value.ToString();

            string dateValue = dg_khachhang.Rows[i].Cells[6].Value.ToString();

            // Chuyển đổi giá trị sang định dạng DateTime
            if (DateTime.TryParse(dateValue, out DateTime date))
            {
                // Đặt giá trị cho DateTimePicker
                dtp_ngaysinh.Value = date;
            }

        }

        private void bt_luu_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Thêm Khách Hàng mới!", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                command = connection.CreateCommand();
                command.CommandText = "insert into KhachHang values('" + txt_id.Text + "',N'" + txt_hoTen.Text + "', N'" + txt_cmnd.Text + "',N'" + txt_dienThoai.Text + "',N'" + txt_queQuan.Text + "',N'" + txt_hktt.Text + "','" + dtp_ngaysinh.Value + "')";
                command.ExecuteNonQuery();

                loadData();
            }


        }

        private void bt_sua_Click(object sender, EventArgs e)
        {

            command = connection.CreateCommand();
            command.CommandText = "update KhachHang set HoTen = '" + txt_hoTen.Text + "', CMND = '" + txt_cmnd.Text + "',DienThoai = '" + txt_dienThoai.Text + "',QueQuan = '" + txt_queQuan.Text + "',HKTT = '" + txt_hktt.Text + "',NgaySinh = '" + dtp_ngaysinh.Value + "' where ID = '" + txt_id.Text + "'";
            command.ExecuteNonQuery();
            loadData();
            MessageBox.Show("Sửa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void bt_xoa_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa khách hàng?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                command = connection.CreateCommand();
                command.CommandText = @"DELETE FROM HopDongThuePhong
                        WHERE IDKhachHang = @ID";
                command.Parameters.AddWithValue("@ID", txt_id.Text);
                command.ExecuteNonQuery();

                command = connection.CreateCommand();
                command.CommandText = @"DELETE FROM KhachHang
                        WHERE ID = @ID";
                command.Parameters.AddWithValue("@ID", txt_id.Text);
                command.ExecuteNonQuery();



                loadData();
            }

        }

        private void bt_reset_Click(object sender, EventArgs e)
        {
            txt_id.Text = "";
            txt_hoTen.Text = "";
            txt_cmnd.Text = "";
            txt_dienThoai.Text = "";
            txt_queQuan.Text = "";
            txt_hktt.Text = "";
            dtp_ngaysinh.Text = "1/1/2024";

            loadData();
        }



        private void bt__Click(object sender, EventArgs e)
        {
            fHome fh = new fHome();
            fh.Show();
            this.Close();
        }




        private void bt_timkiem_Click(object sender, EventArgs e)
        {
            string option = cb_timkiem.SelectedItem.ToString();

            if (option == "ID")
            {
                // Xử lý khi lựa chọn "ID" được chọn
                // Ví dụ: Hiển thị thông tin khách hàng theo ID
                string searchID = txt_timkiem.Text;

                command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM KhachHang WHERE ID = @ID";
                command.Parameters.AddWithValue("@ID", searchID);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    dg_khachhang.DataSource = dataTable; // Gán DataTable vào DataSource của DataGridView
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng với ID này!");
                }
            }
            else if (option == "Họ tên")
            {
                // Xử lý khi lựa chọn "Họ tên" được chọn
                // Ví dụ: Hiển thị thông tin khách hàng theo họ tên
                string searchName = txt_timkiem.Text;

                command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM KhachHang WHERE HoTen = @HoTen";
                command.Parameters.AddWithValue("@HoTen", searchName);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    dg_khachhang.DataSource = dataTable; // Gán DataTable vào DataSource của DataGridView
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng với họ tên này!");
                }
            }
            else if (option == "CMND")
            {
                // Xử lý khi lựa chọn "CMND" được chọn
                // Ví dụ: Hiển thị thông tin khách hàng theo CMND
                string searchCMND = txt_timkiem.Text;

                command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM KhachHang WHERE CMND = @CMND";
                command.Parameters.AddWithValue("@CMND", searchCMND);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    dg_khachhang.DataSource = dataTable; // Gán DataTable vào DataSource của DataGridView
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng với CMND này!");
                }
            }
            else if (option == "Quê Quán")
            {
                // Xử lý khi lựa chọn "Quê Quán" được chọn
                // Ví dụ: Hiển thị thông tin khách hàng theo quê quán
                string searchQueQuan = txt_timkiem.Text;

                command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM KhachHang WHERE QueQuan = @QueQuan";
                command.Parameters.AddWithValue("@QueQuan", searchQueQuan);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    dg_khachhang.DataSource = dataTable; // Gán DataTable vào DataSource của DataGridView
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng với quê quán này!");
                }
            }

        }



        private void load_cbbox()
        {
            cb_timkiem.Items.Add("ID");
            cb_timkiem.Items.Add("Họ tên");
            cb_timkiem.Items.Add("CMND");
            cb_timkiem.Items.Add("Quê Quán");
        }



    }
}
