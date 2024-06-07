namespace P.C.U.P.application
{
    partial class Useradd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Useradd));
            this.cancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.TextBox();
            this.fname = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.bunifuLabel2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.update = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.password = new System.Windows.Forms.TextBox();
            this.email = new System.Windows.Forms.TextBox();
            this.phone = new System.Windows.Forms.TextBox();
            this.role = new MetroFramework.Controls.MetroComboBox();
            this.Remarks = new MetroFramework.Controls.MetroComboBox();
            this.barangaylist = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cancel
            // 
            this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel.BackColor = System.Drawing.Color.Red;
            this.cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancel.FlatAppearance.BorderSize = 0;
            this.cancel.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(80)))), ((int)(((byte)(36)))), ((int)(((byte)(95)))));
            this.cancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.cancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel.ForeColor = System.Drawing.Color.White;
            this.cancel.Location = new System.Drawing.Point(499, 575);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(157, 60);
            this.cancel.TabIndex = 9;
            this.cancel.Text = "Cancel";
            this.cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cancel.UseVisualStyleBackColor = false;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoEllipsis = true;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(125, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 28);
            this.label3.TabIndex = 163;
            this.label3.Text = "Full Name : ";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(125, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 28);
            this.label4.TabIndex = 164;
            this.label4.Text = "Username : ";
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(283, 120);
            this.username.Multiline = true;
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(372, 30);
            this.username.TabIndex = 1;
            // 
            // fname
            // 
            this.fname.Location = new System.Drawing.Point(284, 56);
            this.fname.Multiline = true;
            this.fname.Name = "fname";
            this.fname.Size = new System.Drawing.Size(372, 30);
            this.fname.TabIndex = 0;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))));
            this.label13.Location = new System.Drawing.Point(202, 5);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 28);
            this.label13.TabIndex = 167;
            this.label13.Text = "ID # : ";
            // 
            // bunifuLabel2
            // 
            this.bunifuLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuLabel2.AutoSize = true;
            this.bunifuLabel2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))));
            this.bunifuLabel2.Location = new System.Drawing.Point(279, 5);
            this.bunifuLabel2.Name = "bunifuLabel2";
            this.bunifuLabel2.Size = new System.Drawing.Size(23, 28);
            this.bunifuLabel2.TabIndex = 168;
            this.bunifuLabel2.Text = "0";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(158, 300);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 28);
            this.label1.TabIndex = 169;
            this.label1.Text = "Phone : ";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(132, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 28);
            this.label2.TabIndex = 170;
            this.label2.Text = "Password : ";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(169, 233);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 28);
            this.label6.TabIndex = 171;
            this.label6.Text = "Email : ";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(175, 371);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 28);
            this.label8.TabIndex = 172;
            this.label8.Text = "Role :";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(134, 432);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(112, 28);
            this.label9.TabIndex = 173;
            this.label9.Text = "Barangay : ";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(175, 489);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 28);
            this.label7.TabIndex = 174;
            this.label7.Text = "Type :";
            // 
            // update
            // 
            this.update.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.update.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(40)))), ((int)(((byte)(91)))));
            this.update.Cursor = System.Windows.Forms.Cursors.Hand;
            this.update.FlatAppearance.BorderSize = 0;
            this.update.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(80)))), ((int)(((byte)(36)))), ((int)(((byte)(95)))));
            this.update.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(143)))), ((int)(((byte)(241)))));
            this.update.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(80)))), ((int)(((byte)(36)))), ((int)(((byte)(95)))));
            this.update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.update.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.update.ForeColor = System.Drawing.Color.White;
            this.update.Location = new System.Drawing.Point(298, 575);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(157, 60);
            this.update.TabIndex = 176;
            this.update.Text = "Update";
            this.update.UseVisualStyleBackColor = false;
            this.update.Click += new System.EventHandler(this.update_Click);
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
            this.btnSave.Location = new System.Drawing.Point(298, 575);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(157, 60);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(283, 174);
            this.password.Multiline = true;
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(372, 30);
            this.password.TabIndex = 2;
            // 
            // email
            // 
            this.email.Location = new System.Drawing.Point(283, 233);
            this.email.Multiline = true;
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(372, 30);
            this.email.TabIndex = 3;
            // 
            // phone
            // 
            this.phone.Location = new System.Drawing.Point(284, 300);
            this.phone.Multiline = true;
            this.phone.Name = "phone";
            this.phone.Size = new System.Drawing.Size(372, 30);
            this.phone.TabIndex = 4;
            // 
            // role
            // 
            this.role.FormattingEnabled = true;
            this.role.ItemHeight = 24;
            this.role.Items.AddRange(new object[] {
            "ADMIN",
            "CLIENT"});
            this.role.Location = new System.Drawing.Point(284, 371);
            this.role.Name = "role";
            this.role.Size = new System.Drawing.Size(372, 30);
            this.role.TabIndex = 5;
            this.role.UseSelectable = true;
            // 
            // Remarks
            // 
            this.Remarks.FormattingEnabled = true;
            this.Remarks.ItemHeight = 24;
            this.Remarks.Items.AddRange(new object[] {
            "NEW"});
            this.Remarks.Location = new System.Drawing.Point(283, 489);
            this.Remarks.Name = "Remarks";
            this.Remarks.Size = new System.Drawing.Size(372, 30);
            this.Remarks.TabIndex = 7;
            this.Remarks.UseSelectable = true;
            // 
            // barangaylist
            // 
            this.barangaylist.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.barangaylist.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.barangaylist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.barangaylist.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barangaylist.FormattingEnabled = true;
            this.barangaylist.Location = new System.Drawing.Point(282, 432);
            this.barangaylist.Name = "barangaylist";
            this.barangaylist.Size = new System.Drawing.Size(373, 31);
            this.barangaylist.TabIndex = 6;
            // 
            // Useradd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))));
            this.ClientSize = new System.Drawing.Size(829, 674);
            this.Controls.Add(this.barangaylist);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.Remarks);
            this.Controls.Add(this.role);
            this.Controls.Add(this.phone);
            this.Controls.Add(this.email);
            this.Controls.Add(this.password);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.update);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bunifuLabel2);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.fname);
            this.Controls.Add(this.username);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Useradd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ADD USER";
            this.Load += new System.EventHandler(this.Useradd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox username;
        public System.Windows.Forms.TextBox fname;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.Label bunifuLabel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.Button update;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.TextBox password;
        public System.Windows.Forms.TextBox email;
        public System.Windows.Forms.TextBox phone;
        public MetroFramework.Controls.MetroComboBox role;
        public MetroFramework.Controls.MetroComboBox Remarks;
        public System.Windows.Forms.ComboBox barangaylist;
    }
}