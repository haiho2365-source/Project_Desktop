using Project_OOP;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PROJECT_OOP_WINFORM_FINAL
{
    public partial class Login : Form
    {
        private Database _database = new Database();
        private UserManager _userManager;
        private int _selectedRole = 0;

        public Login()
        {
            InitializeComponent();
            _userManager = new UserManager();
            InitializeMockData();
        }

        private void InitializeMockData()
        {
            Admin adminAccount = new Admin("AD01", "Admin User", "admin@ueh.edu.vn", "123456", "Manager");
            _userManager.AddUser(adminAccount);

            Reporter reporterAccount = new Reporter("RP01", "Reporter User", "reporter@ueh.edu.vn", "News Dept", "123");
            _userManager.AddUser(reporterAccount);

            Subscriber subscriberAccount = new Subscriber("SB01", "Subscriber User", "sub@ueh.edu.vn", true, "123");
            _userManager.AddUser(subscriberAccount);
            _database.AddSubscriber(subscriberAccount);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _selectedRole = 1;
            SwitchPanel();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _selectedRole = 2;
            SwitchPanel();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _selectedRole = 3;
            SwitchPanel();
        }

        private void SwitchPanel()
        {
            pnlChonQuyen.Visible = false;
            pnlNhapLieu.Visible = true;
            pnlNhapLieu.BringToFront();

            txtEmail.Clear();
            txtPassword.Clear();
            txtPassword.Enabled = true;
        }

        private void lblQuayLai_Click_1(object sender, EventArgs e)
        {
            pnlNhapLieu.Visible = false;
            pnlChonQuyen.Visible = true;
            _selectedRole = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Email và Mật khẩu", "Yêu cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Person userFound = _userManager.FindUser(email);

            if (userFound == null)
            {
                foreach (Subscriber s in _database.Subscribers)
                {
                    if (s.Email.Equals(email, StringComparison.OrdinalIgnoreCase))
                    {
                        userFound = s;
                        break;
                    }
                }
            }

            if (userFound == null)
            {
                MessageBox.Show("Tài khoản không tồn tại trong hệ thống", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool isPasswordCorrect = false;
            string userRoleName = "";

            if (userFound is Admin admin)
            {
                isPasswordCorrect = admin.CheckPassword(password);
                userRoleName = "Quản trị viên";
            }
            else if (userFound is Reporter reporter)
            {
                isPasswordCorrect = reporter.CheckPassword(password);
                userRoleName = "Phóng viên";
            }
            else if (userFound is Subscriber sub)
            {
                isPasswordCorrect = sub.CheckPassword(password);
                userRoleName = "Độc giả";
            }

            if (isPasswordCorrect)
            {
                bool isRightRole = (_selectedRole == 1 && userFound is Admin) ||
                                   (_selectedRole == 2 && userFound is Reporter) ||
                                   (_selectedRole == 3 && userFound is Subscriber);

                if (isRightRole)
                {
                    MessageBox.Show($"MẬT KHẨU CHÍNH XÁC. Chào mừng {userRoleName} {userFound.FullName} đã đăng nhập thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"MẬT KHẨU ĐÚNG. Nhưng tài khoản này là {userRoleName} không khớp với quyền bạn đã chọn lúc đầu", "Sai quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("MẬT KHẨU SAI. Vui lòng kiểm tra lại mật khẩu của bạn", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void pnlChonQuyen_Paint(object sender, PaintEventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Register frmRegister = new Register(this._database);
            this.Hide();
            frmRegister.ShowDialog();
            this.Show();
        }
    }
}