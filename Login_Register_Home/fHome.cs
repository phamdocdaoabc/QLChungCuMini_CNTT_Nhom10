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
    public partial class fHome : Form
    {
        public fHome()
        {
            InitializeComponent();
        }
        Thread th;
        private void btnQLPhong_Click(object sender, EventArgs e)
        {
            th = new Thread(openNewFormQLPhong);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();
        }
        private void openNewFormQLPhong()
        {
            Application.Run(new fQuanLyPhong());
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            th = new Thread(openNewFormLogin);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();
        }
        private void openNewFormLogin()
        {
            Application.Run(new fLogin());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnPCCC_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnQLHopDong_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        // Lấy tên tk từ đăng nhập
        string taikhoan = "";
        private void fHome_Load(object sender, EventArgs e)
        {
            taikhoan = fLogin.taikhoan;
            labTenTaiKhoan.Text = "Xin chào: "+taikhoan;
        }

        private void labTenTaiKhoan_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        

        private void btnQLP_Click(object sender, EventArgs e)
        {
            th = new Thread(openNewFormQLPhong);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnQLKH_Click_1(object sender, EventArgs e)
        {

        }
    }
}
