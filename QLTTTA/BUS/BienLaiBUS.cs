using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace QLTTTA.BUS
{
    public class BienLaiBUS
    {
        private static BienLaiBUS instance;

        public static BienLaiBUS Instance
        {
            get { if (instance == null) instance = new BienLaiBUS(); return instance; }
            private set { instance = value; }
        }

        private BienLaiBUS() { }
        public bool themBienLai(int maHV, int maLH, int maKH, string hoaDon)
        {
            BienLaiHocPhi bienLai = new BienLaiHocPhi()
            {
                MaHocVien = maHV,
                MaLopHoc = maLH,
                MaKhoaHoc = maKH,
                HoaDon = hoaDon
            };
            using (var db = new TTTA_DBEntities())
            {
                db.BienLaiHocPhis.Add(bienLai);
                //db.Entry(bienLai).State = System.Data.Entity.EntityState.Added;
                return db.SaveChanges() > 0;

            }
        }
        public bool xoaBienLai(int maHV, int maLH, int maKH)
        {
            BienLaiHocPhi bienLai = new BienLaiHocPhi()
            {
                MaHocVien = maHV,
                MaLopHoc = maLH,
                MaKhoaHoc = maKH
            };
            using (var db = new TTTA_DBEntities())
            {
                db.Entry(bienLai).State = System.Data.Entity.EntityState.Deleted;
                return db.SaveChanges() > 0;
            }

        }
        public List<BienLaiHocPhi> getListBienLai(int maKH)
        {
            using (var db = new TTTA_DBEntities())
            {
                return db.BienLaiHocPhis.Where(x => x.MaKhoaHoc == maKH).ToList();
            }
        }
    }
}
