namespace PROJECT_OOP_WINFORM_FINAL
{
    partial class UC_NewsManager
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnApprove = new Button();
            btnDelete = new Button();
            dgvNews = new DataGridView();
            rtbContent = new RichTextBox();
            btnUnapprove = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvNews).BeginInit();
            SuspendLayout();
            // 
            // btnApprove
            // 
            btnApprove.BackColor = Color.White;
            btnApprove.FlatStyle = FlatStyle.Flat;
            btnApprove.Location = new Point(5, 58);
            btnApprove.Name = "btnApprove";
            btnApprove.Size = new Size(112, 34);
            btnApprove.TabIndex = 18;
            btnApprove.Text = "Duyệt";
            btnApprove.UseVisualStyleBackColor = false;
            btnApprove.Click += btnApprove_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.White;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Location = new Point(306, 58);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(112, 34);
            btnDelete.TabIndex = 17;
            btnDelete.Text = "Xoá";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // dgvNews
            // 
            dgvNews.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNews.BackgroundColor = Color.White;
            dgvNews.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNews.Location = new Point(1, 98);
            dgvNews.Name = "dgvNews";
            dgvNews.ReadOnly = true;
            dgvNews.RowHeadersWidth = 62;
            dgvNews.Size = new Size(1043, 509);
            dgvNews.TabIndex = 10;
            dgvNews.CellClick += dgvNews_CellClick;
            // 
            // rtbContent
            // 
            rtbContent.BackColor = Color.White;
            rtbContent.Location = new Point(188, 22);
            rtbContent.Name = "rtbContent";
            rtbContent.ReadOnly = true;
            rtbContent.Size = new Size(721, 584);
            rtbContent.TabIndex = 19;
            rtbContent.Text = "";
            // 
            // btnUnapprove
            // 
            btnUnapprove.BackColor = Color.White;
            btnUnapprove.FlatStyle = FlatStyle.Flat;
            btnUnapprove.Location = new Point(153, 58);
            btnUnapprove.Name = "btnUnapprove";
            btnUnapprove.Size = new Size(112, 34);
            btnUnapprove.TabIndex = 20;
            btnUnapprove.Text = "Huỷ duyệt";
            btnUnapprove.UseVisualStyleBackColor = false;
            btnUnapprove.Click += btnUnapprove_Click;
            // 
            // UC_NewsManager
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnUnapprove);
            Controls.Add(rtbContent);
            Controls.Add(btnApprove);
            Controls.Add(btnDelete);
            Controls.Add(dgvNews);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "UC_NewsManager";
            Size = new Size(1043, 609);
            ((System.ComponentModel.ISupportInitialize)dgvNews).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnApprove;
        private Button btnDelete;
        private DataGridView dgvNews;
        private RichTextBox rtbContent;
        private Button btnUnapprove;
    }
}
