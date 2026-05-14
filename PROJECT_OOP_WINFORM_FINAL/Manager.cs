using Project_OOP;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PROJECT_OOP_WINFORM_FINAL
{
    public partial class Manager : Form
    {
        private Database _database;
        private UserManager _userManager;
        private PublicationManager _pubManager;
        private Person _currentUser;
        private Button _currentActiveButton;

        public Manager(Database db, UserManager uMgr, PublicationManager pMgr, Person currentUser)
        {
            InitializeComponent();

            this._database = db;
            this._userManager = uMgr;
            this._pubManager = pMgr;
            this._currentUser = currentUser; 
        }

        private void ShowFunction(UserControl uc)
        {
            panel2.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panel2.Controls.Add(uc);
            uc.BringToFront();
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (_currentActiveButton != (Button)btnSender)
                {
                    DeactivateButton();

                    _currentActiveButton = (Button)btnSender;
                    _currentActiveButton.BackColor = Color.FromArgb(255, 140, 0);
                    _currentActiveButton.ForeColor = Color.White;
                }
            }
        }

        private void DeactivateButton()
        {
            if (_currentActiveButton != null)
            {
                _currentActiveButton.BackColor = Color.FromArgb(0, 114, 118);
                _currentActiveButton.ForeColor = Color.White;
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

        private void btnUserMgr_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            ShowFunction(new UC_UserManagement(_userManager));
        }

        private void btnPostMgr_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);

            UC_NewsManager uc = new UC_NewsManager(this._pubManager, this._currentUser);

            ShowFunction(uc);
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);

            if (this._currentUser != null)
            {
                UC_Profile ucProfile = new UC_Profile(this._currentUser);
                ShowFunction(ucProfile); 
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin tài khoản!");
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}