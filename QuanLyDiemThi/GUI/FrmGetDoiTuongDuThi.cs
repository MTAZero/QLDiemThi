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
    public partial class FrmGetDoiTuongDuThi : Form
    {
        public FrmGetDoiTuongDuThi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB.IDDoiTuongDuThi = (int) txtDoiTuongID.Value;
            this.Close();
        }
    }
}
