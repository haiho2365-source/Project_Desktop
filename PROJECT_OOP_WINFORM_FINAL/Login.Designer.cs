namespace PROJECT_OOP_WINFORM_FINAL
{
    partial class Login
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
            pnlLeft = new Panel();
            label2 = new Label();
            label1 = new Label();
            button5 = new Button();
            button4 = new Button();
            txtPassword = new TextBox();
            txtEmail = new TextBox();
            label4 = new Label();
            label3 = new Label();
            lblQuayLai = new Label();
            pnlChonQuyen = new Panel();
            button6 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            pnlNhapLieu = new Panel();
            pnlLeft.SuspendLayout();
            pnlChonQuyen.SuspendLayout();
            pnlNhapLieu.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLeft
            // 
            pnlLeft.BackColor = Color.FromArgb(0, 114, 118);
            pnlLeft.Controls.Add(label2);
            pnlLeft.Controls.Add(label1);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(350, 553);
            pnlLeft.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(255, 112, 67);
            label2.Location = new Point(117, 48);
            label2.Name = "label2";
            label2.Size = new Size(166, 48);
            label2.TabIndex = 2;
            label2.Text = "BẢN TIN";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(174, 48);
            label1.TabIndex = 1;
            label1.Text = "QUẢN LÝ";
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(255, 112, 67);
            button5.BackgroundImageLayout = ImageLayout.Center;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.ForeColor = Color.White;
            button5.Location = new Point(194, 360);
            button5.Name = "button5";
            button5.Size = new Size(350, 50);
            button5.TabIndex = 12;
            button5.Text = "ĐĂNG KÝ TÀI KHOẢN";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(0, 114, 118);
            button4.BackgroundImageLayout = ImageLayout.Center;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.White;
            button4.Location = new Point(194, 284);
            button4.Name = "button4";
            button4.Size = new Size(350, 50);
            button4.TabIndex = 11;
            button4.Text = "ĐĂNG NHẬP";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Location = new Point(251, 209);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(251, 34);
            txtPassword.TabIndex = 10;
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Location = new Point(251, 140);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(251, 34);
            txtEmail.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(115, 209);
            label4.Name = "label4";
            label4.Size = new Size(94, 28);
            label4.TabIndex = 8;
            label4.Text = "Mật khẩu";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(115, 140);
            label3.Name = "label3";
            label3.Size = new Size(94, 28);
            label3.TabIndex = 7;
            label3.Text = "Tài khoản";
            // 
            // lblQuayLai
            // 
            lblQuayLai.AutoSize = true;
            lblQuayLai.BackColor = Color.White;
            lblQuayLai.Location = new Point(6, 516);
            lblQuayLai.Name = "lblQuayLai";
            lblQuayLai.Size = new Size(83, 28);
            lblQuayLai.TabIndex = 6;
            lblQuayLai.Text = "Quay lại";
            lblQuayLai.Click += lblQuayLai_Click_1;
            // 
            // pnlChonQuyen
            // 
            pnlChonQuyen.Controls.Add(button6);
            pnlChonQuyen.Controls.Add(button3);
            pnlChonQuyen.Controls.Add(button2);
            pnlChonQuyen.Controls.Add(button1);
            pnlChonQuyen.Dock = DockStyle.Fill;
            pnlChonQuyen.Location = new Point(0, 0);
            pnlChonQuyen.Name = "pnlChonQuyen";
            pnlChonQuyen.Size = new Size(1021, 553);
            pnlChonQuyen.TabIndex = 1;
            pnlChonQuyen.Paint += pnlChonQuyen_Paint;
            // 
            // button6
            // 
            button6.BackColor = Color.FromArgb(0, 114, 118);
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.ForeColor = Color.White;
            button6.Location = new Point(517, 375);
            button6.Name = "button6";
            button6.Size = new Size(350, 50);
            button6.TabIndex = 3;
            button6.Text = "Đăng ký tài khoản";
            button6.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(198, 40, 40);
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = Color.White;
            button3.Location = new Point(517, 284);
            button3.Name = "button3";
            button3.Size = new Size(350, 50);
            button3.TabIndex = 2;
            button3.Text = "Độc giả đăng nhập";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(255, 112, 67);
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = Color.White;
            button2.Location = new Point(517, 187);
            button2.Name = "button2";
            button2.Size = new Size(350, 50);
            button2.TabIndex = 1;
            button2.Text = "Phóng viên đăng nhập";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(76, 175, 80);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.White;
            button1.Location = new Point(517, 87);
            button1.Name = "button1";
            button1.Size = new Size(350, 50);
            button1.TabIndex = 0;
            button1.Text = "Quản trị viên đăng nhập";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // pnlNhapLieu
            // 
            pnlNhapLieu.Controls.Add(button5);
            pnlNhapLieu.Controls.Add(txtPassword);
            pnlNhapLieu.Controls.Add(lblQuayLai);
            pnlNhapLieu.Controls.Add(button4);
            pnlNhapLieu.Controls.Add(label3);
            pnlNhapLieu.Controls.Add(label4);
            pnlNhapLieu.Controls.Add(txtEmail);
            pnlNhapLieu.Location = new Point(350, 0);
            pnlNhapLieu.Name = "pnlNhapLieu";
            pnlNhapLieu.Size = new Size(671, 553);
            pnlNhapLieu.TabIndex = 3;
            pnlNhapLieu.Visible = false;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.White;
            ClientSize = new Size(1021, 553);
            Controls.Add(pnlLeft);
            Controls.Add(pnlNhapLieu);
            Controls.Add(pnlChonQuyen);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ĐĂNG NHẬP HỆ THỐNG";
            pnlLeft.ResumeLayout(false);
            pnlLeft.PerformLayout();
            pnlChonQuyen.ResumeLayout(false);
            pnlNhapLieu.ResumeLayout(false);
            pnlNhapLieu.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLeft;
        private Label label2;
        private Label label1;
        private Panel pnlChonQuyen;
        private Button button3;
        private Button button2;
        private Button button1;
        private Panel pnlNhapLieu;
        private Button button4;
        private TextBox txtPassword;
        private TextBox txtEmail;
        private Label label4;
        private Label label3;
        private Label lblQuayLai;
        private Button button5;
        private Button button6;
    }
}