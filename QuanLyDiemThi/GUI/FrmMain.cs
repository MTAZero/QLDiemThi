using QuanLyDiemThi.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDiemThi
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        #region LoadForm
        private void FrmMain_Load(object sender, EventArgs e)
        {
            
            


        }
        #endregion

        #region sự kiện
        private void btnQLSinhVien_Click(object sender, EventArgs e)
        {
            FrmQuanLySinhVien form = new FrmQuanLySinhVien();
            panelMain.Controls.Clear();
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            panelMain.Controls.Add(form);
            form.Show();
        }

        private void btnQuanLyDoiTuongThi_Click(object sender, EventArgs e)
        {
            FrmQuanLyDoiTuongThi form = new FrmQuanLyDoiTuongThi();
            panelMain.Controls.Clear();
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            panelMain.Controls.Add(form);
            form.Show();
        }

        private void btnQuanLyDiemThi_Click(object sender, EventArgs e)
        {
            FrmQuanLyDiemThi form = new FrmQuanLyDiemThi();
            panelMain.Controls.Clear();
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            panelMain.Controls.Add(form);
            form.Show();
        }
        #endregion

        private void btnTraCuuDiemThi_Click(object sender, EventArgs e)
        {
            FrmTraCuuDiemThi form = new FrmTraCuuDiemThi();
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(form);
            form.Show();
        }
    }
}
