using Project_OOP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJECT_OOP_WINFORM_FINAL.GUI
{
    public partial class Profile : Form
    {
        private Person _user;


        public Profile(Person inputUser)
        {
            InitializeComponent();
            this._user = inputUser;

            LoadProfileData();
        }
        private void LoadProfileData()
        {
            
            if (_user == null) return;

            this.txtName.Text = this._user.FullName;
            this.txtEmail.Text = this._user.Email;

            this.txtName.ReadOnly = true;
            this.txtEmail.ReadOnly = true;
            this.txtRole.ReadOnly = true;

           
            if (this._user is Admin)
            {
                Admin admin = (Admin)this._user;
                this.txtRole.Text = "Quản trị viên / Đạo diễn";
            }
            else if (this._user is Reporter)
            {
                Reporter reporter = (Reporter)this._user;
                this.txtRole.Text = "Phóng viên / Biên tập viên";
            }
            else if (this._user is Subscriber)
            {
                Subscriber sub = (Subscriber)this._user;
                this.txtRole.Text = "Khán giả truyền hình";
            }
        }
    }
}
