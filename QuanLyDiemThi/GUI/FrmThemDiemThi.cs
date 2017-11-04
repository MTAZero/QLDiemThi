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
    public partial class FrmThemDiemThi : Form
    {
        public FrmThemDiemThi()
        {
            InitializeComponent();
        }

        #region Hàm chức năng
        private bool Check()
        {
            // check SBD
            if (txtSBD.Text == "")
            {
                MessageBox.Show("Số báo danh của thí sinh không được để trống",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }

            // check Toán
            try
            {
                float toan = float.Parse(txtToan.Text);
            }
            catch
            {
                MessageBox.Show("Điểm toán của thí sinh phải là số thực",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }

            // check Văn
            try
            {
                float toan = float.Parse(txtVan.Text);
            }
            catch
            {
                MessageBox.Show("Điểm văn của thí sinh phải là số thực",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }

            // check Anh
            try
            {
                float toan = float.Parse(txtAnh.Text);
            }
            catch
            {
                MessageBox.Show("Điểm Anh của thí sinh phải là số thực",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }

            // check STT
            try
            {
                int stt = Int32.Parse(txtSTT.Text);
                if (stt < 1 || stt > DB.DiemThis.Count + 1) stt = 1 / (stt - stt);
            }
            catch
            {
                MessageBox.Show("STT sau khi thêm của điểm thi phải từ 1 đến số điểm thi cũ + 1",
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
                    DiemThi tg = new DiemThi();
                    tg.SBD = Int32.Parse(txtSBD.Text);
                    tg.Toan = float.Parse(txtToan.Text);
                    tg.Van = float.Parse(txtVan.Text);
                    tg.Anh = float.Parse(txtAnh.Text);

                    int STT = Int32.Parse(txtSTT.Text);

                    List<DiemThi> temp = new List<DiemThi>();
                    for (int i = 1; i < STT; i++)
                        temp.Add(DB.DiemThis[i - 1]);
                    temp.Add(tg);
                    for (int i = STT; i <= DB.DiemThis.Count; i++)
                        temp.Add(DB.DiemThis[i - 1]);

                    DB.DiemThis = temp;

                    MessageBox.Show("Thêm điểm thi thành công",
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
