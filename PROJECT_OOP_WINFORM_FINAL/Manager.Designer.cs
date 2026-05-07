namespace PROJECT_OOP_WINFORM_FINAL
{
    partial class Manager
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            btnLogout = new Button();
            btnProfile = new Button();
            btnPostMgr = new Button();
            btnUserMgr = new Button();
            label2 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 114, 118);
            panel1.Controls.Add(btnLogout);
            panel1.Controls.Add(btnProfile);
            panel1.Controls.Add(btnPostMgr);
            panel1.Controls.Add(btnUserMgr);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1021, 198);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(0, 114, 118);
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(888, 119);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(133, 79);
            btnLogout.TabIndex = 7;
            btnLogout.Text = "Đăng xuất";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            btnLogout.MouseEnter += btnNav_MouseEnter;
            btnLogout.MouseLeave += btnNav_MouseLeave;
            // 
            // btnProfile
            // 
            btnProfile.BackColor = Color.FromArgb(0, 114, 118);
            btnProfile.FlatAppearance.BorderSize = 0;
            btnProfile.FlatStyle = FlatStyle.Flat;
            btnProfile.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnProfile.ForeColor = Color.White;
            btnProfile.Location = new Point(278, 119);
            btnProfile.Name = "btnProfile";
            btnProfile.Size = new Size(133, 79);
            btnProfile.TabIndex = 6;
            btnProfile.Text = "Hồ sơ";
            btnProfile.UseVisualStyleBackColor = false;
            btnProfile.MouseEnter += btnNav_MouseEnter;
            btnProfile.MouseLeave += btnNav_MouseLeave;
            // 
            // btnPostMgr
            // 
            btnPostMgr.BackColor = Color.FromArgb(0, 114, 118);
            btnPostMgr.FlatAppearance.BorderSize = 0;
            btnPostMgr.FlatStyle = FlatStyle.Flat;
            btnPostMgr.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnPostMgr.ForeColor = Color.White;
            btnPostMgr.Location = new Point(139, 119);
            btnPostMgr.Name = "btnPostMgr";
            btnPostMgr.Size = new Size(133, 79);
            btnPostMgr.TabIndex = 5;
            btnPostMgr.Text = "Quản lý\r\nbài báo";
            btnPostMgr.UseVisualStyleBackColor = false;
            btnPostMgr.Click += btnPostMgr_Click;
            btnPostMgr.MouseEnter += btnNav_MouseEnter;
            btnPostMgr.MouseLeave += btnNav_MouseLeave;
            // 
            // btnUserMgr
            // 
            btnUserMgr.BackColor = Color.FromArgb(0, 114, 118);
            btnUserMgr.FlatAppearance.BorderSize = 0;
            btnUserMgr.FlatStyle = FlatStyle.Flat;
            btnUserMgr.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnUserMgr.ForeColor = Color.White;
            btnUserMgr.Location = new Point(0, 119);
            btnUserMgr.Name = "btnUserMgr";
            btnUserMgr.Size = new Size(133, 79);
            btnUserMgr.TabIndex = 0;
            btnUserMgr.Text = "Quản lý\r\nngười dùng";
            btnUserMgr.UseVisualStyleBackColor = false;
            btnUserMgr.Click += btnUserMgr_Click;
            btnUserMgr.MouseEnter += btnNav_MouseEnter;
            btnUserMgr.MouseLeave += btnNav_MouseLeave;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(255, 112, 67);
            label2.Location = new Point(132, 54);
            label2.Name = "label2";
            label2.Size = new Size(166, 48);
            label2.TabIndex = 4;
            label2.Text = "BẢN TIN";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(174, 48);
            label1.TabIndex = 3;
            label1.Text = "QUẢN LÝ";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Location = new Point(0, 198);
            panel2.Name = "panel2";
            panel2.Size = new Size(1021, 355);
            panel2.TabIndex = 1;
            // 
            // Manager
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            ClientSize = new Size(1021, 553);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Manager";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GIAO DIỆN QUẢN TRỊ VIÊN";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label2;
        private Label label1;
        private Button btnUserMgr;
        private Panel panel2;
        private Button btnProfile;
        private Button btnPostMgr;
        private Button btnLogout;
    }
}