using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTTTA.BUS
{
    public class KetQuaBUS
    {
        private static KetQuaBUS instance;

        public static KetQuaBUS Instance
        {
            get { if (instance == null) instance = new KetQuaBUS(); return instance; }
            private set { instance = value; }
        }

        private KetQuaBUS() { }
        public KetQua getKetQua(int maHV, int maLH, int maKH)
        {
            using (var db = new TTTA_DBEntities())
            {
                return db.KetQuas.SingleOrDefault(
                    x => x.MaHocVien == maHV &&
                    x.MaLopHoc == maLH &&
                    x.MaKhoaHoc == maKH);
            }
        }
        public bool themKetQua(int maHV, int maLH, int maKH, float? diemGiuaKy, float? diemCuoiKy, float? diemTB)
        {
            KetQua ketQua = new KetQua()
            {
                MaHocVien = maHV,
                MaLopHoc = maLH,
                MaKhoaHoc = maKH,
                DiemGiuaKy = diemGiuaKy,
                DiemCuoiKy = diemCuoiKy,
                DiemTB = diemTB
            };
            using (var db = new TTTA_DBEntities())
            {
                db.KetQuas.Add(ketQua);
                return db.SaveChanges() > 0;
            }
        }
        public bool capNhatKetQua(int maHV, int maLH, int maKH, float? diemGiuaKy, float? diemCuoiKy, float? diemTB)
        {
            KetQua ketQua = new KetQua()
            {
                MaHocVien = maHV,
                MaLopHoc = maLH,
                MaKhoaHoc = maKH,
                DiemGiuaKy = diemGiuaKy,
                DiemCuoiKy = diemCuoiKy,
                DiemTB = diemTB
            };
            using (var db = new TTTA_DBEntities())
            {
                db.Entry(ketQua).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
        }
        public bool xoaKetQua(int maHV, int maLH, int maKH)
        {
            KetQua ketQua = new KetQua()
            {
                MaHocVien = maHV,
                MaLopHoc = maLH,
                MaKhoaHoc = maKH
            };
            using (var db = new TTTA_DBEntities())
            {
                db.Entry(ketQua).State = System.Data.Entity.EntityState.Deleted;
                return db.SaveChanges() > 0;
            }
        }
        public List<KetQua> getListKetQua(int makh, int malh)
        {
            using (var db = new TTTA_DBEntities())
            {
                return db.KetQuas.Include("HocVien").Where(x => x.MaKhoaHoc == makh && x.MaLopHoc == malh).ToList();
            }
        }
        public int tinhDiemTB(int maLH, int maKH)
        {
            using (var db = new TTTA_DBEntities())
            {
                db.KetQuas.Where(x => x.MaKhoaHoc == maKH && x.MaLopHoc == maLH).ToList().
                    ForEach(x =>
                    {
                        x.DiemTB = (x.DiemCuoiKy + x.DiemGiuaKy) / 2;
                        db.Entry(x).State = System.Data.Entity.EntityState.Modified;
                    });

                return db.SaveChanges();
            }
        }
    }
}
