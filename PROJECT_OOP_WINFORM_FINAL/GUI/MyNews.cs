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
    public partial class MyNews : Form
    {
        private PublicationManager _pubManager;
        private Person _currentUser;
        private void WireEvents()
        {
            btnAdd.Click += btnThemMoi_Click;
            btnEdit.Click += btnEdit_Click;
            btnDelete.Click += btnDelete_Click;
            dgvMyPosts.CellClick += dgvMyPosts_CellClick;
        }
        public MyNews()
        {
            InitializeComponent();
            WireEvents();

        }
        public MyNews(PublicationManager pubManager, Person user)
        {
            InitializeComponent();
            WireEvents();
            this._pubManager = pubManager;
            this._currentUser = user;

            LoadData();
        }

        public void LoadData()
        {
            if (_pubManager == null) return;

            dgvMyPosts.DataSource = null;
            dgvMyPosts.DataSource = _pubManager.GetPostList();

            if (dgvMyPosts.Columns["Content"] != null) dgvMyPosts.Columns["Content"].Visible = false;
            if (dgvMyPosts.Columns["VideoUrl"] != null) dgvMyPosts.Columns["VideoUrl"].Visible = false;
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            if (_pubManager == null)
            {
                MessageBox.Show("Không tìm thấy dữ liệu bài viết!");
                return;
            }

            using (Form_NewsEditor frm = new Form_NewsEditor())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _pubManager.AddPost(frm.CreatedPost);
                    LoadData();
                    MessageBox.Show("Thêm bản tin mới thành công!");
                }
            }
        }

        private Publication? GetSelectedPost()
        {
            if (dgvMyPosts.CurrentRow == null) return null;

            return dgvMyPosts.CurrentRow.DataBoundItem as Publication;
        }

        private void EditPost(Publication selectedPost)
        {
            using (Form_NewsEditor frm = new Form_NewsEditor(selectedPost))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                    MessageBox.Show("Cập nhật thành công!");
                }
            }
        }

        private void DeletePost(Publication selectedPost)
        {
            if (_pubManager == null)
            {
                MessageBox.Show("Không tìm thấy dữ liệu bài viết!");
                return;
            }

            DialogResult dr = MessageBox.Show("Bạn có chắc muốn xoá bản tin này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                _pubManager.RemovePost(selectedPost.Id);
                LoadData();
                MessageBox.Show("Đã xoá bản tin.");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Publication? selectedPost = GetSelectedPost();
            if (selectedPost == null)
            {
                MessageBox.Show("Vui lòng chọn bản tin cần sửa!");
                return;
            }

            EditPost(selectedPost);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Publication? selectedPost = GetSelectedPost();
            if (selectedPost == null)
            {
                MessageBox.Show("Vui lòng chọn bản tin cần xoá!");
                return;
            }

            DeletePost(selectedPost);
        }

        private void dgvMyPosts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                Publication selectedPost = dgvMyPosts.Rows[e.RowIndex].DataBoundItem as Publication;

                if (selectedPost == null) return;

                string columnName = dgvMyPosts.Columns[e.ColumnIndex].Name;

                if (columnName == "btnEdit")
                {
                    EditPost(selectedPost);
                }
                else if (columnName == "btnDelete")
                {
                    DeletePost(selectedPost);
                }
            }
        }
    }
}
