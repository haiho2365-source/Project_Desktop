using System;
using System.Windows.Forms;
using Project_OOP; 
namespace PROJECT_OOP_WINFORM_FINAL
{
    public partial class UC_Profile : UserControl
    {
        private Person _user;

        public UC_Profile(Person inputUser)
        {
            InitializeComponent();
            this._user = inputUser;

            this.Dock = DockStyle.Fill;
            LoadProfileData();
        }

        private void LoadProfileData()
        {
            this.txtName.Text = this._user.FullName;
            this.txtEmail.Text = this._user.Email;

            this.txtName.ReadOnly = true;
            this.txtEmail.ReadOnly = true;
            this.txtRole.ReadOnly = true;
            this.txtExtraInfo.ReadOnly = true;

            if (this._user is Admin)
            {
                Admin admin = (Admin)this._user;

                this.txtRole.Text = "Quản trị viên / Đạo diễn";

                this.lblExtra.Visible = false;
                this.txtExtraInfo.Visible = false;
            }
            else if (this._user is Reporter)
            {
                Reporter reporter = (Reporter)this._user;

                this.txtRole.Text = "Phóng viên / Biên tập viên";

                this.lblExtra.Text = "Thông tin công tác:";
                this.txtExtraInfo.Text = "Phòng: " + reporter.Department + " | Đã nộp: " + reporter.PostsCount.ToString() + " bài";

                this.lblExtra.Visible = true;
                this.txtExtraInfo.Visible = true;
            }
            else if (this._user is Subscriber)
            {
                Subscriber sub = (Subscriber)this._user;

                this.txtRole.Text = "Khán giả truyền hình";

                this.lblExtra.Text = "Hạng tài khoản:";
                if (sub.IsPremium == true)
                {
                    this.txtExtraInfo.Text = "Tài khoản VIP (Premium)";
                }
                else
                {
                    this.txtExtraInfo.Text = "Tài khoản Thường";
                }

                this.lblExtra.Visible = true;
                this.txtExtraInfo.Visible = true;
            }
        }
    }
}