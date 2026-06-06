using Project_OOP;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PROJECT_OOP_WINFORM_FINAL.GUI
{
    public class ResetPasswordForm : Form
    {
        private readonly AdminLinqSqlRepository _repository = new AdminLinqSqlRepository();
        private Panel pnlLeft = null!;
        private Panel pnlContent = null!;
        private TextBox txtFullName = null!;
        private TextBox txtEmail = null!;
        private ComboBox cbRole = null!;
        private TextBox txtNewPassword = null!;
        private TextBox txtConfirmPassword = null!;
        private Button btnResetPassword = null!;
        private Button btnClose = null!;

        public ResetPasswordForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.pnlLeft = new Panel();
            this.pnlContent = new Panel();
            Label lblBrandTop = new Label();
            Label lblBrandBottom = new Label();
            Label lblTitle = new Label();
            Label lblName = new Label();
            Label lblEmail = new Label();
            Label lblRole = new Label();
            Label lblNewPassword = new Label();
            Label lblConfirmPassword = new Label();

            this.txtFullName = new TextBox();
            this.txtEmail = new TextBox();
            this.cbRole = new ComboBox();
            this.txtNewPassword = new TextBox();
            this.txtConfirmPassword = new TextBox();
            this.btnResetPassword = new Button();
            this.btnClose = new Button();

            this.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlContent.SuspendLayout();

            this.pnlLeft.BackColor = Color.FromArgb(0, 114, 118);
            this.pnlLeft.Dock = DockStyle.Left;
            this.pnlLeft.Size = new Size(280, 553);
            this.pnlLeft.Controls.Add(lblBrandTop);
            this.pnlLeft.Controls.Add(lblBrandBottom);

            lblBrandTop.AutoSize = true;
            lblBrandTop.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblBrandTop.ForeColor = Color.White;
            lblBrandTop.Location = new Point(0, 0);
            lblBrandTop.Text = "QUẢN LÝ";

            lblBrandBottom.AutoSize = true;
            lblBrandBottom.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblBrandBottom.ForeColor = Color.FromArgb(255, 112, 67);
            lblBrandBottom.Location = new Point(100, 48);
            lblBrandBottom.Text = "BẢN TIN";

            this.pnlContent.Dock = DockStyle.Fill;
            this.pnlContent.BackColor = Color.White;
            this.pnlContent.Controls.Add(lblTitle);
            this.pnlContent.Controls.Add(lblName);
            this.pnlContent.Controls.Add(this.txtFullName);
            this.pnlContent.Controls.Add(lblEmail);
            this.pnlContent.Controls.Add(this.txtEmail);
            this.pnlContent.Controls.Add(lblRole);
            this.pnlContent.Controls.Add(this.cbRole);
            this.pnlContent.Controls.Add(lblNewPassword);
            this.pnlContent.Controls.Add(this.txtNewPassword);
            this.pnlContent.Controls.Add(lblConfirmPassword);
            this.pnlContent.Controls.Add(this.txtConfirmPassword);
            this.pnlContent.Controls.Add(this.btnResetPassword);
            this.pnlContent.Controls.Add(this.btnClose);

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 114, 118);
            lblTitle.Location = new Point(155, 44);
            lblTitle.Text = "ĐẶT LẠI MẬT KHẨU";

            ConfigureLabel(lblName, "Họ tên", 110);
            ConfigureTextBox(this.txtFullName, 110);

            ConfigureLabel(lblEmail, "Email", 170);
            ConfigureTextBox(this.txtEmail, 170);

            ConfigureLabel(lblRole, "Vai trò", 230);
            this.cbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbRole.Items.Add("Admin");
            this.cbRole.Items.Add("Reporter");
            this.cbRole.Items.Add("Subscriber");
            this.cbRole.SelectedIndex = 0;
            this.cbRole.Location = new Point(230, 230);
            this.cbRole.Size = new Size(280, 34);

            ConfigureLabel(lblNewPassword, "Mật khẩu mới", 290);
            ConfigureTextBox(this.txtNewPassword, 290);
            this.txtNewPassword.PasswordChar = '*';

            ConfigureLabel(lblConfirmPassword, "Xác nhận", 350);
            ConfigureTextBox(this.txtConfirmPassword, 350);
            this.txtConfirmPassword.PasswordChar = '*';

            ConfigureButton(this.btnResetPassword, "CẬP NHẬT MẬT KHẨU", Color.FromArgb(0, 114, 118), 230, 420, 280, 46);
            this.btnResetPassword.Click += btnResetPassword_Click;

            ConfigureButton(this.btnClose, "ĐÓNG", Color.FromArgb(255, 112, 67), 230, 475, 280, 42);
            this.btnClose.Click += btnClose_Click;

            this.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = Color.White;
            this.ClientSize = new Size(850, 553);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlLeft);
            this.Font = new Font("Segoe UI", 10F);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "ĐẶT LẠI MẬT KHẨU";

            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            this.ResumeLayout(false);
        }

        private static void ConfigureLabel(Label label, string text, int top)
        {
            label.AutoSize = true;
            label.Location = new Point(95, top + 4);
            label.Text = text;
        }

        private static void ConfigureTextBox(TextBox textBox, int top)
        {
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.Location = new Point(230, top);
            textBox.Size = new Size(280, 34);
        }

        private static void ConfigureButton(Button button, string text, Color color, int left, int top, int width, int height)
        {
            button.BackColor = color;
            button.FlatAppearance.BorderSize = 0;
            button.FlatStyle = FlatStyle.Flat;
            button.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button.ForeColor = Color.White;
            button.Location = new Point(left, top);
            button.Size = new Size(width, height);
            button.Text = text;
            button.UseVisualStyleBackColor = false;
        }

        private void btnResetPassword_Click(object? sender, EventArgs e)
        {
            string fullName = this.txtFullName.Text.Trim();
            string email = this.txtEmail.Text.Trim();
            string role = this.cbRole.SelectedItem?.ToString() ?? "";
            string newPassword = this.txtNewPassword.Text.Trim();
            string confirmPassword = this.txtConfirmPassword.Text.Trim();

            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(role) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin để xác minh tài khoản.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Mật khẩu xác nhận không trùng khớp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                bool isSuccess = this._repository.TryResetPassword(fullName, email, role, newPassword);

                if (isSuccess)
                {
                    MessageBox.Show("Đặt lại mật khẩu thành công. Bạn có thể đăng nhập bằng mật khẩu mới.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thông tin xác minh không khớp với tài khoản trong hệ thống.", "Không tìm thấy", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể cập nhật mật khẩu: " + ex.Message, "Lỗi database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}
