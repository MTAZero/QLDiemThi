namespace QuanLyDiemThi.GUI
{
    partial class FrmTraCuuDiemThi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnTatCaHocSinh = new System.Windows.Forms.Button();
            this.btnHocSinhKhaGioi = new System.Windows.Forms.Button();
            this.btnHocSinhTruot = new System.Windows.Forms.Button();
            this.btnHocSinhThuKhoa = new System.Windows.Forms.Button();
            this.btnTheoDoiTuongDuThi = new System.Windows.Forms.Button();
            this.btnTheoTungThiSinh = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMain = new System.Windows.Forms.TextBox();
            this.btnMo = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1105, 709);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.btnTheoTungThiSinh);
            this.panel2.Controls.Add(this.btnTheoDoiTuongDuThi);
            this.panel2.Controls.Add(this.btnHocSinhThuKhoa);
            this.panel2.Controls.Add(this.btnHocSinhTruot);
            this.panel2.Controls.Add(this.btnHocSinhKhaGioi);
            this.panel2.Controls.Add(this.btnTatCaHocSinh);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1103, 75);
            this.panel2.TabIndex = 0;
            // 
            // btnTatCaHocSinh
            // 
            this.btnTatCaHocSinh.Location = new System.Drawing.Point(11, 11);
            this.btnTatCaHocSinh.Name = "btnTatCaHocSinh";
            this.btnTatCaHocSinh.Size = new System.Drawing.Size(169, 50);
            this.btnTatCaHocSinh.TabIndex = 0;
            this.btnTatCaHocSinh.Text = "Điểm tất cả học sinh";
            this.btnTatCaHocSinh.UseVisualStyleBackColor = true;
            this.btnTatCaHocSinh.Click += new System.EventHandler(this.btnTatCaHocSinh_Click);
            // 
            // btnHocSinhKhaGioi
            // 
            this.btnHocSinhKhaGioi.Location = new System.Drawing.Point(193, 11);
            this.btnHocSinhKhaGioi.Name = "btnHocSinhKhaGioi";
            this.btnHocSinhKhaGioi.Size = new System.Drawing.Size(169, 50);
            this.btnHocSinhKhaGioi.TabIndex = 1;
            this.btnHocSinhKhaGioi.Text = "Học sinh khá giỏi";
            this.btnHocSinhKhaGioi.UseVisualStyleBackColor = true;
            this.btnHocSinhKhaGioi.Click += new System.EventHandler(this.btnHocSinhKhaGioi_Click);
            // 
            // btnHocSinhTruot
            // 
            this.btnHocSinhTruot.Location = new System.Drawing.Point(375, 11);
            this.btnHocSinhTruot.Name = "btnHocSinhTruot";
            this.btnHocSinhTruot.Size = new System.Drawing.Size(169, 50);
            this.btnHocSinhTruot.TabIndex = 2;
            this.btnHocSinhTruot.Text = "Học sinh trượt";
            this.btnHocSinhTruot.UseVisualStyleBackColor = true;
            this.btnHocSinhTruot.Click += new System.EventHandler(this.btnHocSinhTruot_Click);
            // 
            // btnHocSinhThuKhoa
            // 
            this.btnHocSinhThuKhoa.Location = new System.Drawing.Point(557, 11);
            this.btnHocSinhThuKhoa.Name = "btnHocSinhThuKhoa";
            this.btnHocSinhThuKhoa.Size = new System.Drawing.Size(169, 50);
            this.btnHocSinhThuKhoa.TabIndex = 3;
            this.btnHocSinhThuKhoa.Text = "Học sinh thủ khoa";
            this.btnHocSinhThuKhoa.UseVisualStyleBackColor = true;
            this.btnHocSinhThuKhoa.Click += new System.EventHandler(this.btnHocSinhThuKhoa_Click);
            // 
            // btnTheoDoiTuongDuThi
            // 
            this.btnTheoDoiTuongDuThi.Location = new System.Drawing.Point(739, 11);
            this.btnTheoDoiTuongDuThi.Name = "btnTheoDoiTuongDuThi";
            this.btnTheoDoiTuongDuThi.Size = new System.Drawing.Size(169, 50);
            this.btnTheoDoiTuongDuThi.TabIndex = 4;
            this.btnTheoDoiTuongDuThi.Text = "Theo đối tượng dự thi";
            this.btnTheoDoiTuongDuThi.UseVisualStyleBackColor = true;
            this.btnTheoDoiTuongDuThi.Click += new System.EventHandler(this.btnTheoDoiTuongDuThi_Click);
            // 
            // btnTheoTungThiSinh
            // 
            this.btnTheoTungThiSinh.Location = new System.Drawing.Point(921, 11);
            this.btnTheoTungThiSinh.Name = "btnTheoTungThiSinh";
            this.btnTheoTungThiSinh.Size = new System.Drawing.Size(169, 50);
            this.btnTheoTungThiSinh.TabIndex = 5;
            this.btnTheoTungThiSinh.Text = "Theo từng thí sinh";
            this.btnTheoTungThiSinh.UseVisualStyleBackColor = true;
            this.btnTheoTungThiSinh.Click += new System.EventHandler(this.btnTheoTungThiSinh_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.btnLuu);
            this.panel3.Controls.Add(this.btnMo);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 655);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1103, 52);
            this.panel3.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox1.Controls.Add(this.txtMain);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1103, 580);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách điểm thi";
            // 
            // txtMain
            // 
            this.txtMain.BackColor = System.Drawing.Color.White;
            this.txtMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMain.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMain.Location = new System.Drawing.Point(3, 22);
            this.txtMain.Multiline = true;
            this.txtMain.Name = "txtMain";
            this.txtMain.ReadOnly = true;
            this.txtMain.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMain.Size = new System.Drawing.Size(1097, 555);
            this.txtMain.TabIndex = 2;
            // 
            // btnMo
            // 
            this.btnMo.Location = new System.Drawing.Point(739, 6);
            this.btnMo.Name = "btnMo";
            this.btnMo.Size = new System.Drawing.Size(169, 38);
            this.btnMo.TabIndex = 6;
            this.btnMo.Text = "Mở file";
            this.btnMo.UseVisualStyleBackColor = true;
            this.btnMo.Click += new System.EventHandler(this.btnMo_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(921, 6);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(169, 38);
            this.btnLuu.TabIndex = 7;
            this.btnLuu.Text = "Lưu file";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // FrmTraCuuDiemThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 709);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTraCuuDiemThi";
            this.Text = "FrmTraCuuDiemThi";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnTatCaHocSinh;
        private System.Windows.Forms.Button btnHocSinhTruot;
        private System.Windows.Forms.Button btnHocSinhKhaGioi;
        private System.Windows.Forms.Button btnHocSinhThuKhoa;
        private System.Windows.Forms.Button btnTheoDoiTuongDuThi;
        private System.Windows.Forms.Button btnTheoTungThiSinh;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMain;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnMo;
    }
}