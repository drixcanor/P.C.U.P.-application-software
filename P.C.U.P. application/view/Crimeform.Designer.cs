namespace P.C.U.P.application
{
    partial class Crimeform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Crimeform));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.searchcrime = new MetroFramework.Controls.MetroTextBox();
            this.selectcrime = new MetroFramework.Controls.MetroComboBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.editcrime = new System.Windows.Forms.Button();
            this.deletecrime = new System.Windows.Forms.Button();
            this.addcrime = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.crimechart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.crimepanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.crimedg = new System.Windows.Forms.DataGridView();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.crimechart)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.crimepanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.crimedg)).BeginInit();
            this.SuspendLayout();
            // 
            // searchcrime
            // 
            // 
            // 
            // 
            this.searchcrime.CustomButton.Image = null;
            this.searchcrime.CustomButton.Location = new System.Drawing.Point(255, 2);
            this.searchcrime.CustomButton.Name = "";
            this.searchcrime.CustomButton.Size = new System.Drawing.Size(31, 31);
            this.searchcrime.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.searchcrime.CustomButton.TabIndex = 1;
            this.searchcrime.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.searchcrime.CustomButton.UseSelectable = true;
            this.searchcrime.CustomButton.Visible = false;
            this.searchcrime.Lines = new string[0];
            this.searchcrime.Location = new System.Drawing.Point(63, 19);
            this.searchcrime.MaxLength = 32767;
            this.searchcrime.Multiline = true;
            this.searchcrime.Name = "searchcrime";
            this.searchcrime.PasswordChar = '\0';
            this.searchcrime.PromptText = "Search";
            this.searchcrime.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.searchcrime.SelectedText = "";
            this.searchcrime.SelectionLength = 0;
            this.searchcrime.SelectionStart = 0;
            this.searchcrime.ShortcutsEnabled = true;
            this.searchcrime.Size = new System.Drawing.Size(289, 36);
            this.searchcrime.TabIndex = 31;
            this.searchcrime.UseSelectable = true;
            this.searchcrime.WaterMark = "Search";
            this.searchcrime.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.searchcrime.WaterMarkFont = new System.Drawing.Font("Segoe UI", 9F);
            this.searchcrime.Click += new System.EventHandler(this.searchcrime_Click);
            // 
            // selectcrime
            // 
            this.selectcrime.FormattingEnabled = true;
            this.selectcrime.ItemHeight = 24;
            this.selectcrime.Location = new System.Drawing.Point(855, 30);
            this.selectcrime.Name = "selectcrime";
            this.selectcrime.PromptText = "Select Barangay";
            this.selectcrime.Size = new System.Drawing.Size(207, 30);
            this.selectcrime.TabIndex = 30;
            this.selectcrime.UseSelectable = true;
            this.selectcrime.SelectedIndexChanged += new System.EventHandler(this.selectcrime_SelectedIndexChanged_1);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(366, 33);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(91, 24);
            this.checkBox2.TabIndex = 29;
            this.checkBox2.Text = "Select all";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // editcrime
            // 
            this.editcrime.BackColor = System.Drawing.Color.LawnGreen;
            this.editcrime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.editcrime.FlatAppearance.BorderSize = 0;
            this.editcrime.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(80)))), ((int)(((byte)(36)))), ((int)(((byte)(95)))));
            this.editcrime.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(168)))), ((int)(((byte)(0)))));
            this.editcrime.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(226)))), ((int)(((byte)(170)))));
            this.editcrime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editcrime.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editcrime.ForeColor = System.Drawing.Color.White;
            this.editcrime.Image = ((System.Drawing.Image)(resources.GetObject("editcrime.Image")));
            this.editcrime.Location = new System.Drawing.Point(607, 11);
            this.editcrime.Name = "editcrime";
            this.editcrime.Size = new System.Drawing.Size(100, 49);
            this.editcrime.TabIndex = 27;
            this.editcrime.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.editcrime.UseVisualStyleBackColor = false;
            this.editcrime.Click += new System.EventHandler(this.editcrime_Click);
            // 
            // deletecrime
            // 
            this.deletecrime.BackColor = System.Drawing.Color.Red;
            this.deletecrime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deletecrime.FlatAppearance.BorderSize = 0;
            this.deletecrime.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(80)))), ((int)(((byte)(36)))), ((int)(((byte)(95)))));
            this.deletecrime.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.deletecrime.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.deletecrime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deletecrime.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deletecrime.ForeColor = System.Drawing.Color.White;
            this.deletecrime.Image = ((System.Drawing.Image)(resources.GetObject("deletecrime.Image")));
            this.deletecrime.Location = new System.Drawing.Point(713, 11);
            this.deletecrime.Name = "deletecrime";
            this.deletecrime.Size = new System.Drawing.Size(100, 49);
            this.deletecrime.TabIndex = 26;
            this.deletecrime.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.deletecrime.UseVisualStyleBackColor = false;
            this.deletecrime.Click += new System.EventHandler(this.deletecrime_Click);
            // 
            // addcrime
            // 
            this.addcrime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(40)))), ((int)(((byte)(91)))));
            this.addcrime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addcrime.FlatAppearance.BorderSize = 0;
            this.addcrime.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(80)))), ((int)(((byte)(36)))), ((int)(((byte)(95)))));
            this.addcrime.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(143)))), ((int)(((byte)(241)))));
            this.addcrime.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(80)))), ((int)(((byte)(36)))), ((int)(((byte)(95)))));
            this.addcrime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addcrime.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addcrime.ForeColor = System.Drawing.Color.White;
            this.addcrime.Image = ((System.Drawing.Image)(resources.GetObject("addcrime.Image")));
            this.addcrime.Location = new System.Drawing.Point(501, 11);
            this.addcrime.Name = "addcrime";
            this.addcrime.Size = new System.Drawing.Size(100, 49);
            this.addcrime.TabIndex = 28;
            this.addcrime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addcrime.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.addcrime.UseVisualStyleBackColor = false;
            this.addcrime.Click += new System.EventHandler(this.addcrime_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(14, 19);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(43, 36);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 22;
            this.pictureBox2.TabStop = false;
            // 
            // crimechart
            // 
            this.crimechart.BackColor = System.Drawing.Color.Gray;
            this.crimechart.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.DiagonalRight;
            this.crimechart.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss;
            chartArea1.Name = "ChartArea1";
            this.crimechart.ChartAreas.Add(chartArea1);
            this.crimechart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.crimechart.Legends.Add(legend1);
            this.crimechart.Location = new System.Drawing.Point(3, 3);
            this.crimechart.Name = "crimechart";
            this.crimechart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.crimechart.Series.Add(series1);
            this.crimechart.Size = new System.Drawing.Size(1377, 487);
            this.crimechart.TabIndex = 0;
            this.crimechart.Text = "chart2";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.crimechart, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.crimepanel, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 64.44444F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.55556F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1383, 765);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // crimepanel
            // 
            this.crimepanel.AutoScroll = true;
            this.crimepanel.AutoSize = true;
            this.crimepanel.BackColor = System.Drawing.Color.GhostWhite;
            this.crimepanel.Controls.Add(this.button1);
            this.crimepanel.Controls.Add(this.searchcrime);
            this.crimepanel.Controls.Add(this.selectcrime);
            this.crimepanel.Controls.Add(this.checkBox2);
            this.crimepanel.Controls.Add(this.editcrime);
            this.crimepanel.Controls.Add(this.deletecrime);
            this.crimepanel.Controls.Add(this.addcrime);
            this.crimepanel.Controls.Add(this.pictureBox2);
            this.crimepanel.Controls.Add(this.crimedg);
            this.crimepanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crimepanel.Location = new System.Drawing.Point(3, 496);
            this.crimepanel.Name = "crimepanel";
            this.crimepanel.Size = new System.Drawing.Size(1377, 266);
            this.crimepanel.TabIndex = 28;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(80)))), ((int)(((byte)(36)))), ((int)(((byte)(95)))));
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(143)))), ((int)(((byte)(241)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(80)))), ((int)(((byte)(36)))), ((int)(((byte)(95)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(1318, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(46, 49);
            this.button1.TabIndex = 61;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // crimedg
            // 
            this.crimedg.AllowUserToAddRows = false;
            this.crimedg.AllowUserToDeleteRows = false;
            this.crimedg.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.crimedg.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.crimedg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crimedg.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.crimedg.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.crimedg.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.crimedg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.crimedg.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(165)))), ((int)(((byte)(165)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.crimedg.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.crimedg.ColumnHeadersHeight = 29;
            this.crimedg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn2,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.Column2,
            this.Column1});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.crimedg.DefaultCellStyle = dataGridViewCellStyle3;
            this.crimedg.Location = new System.Drawing.Point(14, 66);
            this.crimedg.Name = "crimedg";
            this.crimedg.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.crimedg.RowHeadersVisible = false;
            this.crimedg.RowHeadersWidth = 51;
            this.crimedg.RowTemplate.Height = 24;
            this.crimedg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.crimedg.Size = new System.Drawing.Size(1350, 185);
            this.crimedg.TabIndex = 12;
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewCheckBoxColumn2.HeaderText = "";
            this.dataGridViewCheckBoxColumn2.MinimumWidth = 50;
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            this.dataGridViewCheckBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewCheckBoxColumn2.Width = 50;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn6.HeaderText = "ID #";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Visible = false;
            this.dataGridViewTextBoxColumn6.Width = 66;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn7.HeaderText = "VIOLATION";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 112;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn9.HeaderText = "DATE";
            this.dataGridViewTextBoxColumn9.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 74;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn8.HeaderText = "COMPLAINANT";
            this.dataGridViewTextBoxColumn8.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 140;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn10.HeaderText = "VIOLATOR/SUSPECT";
            this.dataGridViewTextBoxColumn10.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn11.HeaderText = "BARANGAY";
            this.dataGridViewTextBoxColumn11.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "COMMENTS";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "STATUS";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            this.Column1.Width = 88;
            // 
            // Crimeform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1383, 765);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HelpButton = true;
            this.Name = "Crimeform";
            this.Text = "Crimeform";
            this.Load += new System.EventHandler(this.Crimeform_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.crimechart)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.crimepanel.ResumeLayout(false);
            this.crimepanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.crimedg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public MetroFramework.Controls.MetroComboBox selectcrime;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Button editcrime;
        private System.Windows.Forms.Button deletecrime;
        private System.Windows.Forms.Button addcrime;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DataVisualization.Charting.Chart crimechart;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel crimepanel;
        private System.Windows.Forms.DataGridView crimedg;
        public MetroFramework.Controls.MetroTextBox searchcrime;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}