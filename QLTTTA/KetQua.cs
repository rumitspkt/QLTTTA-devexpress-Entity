//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLTTTA
{
    using System;
    using System.Collections.Generic;
    
    public partial class KetQua
    {
        public int MaHocVien { get; set; }
        public int MaLopHoc { get; set; }
        public int MaKhoaHoc { get; set; }
        public Nullable<double> DiemGiuaKy { get; set; }
        public Nullable<double> DiemCuoiKy { get; set; }
        public Nullable<double> DiemTB { get; set; }
    
        public virtual HocVien HocVien { get; set; }
        public virtual LopHoc LopHoc { get; set; }
    }
}
