using Project_OOP;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PROJECT_OOP_WINFORM_FINAL
{
    public partial class Login : Form
    {
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

            Admin adminAccount = new Admin("AD01", "Admin", "admin@ueh.edu.vn", "123", "Manager");
            _userManager.AddUser(adminAccount);

            Reporter reporterAccount = new Reporter("RP01", "Reporter", "reporter@ueh.edu.vn", "News");
            _userManager.AddUser(reporterAccount);

            Subscriber subscriberAccount = new Subscriber("SB01", "Subscriber", "sub@ueh.edu.vn", true);
            _userManager.AddUser(subscriberAccount);
        }

        private void button1_Click(object sender, EventArgs e) { _selectedRole = 1; SwitchPanel(); }
        private void button2_Click(object sender, EventArgs e) { _selectedRole = 2; SwitchPanel(); }
        private void button3_Click(object sender, EventArgs e) { _selectedRole = 3; SwitchPanel(); }

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
                MessageBox.Show("Vui lòng nhập đủ Email và Mật khẩu!");
                return;
            }

            Person userFound = _userManager.FindUser(email);

            if (userFound == null)
            {
                MessageBox.Show("Tài khoản không tồn tại!");
                return;
            }

            bool isPasswordCorrect = false;

            if (userFound is Admin admin)
            {
                if (admin.CheckPassword(password)) isPasswordCorrect = true;
            }
            else
            {
                if (password == "123") isPasswordCorrect = true;
            }

            if (isPasswordCorrect)
            {
                if ((_selectedRole == 1 && userFound is Admin) ||
                    (_selectedRole == 2 && userFound is Reporter) ||
                    (_selectedRole == 3 && userFound is Subscriber))
                {
                    MessageBox.Show("Đăng nhập thành công!");
                }
                else
                {
                    MessageBox.Show("Sai vai trò đăng nhập!");
                }
            }
            else
            {
                MessageBox.Show("Sai mật khẩu!");
            }
        }
    }
}