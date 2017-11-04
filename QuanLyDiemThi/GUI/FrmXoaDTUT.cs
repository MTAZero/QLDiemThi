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
    public partial class FrmXoaDTUT : Form
    {
        public FrmXoaDTUT()
        {
            InitializeComponent();
        }
        
        #region sự kiện
        private void btnXoa_Click(object sender, EventArgs e)
        {
            int index;
            try
            {
                index = Int32.Parse(txtSTT.Text);
            }
            catch
            {
                MessageBox.Show("Số thứ tự của đối tượng ưu tiên bị xóa phải là số nguyên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (index> DB.DoiTuongDuThis.Count || index<1)
            {
                MessageBox.Show("STT của đối tượng ưu tiên bị xóa phải nằm trong khoảng 0 đến số lượng đối tượng ưu tiên",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            DoiTuongDuThi a = DB.DoiTuongDuThis[index - 1];
            DB.DoiTuongDuThis.Remove(a);

            MessageBox.Show("Xóa thông tin đối tượng ưu tiên thành công",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
