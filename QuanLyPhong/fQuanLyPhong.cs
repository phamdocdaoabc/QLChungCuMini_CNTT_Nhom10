using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLChungCuMini
{
    public partial class fQuanLyPhong : Form
    {
        public fQuanLyPhong()
        {
            InitializeComponent();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        // Nút sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (CheckTextBoxes())
            {
                GetValuesTextBoxes();
                string query = "UPDATE Phong SET ID = '" + quanLyPhong.IdPhong + "',TenPhong = '" + quanLyPhong.TenPhong + "',TrangThai = N'" + quanLyPhong.TrangThai + "',ViTri = N'" + quanLyPhong.ViTri + "',LoaiPhong = N'" + quanLyPhong.LoaiPhong + "',GiaPhong = " + quanLyPhong.GiaPhong + ",IDKhachHang = '" + quanLyPhong.IdKhach + "',NoiThat = N'" + quanLyPhong.NoiThat + "'";
                query += "WHERE ID= '" + quanLyPhong.IdPhong + "'";
                try
                {
                    quanLyPhongDAO.Comand(query);
                    MessageBox.Show("Sửa thành công");
                    fQuanLyPhong_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }
        // Nút quay lại trang chủ
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

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string id = txtIDP.Text.Trim();
            string tenP = txtTenP.Text.Trim();
            string trangTh = comboTrangThai.SelectedItem?.ToString();
            string viTr = comboViTri.SelectedItem?.ToString();
            string loaiP = txtLoaiPhong.Text.Trim();
            string idKh = txtIDKhach.Text.Trim();
            string noithat = txtNoiThat.Text.Trim();
            
            if (id != "")
            {
                string query = "Select * from Phong where ID like '%" + id + "%'";
                dataGridViewPhong.DataSource = quanLyPhongDAO.Table(query);
            }
            else if (tenP != "")
            {
                string query = "Select * from Phong where TenPhong like '%" + tenP + "%'";
                dataGridViewPhong.DataSource = quanLyPhongDAO.Table(query);
            }
            else if(!string.IsNullOrEmpty(trangTh))
            {              
                string query = "Select * from Phong where TrangThai = N'" + trangTh + "'";
                dataGridViewPhong.DataSource = quanLyPhongDAO.Table(query);
            }
            else if (!string.IsNullOrEmpty(viTr))
            {
                string query = "Select * from Phong where ViTri = N'" + viTr + "'";
                dataGridViewPhong.DataSource = quanLyPhongDAO.Table(query);
            }
            else if (loaiP != "")
            {
                string query = "Select * from Phong where LoaiPhong like N'%" + loaiP + "%'";
                dataGridViewPhong.DataSource = quanLyPhongDAO.Table(query);
            }
            else if (float.TryParse(txtGiaPhong.Text, out float giaP))
            {
                string query = "Select * from Phong where GiaPhong = " + giaP.ToString();
                dataGridViewPhong.DataSource = quanLyPhongDAO.Table(query);
            }
            else if (idKh != "")
            {
                string query = "Select * from Phong where IDKhachHang like '%" + idKh + "%'";
                dataGridViewPhong.DataSource = quanLyPhongDAO.Table(query);
            }
            else if (noithat != "")
            {
                string query = "Select * from Phong where NoiThat like N'%" + noithat + "%'";
                dataGridViewPhong.DataSource = quanLyPhongDAO.Table(query);
            }

        }

        private void txtTrangThai_TextChanged(object sender, EventArgs e)
        {

        }

        QuanLyPhongDAO quanLyPhongDAO = new QuanLyPhongDAO();
        private void fQuanLyPhong_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridViewPhong.DataSource = quanLyPhongDAO.Table("Select * from Phong");
            }catch(Exception ex)
            {
                MessageBox.Show("Lỗi: "+ex.Message);
            }
        }

        private void txtGiaPhong_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtGiaPhong_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Ko cho nhập chữ chỉ nhập số
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        // Nút Refresh
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtIDP.Text = "";
            txtTenP.Text = "";
            comboTrangThai.SelectedIndex = -1;
            comboViTri.SelectedIndex = -1;
            txtLoaiPhong.Text = "";
            txtGiaPhong.Text = "";
            txtIDKhach.Text = "";
            txtNoiThat.Text = "";
            fQuanLyPhong_Load(sender, e);
        }
        // Nút thêm
        QuanLyPhong quanLyPhong = new QuanLyPhong();

        private bool CheckTextBoxes()
        {
            if(txtIDP.Text == "" || txtTenP.Text == "" || txtLoaiPhong.Text == "")
            {
                MessageBox.Show("Bạn cần nhập đủ thông tin id phong, ten phong, loai phong cần thiết để thêm", "Thông báo");
                return false;
            }
            if (comboTrangThai.SelectedIndex == -1 || comboViTri.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn cần nhập trạng thái, vị trí để thêm", "Thông báo");
                return false;
            }
            return true;
        }
        private void GetValuesTextBoxes()
        {
            string idPhong = txtIDP.Text;
            string tenPhong = txtTenP.Text;
            string trangThai = comboTrangThai.Text;
            string viTri = comboViTri.Text;
            string loaiPhong = txtLoaiPhong.Text;
            float giaPhong = float.Parse(txtGiaPhong.Text);
            string idKhach = txtIDKhach.Text;
            string noiThat = txtNoiThat.Text;
            quanLyPhong = new QuanLyPhong(idPhong, tenPhong, trangThai, viTri, loaiPhong, giaPhong, idKhach, noiThat);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (CheckTextBoxes())
            {
                GetValuesTextBoxes();
                string query = "INSERT INTO Phong VALUES ('" + quanLyPhong.IdPhong + "','" + quanLyPhong.TenPhong + "',N'" + quanLyPhong.TrangThai + "',N'" + quanLyPhong.ViTri + "',N'" + quanLyPhong.LoaiPhong + "'," + quanLyPhong.GiaPhong + ",'" + quanLyPhong.IdKhach + "',N'" + quanLyPhong.NoiThat + "')";
                try
                {
                    quanLyPhongDAO.Comand(query);
                    MessageBox.Show("Thêm thành công");
                    fQuanLyPhong_Load(sender,e);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }
        // Nút xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridViewPhong.Rows.Count>1)
            {
                string choose = dataGridViewPhong.SelectedRows[0].Cells[0].Value.ToString();
                string query = "DELETE Phong ";
                query += "Where ID='"+choose+"'";
                try
                {
                    quanLyPhongDAO.Comand(query);
                    MessageBox.Show("Xóa thành công");
                    fQuanLyPhong_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

       
        // click dl trong bảng
        private void dataGridViewPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewPhong.Rows.Count > 1)
            {
                txtIDP.Text = dataGridViewPhong.SelectedRows[0].Cells[0].Value.ToString();
                txtTenP.Text = dataGridViewPhong.SelectedRows[0].Cells[1].Value.ToString();
                comboTrangThai.SelectedItem = dataGridViewPhong.SelectedRows[0].Cells[2].Value.ToString();
                comboViTri.SelectedItem = dataGridViewPhong.SelectedRows[0].Cells[3].Value.ToString();
                txtLoaiPhong.Text = dataGridViewPhong.SelectedRows[0].Cells[4].Value.ToString();
                txtGiaPhong.Text = dataGridViewPhong.SelectedRows[0].Cells[5].Value.ToString();
                txtIDKhach.Text = dataGridViewPhong.SelectedRows[0].Cells[6].Value.ToString();
                txtNoiThat.Text = dataGridViewPhong.SelectedRows[0].Cells[7].Value.ToString();
            }
        }
    }
}
