using System;
using System.Collections.Generic; // Bắt buộc phải có để dùng List
using System.Windows.Forms;
using Project_OOP;

namespace PROJECT_OOP_WINFORM_FINAL
{
    public partial class UC_UserManagement : UserControl
    {
        private UserManager _userManager;

        public UC_UserManagement(UserManager uMgr)
        {
            InitializeComponent();
            this._userManager = uMgr;

            this.LoadData();
        }

        private void LoadData()
        {
            List<Person> listToShow = this._userManager.GetUsersForDisplay();

            this.dgvUsers.DataSource = null;
            this.dgvUsers.DataSource = listToShow;

            if (this.dgvUsers.Columns["Password"] != null)
            {
                this.dgvUsers.Columns["Password"].Visible = false;
            }
        }

        private void ClearFields()
        {
            this.txtID.Text = "";
            this.txtName.Text = "";
            this.txtEmail.Text = "";
            this.txtID.ReadOnly = false;
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvUsers.Rows[e.RowIndex];

                if (row.Cells["Id"].Value != null)
                {
                    this.txtID.Text = row.Cells["Id"].Value.ToString();
                }

                if (row.Cells["FullName"].Value != null)
                {
                    this.txtName.Text = row.Cells["FullName"].Value.ToString();
                }

                if (row.Cells["Email"].Value != null)
                {
                    this.txtEmail.Text = row.Cells["Email"].Value.ToString();
                }

                this.txtID.ReadOnly = true;
            }
        }

       

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string id = this.txtID.Text;
            string fullName = this.txtName.Text;
            string email = this.txtEmail.Text;

            if (string.IsNullOrEmpty(id) == true)
            {
                MessageBox.Show("Vui lòng chọn một người dùng từ bảng để sửa!");
                return;
            }

            bool isSuccess = this._userManager.UpdateUser(id, fullName, email);

            if (isSuccess == true)
            {
                MessageBox.Show("Cập nhật thông tin thành công!");
                this.LoadData();
                this.ClearFields();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại. Không tìm thấy ID tương ứng!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = this.txtID.Text;

            if (string.IsNullOrEmpty(id) == true)
            {
                MessageBox.Show("Vui lòng chọn một người dùng từ bảng để xóa!");
                return;
            }

            DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa người dùng ID: " + id + "?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                bool isSuccess = this._userManager.DeleteUser(id);

                if (isSuccess == true)
                {
                    MessageBox.Show("Xóa người dùng thành công!");
                    this.LoadData();
                    this.ClearFields();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại. Không tìm thấy ID!");
                }
            }
        }
    }
}