using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QLTTTA.BUS
{
    public class GiangVienBUS
    {
        private static GiangVienBUS instance;

        public static GiangVienBUS Instance
        {
            get { if (instance == null) instance = new GiangVienBUS(); return instance; }
            private set { instance = value; }
        }

        private GiangVienBUS() { }
        public bool suaThongTinGV(GiangVien gv, string hoTen, DateTime ngaySinh)
        {
            return capNhatGiangVien(gv.MaGV, hoTen, ngaySinh, gv.ThamNien, gv.HocVi, gv.Luong, gv.Mail);
        }
        public GiangVien getGiangVien(string mail)
        {
            using (var db = new TTTA_DBEntities())
            {
                return db.GiangViens.SingleOrDefault(x => x.Mail == mail);
            }
        }
        public GiangVien getGiangVien(int maGV)
        {
            using (var db = new TTTA_DBEntities())
            {
                return db.GiangViens.SingleOrDefault(x => x.MaGV == maGV);
            }
        }
        public bool themGiangVien(int maGV, string tenGV, DateTime ngaySinh, int thamNien, string hocVi, int luong, string mail)
        {
            GiangVien giangVien = new GiangVien()
            {
                MaGV = maGV,
                TenGV = tenGV,
                NgaySinh = ngaySinh,
                ThamNien = thamNien,
                HocVi = hocVi,
                Luong = luong,
                Mail = mail
            };
            using (var db = new TTTA_DBEntities())
            {
                db.GiangViens.Add(giangVien);
                return db.SaveChanges() > 0;
            }
        }
        public bool capNhatGiangVien(int maGV, string tenGV, DateTime ngaySinh, int thamNien, string hocVi, int luong, string mail)
        {
            GiangVien giangVien = new GiangVien()
            {
                MaGV = maGV,
                TenGV = tenGV,
                NgaySinh = ngaySinh,
                ThamNien = thamNien,
                HocVi = hocVi,
                Luong = luong,
                Mail = mail
            };
            using (var db = new TTTA_DBEntities())
            {
                db.Entry(giangVien).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
        }
        public bool xoaGiangVien(int maGV)
        {
            GiangVien giangVien = new GiangVien()
            {
                MaGV = maGV
            };
            using (var db = new TTTA_DBEntities())
            {
                db.Entry(giangVien).State = System.Data.Entity.EntityState.Deleted;
                return db.SaveChanges() > 0;
            }
        }
        public List<GiangVien> getLisGiangVien()
        {
            using (var db = new TTTA_DBEntities())
            {
                return db.GiangViens.ToList();
            }
        }
    }
}
