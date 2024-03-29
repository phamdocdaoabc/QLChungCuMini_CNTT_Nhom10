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
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        // Khởi tạo để lấy tên tài khoản cho vào trang chủ
        public static string taikhoan = "";
        // Nút đăng nhập
        Thread th;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string tenTK = txtTaiKhoan.Text;
            string matKhau = txtPassW.Text;
            // Check lỗi
            TaiKhoanAdminDAO taiKhoanAdminDAO = new TaiKhoanAdminDAO();
            if (tenTK.Trim() == "") { 
                MessageBox.Show("Vui lòng nhập tên tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); 
            }else if (matKhau.Trim() == "") { 
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else {
                string query = "Select * from Admin where TaiKhoan ='" + tenTK + "' and MatKhau ='" + matKhau + "'";
                if (taiKhoanAdminDAO.TaiKhoan(query).Count!=0)
                {
                    
                    taikhoan = tenTK; // cho taikhoan lấy gt tên tk
                    MessageBox.Show("Đăng nhập thành công!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    th = new Thread(openNewForm1);
                    th.SetApartmentState(ApartmentState.STA);
                    th.Start();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tên tài khoản hoặc mật khẩu sai!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }     
        }
        private void openNewForm1()
        {
            Application.Run(new fHome());
        }
        // Nút đăng ký
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            th = new Thread(openNewForm2);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();
        }
        private void openNewForm2()
        {
            Application.Run(new fDangKy());
        }

       

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }


        private void txtTaiKhoan_TextChanged(object sender, EventArgs e)
        {
        }
        private void txtPassW_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnQuenMK_Click(object sender, EventArgs e)
        {

        }

        private void fLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
