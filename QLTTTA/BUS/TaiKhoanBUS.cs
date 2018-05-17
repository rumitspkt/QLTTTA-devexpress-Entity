using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QLTTTA.BUS
{
    public class TaiKhoanBUS
    {
        private static TaiKhoanBUS instance;

        public static TaiKhoanBUS Instance
        {
            get { if (instance == null) instance = new TaiKhoanBUS(); return instance; }
            private set { instance = value; }
        }

        private TaiKhoanBUS() { }
        public DangNhap xacThuc(string mail, string matKhau, string quyenDangNhap)
        {
            using (var db = new TTTA_DBEntities())
            {
                return db.DangNhaps.Where(x => x.Mail == mail && x.MatKhau == matKhau && x.QuyenDangNhap == quyenDangNhap).FirstOrDefault();
            }

        }
        public bool doiMatKhau(DangNhap taiKhoan, string matKhauMoi)
        {
            using (var db = new TTTA_DBEntities())
            {
                var result = db.DangNhaps.SingleOrDefault(x => x.Mail == taiKhoan.Mail);
                if (result != null)
                {
                    result.MatKhau = matKhauMoi;
                    db.SaveChanges();
                }
                return false;
            }
        }
        public DangNhap getTaiKhoan(string mail)
        {
            using (var db = new TTTA_DBEntities())
            {
                return db.DangNhaps.SingleOrDefault(x => x.Mail == mail);
            }
        }
        public List<DangNhap> getListTaiKhoan()
        {
            using (var db = new TTTA_DBEntities())
            {
                return db.DangNhaps.ToList();
            }
        }
        public List<DangNhap> getListTaiKhoanGV()
        {
            using (var db = new TTTA_DBEntities())
            {
                return db.DangNhaps.Where(x => x.QuyenDangNhap == "giangvien").ToList();
            }
        }
        public List<DangNhap> getListTaiKhoanGVChuaDK()
        {
            //List<GiangVien> listGiangVien = GiangVienBUS.Instance.getLisGiangVien();
            
            //for (int i = 0; i < listTaiKhoan.Count; i++)
            //{
            //    bool flag = true;
            //    for (int j = 0; j < listGiangVien.Count; j++)
            //    {
            //        if (listTaiKhoan[i].Mail == listGiangVien[j].Mail)
            //        {
            //            flag = false;
            //            break;
            //        }
            //    }
            //    if (flag)
            //    {
            //        listTaiKhoancChuaDK.Add(listTaiKhoan[i]);
            //    }
            //}
            using (var db = new TTTA_DBEntities())
            {
                List<DangNhap> listTaiKhoanDaDK = new List<DangNhap>();
                db.GiangViens.Include("DangNhap").ToList().ForEach(x => listTaiKhoanDaDK.Add(x.DangNhap));
                db.NhanViens.Include("DangNhap").ToList().ForEach(x => listTaiKhoanDaDK.Add(x.DangNhap));

                return db.DangNhaps.ToList().Except(listTaiKhoanDaDK).ToList();
            }
            
        }
        public bool themTaiKhoan(string mail, string matKhau, string quyenDangNhap)
        {
            DangNhap dangnhap = new DangNhap()
            {
                Mail = mail,
                MatKhau = matKhau,
                QuyenDangNhap = quyenDangNhap
            };
            using (var db = new TTTA_DBEntities())
            {
                db.DangNhaps.Add(dangnhap);
                return db.SaveChanges() > 0;
            }
        }
        public bool capNhatTaiKhoan(string mail, string matKhau, string quyenDangNhap)
        {
            DangNhap dangnhap = new DangNhap()
            {
                Mail = mail,
                MatKhau = matKhau,
                QuyenDangNhap = quyenDangNhap
            };
            using (var db = new TTTA_DBEntities())
            { 
                db.Entry(dangnhap).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
        }
        public bool xoaTaiKhoan(string mail)
        {
            DangNhap dangnhap = new DangNhap()
            {
                Mail = mail,

            };
            using (var db = new TTTA_DBEntities())
            {
                db.DangNhaps.Attach(dangnhap);
                db.DangNhaps.Remove(dangnhap);
                return db.SaveChanges() > 0;
            }
        }
    }
}
