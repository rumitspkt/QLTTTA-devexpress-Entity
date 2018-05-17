using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTTTA.BUS
{
    public class MonHocBUS
    {
        private static MonHocBUS instance;

        public static MonHocBUS Instance
        {
            get { if (instance == null) instance = new MonHocBUS(); return instance; }
            private set { instance = value; }
        }

        private MonHocBUS() { }
        public MonHoc getMonHoc(int maMH)
        {
            using (var db = new TTTA_DBEntities())
            {
                return db.MonHocs.SingleOrDefault(x => x.MaMH == maMH);
            }
        }
        public List<MonHoc> getListMonHoc()
        {
            using (var db = new TTTA_DBEntities())
            {
                return db.MonHocs.ToList();
            }
        }
        public bool themMonHoc(int maMH, string tenMH, int soGioHoc)
        {
            MonHoc monHoc = new MonHoc()
            {
                MaMH = maMH,
                TenMH = tenMH,
                SoGioHoc = soGioHoc
            };
            using (var db = new TTTA_DBEntities())
            {
                db.MonHocs.Add(monHoc);
                return db.SaveChanges() > 0;

            }
        }
        public bool capNhatMonHoc(int maMH, string tenMH, int soGioHoc)
        {
            MonHoc monHoc = new MonHoc()
            {
                MaMH = maMH,
                TenMH = tenMH,
                SoGioHoc = soGioHoc
            };
            using (var db = new TTTA_DBEntities())
            {
                db.Entry(monHoc).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
        }
        public bool xoaMonHoc(int maMH)
        {
            MonHoc monHoc = new MonHoc()
            {
                MaMH = maMH
            };
            using (var db = new TTTA_DBEntities())
            {
                db.Entry(monHoc).State = System.Data.Entity.EntityState.Deleted;
                return db.SaveChanges() > 0;
            }
        }

    }
}
