namespace quanLyCuocGiaoHang
{
    partial class frmGiaohang
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
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTrangthai = new System.Windows.Forms.TextBox();
            this.gbInfor = new System.Windows.Forms.GroupBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNguoiNhan = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtKH = new System.Windows.Forms.TextBox();
            this.btnTimDon = new System.Windows.Forms.Button();
            this.txtMaDon = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.gbReality = new System.Windows.Forms.GroupBox();
            this.txtGhiChuThucTe = new System.Windows.Forms.TextBox();
            this.cboKetQuaGiao = new System.Windows.Forms.ComboBox();
            this.lbNote = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.gbSearch.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbInfor.SuspendLayout();
            this.gbReality.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSearch
            // 
            this.gbSearch.BackColor = System.Drawing.Color.White;
            this.gbSearch.Controls.Add(this.btnReset);
            this.gbSearch.Controls.Add(this.groupBox1);
            this.gbSearch.Controls.Add(this.gbInfor);
            this.gbSearch.Controls.Add(this.btnTimDon);
            this.gbSearch.Controls.Add(this.txtMaDon);
            this.gbSearch.Controls.Add(this.label1);
            this.gbSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbSearch.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSearch.Location = new System.Drawing.Point(0, 0);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(349, 450);
            this.gbSearch.TabIndex = 0;
            this.gbSearch.TabStop = false;
            this.gbSearch.Text = "Tra cứu đơn hàng";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTrangthai);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, 351);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(336, 93);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Trạng thái hiện tại";
            // 
            // txtTrangthai
            // 
            this.txtTrangthai.BackColor = System.Drawing.Color.White;
            this.txtTrangthai.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTrangthai.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTrangthai.ForeColor = System.Drawing.Color.Red;
            this.txtTrangthai.Location = new System.Drawing.Point(10, 35);
            this.txtTrangthai.Name = "txtTrangthai";
            this.txtTrangthai.ReadOnly = true;
            this.txtTrangthai.Size = new System.Drawing.Size(303, 27);
            this.txtTrangthai.TabIndex = 1;
            this.txtTrangthai.TabStop = false;
            // 
            // gbInfor
            // 
            this.gbInfor.Controls.Add(this.txtDiaChi);
            this.gbInfor.Controls.Add(this.label2);
            this.gbInfor.Controls.Add(this.label4);
            this.gbInfor.Controls.Add(this.txtNguoiNhan);
            this.gbInfor.Controls.Add(this.txtSDT);
            this.gbInfor.Controls.Add(this.label5);
            this.gbInfor.Controls.Add(this.label3);
            this.gbInfor.Controls.Add(this.txtKH);
            this.gbInfor.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbInfor.Location = new System.Drawing.Point(6, 143);
            this.gbInfor.Name = "gbInfor";
            this.gbInfor.Size = new System.Drawing.Size(337, 202);
            this.gbInfor.TabIndex = 2;
            this.gbInfor.TabStop = false;
            this.gbInfor.Text = "Thông tin khách hàng";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.BackColor = System.Drawing.Color.White;
            this.txtDiaChi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDiaChi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiaChi.Location = new System.Drawing.Point(120, 143);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.ReadOnly = true;
            this.txtDiaChi.Size = new System.Drawing.Size(193, 18);
            this.txtDiaChi.TabIndex = 1;
            this.txtDiaChi.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên khách hàng:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(60, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "Địa chỉ:";
            // 
            // txtNguoiNhan
            // 
            this.txtNguoiNhan.BackColor = System.Drawing.Color.White;
            this.txtNguoiNhan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNguoiNhan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNguoiNhan.Location = new System.Drawing.Point(120, 81);
            this.txtNguoiNhan.Name = "txtNguoiNhan";
            this.txtNguoiNhan.ReadOnly = true;
            this.txtNguoiNhan.Size = new System.Drawing.Size(193, 18);
            this.txtNguoiNhan.TabIndex = 1;
            this.txtNguoiNhan.TabStop = false;
            // 
            // txtSDT
            // 
            this.txtSDT.BackColor = System.Drawing.Color.White;
            this.txtSDT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSDT.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSDT.Location = new System.Drawing.Point(120, 112);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.ReadOnly = true;
            this.txtSDT.Size = new System.Drawing.Size(193, 18);
            this.txtSDT.TabIndex = 1;
            this.txtSDT.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(60, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "Mã KH:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Số điện thoại:";
            // 
            // txtKH
            // 
            this.txtKH.BackColor = System.Drawing.Color.White;
            this.txtKH.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtKH.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKH.Location = new System.Drawing.Point(120, 50);
            this.txtKH.Name = "txtKH";
            this.txtKH.ReadOnly = true;
            this.txtKH.Size = new System.Drawing.Size(193, 18);
            this.txtKH.TabIndex = 1;
            this.txtKH.TabStop = false;
            // 
            // btnTimDon
            // 
            this.btnTimDon.BackColor = System.Drawing.Color.Blue;
            this.btnTimDon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimDon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimDon.ForeColor = System.Drawing.Color.White;
            this.btnTimDon.Location = new System.Drawing.Point(220, 81);
            this.btnTimDon.Name = "btnTimDon";
            this.btnTimDon.Size = new System.Drawing.Size(91, 28);
            this.btnTimDon.TabIndex = 2;
            this.btnTimDon.Text = "Tìm đơn";
            this.btnTimDon.UseVisualStyleBackColor = false;
            this.btnTimDon.Click += new System.EventHandler(this.btnTimDon_Click);
            // 
            // txtMaDon
            // 
            this.txtMaDon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaDon.Location = new System.Drawing.Point(118, 50);
            this.txtMaDon.Name = "txtMaDon";
            this.txtMaDon.Size = new System.Drawing.Size(193, 25);
            this.txtMaDon.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập mã đơn: ";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.BackColor = System.Drawing.Color.Blue;
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirm.Location = new System.Drawing.Point(128, 389);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(317, 49);
            this.btnConfirm.TabIndex = 5;
            this.btnConfirm.Text = "Xác nhận && Cập nhật hệ thống";
            this.btnConfirm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // gbReality
            // 
            this.gbReality.BackColor = System.Drawing.Color.White;
            this.gbReality.Controls.Add(this.txtGhiChuThucTe);
            this.gbReality.Controls.Add(this.cboKetQuaGiao);
            this.gbReality.Controls.Add(this.btnConfirm);
            this.gbReality.Controls.Add(this.lbNote);
            this.gbReality.Controls.Add(this.label6);
            this.gbReality.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbReality.Enabled = false;
            this.gbReality.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbReality.Location = new System.Drawing.Point(349, 0);
            this.gbReality.Name = "gbReality";
            this.gbReality.Size = new System.Drawing.Size(451, 450);
            this.gbReality.TabIndex = 1;
            this.gbReality.TabStop = false;
            this.gbReality.Text = "Cập nhật kết quả thực tế";
            // 
            // txtGhiChuThucTe
            // 
            this.txtGhiChuThucTe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGhiChuThucTe.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGhiChuThucTe.Location = new System.Drawing.Point(26, 157);
            this.txtGhiChuThucTe.Multiline = true;
            this.txtGhiChuThucTe.Name = "txtGhiChuThucTe";
            this.txtGhiChuThucTe.Size = new System.Drawing.Size(413, 195);
            this.txtGhiChuThucTe.TabIndex = 3;
            // 
            // cboKetQuaGiao
            // 
            this.cboKetQuaGiao.BackColor = System.Drawing.Color.White;
            this.cboKetQuaGiao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKetQuaGiao.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboKetQuaGiao.ForeColor = System.Drawing.Color.Black;
            this.cboKetQuaGiao.FormattingEnabled = true;
            this.cboKetQuaGiao.Items.AddRange(new object[] {
            "Đã giao thành công",
            "Khách hẹn ngày giao lại",
            "Đơn hàng hoàn lại",
            "Đang vận chuyển",
            "Tiếp nhận"});
            this.cboKetQuaGiao.Location = new System.Drawing.Point(26, 81);
            this.cboKetQuaGiao.Name = "cboKetQuaGiao";
            this.cboKetQuaGiao.Size = new System.Drawing.Size(186, 25);
            this.cboKetQuaGiao.TabIndex = 2;
            // 
            // lbNote
            // 
            this.lbNote.AutoSize = true;
            this.lbNote.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNote.Location = new System.Drawing.Point(22, 129);
            this.lbNote.Name = "lbNote";
            this.lbNote.Size = new System.Drawing.Size(104, 19);
            this.lbNote.TabIndex = 0;
            this.lbNote.Text = "Ghi chú chi tiết:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(22, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 19);
            this.label6.TabIndex = 0;
            this.label6.Text = "Chọn trạng thái mới:";
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.White;
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.Black;
            this.btnReset.Location = new System.Drawing.Point(220, 115);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(91, 28);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Làm mới";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // frmGiaohang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gbReality);
            this.Controls.Add(this.gbSearch);
            this.Name = "frmGiaohang";
            this.Text = "Giao hàng thực tế";
            this.Load += new System.EventHandler(this.frmGiaohang_Load);
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbInfor.ResumeLayout(false);
            this.gbInfor.PerformLayout();
            this.gbReality.ResumeLayout(false);
            this.gbReality.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSearch;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.TextBox txtMaDon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTimDon;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtKH;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNguoiNhan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbInfor;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTrangthai;
        private System.Windows.Forms.GroupBox gbReality;
        private System.Windows.Forms.ComboBox cboKetQuaGiao;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtGhiChuThucTe;
        private System.Windows.Forms.Label lbNote;
        private System.Windows.Forms.Button btnReset;
    }
}