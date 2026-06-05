using Project_OOP;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PROJECT_OOP_WINFORM_FINAL.GUI
{
    public class AdminStatisticsForm : Form
    {
        private readonly AdminLinqSqlRepository _repository = new AdminLinqSqlRepository();
        private Label lblTotalUsers = null!;
        private Label lblTotalPosts = null!;
        private Label lblApprovedPosts = null!;
        private Label lblUnreadMessages = null!;
        private DataGridView dgvUsersByRole = null!;
        private DataGridView dgvPostsByType = null!;
        private DataGridView dgvPostsByStatus = null!;
        private Button btnRefresh = null!;

        public AdminStatisticsForm()
        {
            InitializeComponent();
            LoadStatistics();
        }

        private void InitializeComponent()
        {
            Label lblTitle = new Label();
            Label lblUsersGrid = new Label();
            Label lblTypesGrid = new Label();
            Label lblStatusGrid = new Label();

            this.lblTotalUsers = new Label();
            this.lblTotalPosts = new Label();
            this.lblApprovedPosts = new Label();
            this.lblUnreadMessages = new Label();
            this.dgvUsersByRole = new DataGridView();
            this.dgvPostsByType = new DataGridView();
            this.dgvPostsByStatus = new DataGridView();
            this.btnRefresh = new Button();

            ((System.ComponentModel.ISupportInitialize)this.dgvUsersByRole).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.dgvPostsByType).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.dgvPostsByStatus).BeginInit();
            this.SuspendLayout();

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 114, 118);
            lblTitle.Location = new Point(18, 15);
            lblTitle.Text = "BÁO CÁO THỐNG KÊ";

            ConfigureMetricLabel(this.lblTotalUsers, "Người dùng: 0", 18, 62);
            ConfigureMetricLabel(this.lblTotalPosts, "Bài báo: 0", 250, 62);
            ConfigureMetricLabel(this.lblApprovedPosts, "Đã duyệt: 0", 482, 62);
            ConfigureMetricLabel(this.lblUnreadMessages, "Thư chưa đọc: 0", 714, 62);

            ConfigureButton(this.btnRefresh, "LÀM MỚI", Color.FromArgb(255, 112, 67), 870, 15, 120, 38);
            this.btnRefresh.Click += btnRefresh_Click;

            ConfigureGridTitle(lblUsersGrid, "Người dùng theo vai trò", 18, 118);
            ConfigureGridTitle(lblTypesGrid, "Bài báo theo loại", 348, 118);
            ConfigureGridTitle(lblStatusGrid, "Trạng thái duyệt", 678, 118);

            ConfigureGrid(this.dgvUsersByRole, 18, 155);
            ConfigureGrid(this.dgvPostsByType, 348, 155);
            ConfigureGrid(this.dgvPostsByStatus, 678, 155);

            this.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = Color.White;
            this.ClientSize = new Size(1021, 355);
            this.Controls.Add(lblTitle);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblTotalUsers);
            this.Controls.Add(this.lblTotalPosts);
            this.Controls.Add(this.lblApprovedPosts);
            this.Controls.Add(this.lblUnreadMessages);
            this.Controls.Add(lblUsersGrid);
            this.Controls.Add(lblTypesGrid);
            this.Controls.Add(lblStatusGrid);
            this.Controls.Add(this.dgvUsersByRole);
            this.Controls.Add(this.dgvPostsByType);
            this.Controls.Add(this.dgvPostsByStatus);
            this.Font = new Font("Segoe UI", 10F);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Name = "AdminStatisticsForm";
            this.Text = "Báo cáo thống kê";

            ((System.ComponentModel.ISupportInitialize)this.dgvUsersByRole).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.dgvPostsByType).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.dgvPostsByStatus).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private static void ConfigureMetricLabel(Label label, string text, int left, int top)
        {
            label.BackColor = Color.FromArgb(0, 114, 118);
            label.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label.ForeColor = Color.White;
            label.Location = new Point(left, top);
            label.Size = new Size(210, 42);
            label.Text = text;
            label.TextAlign = ContentAlignment.MiddleCenter;
        }

        private static void ConfigureGridTitle(Label label, string text, int left, int top)
        {
            label.AutoSize = true;
            label.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label.ForeColor = Color.FromArgb(0, 114, 118);
            label.Location = new Point(left, top);
            label.Text = text;
        }

        private static void ConfigureGrid(DataGridView grid, int left, int top)
        {
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.BackgroundColor = Color.White;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grid.Location = new Point(left, top);
            grid.ReadOnly = true;
            grid.RowHeadersWidth = 51;
            grid.Size = new Size(312, 185);
        }

        private static void ConfigureButton(Button button, string text, Color backColor, int left, int top, int width, int height)
        {
            button.BackColor = backColor;
            button.FlatAppearance.BorderSize = 0;
            button.FlatStyle = FlatStyle.Flat;
            button.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button.ForeColor = Color.White;
            button.Location = new Point(left, top);
            button.Size = new Size(width, height);
            button.Text = text;
            button.UseVisualStyleBackColor = false;
        }

        private void LoadStatistics()
        {
            try
            {
                AdminStatisticsReport report = this._repository.LoadStatistics();

                this.lblTotalUsers.Text = "Người dùng: " + report.TotalUsers;
                this.lblTotalPosts.Text = "Bài báo: " + report.TotalPublications;
                this.lblApprovedPosts.Text = "Đã duyệt: " + report.ApprovedPublications + " | Chờ: " + report.PendingPublications;
                this.lblUnreadMessages.Text = "Thư chưa đọc: " + report.UnreadMessages;

                BindStatisticGrid(this.dgvUsersByRole, report.UsersByRole);
                BindStatisticGrid(this.dgvPostsByType, report.PublicationsByType);
                BindStatisticGrid(this.dgvPostsByStatus, report.PublicationsByStatus);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải báo cáo thống kê: " + ex.Message, "Lỗi database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void BindStatisticGrid(DataGridView grid, object dataSource)
        {
            grid.DataSource = null;
            grid.DataSource = dataSource;

            if (grid.Columns["Name"] != null)
            {
                grid.Columns["Name"].HeaderText = "Nhóm";
            }

            if (grid.Columns["Count"] != null)
            {
                grid.Columns["Count"].HeaderText = "Số lượng";
            }
        }

        private void btnRefresh_Click(object? sender, EventArgs e)
        {
            LoadStatistics();
        }
    }
}
