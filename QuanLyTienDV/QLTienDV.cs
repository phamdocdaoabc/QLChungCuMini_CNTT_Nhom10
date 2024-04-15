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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace QLChungCuMini
{
    public partial class QLTienDV : Form
    {

        SqlConnection connection;
        SqlCommand command;
        //String str = fLogin.GlobalVariables.MyGlobalStringSQL;
        //data của mạnh
        String str = "Data Source=MANHCAO\\SQLEXPRESS;Initial Catalog=QLChungCuMini;Integrated Security=True";
        //data đức dz
        // String str = "Data Source=LAPTOP-ACERI5\\SQLEXPRESS;Initial Catalog=QLChungCuMini;Integrated Security=True;";

        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();


        void loadData()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from TienDichVuThang";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataViewQLTDV.DataSource = table;
        }


        public QLTienDV()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void QLTienDV_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loadData();
            load_cbbox();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string option = cbTimKiem.SelectedItem.ToString();

            if (option == "ID")
            {
                MessageBox.Show("Mời bạn nhập theo ID Phòng để in báo cáo");
            }
            else if (option == "ID_Phong")
            {
                // Xử lý khi lựa chọn "IDPhong" được chọn
                string searchIDPhong = txtTimKiem.Text;

                command = connection.CreateCommand();
                command.CommandText = "BCTienDVTheoPhong";
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;
                command.Parameters.Add(new SqlParameter("@IDPhong", searchIDPhong));

                // Tạo DataSet để lưu dữ liệu
                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(ds);

                // Khởi tạo FormReport và truyền DataSet vào
                BaoCao baocao = new BaoCao();
                baocao.ReportDataSet = ds; // Truyền DataSet vào thuộc tính ReportDataSet
                baocao.ShowDialog();
            }
        }
        
        private void btnThem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Thêm Dịch Vụ mới!", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                command = connection.CreateCommand();
                command.CommandText = "insert into TienDichVuThang values('" + txtID.Text + "',N'" + txtIDPhong.Text + "',N'" + txtTenDV.Text + "', N'" + txtGiaCa.Text + "',N'" + txtSoLuong.Text + "',N'" + dtpNgayThue.Value + "',N'" + dtpHanThue.Value + "',N'" + txtChiSoCu.Text + "',N'" + txtChiSoMoi.Text + "',N'" + txtDonGia.Text + "',N'" + cbTrangThai.Text + "')";
                command.ExecuteNonQuery();

                loadData();
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "update TienDichVuThang set IDPhong = '" + txtIDPhong.Text + "',TenDichVu = '" + txtTenDV.Text + "', GiaCa = '" + txtGiaCa.Text + "',SoLuong = '" + txtSoLuong.Text + "',TuNgay = '" + dtpNgayThue.Value + "',ToiNgay = '" + dtpHanThue.Value + "',ChiSoCu = '" + txtChiSoCu.Text + "',chiSoMoi = '" + txtChiSoMoi.Text + "',DonGia = '" + txtDonGia.Text + "',TrangThaiThanhToan = '" + cbTrangThai.Text + "' where ID = '" + txtID.Text + "'";
            command.ExecuteNonQuery();
            loadData();
            MessageBox.Show("Sửa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa dịch vụ?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                command = connection.CreateCommand();
                command.CommandText = "delete from TienDichVuThang where ID = '" + txtID.Text + "'";
                command.ExecuteNonQuery();
                loadData();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string option = cbTimKiem.SelectedItem.ToString();

            if (option == "ID")
            {
                // Xử lý khi lựa chọn "ID" được chọn
                // Ví dụ: Hiển thị thông tin khách hàng theo ID
                string searchID = txtTimKiem.Text;

                command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM TienDichVuThang WHERE ID = @ID";
                command.Parameters.AddWithValue("@ID", searchID);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    dataViewQLTDV.DataSource = dataTable; // Gán DataTable vào DataSource của DataGridView
                }
                else
                {
                    MessageBox.Show("Không tìm thấy Dịch Vụ với ID này!");
                }
            }
            else if (option == "ID_Phong")
            {
                // Xử lý khi lựa chọn "CMND" được chọn
                string searchIDPhong = txtTimKiem.Text;

                command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM TienDichVuThang WHERE IDPhong = @ID";
                command.Parameters.AddWithValue("@ID", searchIDPhong);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    dataViewQLTDV.DataSource = dataTable; // Gán DataTable vào DataSource của DataGridView
                }
                else
                {
                    MessageBox.Show("Không tìm thấy Dịch Vụ với ID phòng này!");
                }
            }
        }
        Thread th;
        private void btnQuayLai_Click(object sender, EventArgs e)
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

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtIDPhong.Text = "";
            txtTenDV.Text = "";
            txtGiaCa.Text = "";
            txtSoLuong.Text = "";
            dtpNgayThue.Text = "1/2/2024";
            dtpHanThue.Text = "1/1/2024";
            txtChiSoCu.Text = "";
            txtChiSoMoi.Text = "";
            txtDonGia.Text = "";
            cbTrangThai.Text = "";
            txtTimKiem.Text = "";
            loadData();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void load_cbbox()
        {

            cbTrangThai.Items.Add("Đã thanh toán");
            cbTrangThai.Items.Add("Chưa thanh toán");
            cbTimKiem.Items.Add("ID");
            cbTimKiem.Items.Add("ID_Phong");
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataViewQLTDV_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataViewQLTDV.CurrentRow.Index;
            txtID.Text = dataViewQLTDV.Rows[i].Cells[0].Value.ToString();
            txtIDPhong.Text = dataViewQLTDV.Rows[i].Cells[1].Value.ToString();
            txtTenDV.Text = dataViewQLTDV.Rows[i].Cells[2].Value.ToString();
            txtSoLuong.Text = dataViewQLTDV.Rows[i].Cells[3].Value.ToString();
            txtGiaCa.Text = dataViewQLTDV.Rows[i].Cells[4].Value.ToString();


            string dateValue = dataViewQLTDV.Rows[i].Cells[5].Value.ToString();
            string dateValue1 = dataViewQLTDV.Rows[i].Cells[6].Value.ToString();

            // Chuyển đổi giá trị sang định dạng DateTime
            if (DateTime.TryParse(dateValue, out DateTime date))
            {
                // Đặt giá trị cho DateTimePicker
                dtpNgayThue.Value = date;

            }

            if (DateTime.TryParse(dateValue1, out DateTime date1))
            {
                // Đặt giá trị cho DateTimePicker              
                dtpHanThue.Value = date1;
            }
            txtChiSoCu.Text = dataViewQLTDV.Rows[i].Cells[7].Value.ToString();
            txtChiSoMoi.Text = dataViewQLTDV.Rows[i].Cells[8].Value.ToString();
            txtDonGia.Text = dataViewQLTDV.Rows[i].Cells[9].Value.ToString();
            cbTrangThai.Text = dataViewQLTDV.Rows[i].Cells[10].Value.ToString();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
