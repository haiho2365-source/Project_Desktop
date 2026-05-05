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
            pnlChonQuyen = new Panel();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            pnlNhapLieu = new Panel();
            button4 = new Button();
            txtPassword = new TextBox();
            txtEmail = new TextBox();
            label4 = new Label();
            label3 = new Label();
            lblQuayLai = new Label();
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
            // pnlChonQuyen
            // 
            pnlChonQuyen.Controls.Add(button3);
            pnlChonQuyen.Controls.Add(button2);
            pnlChonQuyen.Controls.Add(button1);
            pnlChonQuyen.Dock = DockStyle.Fill;
            pnlChonQuyen.Location = new Point(0, 0);
            pnlChonQuyen.Name = "pnlChonQuyen";
            pnlChonQuyen.Size = new Size(1021, 553);
            pnlChonQuyen.TabIndex = 1;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(198, 40, 40);
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = Color.White;
            button3.Location = new Point(480, 341);
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
            button2.Location = new Point(480, 244);
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
            button1.Location = new Point(480, 144);
            button1.Name = "button1";
            button1.Size = new Size(350, 50);
            button1.TabIndex = 0;
            button1.Text = "Quản trị viên đăng nhập";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // pnlNhapLieu
            // 
            pnlNhapLieu.Controls.Add(button4);
            pnlNhapLieu.Controls.Add(txtPassword);
            pnlNhapLieu.Controls.Add(txtEmail);
            pnlNhapLieu.Controls.Add(label4);
            pnlNhapLieu.Controls.Add(label3);
            pnlNhapLieu.Controls.Add(lblQuayLai);
            pnlNhapLieu.Dock = DockStyle.Fill;
            pnlNhapLieu.Location = new Point(0, 0);
            pnlNhapLieu.Name = "pnlNhapLieu";
            pnlNhapLieu.Size = new Size(1021, 553);
            pnlNhapLieu.TabIndex = 3;
            pnlNhapLieu.Visible = false;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(0, 114, 118);
            button4.BackgroundImageLayout = ImageLayout.Center;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.White;
            button4.Location = new Point(559, 300);
            button4.Name = "button4";
            button4.Size = new Size(350, 50);
            button4.TabIndex = 11;
            button4.Text = "ĐĂNG NHẬP";
            button4.UseVisualStyleBackColor = false;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Location = new Point(616, 225);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(251, 34);
            txtPassword.TabIndex = 10;
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Location = new Point(616, 156);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(251, 34);
            txtEmail.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(480, 225);
            label4.Name = "label4";
            label4.Size = new Size(94, 28);
            label4.TabIndex = 8;
            label4.Text = "Mật khẩu";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(480, 156);
            label3.Name = "label3";
            label3.Size = new Size(94, 28);
            label3.TabIndex = 7;
            label3.Text = "Tài khoản";
            // 
            // lblQuayLai
            // 
            lblQuayLai.AutoSize = true;
            lblQuayLai.BackColor = Color.White;
            lblQuayLai.Location = new Point(356, 516);
            lblQuayLai.Name = "lblQuayLai";
            lblQuayLai.Size = new Size(83, 28);
            lblQuayLai.TabIndex = 6;
            lblQuayLai.Text = "Quay lại";
            lblQuayLai.Click += lblQuayLai_Click_1;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
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
    }
}