using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLChungCuMini
{
    internal class TaiKhoanAdmin
    {
        private string tenTaiKhoan;
        private string matKhau;
        private string hoTen;
        private string diaChiTK;
        private string soDT;

        public TaiKhoanAdmin()
        {
        }

        public TaiKhoanAdmin(string tenTaiKhoan, string matKhau)
        {
            this.TenTaiKhoan = tenTaiKhoan;
            this.MatKhau = matKhau;
        }

        public string TenTaiKhoan { get => tenTaiKhoan; set => tenTaiKhoan = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string DiaChiTK { get => diaChiTK; set => diaChiTK = value; }
        public string SoDT { get => soDT; set => soDT = value; }
    }
}
