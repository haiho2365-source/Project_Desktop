using Project_OOP;
using System;
using System.Windows.Forms;

namespace PROJECT_OOP_WINFORM_FINAL
{
    public partial class Register : Form
    {
        private Database _database;
        private RegistrationService _registrationService;

        public Register(Database databaseTruyenSang)
        {
            InitializeComponent();
            this._database = databaseTruyenSang;
            this._registrationService = new RegistrationService(this._database);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string id = "SB" + DateTime.Now.ToString("MMddHHmmss");

            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string pass = txtPassword.Text.Trim();
            string confirmPass = txtConfirmPassword.Text.Trim();

            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (pass != confirmPass)
            {
                MessageBox.Show("Mật khẩu xác nhận không trùng khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool isSuccess = _registrationService.Register(id, fullName, email, pass);

            if (isSuccess)
            {
                MessageBox.Show("Đăng ký thành công!\nMã ID của bạn là: " + id, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Email này đã được đăng ký, vui lòng chọn email khác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}