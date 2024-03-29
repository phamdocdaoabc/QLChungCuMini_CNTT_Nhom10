using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLChungCuMini
{
    internal class QuanLyPhong
    {
        private string idPhong, tenPhong, trangThai, viTri, loaiPhong, idKhach, noiThat;
        private float giaPhong;

        public QuanLyPhong()
        {
        }

        public QuanLyPhong(string idPhong, string tenPhong, string trangThai, string viTri, string loaiPhong, float giaPhong, string idKhach, string noiThat)
        {
            this.idPhong = idPhong;
            this.tenPhong = tenPhong;
            this.trangThai = trangThai;
            this.viTri = viTri;
            this.loaiPhong = loaiPhong;
            this.giaPhong = giaPhong;
            this.idKhach = idKhach;
            this.noiThat = noiThat;
           
        }

        public string IdPhong { get => idPhong; set => idPhong = value; }
        public string TenPhong { get => tenPhong; set => tenPhong = value; }
        public string TrangThai { get => trangThai; set => trangThai = value; }
        public string ViTri { get => viTri; set => viTri = value; }
        public string LoaiPhong { get => loaiPhong; set => loaiPhong = value; }
        public string IdKhach { get => idKhach; set => idKhach = value; }
        public string NoiThat { get => noiThat; set => noiThat = value; }
        public float GiaPhong { get => giaPhong; set => giaPhong = value; }
    }
}
