using Project_OOP;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PROJECT_OOP_WINFORM_FINAL.GUI
{
    public class MailboxForm : Form
    {
        private readonly AdminLinqSqlRepository _repository = new AdminLinqSqlRepository();
        private readonly Person _currentUser;
        private DataGridView dgvMessages = null!;
        private TextBox txtSenderEmail = null!;
        private TextBox txtReceiverEmail = null!;
        private TextBox txtSubject = null!;
        private RichTextBox rtbContent = null!;
        private Button btnRefresh = null!;
        private Button btnSave = null!;
        private Button btnRead = null!;
        private Button btnDelete = null!;
        private Button btnClear = null!;

        public MailboxForm(Person currentUser)
        {
            this._currentUser = currentUser;
            InitializeComponent();
            LoadMessages();
        }

        private void InitializeComponent()
        {
            Label lblTitle = new Label();
            Label lblSender = new Label();
            Label lblReceiver = new Label();
            Label lblSubject = new Label();
            Label lblContent = new Label();
            TableLayoutPanel rootLayout = new TableLayoutPanel();
            TableLayoutPanel bodyLayout = new TableLayoutPanel();
            TableLayoutPanel leftLayout = new TableLayoutPanel();
            TableLayoutPanel rightLayout = new TableLayoutPanel();
            FlowLayoutPanel listButtonLayout = new FlowLayoutPanel();
            FlowLayoutPanel formButtonLayout = new FlowLayoutPanel();

            this.dgvMessages = new DataGridView();
            this.txtSenderEmail = new TextBox();
            this.txtReceiverEmail = new TextBox();
            this.txtSubject = new TextBox();
            this.rtbContent = new RichTextBox();
            this.btnRefresh = new Button();
            this.btnSave = new Button();
            this.btnRead = new Button();
            this.btnDelete = new Button();
            this.btnClear = new Button();

            ((System.ComponentModel.ISupportInitialize)this.dgvMessages).BeginInit();
            this.SuspendLayout();

            rootLayout.ColumnCount = 1;
            rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            rootLayout.Dock = DockStyle.Fill;
            rootLayout.RowCount = 2;
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 54F));
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            bodyLayout.ColumnCount = 2;
            bodyLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58F));
            bodyLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42F));
            bodyLayout.Dock = DockStyle.Fill;
            bodyLayout.Padding = new Padding(16, 0, 16, 12);

            leftLayout.ColumnCount = 1;
            leftLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            leftLayout.Dock = DockStyle.Fill;
            leftLayout.Margin = new Padding(0, 0, 10, 0);
            leftLayout.RowCount = 2;
            leftLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            leftLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 54F));

            rightLayout.ColumnCount = 2;
            rightLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            rightLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            rightLayout.Dock = DockStyle.Fill;
            rightLayout.Margin = new Padding(10, 0, 0, 0);
            rightLayout.RowCount = 5;
            rightLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            rightLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            rightLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            rightLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            rightLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 54F));

            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 114, 118);
            lblTitle.Padding = new Padding(18, 0, 0, 0);
            lblTitle.Text = this._currentUser is Admin ? "HÒM THƯ QUẢN TRỊ" : "HÒM THƯ CÁ NHÂN";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;

            this.dgvMessages.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMessages.BackgroundColor = Color.White;
            this.dgvMessages.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMessages.Dock = DockStyle.Fill;
            this.dgvMessages.Margin = Padding.Empty;
            this.dgvMessages.MultiSelect = false;
            this.dgvMessages.Name = "dgvMessages";
            this.dgvMessages.ReadOnly = true;
            this.dgvMessages.RowHeadersVisible = false;
            this.dgvMessages.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvMessages.TabIndex = 0;
            this.dgvMessages.CellClick += dgvMessages_CellClick;

            ConfigureFormLabel(lblSender, "Người gửi");
            ConfigureFormTextBox(this.txtSenderEmail);
            this.txtSenderEmail.Text = this._currentUser == null ? "" : this._currentUser.Email;
            this.txtSenderEmail.ReadOnly = !(this._currentUser is Admin);

            ConfigureFormLabel(lblReceiver, "Người nhận");
            ConfigureFormTextBox(this.txtReceiverEmail);
            this.txtReceiverEmail.Text = this._currentUser is Admin ? "admin@ueh.edu.vn" : "admin@ueh.edu.vn";

            ConfigureFormLabel(lblSubject, "Tiêu đề");
            ConfigureFormTextBox(this.txtSubject);

            ConfigureFormLabel(lblContent, "Nội dung");
            lblContent.TextAlign = ContentAlignment.TopLeft;
            this.rtbContent.BorderStyle = BorderStyle.FixedSingle;
            this.rtbContent.Dock = DockStyle.Fill;
            this.rtbContent.Margin = new Padding(0, 0, 0, 8);

            ConfigureButton(this.btnRefresh, "LÀM MỚI", Color.White, Color.Black, 106, 38);
            this.btnRefresh.Click += btnRefresh_Click;

            ConfigureButton(this.btnRead, "ĐÃ ĐỌC", Color.FromArgb(76, 175, 80), Color.White, 106, 38);
            this.btnRead.Click += btnRead_Click;

            ConfigureButton(this.btnDelete, "XÓA", Color.FromArgb(198, 40, 40), Color.White, 106, 38);
            this.btnDelete.Click += btnDelete_Click;

            ConfigureButton(this.btnSave, "LƯU THƯ", Color.FromArgb(0, 114, 118), Color.White, 120, 40);
            this.btnSave.Click += btnSave_Click;

            ConfigureButton(this.btnClear, "XÓA TRẮNG", Color.FromArgb(255, 112, 67), Color.White, 120, 40);
            this.btnClear.Click += btnClear_Click;

            listButtonLayout.Dock = DockStyle.Fill;
            listButtonLayout.FlowDirection = FlowDirection.LeftToRight;
            listButtonLayout.Margin = Padding.Empty;
            listButtonLayout.Padding = new Padding(0, 9, 0, 0);
            listButtonLayout.WrapContents = false;
            listButtonLayout.Controls.Add(this.btnRefresh);
            listButtonLayout.Controls.Add(this.btnRead);
            listButtonLayout.Controls.Add(this.btnDelete);

            formButtonLayout.Dock = DockStyle.Fill;
            formButtonLayout.FlowDirection = FlowDirection.LeftToRight;
            formButtonLayout.Margin = Padding.Empty;
            formButtonLayout.Padding = new Padding(0, 8, 0, 0);
            formButtonLayout.WrapContents = false;
            formButtonLayout.Controls.Add(this.btnSave);
            formButtonLayout.Controls.Add(this.btnClear);

            leftLayout.Controls.Add(this.dgvMessages, 0, 0);
            leftLayout.Controls.Add(listButtonLayout, 0, 1);

            rightLayout.Controls.Add(lblSender, 0, 0);
            rightLayout.Controls.Add(this.txtSenderEmail, 1, 0);
            rightLayout.Controls.Add(lblReceiver, 0, 1);
            rightLayout.Controls.Add(this.txtReceiverEmail, 1, 1);
            rightLayout.Controls.Add(lblSubject, 0, 2);
            rightLayout.Controls.Add(this.txtSubject, 1, 2);
            rightLayout.Controls.Add(lblContent, 0, 3);
            rightLayout.Controls.Add(this.rtbContent, 1, 3);
            rightLayout.Controls.Add(formButtonLayout, 0, 4);
            rightLayout.SetColumnSpan(formButtonLayout, 2);

            bodyLayout.Controls.Add(leftLayout, 0, 0);
            bodyLayout.Controls.Add(rightLayout, 1, 0);
            rootLayout.Controls.Add(lblTitle, 0, 0);
            rootLayout.Controls.Add(bodyLayout, 0, 1);

            this.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = Color.White;
            this.ClientSize = new Size(1021, 355);
            this.Controls.Add(rootLayout);
            this.Font = new Font("Segoe UI", 10F);
            this.FormBorderStyle = FormBorderStyle.None;
            this.MinimumSize = new Size(760, 320);
            this.Name = "MailboxForm";
            this.Text = "Hòm thư";

            ((System.ComponentModel.ISupportInitialize)this.dgvMessages).EndInit();
            this.ResumeLayout(false);
        }

        private static void ConfigureLabel(Label label, string text, int left, int top)
        {
            label.AutoSize = true;
            label.Location = new Point(left, top + 4);
            label.Text = text;
        }

        private static void ConfigureTextBox(TextBox textBox, int left, int top)
        {
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.Location = new Point(left, top);
            textBox.Size = new Size(275, 34);
        }

        private static void ConfigureFormLabel(Label label, string text)
        {
            label.Dock = DockStyle.Fill;
            label.Margin = new Padding(0, 0, 8, 8);
            label.Text = text;
            label.TextAlign = ContentAlignment.MiddleLeft;
        }

        private static void ConfigureFormTextBox(TextBox textBox)
        {
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.Dock = DockStyle.Fill;
            textBox.Margin = new Padding(0, 0, 0, 8);
            textBox.MinimumSize = new Size(0, 30);
        }

        private static void ConfigureButton(Button button, string text, Color backColor, Color foreColor, int width, int height)
        {
            button.BackColor = backColor;
            button.FlatStyle = FlatStyle.Flat;
            button.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button.ForeColor = foreColor;
            button.Margin = new Padding(0, 0, 10, 0);
            button.Size = new Size(width, height);
            button.Text = text;
            button.UseVisualStyleBackColor = false;
        }

        private void LoadMessages()
        {
            try
            {
                List<MailboxMessageRecord> messages = this._repository.LoadMailboxMessages();

                if (!(this._currentUser is Admin) && this._currentUser != null)
                {
                    messages = messages
                        .Where(message =>
                            string.Equals(message.SenderEmail, this._currentUser.Email, StringComparison.OrdinalIgnoreCase) ||
                            string.Equals(message.ReceiverEmail, this._currentUser.Email, StringComparison.OrdinalIgnoreCase))
                        .ToList();
                }

                this.dgvMessages.DataSource = null;
                this.dgvMessages.DataSource = messages;

                if (this.dgvMessages.Columns["Id"] != null) this.dgvMessages.Columns["Id"].Visible = false;
                if (this.dgvMessages.Columns["Content"] != null) this.dgvMessages.Columns["Content"].Visible = false;
                if (this.dgvMessages.Columns["SenderEmail"] != null) this.dgvMessages.Columns["SenderEmail"].HeaderText = "Người gửi";
                if (this.dgvMessages.Columns["ReceiverEmail"] != null) this.dgvMessages.Columns["ReceiverEmail"].HeaderText = "Người nhận";
                if (this.dgvMessages.Columns["Subject"] != null) this.dgvMessages.Columns["Subject"].HeaderText = "Tiêu đề";
                if (this.dgvMessages.Columns["CreatedAt"] != null) this.dgvMessages.Columns["CreatedAt"].HeaderText = "Thời gian";
                if (this.dgvMessages.Columns["IsRead"] != null) this.dgvMessages.Columns["IsRead"].HeaderText = "Đã đọc";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải hòm thư: " + ex.Message, "Lỗi database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvMessages_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || this.dgvMessages.CurrentRow == null)
            {
                return;
            }

            this.txtSenderEmail.Text = Convert.ToString(this.dgvMessages.CurrentRow.Cells["SenderEmail"].Value) ?? "";
            this.txtReceiverEmail.Text = Convert.ToString(this.dgvMessages.CurrentRow.Cells["ReceiverEmail"].Value) ?? "";
            this.txtSubject.Text = Convert.ToString(this.dgvMessages.CurrentRow.Cells["Subject"].Value) ?? "";
            this.rtbContent.Text = Convert.ToString(this.dgvMessages.CurrentRow.Cells["Content"].Value) ?? "";
        }

        private void btnRefresh_Click(object? sender, EventArgs e)
        {
            LoadMessages();
        }

        private void btnSave_Click(object? sender, EventArgs e)
        {
            string senderEmail = this._currentUser == null || this._currentUser is Admin
                ? this.txtSenderEmail.Text.Trim()
                : this._currentUser.Email;
            string receiverEmail = this.txtReceiverEmail.Text.Trim();
            string subject = this.txtSubject.Text.Trim();
            string content = this.rtbContent.Text.Trim();

            if (string.IsNullOrEmpty(senderEmail) || string.IsNullOrEmpty(receiverEmail) ||
                string.IsNullOrEmpty(subject) || string.IsNullOrEmpty(content))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin thư.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool isSuccess = this._repository.AddMailboxMessage(senderEmail, receiverEmail, subject, content);

                if (isSuccess)
                {
                    MessageBox.Show("Lưu thư vào hòm thư thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                    LoadMessages();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể lưu thư: " + ex.Message, "Lỗi database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRead_Click(object? sender, EventArgs e)
        {
            int id = GetSelectedMessageId();
            if (id <= 0)
            {
                MessageBox.Show("Vui lòng chọn một thư để đánh dấu đã đọc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (this._repository.MarkMessageAsRead(id))
                {
                    MessageBox.Show("Đã đánh dấu thư là đã đọc.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadMessages();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể cập nhật trạng thái thư: " + ex.Message, "Lỗi database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object? sender, EventArgs e)
        {
            int id = GetSelectedMessageId();
            if (id <= 0)
            {
                MessageBox.Show("Vui lòng chọn một thư để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa thư này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes)
            {
                return;
            }

            try
            {
                if (this._repository.DeleteMailboxMessage(id))
                {
                    MessageBox.Show("Xóa thư thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                    LoadMessages();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa thư: " + ex.Message, "Lỗi database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object? sender, EventArgs e)
        {
            ClearInputs();
        }

        private int GetSelectedMessageId()
        {
            if (this.dgvMessages.CurrentRow == null || this.dgvMessages.CurrentRow.Cells["Id"].Value == null)
            {
                return 0;
            }

            return Convert.ToInt32(this.dgvMessages.CurrentRow.Cells["Id"].Value);
        }

        private void ClearInputs()
        {
            this.txtSenderEmail.Text = this._currentUser == null ? "" : this._currentUser.Email;
            this.txtReceiverEmail.Text = "admin@ueh.edu.vn";
            this.txtSubject.Clear();
            this.rtbContent.Clear();
        }
    }
}
