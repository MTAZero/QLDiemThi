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
    public partial class FrmXoaDiemThi : Form
    {
        public FrmXoaDiemThi()
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
                MessageBox.Show("Số thứ tự của Điểm thi bị xóa phải là số nguyên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (index> DB.DiemThis.Count || index<1)
            {
                MessageBox.Show("STT của Điểm thi bị xóa phải nằm trong khoảng 0 đến số lượng điểm thi",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            DiemThi a = DB.DiemThis[index - 1];
            DB.DiemThis.Remove(a);

            MessageBox.Show("Xóa thông tin điểm thi thành công",
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
