namespace PROJECT_OOP_WINFORM_FINAL
{
    partial class Register
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
            pnlNhapLieu = new Panel();
            txtConfirmPassword = new TextBox();
            label6 = new Label();
            txtEmail = new TextBox();
            label5 = new Label();
            btnBack = new Button();
            btnRegister = new Button();
            txtPassword = new TextBox();
            txtFullName = new TextBox();
            label4 = new Label();
            label3 = new Label();
            pnlLeft.SuspendLayout();
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
            pnlLeft.Size = new Size(385, 553);
            pnlLeft.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(255, 112, 67);
            label2.Location = new Point(129, 54);
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
            // pnlNhapLieu
            // 
            pnlNhapLieu.BackColor = Color.White;
            pnlNhapLieu.Controls.Add(txtConfirmPassword);
            pnlNhapLieu.Controls.Add(label6);
            pnlNhapLieu.Controls.Add(txtEmail);
            pnlNhapLieu.Controls.Add(label5);
            pnlNhapLieu.Controls.Add(btnBack);
            pnlNhapLieu.Controls.Add(btnRegister);
            pnlNhapLieu.Controls.Add(txtPassword);
            pnlNhapLieu.Controls.Add(txtFullName);
            pnlNhapLieu.Controls.Add(label4);
            pnlNhapLieu.Controls.Add(label3);
            pnlNhapLieu.Dock = DockStyle.Fill;
            pnlNhapLieu.Location = new Point(385, 0);
            pnlNhapLieu.Name = "pnlNhapLieu";
            pnlNhapLieu.Size = new Size(636, 553);
            pnlNhapLieu.TabIndex = 6;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.BorderStyle = BorderStyle.FixedSingle;
            txtConfirmPassword.Location = new Point(274, 281);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(276, 34);
            txtConfirmPassword.TabIndex = 16;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(94, 283);
            label6.Name = "label6";
            label6.Size = new Size(171, 28);
            label6.TabIndex = 15;
            label6.Text = "Nhập lại mật khẩu";
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Location = new Point(274, 167);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(276, 34);
            txtEmail.TabIndex = 14;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(94, 169);
            label5.Name = "label5";
            label5.Size = new Size(59, 28);
            label5.TabIndex = 13;
            label5.Text = "Email";
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(255, 112, 67);
            btnBack.BackgroundImageLayout = ImageLayout.Center;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(129, 437);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(385, 74);
            btnBack.TabIndex = 12;
            btnBack.Text = "ĐÃ CÓ TÀI KHOẢN?\r\nĐĂNG NHẬP NGAY\r\n";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(0, 114, 118);
            btnRegister.BackgroundImageLayout = ImageLayout.Center;
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(129, 352);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(385, 56);
            btnRegister.TabIndex = 11;
            btnRegister.Text = "ĐĂNG KÝ";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Location = new Point(274, 224);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(276, 34);
            txtPassword.TabIndex = 10;
            // 
            // txtFullName
            // 
            txtFullName.BorderStyle = BorderStyle.FixedSingle;
            txtFullName.Location = new Point(274, 106);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(276, 34);
            txtFullName.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(94, 226);
            label4.Name = "label4";
            label4.Size = new Size(94, 28);
            label4.TabIndex = 8;
            label4.Text = "Mật khẩu";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(94, 108);
            label3.Name = "label3";
            label3.Size = new Size(111, 28);
            label3.TabIndex = 7;
            label3.Text = "Tên hiển thị";
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1021, 553);
            Controls.Add(pnlNhapLieu);
            Controls.Add(pnlLeft);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "Register";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Register";
            pnlLeft.ResumeLayout(false);
            pnlLeft.PerformLayout();
            pnlNhapLieu.ResumeLayout(false);
            pnlNhapLieu.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLeft;
        private Label label2;
        private Label label1;
        private Panel pnlNhapLieu;
        private Button btnBack;
        private TextBox txtPassword;
        private TextBox txtFullName;
        private Label label4;
        private Label label3;
        private Button btnRegister;
        private TextBox txtConfirmPassword;
        private Label label6;
        private TextBox txtEmail;
        private Label label5;
    }
}