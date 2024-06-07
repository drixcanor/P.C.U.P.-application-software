namespace P.C.U.P.application
{
    partial class login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            this.button1 = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.user_password = new MetroFramework.Controls.MetroTextBox();
            this.user_name = new MetroFramework.Controls.MetroTextBox();
            this.btnSign_in = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(40)))), ((int)(((byte)(91)))));
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(80)))), ((int)(((byte)(36)))), ((int)(((byte)(95)))));
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(143)))), ((int)(((byte)(241)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(80)))), ((int)(((byte)(36)))), ((int)(((byte)(95)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(241, 416);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 50);
            this.button1.TabIndex = 1;
            this.button1.Text = "Sign up";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(40)))), ((int)(((byte)(91)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(80)))), ((int)(((byte)(36)))), ((int)(((byte)(95)))));
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(143)))), ((int)(((byte)(241)))));
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(80)))), ((int)(((byte)(36)))), ((int)(((byte)(95)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(60, 416);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(132, 50);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Sign in";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(426, 362);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.user_password);
            this.panel1.Controls.Add(this.user_name);
            this.panel1.Controls.Add(this.btnSign_in);
            this.panel1.Controls.Add(this.button7);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(444, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(499, 537);
            this.panel1.TabIndex = 15;
            // 
            // user_password
            // 
            // 
            // 
            // 
            this.user_password.CustomButton.Image = null;
            this.user_password.CustomButton.Location = new System.Drawing.Point(321, 1);
            this.user_password.CustomButton.Name = "";
            this.user_password.CustomButton.Size = new System.Drawing.Size(39, 39);
            this.user_password.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.user_password.CustomButton.TabIndex = 1;
            this.user_password.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.user_password.CustomButton.UseSelectable = true;
            this.user_password.CustomButton.Visible = false;
            this.user_password.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.user_password.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.user_password.Lines = new string[0];
            this.user_password.Location = new System.Drawing.Point(81, 270);
            this.user_password.MaxLength = 32767;
            this.user_password.Multiline = true;
            this.user_password.Name = "user_password";
            this.user_password.PasswordChar = '*';
            this.user_password.PromptText = "Password";
            this.user_password.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.user_password.SelectedText = "";
            this.user_password.SelectionLength = 0;
            this.user_password.SelectionStart = 0;
            this.user_password.ShortcutsEnabled = true;
            this.user_password.Size = new System.Drawing.Size(361, 41);
            this.user_password.TabIndex = 1;
            this.user_password.UseSelectable = true;
            this.user_password.WaterMark = "Password";
            this.user_password.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.user_password.WaterMarkFont = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user_password.Click += new System.EventHandler(this.user_password_Click);
            this.user_password.Enter += new System.EventHandler(this.user_password_Enter);
            this.user_password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.user_password_KeyDown);
            // 
            // user_name
            // 
            // 
            // 
            // 
            this.user_name.CustomButton.Image = null;
            this.user_name.CustomButton.Location = new System.Drawing.Point(321, 1);
            this.user_name.CustomButton.Name = "";
            this.user_name.CustomButton.Size = new System.Drawing.Size(39, 39);
            this.user_name.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.user_name.CustomButton.TabIndex = 1;
            this.user_name.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.user_name.CustomButton.UseSelectable = true;
            this.user_name.CustomButton.Visible = false;
            this.user_name.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.user_name.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.user_name.Lines = new string[0];
            this.user_name.Location = new System.Drawing.Point(81, 212);
            this.user_name.MaxLength = 32767;
            this.user_name.Multiline = true;
            this.user_name.Name = "user_name";
            this.user_name.PasswordChar = '\0';
            this.user_name.PromptText = "Username";
            this.user_name.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.user_name.SelectedText = "";
            this.user_name.SelectionLength = 0;
            this.user_name.SelectionStart = 0;
            this.user_name.ShortcutsEnabled = true;
            this.user_name.Size = new System.Drawing.Size(361, 41);
            this.user_name.TabIndex = 0;
            this.user_name.UseSelectable = true;
            this.user_name.WaterMark = "Username";
            this.user_name.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.user_name.WaterMarkFont = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnSign_in
            // 
            this.btnSign_in.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSign_in.BackColor = System.Drawing.Color.White;
            this.btnSign_in.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSign_in.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(40)))), ((int)(((byte)(91)))));
            this.btnSign_in.FlatAppearance.BorderSize = 2;
            this.btnSign_in.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(80)))), ((int)(((byte)(36)))), ((int)(((byte)(95)))));
            this.btnSign_in.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(143)))), ((int)(((byte)(241)))));
            this.btnSign_in.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(80)))), ((int)(((byte)(36)))), ((int)(((byte)(95)))));
            this.btnSign_in.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSign_in.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSign_in.ForeColor = System.Drawing.Color.Black;
            this.btnSign_in.Location = new System.Drawing.Point(81, 416);
            this.btnSign_in.Name = "btnSign_in";
            this.btnSign_in.Size = new System.Drawing.Size(361, 50);
            this.btnSign_in.TabIndex = 2;
            this.btnSign_in.Text = "Login";
            this.btnSign_in.UseVisualStyleBackColor = false;
            this.btnSign_in.Click += new System.EventHandler(this.btnSign_in_Click);
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button7.BackColor = System.Drawing.Color.Transparent;
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.button7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Image = ((System.Drawing.Image)(resources.GetObject("button7.Image")));
            this.button7.Location = new System.Drawing.Point(447, 3);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(49, 36);
            this.button7.TabIndex = 127;
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.checkBox1.FlatAppearance.BorderSize = 2;
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.Color.White;
            this.checkBox1.Location = new System.Drawing.Point(288, 317);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(154, 25);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Show Password";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(185, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sign in";
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 537);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "login";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        public MetroFramework.Controls.MetroTextBox user_password;
        public MetroFramework.Controls.MetroTextBox user_name;
        public System.Windows.Forms.Button btnSign_in;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
    }
}