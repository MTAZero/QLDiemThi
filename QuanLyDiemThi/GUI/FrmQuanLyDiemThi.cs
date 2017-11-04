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
    public partial class FrmQuanLyDiemThi : Form
    {
        public FrmQuanLyDiemThi()
        {
            InitializeComponent();
        }

        #region LoadForm

        private void LoadDsDiemThi()
        {
            txtDiemThi.Text = "";

            // thêm tiêu đề
            string s = "";

            string SBD = StringHelper.StringWithLength("SBD", 16);
            string Toan = StringHelper.StringWithLength("Điểm Toán", 18);
            string Van = StringHelper.StringWithLength("Điểm Văn", 18);
            string Anh = StringHelper.StringWithLength("Điểm Anh", 18);

            s = String.Format("| {4,-5} | {0,-16} | {1,-18} | {2,-18} | {3,-18} |", SBD, Toan, Van, Anh, "STT");

            txtDiemThi.AppendText(s + Environment.NewLine);

            // thêm các cột
            int stt = 1;
            foreach(DiemThi sv in DB.DiemThis)
            {
                s = "";

                SBD = StringHelper.StringWithLength(sv.SBD.ToString(), 16);
                Toan = StringHelper.StringWithLength(sv.Toan.ToString("0.00"), 18);
                Van = StringHelper.StringWithLength(sv.Van.ToString("0.00"), 18);
                Anh = StringHelper.StringWithLength(sv.Anh.ToString("0.00"), 18);

                s = String.Format("| {4,-5} | {0,-16} | {1,-18} | {2,-18} | {3,-18} |", SBD, Toan, Van, Anh, stt++);

                txtDiemThi.AppendText(s + Environment.NewLine);
            }
        }
        private void FrmQuanLySinhVien_Load(object sender, EventArgs e)
        {
            LoadDsDiemThi();
        }
        #endregion

        #region sự kiện
        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog a = new OpenFileDialog();
            a.Filter = "Txt File | *.txt";
            a.ShowDialog();

            string err = "";
            bool  ok = DB.ImportDiemThi(a.FileName, ref err);

            if (ok == true)
            {
                MessageBox.Show("Import danh sách điểm thi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDsDiemThi();
                return;
            }
            else
            {
                MessageBox.Show("Import danh sách điểm thi thất bại\n"+err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            SaveFileDialog a = new SaveFileDialog();
            a.Filter = "Txt File | *.txt";
            a.ShowDialog();

            string err = "";
            bool ok = DB.SaveDiemThi(a.FileName, ref err);

            if (ok == true)
            {
                MessageBox.Show("Lưu danh sách điểm thi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                MessageBox.Show("Lưu danh sách điểm thi thất bại\n" + err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FrmThemDiemThi form = new FrmThemDiemThi();

            int n = DB.DiemThis.ToList().Count;
            form.ShowDialog();
            if (DB.DiemThis.ToList().Count != n)
                LoadDsDiemThi();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            FrmXoaDiemThi form = new FrmXoaDiemThi();

            int n = DB.DiemThis.ToList().Count;
            form.ShowDialog();
            if (DB.DiemThis.ToList().Count != n)
                LoadDsDiemThi();
        }
        #endregion
    }
}
