using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Project_OOP;

namespace PROJECT_OOP_WINFORM_FINAL
{
    public partial class UC_NewsManager : UserControl
    {
        private PublicationManager _pubManager;

        public UC_NewsManager(PublicationManager pMgr)
        {
            InitializeComponent();
            this._pubManager = pMgr;

            this.rtbContent.Visible = false;

            if (this._pubManager.GetPostList().Count == 0)
            {
                this.CreateSampleData();
            }

            this.LoadData();
        }

        private void LoadData()
        {
            List<Publication> listToShow = this._pubManager.GetPostList();

            this.dgvNews.DataSource = null;
            this.dgvNews.DataSource = listToShow;

            this.dgvNews.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (this.dgvNews.Columns["Id"] != null) this.dgvNews.Columns["Id"].Visible = false;
            if (this.dgvNews.Columns["PublishDate"] != null) this.dgvNews.Columns["PublishDate"].Visible = false;
            if (this.dgvNews.Columns["ViewCount"] != null) this.dgvNews.Columns["ViewCount"].Visible = false;

            if (this.dgvNews.Columns["Title"] != null)
            {
                this.dgvNews.Columns["Title"].HeaderText = "Tiêu đề bản tin";
                this.dgvNews.Columns["Title"].FillWeight = 200;
            }
            if (this.dgvNews.Columns["IsApproved"] != null)
            {
                this.dgvNews.Columns["IsApproved"].HeaderText = "Trạng thái duyệt";
                this.dgvNews.Columns["IsApproved"].FillWeight = 50;
            }
        }

        private void btnUnapprove_Click(object sender, EventArgs e)
        {
            if (this.dgvNews.CurrentRow != null)
            {
                string id = this.dgvNews.CurrentRow.Cells["Id"].Value.ToString();
                bool isSuccess = this._pubManager.UnapprovePost(id);

                if (isSuccess == true)
                {
                    MessageBox.Show("Đã hủy duyệt bản tin!");
                    this.LoadData();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn bài báo để hủy duyệt!");
            }
        }

        private void dgvNews_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && this.dgvNews.CurrentRow != null)
            {
                this.rtbContent.Visible = true;

                string id = this.dgvNews.CurrentRow.Cells["Id"].Value.ToString();
                List<Publication> allPosts = this._pubManager.GetPostList();
                Publication selectedPost = null;

                for (int i = 0; i < allPosts.Count; i = i + 1)
                {
                    if (allPosts[i].Id == id)
                    {
                        selectedPost = allPosts[i];
                        break;
                    }
                }

                if (selectedPost != null)
                {
                    string displayText = "--- CHI TIẾT BẢN TIN ---\n\n";
                    displayText += "Tiêu đề: " + selectedPost.Title + "\n";

                    if (selectedPost is BreakingNews)
                    {
                        BreakingNews bn = (BreakingNews)selectedPost;
                        displayText += "[TIN KHẨN] Độ nóng: " + bn.TrendLevel + "\n";
                    }
                    else if (selectedPost is DailyNews)
                    {
                        DailyNews dn = (DailyNews)selectedPost;
                        displayText += "[TIN NGÀY] Độ nóng: " + dn.TrendLevel + "\n";
                    }
                    else if (selectedPost is VideoReport)
                    {
                        VideoReport vr = (VideoReport)selectedPost;
                        displayText += "[VIDEO] Thời lượng: " + vr.Duration + "p - " + vr.Resolution + "\n";
                    }
                    else if (selectedPost is WeeklyMagazine)
                    {
                        WeeklyMagazine wm = (WeeklyMagazine)selectedPost;
                        displayText += "[TẠP CHÍ] Tác giả: " + wm.Author + "\nNguồn: " + (wm.References.Count > 0 ? wm.References[0] : "N/A") + "\n";
                    }

                    this.rtbContent.Text = displayText;
                }
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (this.dgvNews.CurrentRow != null)
            {
                string id = this.dgvNews.CurrentRow.Cells["Id"].Value.ToString();
                if (this._pubManager.ApprovePost(id))
                {
                    MessageBox.Show("Duyệt thành công!");
                    this.LoadData();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.dgvNews.CurrentRow != null)
            {
                string id = this.dgvNews.CurrentRow.Cells["Id"].Value.ToString();
                if (MessageBox.Show("Xóa?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (this._pubManager.RemovePost(id))
                    {
                        this.LoadData();
                        this.rtbContent.Visible = false; 
                    }
                }
            }
        }

        private void CreateSampleData()
        {
            this._pubManager.AddPost(new DailyNews("DN01", "Giá xăng giảm mạnh vào chiều nay", DateTime.Now, 8));
            this._pubManager.AddPost(new BreakingNews("BN01", "Hỏa hoạn lớn tại chung cư mini", DateTime.Now, 10));
            this._pubManager.AddPost(new VideoReport("VR01", "Review ẩm thực đường phố Sài Gòn", DateTime.Now, 12.5, "4K"));
            this._pubManager.AddPost(new WeeklyMagazine("WM01", "Kỷ nguyên của xe điện", DateTime.Now, "John Wick"));
        }
    }
}