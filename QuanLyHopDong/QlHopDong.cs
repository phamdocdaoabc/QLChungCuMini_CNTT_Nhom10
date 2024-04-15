using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLChungCuMini
{
    public partial class QlHopDong : Form
    {

        SqlConnection connection;
        SqlCommand command;
        private static string str = @"Data Source=MANHCAO\SQLEXPRESS;Initial Catalog=QLChungCuMini;Integrated Security=True";
        //private static string str = fLogin.GlobalVariables.MyGlobalStringSQL;
        //data đức dz
        // String str = "Data Source=LAPTOP-ACERI5\\SQLEXPRESS;Initial Catalog=QLChungCuMini;Integrated Security=True;";

        SqlDataAdapter adapter = new SqlDataAdapter();      
        DataTable table = new DataTable();


        void loadData()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from HopDongThuePhong";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dg_hopdong.DataSource = table;
        }


        public QlHopDong()
        {
            InitializeComponent();
        }

        private void QlHopDong_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loadData();
            load_cbbox();
            load_IdKhachHang();
            load_IdPhong();

        }

        private void dg_hopdong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dg_hopdong.CurrentRow.Index;
            txt_id.Text = dg_hopdong.Rows[i].Cells[0].Value.ToString();
            cb_idKhachHang.Text = dg_hopdong.Rows[i].Cells[1].Value.ToString();
            cb_idPhong.Text = dg_hopdong.Rows[i].Cells[2].Value.ToString();
            numericUpDown1.Text = dg_hopdong.Rows[i].Cells[3].Value.ToString();
            numericUpDown2.Text = dg_hopdong.Rows[i].Cells[4].Value.ToString();


            string dateValue = dg_hopdong.Rows[i].Cells[5].Value.ToString();
            string dateValue1 = dg_hopdong.Rows[i].Cells[6].Value.ToString();

            // Chuyển đổi giá trị sang định dạng DateTime
            if (DateTime.TryParse(dateValue, out DateTime date))
            {
                // Đặt giá trị cho DateTimePicker
                dtp_ngayThue.Value = date;

            }

            if (DateTime.TryParse(dateValue1, out DateTime date1))
            {
                // Đặt giá trị cho DateTimePicker              
                dtp_ngayTra.Value = date1;
            }

        }

      

        private void load_IdKhachHang()
        {

            DataTable dt = new DataTable();

            command = connection.CreateCommand();
            command.CommandText = "select * from KhachHang";
            adapter.SelectCommand = command;
            dt.Clear();
            adapter.Fill(dt);

            cb_idKhachHang.DisplayMember = "ID";
            cb_idKhachHang.ValueMember = "ID";
            cb_idKhachHang.DataSource = dt;
        }

        private void load_IdPhong()
        {

            DataTable dt = new DataTable();

            command = connection.CreateCommand();
            command.CommandText = "select * from Phong";
            adapter.SelectCommand = command;
            dt.Clear();
            adapter.Fill(dt);

            cb_idPhong.DisplayMember = "ID";
            cb_idPhong.ValueMember = "ID";
            cb_idPhong.DataSource = dt;

        }
        private void bt_luu_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Thêm Hợp Đồng mới!", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                command = connection.CreateCommand();
                command.CommandText = "insert into HopDongThuePhong values('" + txt_id.Text + "',N'" + cb_idKhachHang.Text + "',N'" + cb_idPhong.Text + "', N'" + numericUpDown1.Text + "',N'" + numericUpDown2.Text + "',N'" + dtp_ngayThue.Value + "',N'" + dtp_ngayTra.Value + "')";
                command.ExecuteNonQuery();

                loadData();
            }

        }

        private void bt_sua_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "update HopDongThuePhong set IDKhachHang = '" + cb_idKhachHang.Text + "',IDPhong = '" + cb_idPhong.Text + "',GiaPhong = '" + numericUpDown1.Text + "', TienDatCoc = '" + numericUpDown2.Text + "',NgayThue = '" + dtp_ngayThue.Value + "',NgayTraPhong = '" + dtp_ngayTra.Value + "' where ID = '" + txt_id.Text + "'";
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
                command.CommandText = "delete from HopDongThuePhong where ID = '" + txt_id.Text + "'";
                command.ExecuteNonQuery();
                loadData();
            }

        }

        private void bt_reset_Click(object sender, EventArgs e)
        {
            txt_id.Text = "";
            cb_idKhachHang.Text = "";
            cb_idPhong.Text = "";
            numericUpDown1.Text = "";
            numericUpDown2.Text = "";
            dtp_ngayThue.Text = "1/2/2024";
            dtp_ngayTra.Text = "1/1/2024";

            loadData();

        }
        Thread th;
        private void bt__Click(object sender, EventArgs e)
        {
            th = new Thread(openNewFormHome);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();
        }
        private void openNewFormHome()
        {
            Application.Run(new fHome());
        }



        private void load_cbbox()
        {
            cb_timkiem.Items.Add("ID");
            cb_timkiem.Items.Add("ID_KhachHang");
            cb_timkiem.Items.Add("ID_Phong");


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
                command.CommandText = "SELECT * FROM HopDongThuePhong WHERE ID = @ID";
                command.Parameters.AddWithValue("@ID", searchID);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    dg_hopdong.DataSource = dataTable; // Gán DataTable vào DataSource của DataGridView
                }
                else
                {
                    MessageBox.Show("Không tìm thấy Hợp đồng với ID này!");
                }
            }
            else if (option == "ID_KhachHang")
            {
                // Xử lý khi lựa chọn "Họ tên" được chọn
                // Ví dụ: Hiển thị thông tin khách hàng theo họ tên
                string searchName = txt_timkiem.Text;

                command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM HopDongThuePhong WHERE IDKhachHang = @ID";
                command.Parameters.AddWithValue("@ID", searchName);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    dg_hopdong.DataSource = dataTable; // Gán DataTable vào DataSource của DataGridView
                }
                else
                {
                    MessageBox.Show("Không tìm thấy Hợp Đồng với ID khách hàng này!");
                }
            }
            else if (option == "ID_Phong")
            {
                // Xử lý khi lựa chọn "CMND" được chọn
                // Ví dụ: Hiển thị thông tin khách hàng theo CMND
                string searchCMND = txt_timkiem.Text;

                command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM HopDongThuePhong WHERE IDPhong = @ID";
                command.Parameters.AddWithValue("@ID", searchCMND);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    dg_hopdong.DataSource = dataTable; // Gán DataTable vào DataSource của DataGridView
                }
                else
                {
                    MessageBox.Show("Không tìm thấy Hợp Đồng với ID phòng này!");
                }
            }

        }

        private void txt_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
