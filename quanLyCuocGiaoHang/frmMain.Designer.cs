namespace quanLyCuocGiaoHang
{
    partial class frmMain
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
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnAuth = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnDelivery = new System.Windows.Forms.Button();
            this.btnTheodoi = new System.Windows.Forms.Button();
            this.btnCalculater = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnKhachHang = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.panelMenu.Controls.Add(this.btnAuth);
            this.panelMenu.Controls.Add(this.btnReport);
            this.panelMenu.Controls.Add(this.btnDelivery);
            this.panelMenu.Controls.Add(this.btnTheodoi);
            this.panelMenu.Controls.Add(this.btnCalculater);
            this.panelMenu.Controls.Add(this.btnCreate);
            this.panelMenu.Controls.Add(this.btnKhachHang);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(206, 450);
            this.panelMenu.TabIndex = 0;
            // 
            // btnAuth
            // 
            this.btnAuth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAuth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.btnAuth.FlatAppearance.BorderSize = 0;
            this.btnAuth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAuth.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAuth.ForeColor = System.Drawing.Color.White;
            this.btnAuth.Location = new System.Drawing.Point(34, 324);
            this.btnAuth.Name = "btnAuth";
            this.btnAuth.Size = new System.Drawing.Size(125, 34);
            this.btnAuth.TabIndex = 7;
            this.btnAuth.Text = "Đăng nhập";
            this.btnAuth.UseVisualStyleBackColor = false;
            this.btnAuth.Click += new System.EventHandler(this.btnAuth_Click);
            // 
            // btnReport
            // 
            this.btnReport.Enabled = false;
            this.btnReport.FlatAppearance.BorderSize = 0;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.ForeColor = System.Drawing.Color.White;
            this.btnReport.Location = new System.Drawing.Point(22, 217);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(149, 34);
            this.btnReport.TabIndex = 6;
            this.btnReport.Text = "Chi tiết báo cáo";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnDelivery
            // 
            this.btnDelivery.Enabled = false;
            this.btnDelivery.FlatAppearance.BorderSize = 0;
            this.btnDelivery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelivery.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelivery.ForeColor = System.Drawing.Color.White;
            this.btnDelivery.Location = new System.Drawing.Point(22, 177);
            this.btnDelivery.Name = "btnDelivery";
            this.btnDelivery.Size = new System.Drawing.Size(149, 34);
            this.btnDelivery.TabIndex = 5;
            this.btnDelivery.Text = "Giao hàng";
            this.btnDelivery.UseVisualStyleBackColor = true;
            this.btnDelivery.Click += new System.EventHandler(this.btnDelivery_Click);
            // 
            // btnTheodoi
            // 
            this.btnTheodoi.Enabled = false;
            this.btnTheodoi.FlatAppearance.BorderSize = 0;
            this.btnTheodoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTheodoi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTheodoi.ForeColor = System.Drawing.Color.White;
            this.btnTheodoi.Location = new System.Drawing.Point(22, 137);
            this.btnTheodoi.Name = "btnTheodoi";
            this.btnTheodoi.Size = new System.Drawing.Size(149, 34);
            this.btnTheodoi.TabIndex = 4;
            this.btnTheodoi.Text = "Theo dõi đơn hàng";
            this.btnTheodoi.UseVisualStyleBackColor = true;
            this.btnTheodoi.Click += new System.EventHandler(this.btnTheoDoi_Click);
            // 
            // btnCalculater
            // 
            this.btnCalculater.Enabled = false;
            this.btnCalculater.FlatAppearance.BorderSize = 0;
            this.btnCalculater.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalculater.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalculater.ForeColor = System.Drawing.Color.White;
            this.btnCalculater.Location = new System.Drawing.Point(34, 97);
            this.btnCalculater.Name = "btnCalculater";
            this.btnCalculater.Size = new System.Drawing.Size(125, 34);
            this.btnCalculater.TabIndex = 3;
            this.btnCalculater.Text = "Tính cước";
            this.btnCalculater.UseVisualStyleBackColor = true;
            this.btnCalculater.Click += new System.EventHandler(this.btnCalculater_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Enabled = false;
            this.btnCreate.FlatAppearance.BorderSize = 0;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.ForeColor = System.Drawing.Color.White;
            this.btnCreate.Location = new System.Drawing.Point(34, 57);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(125, 34);
            this.btnCreate.TabIndex = 2;
            this.btnCreate.Text = "Tạo đơn hàng";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnKhachHang
            // 
            this.btnKhachHang.Enabled = false;
            this.btnKhachHang.FlatAppearance.BorderSize = 0;
            this.btnKhachHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKhachHang.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKhachHang.ForeColor = System.Drawing.Color.White;
            this.btnKhachHang.Location = new System.Drawing.Point(34, 17);
            this.btnKhachHang.Name = "btnKhachHang";
            this.btnKhachHang.Size = new System.Drawing.Size(125, 34);
            this.btnKhachHang.TabIndex = 1;
            this.btnKhachHang.Text = "Khách hàng";
            this.btnKhachHang.UseVisualStyleBackColor = true;
            this.btnKhachHang.Click += new System.EventHandler(this.btnKhachHang_Click);
            // 
            // panelMain
            // 
            this.panelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panelMain.Location = new System.Drawing.Point(206, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(594, 450);
            this.panelMain.TabIndex = 1;
            this.panelMain.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMain_Paint);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelMenu);
            this.Name = "frmMain";
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnTheodoi;
        private System.Windows.Forms.Button btnCalculater;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnKhachHang;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Button btnAuth;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnDelivery;
    }
}