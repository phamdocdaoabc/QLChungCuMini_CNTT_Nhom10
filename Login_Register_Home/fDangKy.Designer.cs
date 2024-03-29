using System;

namespace QLChungCuMini
{
    partial class fDangKy
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
            this.btnDangKy = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDienThoai = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.txtPassLai = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtTaiKhoan = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDN = new System.Windows.Forms.Button();
            this.btnDK = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtMaQuanLy = new System.Windows.Forms.TextBox();
            this.btnDangKy.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDangKy
            // 
            this.btnDangKy.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnDangKy.Controls.Add(this.txtMaQuanLy);
            this.btnDangKy.Controls.Add(this.label11);
            this.btnDangKy.Controls.Add(this.label10);
            this.btnDangKy.Controls.Add(this.label9);
            this.btnDangKy.Controls.Add(this.txtEmail);
            this.btnDangKy.Controls.Add(this.label7);
            this.btnDangKy.Controls.Add(this.txtDienThoai);
            this.btnDangKy.Controls.Add(this.txtDiaChi);
            this.btnDangKy.Controls.Add(this.txtTen);
            this.btnDangKy.Controls.Add(this.txtPassLai);
            this.btnDangKy.Controls.Add(this.txtPass);
            this.btnDangKy.Controls.Add(this.txtTaiKhoan);
            this.btnDangKy.Controls.Add(this.label8);
            this.btnDangKy.Controls.Add(this.label6);
            this.btnDangKy.Controls.Add(this.label5);
            this.btnDangKy.Controls.Add(this.label4);
            this.btnDangKy.Controls.Add(this.label3);
            this.btnDangKy.Controls.Add(this.label2);
            this.btnDangKy.Controls.Add(this.label1);
            this.btnDangKy.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangKy.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDangKy.Location = new System.Drawing.Point(-1, 3);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(628, 592);
            this.btnDangKy.TabIndex = 0;
            this.btnDangKy.Paint += new System.Windows.Forms.PaintEventHandler(this.btnDangKy_Paint);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 60);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(166, 18);
            this.label10.TabIndex = 18;
            this.label10.Text = "I. Thông tin tài khoản";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 312);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(169, 18);
            this.label9.TabIndex = 17;
            this.label9.Text = "II. Thông tin các nhân";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(197, 462);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(386, 24);
            this.txtEmail.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 465);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 18);
            this.label7.TabIndex = 15;
            this.label7.Text = "Email*";
            // 
            // txtDienThoai
            // 
            this.txtDienThoai.Location = new System.Drawing.Point(197, 519);
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new System.Drawing.Size(386, 24);
            this.txtDienThoai.TabIndex = 14;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(197, 403);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(386, 24);
            this.txtDiaChi.TabIndex = 12;
            this.txtDiaChi.TextChanged += new System.EventHandler(this.txtDiaChi_TextChanged);
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(197, 344);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(386, 24);
            this.txtTen.TabIndex = 11;
            this.txtTen.Text = " ";
            this.txtTen.TextChanged += new System.EventHandler(this.txtTen_TextChanged);
            // 
            // txtPassLai
            // 
            this.txtPassLai.Location = new System.Drawing.Point(197, 205);
            this.txtPassLai.Name = "txtPassLai";
            this.txtPassLai.Size = new System.Drawing.Size(386, 24);
            this.txtPassLai.TabIndex = 10;
            this.txtPassLai.UseSystemPasswordChar = true;
            this.txtPassLai.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(197, 147);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(386, 24);
            this.txtPass.TabIndex = 9;
            this.txtPass.UseSystemPasswordChar = true;
            this.txtPass.TextChanged += new System.EventHandler(this.txtPass_TextChanged);
            // 
            // txtTaiKhoan
            // 
            this.txtTaiKhoan.Location = new System.Drawing.Point(197, 92);
            this.txtTaiKhoan.Name = "txtTaiKhoan";
            this.txtTaiKhoan.Size = new System.Drawing.Size(386, 24);
            this.txtTaiKhoan.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(31, 522);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 18);
            this.label8.TabIndex = 7;
            this.label8.Text = "Số điện thoại";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 406);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 18);
            this.label6.TabIndex = 5;
            this.label6.Text = "Địa chỉ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 347);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "Họ và tên*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(31, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mật khẩu nhập lại*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(31, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mật khẩu*";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(31, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên tài khoản*";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(155, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(335, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đăng Ký Tài Khoản Admin";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel2.Controls.Add(this.btnDN);
            this.panel2.Controls.Add(this.btnDK);
            this.panel2.Location = new System.Drawing.Point(0, 588);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(627, 64);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // btnDN
            // 
            this.btnDN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDN.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDN.Location = new System.Drawing.Point(428, 13);
            this.btnDN.Name = "btnDN";
            this.btnDN.Size = new System.Drawing.Size(107, 38);
            this.btnDN.TabIndex = 1;
            this.btnDN.Text = "Đăng Nhập";
            this.btnDN.UseVisualStyleBackColor = false;
            this.btnDN.Click += new System.EventHandler(this.btnDN_Click);
            // 
            // btnDK
            // 
            this.btnDK.BackColor = System.Drawing.Color.Cyan;
            this.btnDK.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDK.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDK.Location = new System.Drawing.Point(196, 13);
            this.btnDK.Name = "btnDK";
            this.btnDK.Size = new System.Drawing.Size(111, 38);
            this.btnDK.TabIndex = 0;
            this.btnDK.Text = "Đăng Ký";
            this.btnDK.UseVisualStyleBackColor = false;
            this.btnDK.Click += new System.EventHandler(this.btnDK_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label11.Location = new System.Drawing.Point(31, 267);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 18);
            this.label11.TabIndex = 19;
            this.label11.Text = "Mã quản lý*";
            // 
            // txtMaQuanLy
            // 
            this.txtMaQuanLy.Location = new System.Drawing.Point(197, 264);
            this.txtMaQuanLy.Name = "txtMaQuanLy";
            this.txtMaQuanLy.Size = new System.Drawing.Size(386, 24);
            this.txtMaQuanLy.TabIndex = 20;
            this.txtMaQuanLy.UseSystemPasswordChar = true;
            // 
            // fDangKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 650);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnDangKy);
            this.Name = "fDangKy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Ký";
            this.Load += new System.EventHandler(this.fDangKy_Load);
            this.btnDangKy.ResumeLayout(false);
            this.btnDangKy.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Panel btnDangKy;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPassLai;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtTaiKhoan;
        private System.Windows.Forms.TextBox txtDienThoai;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDK;
        private System.Windows.Forms.Button btnDN;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMaQuanLy;
        private System.Windows.Forms.Label label11;
    }
}