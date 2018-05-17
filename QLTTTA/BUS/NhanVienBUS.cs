using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace QLTTTA.BUS
{
    public class NhanVienBUS
    {
        private static NhanVienBUS instance;

        public static NhanVienBUS Instance
        {
            get { if (instance == null) instance = new NhanVienBUS(); return instance; }
            private set { instance = value; }
        }

        private NhanVienBUS() { }

        public NhanVien getNhanVien(string mail)
        {
            using (var db = new TTTA_DBEntities())
            {
                return db.NhanViens.SingleOrDefault(x => x.Mail == mail);
            }
        }


    }
}
