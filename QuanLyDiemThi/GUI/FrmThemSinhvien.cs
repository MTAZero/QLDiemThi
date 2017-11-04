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
    public partial class FrmThemSinhvien : Form
    {
        public FrmThemSinhvien()
        {
            InitializeComponent();
        }

        #region Hàm chức năng
        private bool Check()
        {
            // check sbd
            if (txtSBD.Text == "")
            {
                MessageBox.Show("Số báo danh của thí sinh không được để trống",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }

            // check ho
            if (txtHo.Text == "")
            {
                MessageBox.Show("Họ của thí sinh không được để trống",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }

            // check ten
            if (txtTen.Text == "")
            {
                MessageBox.Show("Tên của thí sinh không được để trống",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }

            // check gioi tinh
            try
            {
                int gt = Int32.Parse(txtGioiTinh.Text);
                if (gt < 0 || gt > 1) gt = 1 / (gt - gt);
            }
            catch
            {
                MessageBox.Show("Định dạng của giới tính chưa chính xác",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }

            // check DTUT
            try
            {
                int dtut = Int32.Parse(txtDTUT.Text);
            }
            catch {
                MessageBox.Show("Đối tượng ưu tiên phải là số nguyên",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }

            // check STT
            try
            {
                int index = Int32.Parse(txtSTT.Text);
                if (index < 1 || index > DB.SinhViens.Count + 1) index = 1 / (index - index);
            }
            catch
            {
                MessageBox.Show("STT của thí sinh phải nằm trong khoảng từ 1 đến số lượng thí sinh cũ + 1",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        #endregion

        #region sự kiện
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                try
                {
                    SinhVien sv = new SinhVien();
                    sv.SBD = Int32.Parse(txtSBD.Text);
                    sv.Ho = txtHo.Text;
                    sv.Ten = txtTen.Text;
                    sv.NgaySinh = dateNgaySinh.Value.ToString("dd/MM/yyyy");
                    sv.DTUT = Int32.Parse(txtDTUT.Text);
                    sv.GioiTinh = Int32.Parse(txtGioiTinh.Text);

                    int STT = Int32.Parse(txtSTT.Text);

                    List<SinhVien> temp = new List<SinhVien>();
                    for (int i = 1; i < STT; i++)
                        temp.Add(DB.SinhViens[i - 1]);
                    temp.Add(sv);
                    for (int i = STT; i <= DB.SinhViens.Count; i++)
                        temp.Add(DB.SinhViens[i - 1]);

                    DB.SinhViens = temp;

                    MessageBox.Show("Thêm sinh viên thành công",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    this.Close();
                }
                catch
                {

                }
            }

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
