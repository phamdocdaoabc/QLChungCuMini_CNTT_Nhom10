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
    public partial class QLTBPCCC : Form
    {

        SqlConnection connection;
        SqlCommand command;       
        private static string str = fLogin.GlobalVariables.MyGlobalStringSQL;
        //data đức dz
        // String str = "Data Source=LAPTOP-ACERI5\\SQLEXPRESS;Initial Catalog=QLChungCuMini;Integrated Security=True;";

        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        // hàm loadData de day du lieu tu csdl vao datagridview
        public QLTBPCCC()
        {
            InitializeComponent();
        }
        private void QLTBPCCC_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loadData();
            load_cbbox();
        }
        void loadData()
        {
            command = connection.CreateCommand();//tao doi tuong command de viet command o SQL SERVER
            command.CommandText = "select * from ThietBiPCCC";//cau lenh tru van de lay  tat ca du lieu tu table 
            adapter.SelectCommand = command;//tai du lieu duoc thiet lap thong qua command
            table.Clear();//xoa du lieu dam bao bang clear truoc khi tai du lieu tu csdl
            adapter.Fill(table);//do du lieu vao table
            dgvThietBiPCCC.DataSource = table;//lay nguon du lieu cua gridview la table vua do 
        }
        private void load_cbbox()
        {
            cbSearch.Items.Add("ID");
            cbSearch.Items.Add("Tên Thiết Bị");
            cbSearch.Items.Add("Số Lượng");
            cbSearch.Items.Add("Trạng Thái");
        }
        
        //Lay thong tu tu hang hien tai va hien thong tin do len form de xem hoac cap nhap
        private void dgvThietBiPCCC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvThietBiPCCC.CurrentRow.Index;
            txtID.Text = dgvThietBiPCCC.Rows[i].Cells[0].Value.ToString();
            txtTenThietBi.Text = dgvThietBiPCCC.Rows[i].Cells[1].Value.ToString();
            txtSoLuong.Text = dgvThietBiPCCC.Rows[i].Cells[2].Value.ToString();
            string dateValue = dgvThietBiPCCC.Rows[i].Cells[3].Value.ToString();
            string dateValue1 = dgvThietBiPCCC.Rows[i].Cells[4].Value.ToString();
            txtTrangThai.Text = dgvThietBiPCCC.Rows[i].Cells[5].Value.ToString();
            txtViTri.Text = dgvThietBiPCCC.Rows[i].Cells[6].Value.ToString();
            txtTienMua.Text = dgvThietBiPCCC.Rows[i].Cells[7].Value.ToString();
            txtTienBaoDuong.Text = dgvThietBiPCCC.Rows[i].Cells[8].Value.ToString();
            // Chuyển đổi giá trị sang định dạng DateTime
            if (DateTime.TryParse(dateValue, out DateTime date))
            {
                // Đặt giá trị cho DateTimePicker
                dtpNgayMua.Value = date;
            }
            if (DateTime.TryParse(dateValue1, out DateTime date1))
            {
                // Đặt giá trị cho DateTimePicker
                dtpNgayBaoDuong.Value = date1;
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Thêm Khách Hàng mới!", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string ngayMua = dtpNgayMua.Value.ToString("yyyy-MM-dd HH:mm:ss");
                string ngayBaoDuong = dtpNgayBaoDuong.Value.ToString("yyyy-MM-dd HH:mm:ss");

                // Lấy ID chỉ với số đầu tiên nếu có
                string id = txtID.Text.TrimStart('0');

                // Kiểm tra xem ID đã tồn tại chưa
                if (IsIDExists(id))
                {
                    MessageBox.Show("ID đã tồn tại. Vui lòng chọn một ID khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Dừng lại nếu ID đã tồn tại
                }

                command = connection.CreateCommand();
                command.CommandText = "insert into ThietBiPCCC values('" + id + "',N'" + txtTenThietBi.Text + "', N'" + txtSoLuong.Text + "','" + ngayMua + "','" + ngayBaoDuong + "',N'" + txtTrangThai.Text + "',N'" + txtViTri.Text + "',N'" + txtTienMua.Text + "',N'" + txtTienBaoDuong.Text + "')";
                command.ExecuteNonQuery();//thực hiện truy vấn và thêm dữ liệu vào cơ sở dữ liệu.

                loadData();
            }
        }

        // Hàm kiểm tra xem ID đã tồn tại chưa
        private bool IsIDExists(string id)
        {
            command = connection.CreateCommand();
            command.CommandText = "SELECT COUNT(*) FROM ThietBiPCCC WHERE ID = @ID";
            command.Parameters.AddWithValue("@ID", id);

            int count = Convert.ToInt32(command.ExecuteScalar());

            return count > 0;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "UPDATE ThietBiPCCC " +
                                  "SET TenThietBi = @TenThietBi, " +
                                      "SoLuong = @SoLuong, " +
                                      "NgayMua = @NgayMua, " +
                                      "NgayBaoDuong = @NgayBaoDuong, " +
                                      "TrangThai = @TrangThai, " +
                                      "ViTri = @ViTri, " +
                                      "TienMua = @TienMua, " +
                                      "TienBaoDuong = @TienBaoDuong " +
                                  "WHERE ID = @ID";

            // Thay thế các tham số trong câu lệnh SQL bằng các giá trị tương ứng từ các control trên giao diện
            command.Parameters.AddWithValue("@TenThietBi", txtTenThietBi.Text);
            command.Parameters.AddWithValue("@SoLuong", txtSoLuong.Text);
            command.Parameters.AddWithValue("@NgayMua", dtpNgayMua.Value);
            command.Parameters.AddWithValue("@NgayBaoDuong", dtpNgayBaoDuong.Value);
            command.Parameters.AddWithValue("@TrangThai", txtTrangThai.Text);
            command.Parameters.AddWithValue("@ViTri", txtViTri.Text);
            command.Parameters.AddWithValue("@TienMua", txtTienMua.Text);
            command.Parameters.AddWithValue("@TienBaoDuong", txtTienBaoDuong.Text);
            command.Parameters.AddWithValue("@ID", txtID.Text);

            // Thực thi câu lệnh SQL
            command.ExecuteNonQuery();

            // Tải lại dữ liệu sau khi cập nhật
            loadData();

            // Hiển thị thông báo
            MessageBox.Show("Sửa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa khách hàng?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                command = connection.CreateCommand();
                command.CommandText = @"DELETE FROM ThietBiPCCC
                        WHERE ID = @ID";
                command.Parameters.AddWithValue("@ID", txtID.Text);
                command.ExecuteNonQuery();
                loadData();
            }
        }
        private void btnReload_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtTenThietBi.Text = "";
            txtSoLuong.Text = "";
            dtpNgayMua.Text = "1/1/2024";
            dtpNgayBaoDuong.Text = "1/1/2024";
            txtTrangThai.Text = "";
            txtViTri.Text = "";
            txtTienMua.Text = "";
            txtTienBaoDuong.Text = "";
        }
        Thread th;
        // thoát form hiện tại và mở lại form home
        private void btnExit_Click(object sender, EventArgs e)
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
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string option = cbSearch.SelectedItem.ToString();

            if (option == "ID")
            {
                // Xử lý khi lựa chọn "ID" được chọn
                // Ví dụ: Hiển thị thông tin khách hàng theo ID
                string searchID = txtSearch.Text;

                command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM ThietBiPCCC WHERE ID = @ID";
                command.Parameters.AddWithValue("@ID", searchID);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    dgvThietBiPCCC.DataSource = dataTable; // Gán DataTable vào DataSource của DataGridView
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng với ID này!");
                }
            }
            else if (option == "Tên Thiết Bị")
            {
                // Xử lý khi lựa chọn "Họ tên" được chọn
                // Ví dụ: Hiển thị thông tin khách hàng theo họ tên
                string searchName = txtSearch.Text;

                command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM ThietBiPCCC WHERE TenThietBi = @TenThietBi";
                command.Parameters.AddWithValue("@TenThietBi", searchName);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    dgvThietBiPCCC.DataSource = dataTable; // Gán DataTable vào DataSource của DataGridView
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng với họ tên này!");
                }
            }
            else if (option == "Số Lượng")
            {
                // Xử lý khi lựa chọn "CMND" được chọn
                // Ví dụ: Hiển thị thông tin khách hàng theo CMND
                string searchSoLuong = txtSearch.Text;

                command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM ThietBiPCCC WHERE SoLuong = @SoLuong";
                command.Parameters.AddWithValue("@SoLuong", searchSoLuong);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    dgvThietBiPCCC.DataSource = dataTable; // Gán DataTable vào DataSource của DataGridView
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng với CMND này!");
                }
            }
            else if (option == "Trạng Thái")
            {
                // Xử lý khi lựa chọn "Quê Quán" được chọn
                // Ví dụ: Hiển thị thông tin khách hàng theo quê quán
                string searchTrangThai = txtSearch.Text;

                command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM ThietBiPCCC WHERE TrangThai = @TrangThai";
                command.Parameters.AddWithValue("@TrangThai", searchTrangThai);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    dgvThietBiPCCC.DataSource = dataTable; // Gán DataTable vào DataSource của DataGridView
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng với quê quán này!");
                }
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void cbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
