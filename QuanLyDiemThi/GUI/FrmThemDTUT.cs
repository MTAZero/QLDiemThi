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
    public partial class FrmThemDTUT : Form
    {
        public FrmThemDTUT()
        {
            InitializeComponent();
        }

        #region Hàm chức năng
        private bool Check()
        {
            // check sbd
            try
            {
                int ma = Int32.Parse(txtMa.Text);
            }
            catch
            {
                MessageBox.Show("Mã của đối tượng dự thi phải là số nguyên",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }

            // check Ten
            if (txtTen.Text == "")
            {
                MessageBox.Show("Tên của đối tượng dự thi không được để trống",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }

            // check diemUT
            try
            {
                int diemUt = Int32.Parse(txtDiemUT.Text);
            }
            catch
            {
                MessageBox.Show("Điểm ưu tiên phải là số nguyên",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }

            

            // check STT
            try
            {
                int index = Int32.Parse(txtSTT.Text);
                if (index < 1 || index > DB.DoiTuongDuThis.Count + 1) index = 1 / (index - index);
            }
            catch
            {
                MessageBox.Show("STT sau khi thêm phải nằm trong khoảng từ 1 đến số lượng cũ + 1",
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
                    DoiTuongDuThi tg = new DoiTuongDuThi();
                    tg.ID = Int32.Parse(txtMa.Text);
                    tg.Ten = txtTen.Text;
                    tg.DiemUT = Int32.Parse(txtDiemUT.Text);

                    int STT = Int32.Parse(txtSTT.Text);

                    List<DoiTuongDuThi> temp = new List<DoiTuongDuThi>();
                    for (int i = 1; i < STT; i++)
                        temp.Add(DB.DoiTuongDuThis[i - 1]);
                    temp.Add(tg);
                    for (int i = STT; i <= DB.DoiTuongDuThis.Count; i++)
                        temp.Add(DB.DoiTuongDuThis[i - 1]);

                    DB.DoiTuongDuThis = temp;

                    MessageBox.Show("Thêm đối tượng dự thi thành công",
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
