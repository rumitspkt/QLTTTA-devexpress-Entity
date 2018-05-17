using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTTTA.BUS
{
    public class HocVienBUS
    {
        private static HocVienBUS instance;

        public static HocVienBUS Instance
        {
            get { if (instance == null) instance = new HocVienBUS(); return instance; }
            private set { instance = value; }
        }

        private HocVienBUS() { }
        public List<HocVien> getListHocVien(int maKH, int maLH)
        {
            List<HocVien> listHV = new List<HocVien>();
            using (var db = new TTTA_DBEntities())
            {
                db.BienLaiHocPhis.Include("HocVien").Where(x => x.MaKhoaHoc == maKH && x.MaLopHoc == maLH).ToList().ForEach(x => listHV.Add(x.HocVien));
            }
            return listHV;
        }
        public HocVien getHocVien(int maHV)
        {

            using (var db = new TTTA_DBEntities())
            {
                return db.HocViens.SingleOrDefault(x => x.MaHV == maHV);
            }
        }
        public bool themHocVien(int maHV, string hoTen, DateTime ngaySinh, string gioiTinh, string diaChi, string soDienThoai)
        {
            HocVien hocVien = new HocVien()
            {
                MaHV = maHV,
                HoTen = hoTen,
                NgaySinh = ngaySinh,
                GioiTinh = gioiTinh,
                DiaChi = diaChi,
                SoDienThoai = soDienThoai
            };
            using (var db = new TTTA_DBEntities())
            {
                db.HocViens.Add(hocVien);
                return db.SaveChanges() > 0;
            }
        }
        public bool capNhatHocVien(int maHV, string hoTen, DateTime ngaySinh, string gioiTinh, string diaChi, string soDienThoai)
        {
            HocVien hocVien = new HocVien()
            {
                MaHV = maHV,
                HoTen = hoTen,
                NgaySinh = ngaySinh,
                GioiTinh = gioiTinh,
                DiaChi = diaChi,
                SoDienThoai = soDienThoai
            };
            using (var db = new TTTA_DBEntities())
            {
                db.Entry(hocVien).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
        }
        public bool xoaHocVien(int maHV)
        {
            HocVien hocVien = new HocVien()
            {
                MaHV = maHV

            };
            using (var db = new TTTA_DBEntities())
            {
                db.Entry(hocVien).State = System.Data.Entity.EntityState.Deleted;
                return db.SaveChanges() > 0;
            }
        }
        public List<HocVien> getListHocVien()
        {
            using (var db = new TTTA_DBEntities())
            {
                return db.HocViens.ToList();

            }
        }
    }
}
