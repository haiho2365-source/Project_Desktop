using Project_OOP;
using System;
using System.Collections.Generic;
using System.Drawing;
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

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 114, 118);
            lblTitle.Location = new Point(18, 15);
            lblTitle.Text = "HÒM THƯ QUẢN TRỊ";

            this.dgvMessages.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMessages.BackgroundColor = Color.White;
            this.dgvMessages.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMessages.Location = new Point(18, 58);
            this.dgvMessages.MultiSelect = false;
            this.dgvMessages.Name = "dgvMessages";
            this.dgvMessages.ReadOnly = true;
            this.dgvMessages.RowHeadersWidth = 51;
            this.dgvMessages.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvMessages.Size = new Size(560, 225);
            this.dgvMessages.TabIndex = 0;
            this.dgvMessages.CellClick += dgvMessages_CellClick;

            ConfigureLabel(lblSender, "Người gửi", 595, 58);
            ConfigureTextBox(this.txtSenderEmail, 710, 58);

            ConfigureLabel(lblReceiver, "Người nhận", 595, 102);
            ConfigureTextBox(this.txtReceiverEmail, 710, 102);
            this.txtReceiverEmail.Text = this._currentUser == null ? "admin@ueh.edu.vn" : this._currentUser.Email;

            ConfigureLabel(lblSubject, "Tiêu đề", 595, 146);
            ConfigureTextBox(this.txtSubject, 710, 146);

            ConfigureLabel(lblContent, "Nội dung", 595, 190);
            this.rtbContent.BorderStyle = BorderStyle.FixedSingle;
            this.rtbContent.Location = new Point(710, 190);
            this.rtbContent.Size = new Size(275, 72);

            ConfigureButton(this.btnRefresh, "LÀM MỚI", Color.White, Color.Black, 18, 295, 112, 38);
            this.btnRefresh.Click += btnRefresh_Click;

            ConfigureButton(this.btnRead, "ĐÃ ĐỌC", Color.FromArgb(76, 175, 80), Color.White, 140, 295, 112, 38);
            this.btnRead.Click += btnRead_Click;

            ConfigureButton(this.btnDelete, "XÓA", Color.FromArgb(198, 40, 40), Color.White, 262, 295, 112, 38);
            this.btnDelete.Click += btnDelete_Click;

            ConfigureButton(this.btnSave, "LƯU THƯ", Color.FromArgb(0, 114, 118), Color.White, 710, 275, 130, 42);
            this.btnSave.Click += btnSave_Click;

            ConfigureButton(this.btnClear, "XÓA TRẮNG", Color.FromArgb(255, 112, 67), Color.White, 855, 275, 130, 42);
            this.btnClear.Click += btnClear_Click;

            this.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = Color.White;
            this.ClientSize = new Size(1021, 355);
            this.Controls.Add(lblTitle);
            this.Controls.Add(this.dgvMessages);
            this.Controls.Add(lblSender);
            this.Controls.Add(this.txtSenderEmail);
            this.Controls.Add(lblReceiver);
            this.Controls.Add(this.txtReceiverEmail);
            this.Controls.Add(lblSubject);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(lblContent);
            this.Controls.Add(this.rtbContent);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClear);
            this.Font = new Font("Segoe UI", 10F);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Name = "MailboxForm";
            this.Text = "Hòm thư";

            ((System.ComponentModel.ISupportInitialize)this.dgvMessages).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
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

        private static void ConfigureButton(Button button, string text, Color backColor, Color foreColor, int left, int top, int width, int height)
        {
            button.BackColor = backColor;
            button.FlatStyle = FlatStyle.Flat;
            button.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button.ForeColor = foreColor;
            button.Location = new Point(left, top);
            button.Size = new Size(width, height);
            button.Text = text;
            button.UseVisualStyleBackColor = false;
        }

        private void LoadMessages()
        {
            try
            {
                List<MailboxMessageRecord> messages = this._repository.LoadMailboxMessages();
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
            string senderEmail = this.txtSenderEmail.Text.Trim();
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
            this.txtSenderEmail.Clear();
            this.txtReceiverEmail.Text = this._currentUser == null ? "admin@ueh.edu.vn" : this._currentUser.Email;
            this.txtSubject.Clear();
            this.rtbContent.Clear();
        }
    }
}
