using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDiemThi.GUI
{
    public partial class FrmQuanLySinhVien : Form
    {
        public FrmQuanLySinhVien()
        {
            InitializeComponent();
        }

        #region LoadForm

        private void LoadDsSinhVien()
        {
            txtDsSinhVien.Text = "";

            // thêm tiêu đề
            string s = "";

            string SBD = StringHelper.StringWithLength("SBD", 16);
            string Ho = StringHelper.StringWithLength("Họ", 21);
            string Ten = StringHelper.StringWithLength("Tên", 12);
            string GioiTinh = StringHelper.StringWithLength("GT", 7);
            string NgaySInh = StringHelper.StringWithLength("Ngày sinh", 16);
            string DTUT = StringHelper.StringWithLength("ĐTƯT", 8);

            s = String.Format("| {6,-5} | {0,-16} | {1,-21} | {2,-12} | {3,-7} | {4,-16} | {5,-8} |", SBD, Ho, Ten, GioiTinh, NgaySInh, DTUT, "STT");

            txtDsSinhVien.AppendText(s + Environment.NewLine);

            // thêm các cột
            int stt = 1;
            foreach(SinhVien sv in DB.SinhViens)
            {
                s = "";

                SBD = StringHelper.StringWithLength(sv.SBD.ToString(), 16);
                Ho = StringHelper.StringWithLengthLeft(sv.Ho.ToString(), 21);
                Ten = StringHelper.StringWithLengthLeft(sv.Ten.ToString(), 12);
                GioiTinh = StringHelper.StringWithLength(sv.GioiTinh.ToString(), 7);
                NgaySInh = StringHelper.StringWithLength(sv.NgaySinh, 16);
                DTUT = StringHelper.StringWithLength(sv.DTUT.ToString(), 8);

                s = String.Format("| {6,-5} | {0,-16} | {1,-21} | {2,-12} | {3,-7} | {4,-16} | {5,-8} |", SBD, Ho, Ten, GioiTinh, NgaySInh, DTUT, stt++);

                txtDsSinhVien.AppendText(s + Environment.NewLine);
            }
        }
        private void FrmQuanLySinhVien_Load(object sender, EventArgs e)
        {
            LoadDsSinhVien();
        }
        #endregion

        #region sự kiện
        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog a = new OpenFileDialog();
            a.Filter = "Txt File | *.txt";
            a.ShowDialog();

            string err = "";
            bool  ok = DB.ImportSinhViens(a.FileName, ref err);

            if (ok == true)
            {
                MessageBox.Show("Import danh sách sinh viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDsSinhVien();
                return;
            }
            else
            {
                MessageBox.Show("Import danh sách sinh viên thất bại\n"+err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            SaveFileDialog a = new SaveFileDialog();
            a.Filter = "Txt File | *.txt";
            a.ShowDialog();

            string err = "";
            bool ok = DB.SaveSinhViens(a.FileName, ref err);

            if (ok == true)
            {
                MessageBox.Show("Lưu danh sách sinh viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                MessageBox.Show("Lưu danh sách sinh viên thất bại\n" + err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FrmThemSinhvien form = new FrmThemSinhvien();

            int n = DB.SinhViens.ToList().Count;
            form.ShowDialog();
            if (DB.SinhViens.ToList().Count != n)
                LoadDsSinhVien();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            FrmXoaSinhVien form = new FrmXoaSinhVien();

            int n = DB.SinhViens.ToList().Count;
            form.ShowDialog();
            if (DB.SinhViens.ToList().Count != n)
                LoadDsSinhVien();
        }
        #endregion
    }
}
