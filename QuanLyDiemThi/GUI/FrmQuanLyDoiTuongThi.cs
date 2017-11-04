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
    public partial class FrmQuanLyDoiTuongThi : Form
    {
        public FrmQuanLyDoiTuongThi()
        {
            InitializeComponent();
        }

        #region LoadForm

        private void LoadDsDTUT()
        {
            txtDsDoiTuong.Text = "";

            // thêm tiêu đề
            string s = "";

            string ID = StringHelper.StringWithLength("Mã ĐTƯT", 8);
            string Ten = StringHelper.StringWithLength("Tên đối tượng", 58);
            string DiemUT = StringHelper.StringWithLength("Điểm ưu tiên", 19);

            s = String.Format("| {3,-5} | {0,-8} | {1,-58} | {2,-19} |", ID, Ten, DiemUT, "STT");

            txtDsDoiTuong.AppendText(s + Environment.NewLine);

            // thêm các cột
            int stt = 1;
            foreach(DoiTuongDuThi item in DB.DoiTuongDuThis)
            {
                s = "";
                
                ID = StringHelper.StringWithLength(item.ID.ToString(), 8);
                Ten = StringHelper.StringWithLengthLeft(item.Ten.ToString(), 58);
                DiemUT = StringHelper.StringWithLength(item.DiemUT.ToString(), 19);

                s = String.Format("| {3,-5} | {0,-8} | {1,-58} | {2,-19} |", ID, Ten, DiemUT, stt++);

                txtDsDoiTuong.AppendText(s + Environment.NewLine);
            }
        }
        private void FrmQuanLySinhVien_Load(object sender, EventArgs e)
        {
            LoadDsDTUT();
        }
        #endregion

        #region sự kiện
        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog a = new OpenFileDialog();
            a.Filter = "Txt File | *.txt";
            a.ShowDialog();

            string err = "";
            bool  ok = DB.ImportDoiTuongDuThi(a.FileName, ref err);

            if (ok == true)
            {
                MessageBox.Show("Import danh sách đối tượng ưu tiên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDsDTUT();
                return;
            }
            else
            {
                MessageBox.Show("Import danh sách đối tượng ưu tiên thất bại\n"+err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            SaveFileDialog a = new SaveFileDialog();
            a.Filter = "Txt File | *.txt";
            a.ShowDialog();

            string err = "";
            bool ok = DB.SaveDoiTuongDuThi(a.FileName, ref err);

            if (ok == true)
            {
                MessageBox.Show("Lưu danh sách đối tượng ưu tiên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                MessageBox.Show("Lưu danh sách đối tượng ưu tiên thất bại\n" + err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FrmThemSinhvien form = new FrmThemSinhvien();

            int n = DB.SinhViens.ToList().Count;
            form.ShowDialog();
            if (DB.SinhViens.ToList().Count != n)
                LoadDsDTUT();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            FrmXoaSinhVien form = new FrmXoaSinhVien();

            int n = DB.SinhViens.ToList().Count;
            form.ShowDialog();
            if (DB.SinhViens.ToList().Count != n)
                LoadDsDTUT();
        }
        #endregion
    }
}
