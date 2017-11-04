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
    public partial class FrmXoaSinhVien : Form
    {
        public FrmXoaSinhVien()
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
                MessageBox.Show("Số thứ tự của sinh viên bị xóa phải là số nguyên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (index> DB.SinhViens.Count || index<1)
            {
                MessageBox.Show("STT của sinh viên bị xóa phải nằm trong khoảng 0 đến số lượng sinh viên",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            SinhVien a = DB.SinhViens[index - 1];
            DB.SinhViens.Remove(a);

            MessageBox.Show("Xóa thông tin sinh viên thành công",
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
