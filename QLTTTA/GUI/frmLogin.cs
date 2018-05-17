using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLTTTA.BUS;

namespace QLTTTA.GUI
{
   public partial class frmLogin : Form
   {
      public frmLogin()
      {
         InitializeComponent();
         edtMail.Text = "gv1@abc.com";
         edtMatKhau.Text = "123456";
         rdbGV.Checked = true;
         rdbNV.Checked = false;
      }

      private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
      {
         this.Dispose();
      }
      private void btnDangNhap_Click(object sender, EventArgs e)
      {
         labelControl1.Focus();
         string quyenDangNhap = rdbNV.Checked ? "nhanvien" : "giangvien";
         DangNhap taiKhoan = TaiKhoanBUS.Instance.xacThuc(edtMail.Text, edtMatKhau.Text, quyenDangNhap);
         if (taiKhoan != null)
         {
            frmMain frm = new frmMain(taiKhoan);
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.FormClosing += delegate { this.Show(); };
            frm.Show();
            this.Hide();
         }
         else
         {
            XtraMessageBox.Show("Sai địa chỉ mail hoặc mật khẩu", "Error");
            edtMail.Text = "";
            edtMatKhau.Text = "";
         }

      }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
