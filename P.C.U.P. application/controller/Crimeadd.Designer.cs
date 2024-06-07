namespace P.C.U.P.application
{
    partial class Crimeadd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Crimeadd));
            this.victim = new System.Windows.Forms.TextBox();
            this.suspect = new System.Windows.Forms.TextBox();
            this.date = new MetroFramework.Controls.MetroDateTime();
            this.btnSave = new System.Windows.Forms.Button();
            this.update = new System.Windows.Forms.Button();
            this.bunifuLabel2 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.deleteapprove = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.barangaylist = new System.Windows.Forms.ComboBox();
            this.violation = new MetroFramework.Controls.MetroComboBox();
            this.remark = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // victim
            // 
            this.victim.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.victim.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.victim.Location = new System.Drawing.Point(241, 124);
            this.victim.Multiline = true;
            this.victim.Name = "victim";
            this.victim.Size = new System.Drawing.Size(372, 30);
            this.victim.TabIndex = 2;
            // 
            // suspect
            // 
            this.suspect.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.suspect.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.suspect.Location = new System.Drawing.Point(240, 188);
            this.suspect.Multiline = true;
            this.suspect.Name = "suspect";
            this.suspect.Size = new System.Drawing.Size(372, 30);
            this.suspect.TabIndex = 3;
            // 
            // date
            // 
            this.date.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.date.Location = new System.Drawing.Point(241, 65);
            this.date.MinimumSize = new System.Drawing.Size(0, 30);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(372, 30);
            this.date.TabIndex = 1;
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
            this.btnSave.Location = new System.Drawing.Point(240, 430);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(157, 60);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.update.Location = new System.Drawing.Point(240, 430);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(157, 60);
            this.update.TabIndex = 139;
            this.update.Text = "Update";
            this.update.UseVisualStyleBackColor = false;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // bunifuLabel2
            // 
            this.bunifuLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuLabel2.AutoSize = true;
            this.bunifuLabel2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))));
            this.bunifuLabel2.Location = new System.Drawing.Point(275, 6);
            this.bunifuLabel2.Name = "bunifuLabel2";
            this.bunifuLabel2.Size = new System.Drawing.Size(23, 28);
            this.bunifuLabel2.TabIndex = 146;
            this.bunifuLabel2.Text = "0";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))));
            this.label13.Location = new System.Drawing.Point(198, 6);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 28);
            this.label13.TabIndex = 145;
            this.label13.Text = "ID # : ";
            // 
            // deleteapprove
            // 
            this.deleteapprove.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteapprove.BackColor = System.Drawing.Color.Red;
            this.deleteapprove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteapprove.FlatAppearance.BorderSize = 0;
            this.deleteapprove.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(80)))), ((int)(((byte)(36)))), ((int)(((byte)(95)))));
            this.deleteapprove.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.deleteapprove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.deleteapprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteapprove.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteapprove.ForeColor = System.Drawing.Color.White;
            this.deleteapprove.Location = new System.Drawing.Point(455, 430);
            this.deleteapprove.Name = "deleteapprove";
            this.deleteapprove.Size = new System.Drawing.Size(157, 60);
            this.deleteapprove.TabIndex = 6;
            this.deleteapprove.Text = "Cancel";
            this.deleteapprove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.deleteapprove.UseVisualStyleBackColor = false;
            this.deleteapprove.Click += new System.EventHandler(this.deleteapprove_Click);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(114, 257);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(112, 28);
            this.label9.TabIndex = 144;
            this.label9.Text = "Barangay : ";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(47, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(179, 28);
            this.label4.TabIndex = 143;
            this.label4.Text = "Violator/Suspect : ";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(82, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 28);
            this.label3.TabIndex = 142;
            this.label3.Text = "Complainant : ";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(155, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 28);
            this.label2.TabIndex = 141;
            this.label2.Text = "Date : ";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(116, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 28);
            this.label1.TabIndex = 140;
            this.label1.Text = "Violation : ";
            // 
            // barangaylist
            // 
            this.barangaylist.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.barangaylist.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.barangaylist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.barangaylist.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barangaylist.FormattingEnabled = true;
            this.barangaylist.Location = new System.Drawing.Point(240, 257);
            this.barangaylist.Name = "barangaylist";
            this.barangaylist.Size = new System.Drawing.Size(373, 31);
            this.barangaylist.TabIndex = 4;
            // 
            // violation
            // 
            this.violation.FormattingEnabled = true;
            this.violation.ItemHeight = 24;
            this.violation.Items.AddRange(new object[] {
            "Theft",
            "Burglary",
            "Robbery",
            "Assault",
            "Vandalism",
            "Fraud",
            "Drug Offenses",
            "DUI (Driving Under the Influence)",
            "Domestic Violence",
            "Homicide/Murder"});
            this.violation.Location = new System.Drawing.Point(241, 13);
            this.violation.Name = "violation";
            this.violation.Size = new System.Drawing.Size(372, 30);
            this.violation.TabIndex = 0;
            this.violation.UseSelectable = true;
            // 
            // remark
            // 
            this.remark.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.remark.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.remark.Location = new System.Drawing.Point(241, 311);
            this.remark.Multiline = true;
            this.remark.Name = "remark";
            this.remark.Size = new System.Drawing.Size(372, 88);
            this.remark.TabIndex = 147;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(101, 311);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 28);
            this.label5.TabIndex = 148;
            this.label5.Text = "Comments :  ";
            // 
            // Crimeadd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))));
            this.ClientSize = new System.Drawing.Size(736, 502);
            this.Controls.Add(this.remark);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.barangaylist);
            this.Controls.Add(this.violation);
            this.Controls.Add(this.victim);
            this.Controls.Add(this.suspect);
            this.Controls.Add(this.date);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.update);
            this.Controls.Add(this.bunifuLabel2);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.deleteapprove);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Crimeadd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ADD CRIME";
            this.Load += new System.EventHandler(this.Crimeadd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox victim;
        public System.Windows.Forms.TextBox suspect;
        public MetroFramework.Controls.MetroDateTime date;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Button update;
        public System.Windows.Forms.Label bunifuLabel2;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.Button deleteapprove;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox barangaylist;
        public MetroFramework.Controls.MetroComboBox violation;
        public System.Windows.Forms.TextBox remark;
        private System.Windows.Forms.Label label5;
    }
}