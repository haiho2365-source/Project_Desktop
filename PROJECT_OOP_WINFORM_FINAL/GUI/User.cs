using Project_OOP;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PROJECT_OOP_WINFORM_FINAL
{
    public partial class User : Form
    {
        private Database _database;
        private UserManager _userManager;
        private PublicationManager _pubManager;
        private Person _currentUser;

        private Button _currentActiveButton = null!;
        private Button _btnMailbox = null!;

        public User(Database db, UserManager uMgr, PublicationManager pMgr, Person currentUser)
        {
            InitializeComponent();
            InitializeMailboxButton();

            this._database = db;
            this._userManager = uMgr;
            this._pubManager = pMgr;
            this._currentUser = currentUser;

            if (_currentUser != null)
                this.Text = "Kênh Đọc Tin Tức - Xin chào " + _currentUser.FullName;
        }

        private void InitializeMailboxButton()
        {
            _btnMailbox = new Button();
            _btnMailbox.BackColor = Color.FromArgb(0, 114, 118);
            _btnMailbox.FlatAppearance.BorderSize = 0;
            _btnMailbox.FlatStyle = FlatStyle.Flat;
            _btnMailbox.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            _btnMailbox.ForeColor = Color.White;
            _btnMailbox.Location = new Point(btnProfile.Right + 6, btnProfile.Top);
            _btnMailbox.Padding = Padding.Empty;
            _btnMailbox.Size = btnProfile.Size;
            _btnMailbox.Text = "Hòm thư";
            _btnMailbox.TextAlign = ContentAlignment.MiddleCenter;
            _btnMailbox.UseVisualStyleBackColor = false;
            _btnMailbox.Click += btnMailbox_Click;
            _btnMailbox.MouseEnter += btnNav_MouseEnter;
            _btnMailbox.MouseLeave += btnNav_MouseLeave;
            panel1.Controls.Add(_btnMailbox);
            _btnMailbox.BringToFront();
        }

        private void ShowFunction(Form form)
        {
            panel2.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panel2.Controls.Add(form);
            form.Show();
            form.BringToFront();
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null && _currentActiveButton != (Button)btnSender)
            {
                DeactivateButton();
                _currentActiveButton = (Button)btnSender;
                _currentActiveButton.BackColor = Color.FromArgb(255, 140, 0); 
                _currentActiveButton.ForeColor = Color.White;
            }
        }

        private void DeactivateButton()
        {
            if (_currentActiveButton != null)
            {
                _currentActiveButton.BackColor = Color.FromArgb(0, 128, 128);
                _currentActiveButton.ForeColor = Color.White;
            }
        }

        private void btnPostWatch_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);

            ShowFunction(new GUI.NewsManager(this._pubManager, this._currentUser));
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);

            if (this._currentUser != null)
            {
                panel2.Controls.Clear();

                var frmProfile = new PROJECT_OOP_WINFORM_FINAL.GUI.Profile(this._currentUser);
                frmProfile.TopLevel = false;
                frmProfile.FormBorderStyle = FormBorderStyle.None;
                frmProfile.Dock = DockStyle.Fill;

                panel2.Controls.Add(frmProfile);
                frmProfile.Show();
                frmProfile.BringToFront();
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin tài khoản!");
            }
        }

        private void btnNav_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn != _currentActiveButton)
            {
                btn.BackColor = Color.FromArgb(255, 112, 67);
            }
        }

        private void btnNav_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn != _currentActiveButton)
            {
                btn.BackColor = Color.FromArgb(0, 114, 118);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void btnMailbox_Click(object? sender, EventArgs e)
        {
            ActivateButton(sender);
            ShowFunction(new GUI.MailboxForm(this._currentUser));
        }

        private void User_Load(object sender, EventArgs e)
        {
            btnPostWatch_Click(btnPostWatch, EventArgs.Empty);
        }
    }
}
