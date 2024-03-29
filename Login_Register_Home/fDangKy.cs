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
using System.Text.RegularExpressions;

namespace QLChungCuMini
{
    public partial class fDangKy : Form
    {
        public fDangKy()
        {
            InitializeComponent();
        }

        private void fDangKy_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnDangKy_Paint(object sender, PaintEventArgs e)
        {

        }
        // Nút đăng ký
        public bool checkAccount(string ac) // Hàm check tài khoản mật khẩu
        {
            return Regex.IsMatch(ac, "^[a-zA-Z0-9]{6,24}$");
        }
        public bool checkEmail(string em) // Hàm check email
        {
            return Regex.IsMatch(em, @"^[a-zA-Z0-9_.]{3,20}@gmail.com(.vn|)$");
        }
        TaiKhoanAdminDAO taiKhoanAdminDAO = new TaiKhoanAdminDAO();
        private void btnDK_Click(object sender, EventArgs e)
        {
            string tenTK = txtTaiKhoan.Text;
            string matKhau = txtPass.Text;
            string matKhauLai = txtPassLai.Text;
            string hoTen = txtTen.Text;
            string diaChi = txtDiaChi.Text;
            string email = txtEmail.Text;
            string soDT = txtDienThoai.Text;
            string maQuanLy = txtMaQuanLy.Text;
            if (!checkAccount(tenTK))
            {
                MessageBox.Show("Vui Lòng nhập tên tài khoản dài khoản 6-24 ký tự, với các ký tự chữ và số, chữ hoa và chữ thường!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!checkAccount(matKhau))
            {
                MessageBox.Show("Vui Lòng nhập mật khẩu dài khoản 6-24 ký tự, với các ký tự chữ và số, chữ hoa và chữ thường!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (matKhauLai != matKhau)
            {
                MessageBox.Show("Mật khẩu nhập lại không chính xác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!checkEmail(email))
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng email!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (taiKhoanAdminDAO.TaiKhoan("Select * from Admin where Email ='" + email + "'").Count != 0)
            {
                MessageBox.Show("Email đã đã được đăng ký!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (maQuanLy == "" || matKhauLai == "" || hoTen == "" || email == "")
            {
                MessageBox.Show("Vui Lòng nhập đủ thông tin bắt buộc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (maQuanLy != "admin" )
            {
                MessageBox.Show("Mã quản lý không chính xác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                string query = "Insert into Admin values ('" + tenTK + "','" + matKhau + "',N'" + hoTen + "',N'" + diaChi + "','" + email + "','" + soDT + "')";
                taiKhoanAdminDAO.Command(query);
                MessageBox.Show("Bạn đã đăng ký tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Tên tài khoản đã được đăng ký, Vui lòng nhập lại tên tài khoản khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }  
        }

        // Nút chuyển trang đăng
        Thread th;
        private void btnDN_Click(object sender, EventArgs e)
        {

            th = new Thread(openNewForm);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();
        }
        private void openNewForm()
        {
            Application.Run(new fLogin());
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtTen_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDiaChi_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
