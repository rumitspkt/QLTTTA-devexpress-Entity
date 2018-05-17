using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DevExpress.XtraPrinting.Native;

namespace QLTTTA.BUS
{
    public class KhoaHocBUS
    {
        private static KhoaHocBUS instance;

        public static KhoaHocBUS Instance
        {
            get { if (instance == null) instance = new KhoaHocBUS(); return instance; }
            private set { instance = value; }
        }

        private KhoaHocBUS() { }
        public List<KhoaHoc> getListKhoaHocByMaGV(int maGV)
        {
            List<KhoaHoc> listKH = new List<KhoaHoc>();
            using (var db = new TTTA_DBEntities())
            {
                db.GiangViens.Include("LopHocs.KhoaHoc1").SingleOrDefault(x => x.MaGV == maGV).LopHocs.ToList().ForEach(x => { if (!listKH.Any(y => y.MaKH == x.KhoaHoc)) listKH.Add(x.KhoaHoc1); });
            }

            return listKH.ToList();
        }
        public List<KhoaHoc> getListKhoaHoc()
        {
            using (var db = new TTTA_DBEntities())
            {
                return db.KhoaHocs.ToList();
            }


        }
        public List<KhoaHoc> getListKhoaHocHoanThanh()
        {
            using (var db = new TTTA_DBEntities())
            {
                return db.KhoaHocs.Where(x => x.TinhTrang.Equals("Hoan thanh")).ToList();
            }
        }
        public List<KhoaHoc> getListKhoaHocChuaHoanThanh()
        {
            using (var db = new TTTA_DBEntities())
            {
                return db.KhoaHocs.Where(x => x.TinhTrang.Equals("Chua hoan thanh")).ToList();
            }
        }
        public KhoaHoc getKhoaHoc(int maKH)
        {
            using (var db = new TTTA_DBEntities())
            {
                return db.KhoaHocs.SingleOrDefault(x => x.MaKH == maKH);
            }
        }
        public bool themKhoaHoc(int maKH, DateTime ngayBatDau, int soTuanHoc, string tinhTrang)
        {
            KhoaHoc khoaHoc = new KhoaHoc()
            {
                MaKH = maKH,
                NgayBatDau = ngayBatDau,
                SoTuanHoc = soTuanHoc,
                TinhTrang = tinhTrang
            };
            using (var db = new TTTA_DBEntities())
            {
                db.KhoaHocs.Add(khoaHoc);
                return db.SaveChanges() > 0;
            }
        }
        public bool capNhatKhoaHoc(int maKH, DateTime ngayBatDau, int soTuanHoc, string tinhTrang)
        {
            KhoaHoc khoaHoc = new KhoaHoc()
            {
                MaKH = maKH,
                NgayBatDau = ngayBatDau,
                SoTuanHoc = soTuanHoc,
                TinhTrang = tinhTrang
            };
            using (var db = new TTTA_DBEntities())
            {
                db.Entry(khoaHoc).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
        }
        public bool xoaKhoaHoc(int maKH)
        {
            KhoaHoc khoaHoc = new KhoaHoc()
            {
                MaKH = maKH
            };
            using (var db = new TTTA_DBEntities())
            {
                db.Entry(khoaHoc).State = System.Data.Entity.EntityState.Deleted;
                return db.SaveChanges() > 0;
            }
        }
    }
}
