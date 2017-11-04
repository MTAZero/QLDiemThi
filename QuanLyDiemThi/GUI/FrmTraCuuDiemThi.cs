using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDiemThi.GUI
{
    public partial class FrmTraCuuDiemThi : Form
    {
        #region constructor
        public FrmTraCuuDiemThi()
        {
            InitializeComponent();
        }
        #endregion

        #region Hàm chức năng
        private float gtnn(float a, float b, float c)
        {
            float ans = a;
            if (a < b) ans = b;
            if (c < ans) ans = c;
            return ans;
        }

        private string XepLoaiz(float a, float b, float c, float diemut)
        {
            float dtn = gtnn(a, b, c);
            float tong = a + b + c + diemut;

            if (tong >= 24 && dtn >= 7) return "Giỏi";
            if (tong >= 21 && dtn >= 6) return "Khá";
            if (tong >= 15 && dtn >= 4) return "Trung Bình";
            return "Trượt";
        }

        private int SoTuoi(string a)
        {
            a = a.Trim();
            try
            {
                string format;
                CultureInfo provider = CultureInfo.InvariantCulture;
                format = "dd/MM/yyyy";

                DateTime k = DateTime.ParseExact(a, format, provider);
                return DateTime.Now.Year - k.Year;
            }
            catch
            {

            }
            return 1;
        }
        #endregion

        #region sự kiện
        private void btnTatCaHocSinh_Click(object sender, EventArgs e)
        {

            var ds = (
                        from doituong in DB.DoiTuongDuThis
                        from sv in DB.SinhViens.Where(p => p.DTUT == doituong.ID)
                        from diem in DB.DiemThis.Where(p => p.SBD == sv.SBD)
                        orderby -(diem.Toan + diem.Van + diem.Anh + doituong.DiemUT)
                        select new
                        {
                            SBD = sv.SBD,
                            Ho = sv.Ho,
                            Ten = sv.Ten,
                            Phai = sv.GioiTinh == 0 ? "Nam" : "Nữ",
                            Tuoi = SoTuoi(sv.NgaySinh),
                            Toan = diem.Toan.ToString("0.00"),
                            Van = diem.Van.ToString("0.00"),
                            Anh = diem.Anh.ToString("0.00"),
                            DTN = gtnn(diem.Toan, diem.Van, diem.Anh).ToString("0.00"),
                            TongDiem = (diem.Toan + diem.Van + diem.Anh + doituong.DiemUT).ToString("0.00"),
                            XepLoai = XepLoaiz(diem.Toan, diem.Van, diem.Anh, doituong.DiemUT),
                            DoiTuongDT = doituong.ID
                        }
                     ).ToList();

            txtMain.Text = "";

            // thêm tiêu đề
            string str = "";
            string s = "";

            string STT = StringHelper.StringWithLength("STT", 5);
            string SBD = StringHelper.StringWithLength("SBD", 10);
            string Ho = StringHelper.StringWithLength("Họ", 15);
            string Ten = StringHelper.StringWithLength("Tên", 7);
            string Phai = StringHelper.StringWithLength("Phái", 4);
            string Tuoi = StringHelper.StringWithLength("Tuổi", 5);
            string Toan = StringHelper.StringWithLength("Toán", 5);
            string Van = StringHelper.StringWithLength("Văn", 5);
            string Anh = StringHelper.StringWithLength("Anh", 5);
            string DTN = StringHelper.StringWithLength("DTN", 5);
            string TongDiem = StringHelper.StringWithLength("Tổng", 6);
            string XepLoai = StringHelper.StringWithLength("Xếp Loại", 10);
            string DoiTuongDT = StringHelper.StringWithLength("Đối tượng", 10);

            s = String.Format("| {0,-5} | {1,-10} | {2,-15} | {3,-7} | {4,-4} | {5,-5} | {6,-5} | {7,-5} | {8,-5} | {9,-5} | {10,-6} | {11,-10} | {12,-10} |", STT, SBD, Ho, Ten, Phai, Tuoi, Toan, Van, Anh, DTN, TongDiem, XepLoai, DoiTuongDT);


            str += s + Environment.NewLine;
            // thêm các cột
            int stt = 1;
            foreach (var item in ds)
            {
                s = "";

                STT = StringHelper.StringWithLength((stt++).ToString(), 5);
                SBD = StringHelper.StringWithLength(item.SBD.ToString(), 10);
                Ho = StringHelper.StringWithLengthLeft(item.Ho, 15);
                Ten = StringHelper.StringWithLengthLeft(item.Ten, 7);
                Phai = StringHelper.StringWithLength(item.Phai, 4);
                Tuoi = StringHelper.StringWithLength(item.Tuoi.ToString(), 3);
                Toan = StringHelper.StringWithLength(item.Toan, 5);
                Van = StringHelper.StringWithLength(item.Van, 5);
                Anh = StringHelper.StringWithLength(item.Anh, 5);
                DTN = StringHelper.StringWithLength(item.DTN, 5);
                TongDiem = StringHelper.StringWithLength(item.TongDiem.ToString(), 6);
                XepLoai = StringHelper.StringWithLength(item.XepLoai, 10);
                DoiTuongDT = StringHelper.StringWithLength(item.DoiTuongDT.ToString(), 10);

                s = String.Format("| {0,-5} | {1,-10} | {2,-15} | {3,-7} | {4,-4} | {5,-5} | {6,-5} | {7,-5} | {8,-5} | {9,-5} | {10,-6} | {11,-10} | {12,-10} |", STT, SBD, Ho, Ten, Phai, Tuoi, Toan, Van, Anh, DTN, TongDiem, XepLoai, DoiTuongDT);

                str += s + Environment.NewLine;
            }

            txtMain.Text = str;
        }

        private void btnHocSinhKhaGioi_Click(object sender, EventArgs e)
        {
            var ds = (
                        from doituong in DB.DoiTuongDuThis
                        from sv in DB.SinhViens.Where(p => p.DTUT == doituong.ID)
                        from diem in DB.DiemThis.Where(p => p.SBD == sv.SBD)
                        where diem.Toan == 10 || diem.Van == 10 || diem.Anh == 10
                        orderby -(diem.Toan + diem.Van + diem.Anh + doituong.DiemUT)
                        select new
                        {
                            SBD = sv.SBD,
                            Ho = sv.Ho,
                            Ten = sv.Ten,
                            Phai = sv.GioiTinh == 0 ? "Nam" : "Nữ",
                            NTNS = sv.NgaySinh,
                            Toan = diem.Toan.ToString("0.00"),
                            Van = diem.Van.ToString("0.00"),
                            Anh = diem.Anh.ToString("0.00"),
                            DTN = gtnn(diem.Toan, diem.Van, diem.Anh).ToString("0.00"),
                            TongDiem = (diem.Toan + diem.Van + diem.Anh + doituong.DiemUT).ToString("0.00"),
                            XepLoai = XepLoaiz(diem.Toan, diem.Van, diem.Anh, doituong.DiemUT),
                            DoiTuongDT = doituong.ID
                        }
                     )
                     .OrderBy(p => p.XepLoai)
                     .ToList();

            txtMain.Text = "";

            // thêm tiêu đề
            string str = "";
            string s = "";

            string STT = StringHelper.StringWithLength("STT", 5);
            string SBD = StringHelper.StringWithLength("SBD", 10);
            string Ho = StringHelper.StringWithLength("Họ", 15);
            string Ten = StringHelper.StringWithLength("Tên", 7);
            string Phai = StringHelper.StringWithLength("Phái", 4);
            string Tuoi = StringHelper.StringWithLength("NTNS", 10);
            string Toan = StringHelper.StringWithLength("Toán", 5);
            string Van = StringHelper.StringWithLength("Văn", 5);
            string Anh = StringHelper.StringWithLength("Anh", 5);
            string DTN = StringHelper.StringWithLength("DTN", 5);
            string TongDiem = StringHelper.StringWithLength("Tổng", 6);
            string XepLoai = StringHelper.StringWithLength("Xếp Loại", 10);
            string DoiTuongDT = StringHelper.StringWithLength("Đối tượng", 10);

            s = String.Format("| {0,-5} | {1,-10} | {2,-15} | {3,-7} | {4,-4} | {5,-10} | {6,-5} | {7,-5} | {8,-5} | {10,-6} | {11,-10} | {12,-10} |", STT, SBD, Ho, Ten, Phai, Tuoi, Toan, Van, Anh, DTN, TongDiem, XepLoai, DoiTuongDT);


            str += s + Environment.NewLine;
            // thêm các cột
            int stt = 1;
            foreach (var item in ds)
            {
                s = "";

                STT = StringHelper.StringWithLength((stt++).ToString(), 5);
                SBD = StringHelper.StringWithLength(item.SBD.ToString(), 10);
                Ho = StringHelper.StringWithLengthLeft(item.Ho, 15);
                Ten = StringHelper.StringWithLengthLeft(item.Ten, 7);
                Phai = StringHelper.StringWithLength(item.Phai, 4);
                Tuoi = StringHelper.StringWithLength(item.NTNS.ToString(), 3);
                Toan = StringHelper.StringWithLength(item.Toan, 5);
                Van = StringHelper.StringWithLength(item.Van, 5);
                Anh = StringHelper.StringWithLength(item.Anh, 5);
                DTN = StringHelper.StringWithLength(item.DTN, 5);
                TongDiem = StringHelper.StringWithLength(item.TongDiem.ToString(), 6);
                XepLoai = StringHelper.StringWithLength(item.XepLoai, 10);
                DoiTuongDT = StringHelper.StringWithLength(item.DoiTuongDT.ToString(), 10);

                s = String.Format("| {0,-5} | {1,-10} | {2,-15} | {3,-7} | {4,-4} | {5,-5} | {6,-5} | {7,-5} | {8,-5} | {10,-6} | {11,-10} | {12,-10} |", STT, SBD, Ho, Ten, Phai, Tuoi, Toan, Van, Anh, DTN, TongDiem, XepLoai, DoiTuongDT);

                str += s + Environment.NewLine;
            }

            txtMain.Text = str;
        }

        private void btnHocSinhTruot_Click(object sender, EventArgs e)
        {
            var ds = (
                        from doituong in DB.DoiTuongDuThis
                        from sv in DB.SinhViens.Where(p => p.DTUT == doituong.ID)
                        from diem in DB.DiemThis.Where(p => p.SBD == sv.SBD)
                        orderby -(diem.Toan + diem.Van + diem.Anh + doituong.DiemUT)
                        select new
                        {
                            SBD = sv.SBD,
                            Ho = sv.Ho,
                            Ten = sv.Ten,
                            Phai = sv.GioiTinh == 0 ? "Nam" : "Nữ",
                            NTNS = sv.NgaySinh,
                            Toan = diem.Toan.ToString("0.00"),
                            Van = diem.Van.ToString("0.00"),
                            Anh = diem.Anh.ToString("0.00"),
                            DTN = gtnn(diem.Toan, diem.Van, diem.Anh).ToString("0.00"),
                            TongDiem = (diem.Toan + diem.Van + diem.Anh + doituong.DiemUT).ToString("0.00"),
                            XepLoai = XepLoaiz(diem.Toan, diem.Van, diem.Anh, doituong.DiemUT),
                            DoiTuongDT = doituong.ID
                        }
                     )
                     .ToList();

            ds = ds.Where(p => p.XepLoai == "Trượt").ToList();

            txtMain.Text = "";

            // thêm tiêu đề
            string str = "";
            string s = "";

            string STT = StringHelper.StringWithLength("STT", 5);
            string SBD = StringHelper.StringWithLength("SBD", 10);
            string Ho = StringHelper.StringWithLength("Họ", 15);
            string Ten = StringHelper.StringWithLength("Tên", 7);
            string Phai = StringHelper.StringWithLength("Phái", 4);
            string Tuoi = StringHelper.StringWithLength("NTNS", 10);
            string Toan = StringHelper.StringWithLength("Toán", 5);
            string Van = StringHelper.StringWithLength("Văn", 5);
            string Anh = StringHelper.StringWithLength("Anh", 5);
            string DTN = StringHelper.StringWithLength("DTN", 5);
            string TongDiem = StringHelper.StringWithLength("Tổng", 6);
            string XepLoai = StringHelper.StringWithLength("Xếp Loại", 10);
            string DoiTuongDT = StringHelper.StringWithLength("Đối tượng", 10);

            s = String.Format("| {0,-5} | {1,-10} | {2,-15} | {3,-7} | {4,-4} | {5,-10} | {6,-5} | {7,-5} | {8,-5} | {10,-6} | {11,-10} | {12,-10} |", STT, SBD, Ho, Ten, Phai, Tuoi, Toan, Van, Anh, DTN, TongDiem, XepLoai, DoiTuongDT);


            str += s + Environment.NewLine;
            // thêm các cột
            int stt = 1;
            foreach (var item in ds)
            {
                s = "";

                STT = StringHelper.StringWithLength((stt++).ToString(), 5);
                SBD = StringHelper.StringWithLength(item.SBD.ToString(), 10);
                Ho = StringHelper.StringWithLengthLeft(item.Ho, 15);
                Ten = StringHelper.StringWithLengthLeft(item.Ten, 7);
                Phai = StringHelper.StringWithLength(item.Phai, 4);
                Tuoi = StringHelper.StringWithLength(item.NTNS.ToString(), 3);
                Toan = StringHelper.StringWithLength(item.Toan, 5);
                Van = StringHelper.StringWithLength(item.Van, 5);
                Anh = StringHelper.StringWithLength(item.Anh, 5);
                DTN = StringHelper.StringWithLength(item.DTN, 5);
                TongDiem = StringHelper.StringWithLength(item.TongDiem.ToString(), 6);
                XepLoai = StringHelper.StringWithLength(item.XepLoai, 10);
                DoiTuongDT = StringHelper.StringWithLength(item.DoiTuongDT.ToString(), 10);

                s = String.Format("| {0,-5} | {1,-10} | {2,-15} | {3,-7} | {4,-4} | {5,-5} | {6,-5} | {7,-5} | {8,-5} | {10,-6} | {11,-10} | {12,-10} |", STT, SBD, Ho, Ten, Phai, Tuoi, Toan, Van, Anh, DTN, TongDiem, XepLoai, DoiTuongDT);

                str += s + Environment.NewLine;
            }

            txtMain.Text = str;
        }

        private void btnHocSinhThuKhoa_Click(object sender, EventArgs e)
        {
            var ds = (
                        from doituong in DB.DoiTuongDuThis
                        from sv in DB.SinhViens.Where(p => p.DTUT == doituong.ID)
                        from diem in DB.DiemThis.Where(p => p.SBD == sv.SBD)
                        orderby -(diem.Toan + diem.Van + diem.Anh + doituong.DiemUT)
                        select new
                        {
                            SBD = sv.SBD,
                            Ho = sv.Ho,
                            Ten = sv.Ten,
                            Phai = sv.GioiTinh == 0 ? "Nam" : "Nữ",
                            NTNS = sv.NgaySinh,
                            Toan = diem.Toan.ToString("0.00"),
                            Van = diem.Van.ToString("0.00"),
                            Anh = diem.Anh.ToString("0.00"),
                            DTN = gtnn(diem.Toan, diem.Van, diem.Anh).ToString("0.00"),
                            TongDiem = (diem.Toan + diem.Van + diem.Anh + doituong.DiemUT).ToString("0.00"),
                            XepLoai = XepLoaiz(diem.Toan, diem.Van, diem.Anh, doituong.DiemUT),
                            DoiTuongDT = doituong.ID
                        }
                     )
                     .Take(1)
                     .ToList();

            txtMain.Text = "";

            // thêm tiêu đề
            string str = "";
            string s = "";

            string STT = StringHelper.StringWithLength("STT", 5);
            string SBD = StringHelper.StringWithLength("SBD", 10);
            string Ho = StringHelper.StringWithLength("Họ", 15);
            string Ten = StringHelper.StringWithLength("Tên", 7);
            string Phai = StringHelper.StringWithLength("Phái", 4);
            string Tuoi = StringHelper.StringWithLength("NTNS", 10);
            string Toan = StringHelper.StringWithLength("Toán", 5);
            string Van = StringHelper.StringWithLength("Văn", 5);
            string Anh = StringHelper.StringWithLength("Anh", 5);
            string DTN = StringHelper.StringWithLength("DTN", 5);
            string TongDiem = StringHelper.StringWithLength("Tổng", 6);
            string XepLoai = StringHelper.StringWithLength("Xếp Loại", 10);
            string DoiTuongDT = StringHelper.StringWithLength("Đối tượng", 10);

            s = String.Format("| {0,-5} | {1,-10} | {2,-15} | {3,-7} | {4,-4} | {5,-10} | {6,-5} | {7,-5} | {8,-5} | {10,-6} | {11,-10} | {12,-10} |", STT, SBD, Ho, Ten, Phai, Tuoi, Toan, Van, Anh, DTN, TongDiem, XepLoai, DoiTuongDT);


            str += s + Environment.NewLine;
            // thêm các cột
            int stt = 1;
            foreach (var item in ds)
            {
                s = "";

                STT = StringHelper.StringWithLength((stt++).ToString(), 5);
                SBD = StringHelper.StringWithLength(item.SBD.ToString(), 10);
                Ho = StringHelper.StringWithLengthLeft(item.Ho, 15);
                Ten = StringHelper.StringWithLengthLeft(item.Ten, 7);
                Phai = StringHelper.StringWithLength(item.Phai, 4);
                Tuoi = StringHelper.StringWithLength(item.NTNS.ToString(), 3);
                Toan = StringHelper.StringWithLength(item.Toan, 5);
                Van = StringHelper.StringWithLength(item.Van, 5);
                Anh = StringHelper.StringWithLength(item.Anh, 5);
                DTN = StringHelper.StringWithLength(item.DTN, 5);
                TongDiem = StringHelper.StringWithLength(item.TongDiem.ToString(), 6);
                XepLoai = StringHelper.StringWithLength(item.XepLoai, 10);
                DoiTuongDT = StringHelper.StringWithLength(item.DoiTuongDT.ToString(), 10);

                s = String.Format("| {0,-5} | {1,-10} | {2,-15} | {3,-7} | {4,-4} | {5,-5} | {6,-5} | {7,-5} | {8,-5} | {10,-6} | {11,-10} | {12,-10} |", STT, SBD, Ho, Ten, Phai, Tuoi, Toan, Van, Anh, DTN, TongDiem, XepLoai, DoiTuongDT);

                str += s + Environment.NewLine;
            }

            txtMain.Text = str;
        }

        private void btnTheoDoiTuongDuThi_Click(object sender, EventArgs e)
        {

            FrmGetDoiTuongDuThi form = new FrmGetDoiTuongDuThi();
            form.ShowDialog();

            var ds = (
                        from doituong in DB.DoiTuongDuThis
                        from sv in DB.SinhViens.Where(p => p.DTUT == doituong.ID)
                        from diem in DB.DiemThis.Where(p => p.SBD == sv.SBD)
                        where doituong.ID == DB.IDDoiTuongDuThi
                        orderby -(diem.Toan + diem.Van + diem.Anh + doituong.DiemUT)
                        select new
                        {
                            SBD = sv.SBD,
                            Ho = sv.Ho,
                            Ten = sv.Ten,
                            Phai = sv.GioiTinh == 0 ? "Nam" : "Nữ",
                            NTNS = sv.NgaySinh,
                            Toan = diem.Toan.ToString("0.00"),
                            Van = diem.Van.ToString("0.00"),
                            Anh = diem.Anh.ToString("0.00"),
                            DTN = gtnn(diem.Toan, diem.Van, diem.Anh).ToString("0.00"),
                            TongDiem = (diem.Toan + diem.Van + diem.Anh + doituong.DiemUT).ToString("0.00"),
                            XepLoai = XepLoaiz(diem.Toan, diem.Van, diem.Anh, doituong.DiemUT),
                            DoiTuongDT = doituong.ID
                        }
                     )
                     .ToList();

            txtMain.Text = "";

            // thêm tiêu đề
            string str = "";
            string s = "";

            string STT = StringHelper.StringWithLength("STT", 5);
            string SBD = StringHelper.StringWithLength("SBD", 10);
            string Ho = StringHelper.StringWithLength("Họ", 15);
            string Ten = StringHelper.StringWithLength("Tên", 7);
            string Phai = StringHelper.StringWithLength("Phái", 4);
            string Tuoi = StringHelper.StringWithLength("NTNS", 10);
            string Toan = StringHelper.StringWithLength("Toán", 5);
            string Van = StringHelper.StringWithLength("Văn", 5);
            string Anh = StringHelper.StringWithLength("Anh", 5);
            string DTN = StringHelper.StringWithLength("DTN", 5);
            string TongDiem = StringHelper.StringWithLength("Tổng", 6);
            string XepLoai = StringHelper.StringWithLength("Xếp Loại", 10);
            string DoiTuongDT = StringHelper.StringWithLength("Đối tượng", 10);

            s = String.Format("| {0,-5} | {1,-10} | {2,-15} | {3,-7} | {4,-4} | {5,-10} | {6,-5} | {7,-5} | {8,-5} | {10,-6} | {11,-10} | {12,-10} |", STT, SBD, Ho, Ten, Phai, Tuoi, Toan, Van, Anh, DTN, TongDiem, XepLoai, DoiTuongDT);


            str += s + Environment.NewLine;
            // thêm các cột
            int stt = 1;
            foreach (var item in ds)
            {
                s = "";

                STT = StringHelper.StringWithLength((stt++).ToString(), 5);
                SBD = StringHelper.StringWithLength(item.SBD.ToString(), 10);
                Ho = StringHelper.StringWithLengthLeft(item.Ho, 15);
                Ten = StringHelper.StringWithLengthLeft(item.Ten, 7);
                Phai = StringHelper.StringWithLength(item.Phai, 4);
                Tuoi = StringHelper.StringWithLength(item.NTNS.ToString(), 3);
                Toan = StringHelper.StringWithLength(item.Toan, 5);
                Van = StringHelper.StringWithLength(item.Van, 5);
                Anh = StringHelper.StringWithLength(item.Anh, 5);
                DTN = StringHelper.StringWithLength(item.DTN, 5);
                TongDiem = StringHelper.StringWithLength(item.TongDiem.ToString(), 6);
                XepLoai = StringHelper.StringWithLength(item.XepLoai, 10);
                DoiTuongDT = StringHelper.StringWithLength(item.DoiTuongDT.ToString(), 10);

                s = String.Format("| {0,-5} | {1,-10} | {2,-15} | {3,-7} | {4,-4} | {5,-5} | {6,-5} | {7,-5} | {8,-5} | {10,-6} | {11,-10} | {12,-10} |", STT, SBD, Ho, Ten, Phai, Tuoi, Toan, Van, Anh, DTN, TongDiem, XepLoai, DoiTuongDT);

                str += s + Environment.NewLine;
            }

            txtMain.Text = str;
        }

        private void btnTheoTungThiSinh_Click(object sender, EventArgs e)
        {
            var ds = (
                        from doituong in DB.DoiTuongDuThis
                        from sv in DB.SinhViens.Where(p => p.DTUT == doituong.ID)
                        from diem in DB.DiemThis.Where(p => p.SBD == sv.SBD)
                        orderby -(diem.Toan + diem.Van + diem.Anh + doituong.DiemUT)
                        select new
                        {
                            SBD = sv.SBD,
                            Ho = sv.Ho,
                            Ten = sv.Ten,
                            Phai = sv.GioiTinh == 0 ? "Anh" : "Chi",
                            NTNS = sv.NgaySinh,
                            Toan = diem.Toan.ToString("0.00"),
                            Van = diem.Van.ToString("0.00"),
                            Anh = diem.Anh.ToString("0.00"),
                            DTN = gtnn(diem.Toan, diem.Van, diem.Anh).ToString("0.00"),
                            TongDiem = (diem.Toan + diem.Van + diem.Anh + doituong.DiemUT).ToString("0.00"),
                            XepLoai = XepLoaiz(diem.Toan, diem.Van, diem.Anh, doituong.DiemUT),
                            DoiTuongDT = doituong.ID
                        }
                     )
                     .ToList();

            txtMain.Text = "";

            // thêm tiêu đề
            string str = "";
            string s = "";

            foreach (var item in ds)
            {
                s = "";
                s += "GIAY BAO DIEM" + Environment.NewLine;
                s += item.Phai + ": " + item.Ho + " " + item.Ten + Environment.NewLine;
                s += "So Bao Danh : " + item.SBD.ToString() + Environment.NewLine;
                s += "Toan : " + item.Toan.ToString() + Environment.NewLine;
                s += "Van : " + item.Van.ToString() + Environment.NewLine;
                s += "Anh Van : " + item.Anh.ToString() + Environment.NewLine;
                s += "Tong Diem : " + item.TongDiem.ToString() + Environment.NewLine;
                s += "Xep Loai : " + item.XepLoai.ToString() + Environment.NewLine;

                str += s + Environment.NewLine;
            }

            txtMain.Text = str;
        }

        private void btnMo_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog a = new OpenFileDialog();
                a.Filter = "Txt File | *.txt";
                a.ShowDialog();

                // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(a.FileName))
                {
                    txtMain.Text = sr.ReadToEnd();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog a = new SaveFileDialog();
                a.Filter = "Txt File | *.txt";
                a.ShowDialog();

                // Open the text file using a stream reader.
                using (StreamWriter sw = new StreamWriter(a.FileName))
                {
                    sw.WriteLine(txtMain.Text);

                    MessageBox.Show("Lưu file thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
    }
}
