using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
namespace QLTTTA.BUS
{
    public class LopHocBUS
    {
        private static LopHocBUS instance;

        public static LopHocBUS Instance
        {
            get { if (instance == null) instance = new LopHocBUS(); return instance; }
            private set { instance = value; }
        }

        private LopHocBUS() { }
        public List<LopHoc> getListLopHocByMaKH_MaGV(int maKH, int maGV)
        {
            using (var db = new TTTA_DBEntities())
            {
                return db.LopHocs.Where(x => x.KhoaHoc == maKH && x.GiangVien == maGV).ToList();
            }
        }
        public List<LopHoc> getListLopHoc()
        {
            using (var db = new TTTA_DBEntities())
            {
                return db.LopHocs.ToList();
            }
        }
        public LopHoc getLopHoc(int maLH)
        {
            using (var db = new TTTA_DBEntities())
            {
                return db.LopHocs.SingleOrDefault(x => x.MaLH == maLH);
            }
        }
        public bool themLopHoc(int maLH, int khoaHoc, int monHoc, int giangVien, string caHoc, string ngayHoc, string soLuongHV, int soTien)
        {
            LopHoc lopHoc = new LopHoc()
            {
                MaLH = maLH,
                KhoaHoc = khoaHoc,
                MonHoc = monHoc,
                GiangVien = giangVien,
                CaHoc = caHoc,
                NgayHoc = ngayHoc,
                SoLuongHV = soLuongHV,
                SoTien = soTien
            };
            using (var db = new TTTA_DBEntities())
            {
                db.LopHocs.Add(lopHoc);
                return db.SaveChanges() > 0;
            }
        }
        public bool capNhatLopHoc(int maLH, int khoaHoc, int monHoc, int giangVien, string caHoc, string ngayHoc, string soLuongHV, int soTien)
        {
            LopHoc lopHoc = new LopHoc()
            {
                MaLH = maLH,
                KhoaHoc = khoaHoc,
                MonHoc = monHoc,
                GiangVien = giangVien,
                CaHoc = caHoc,
                NgayHoc = ngayHoc,
                SoLuongHV = soLuongHV,
                SoTien = soTien
            };
            using (var db = new TTTA_DBEntities())
            {
                db.Entry(lopHoc).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges() > 0;

            }
        }
        public bool xoaLopHoc(int maLH, int khoaHoc)
        {
            LopHoc lopHoc = new LopHoc()
            {
                MaLH = maLH,
                KhoaHoc = khoaHoc
            };
            using (var db = new TTTA_DBEntities())
            {
                db.Entry(lopHoc).State = System.Data.Entity.EntityState.Deleted;
                return db.SaveChanges() > 0;
            }
        }
        public List<LopHoc> getListLopHoc(int maKH)
        {
            using (var db = new TTTA_DBEntities())
            {
                return db.LopHocs.Where(x => x.KhoaHoc == maKH).ToList();
            }
        }
        public List<LopHoc> getListLopHocChiTiet(int maKH)
        {
            using (var db = new TTTA_DBEntities())
            {
                return db.LopHocs.Where(x => x.KhoaHoc == maKH).ToList();
            }
        }
        public List<LopHoc> getListLopHocChuaDK(int maHV, int maKH)
        {

            using (var db = new TTTA_DBEntities())
            {
                List<LopHoc> listDaDK = new List<LopHoc>();
                db.BienLaiHocPhis.Include("LopHoc").Where(x => x.MaKhoaHoc == maKH && x.MaHocVien == maHV).ToList().ForEach(x => listDaDK.Add(x.LopHoc));
                return db.LopHocs.Where(x => x.KhoaHoc == maKH).ToList().Except(listDaDK).ToList();
            }

        }
        public List<LopHoc> getListLopHocDaDK(int maHV, int maKH)
        {

            using (var db = new TTTA_DBEntities())
            {
                List<LopHoc> listDaDK = new List<LopHoc>();
                db.BienLaiHocPhis.Include("LopHoc").Where(x => x.MaKhoaHoc == maKH && x.MaHocVien == maHV).ToList().ForEach(x => listDaDK.Add(x.LopHoc));
                return listDaDK;
            }
        }
    }
}
