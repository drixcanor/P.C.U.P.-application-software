namespace P.C.U.P.application
{
    partial class Programform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Programform));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.search = new MetroFramework.Controls.MetroTextBox();
            this.select = new MetroFramework.Controls.MetroComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btneditreport = new System.Windows.Forms.Button();
            this.btndeletereport = new System.Windows.Forms.Button();
            this.btnAddreport = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.crimepanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.dg_programs = new System.Windows.Forms.DataGridView();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.crimepanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_programs)).BeginInit();
            this.SuspendLayout();
            // 
            // search
            // 
            // 
            // 
            // 
            this.search.CustomButton.Image = null;
            this.search.CustomButton.Location = new System.Drawing.Point(255, 2);
            this.search.CustomButton.Name = "";
            this.search.CustomButton.Size = new System.Drawing.Size(31, 31);
            this.search.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.search.CustomButton.TabIndex = 1;
            this.search.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.search.CustomButton.UseSelectable = true;
            this.search.CustomButton.Visible = false;
            this.search.Lines = new string[0];
            this.search.Location = new System.Drawing.Point(65, 38);
            this.search.MaxLength = 32767;
            this.search.Multiline = true;
            this.search.Name = "search";
            this.search.PasswordChar = '\0';
            this.search.PromptText = "Search";
            this.search.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.search.SelectedText = "";
            this.search.SelectionLength = 0;
            this.search.SelectionStart = 0;
            this.search.ShortcutsEnabled = true;
            this.search.Size = new System.Drawing.Size(289, 36);
            this.search.TabIndex = 31;
            this.search.UseSelectable = true;
            this.search.WaterMark = "Search";
            this.search.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.search.WaterMarkFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search.TextChanged += new System.EventHandler(this.search_TextChanged);
            // 
            // select
            // 
            this.select.FormattingEnabled = true;
            this.select.ItemHeight = 24;
            this.select.Location = new System.Drawing.Point(820, 54);
            this.select.Name = "select";
            this.select.PromptText = "Select Barangay";
            this.select.Size = new System.Drawing.Size(184, 30);
            this.select.TabIndex = 30;
            this.select.UseSelectable = true;
            this.select.SelectedIndexChanged += new System.EventHandler(this.select_SelectedIndexChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(368, 52);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(91, 24);
            this.checkBox1.TabIndex = 29;
            this.checkBox1.Text = "Select all";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btneditreport
            // 
            this.btneditreport.BackColor = System.Drawing.Color.LawnGreen;
            this.btneditreport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btneditreport.FlatAppearance.BorderSize = 0;
            this.btneditreport.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(80)))), ((int)(((byte)(36)))), ((int)(((byte)(95)))));
            this.btneditreport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(168)))), ((int)(((byte)(0)))));
            this.btneditreport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(226)))), ((int)(((byte)(170)))));
            this.btneditreport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btneditreport.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btneditreport.ForeColor = System.Drawing.Color.White;
            this.btneditreport.Image = ((System.Drawing.Image)(resources.GetObject("btneditreport.Image")));
            this.btneditreport.Location = new System.Drawing.Point(576, 35);
            this.btneditreport.Name = "btneditreport";
            this.btneditreport.Size = new System.Drawing.Size(100, 49);
            this.btneditreport.TabIndex = 27;
            this.btneditreport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btneditreport.UseVisualStyleBackColor = false;
            this.btneditreport.Click += new System.EventHandler(this.btneditreport_Click);
            // 
            // btndeletereport
            // 
            this.btndeletereport.BackColor = System.Drawing.Color.Red;
            this.btndeletereport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btndeletereport.FlatAppearance.BorderSize = 0;
            this.btndeletereport.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(80)))), ((int)(((byte)(36)))), ((int)(((byte)(95)))));
            this.btndeletereport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btndeletereport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.btndeletereport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndeletereport.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndeletereport.ForeColor = System.Drawing.Color.White;
            this.btndeletereport.Image = ((System.Drawing.Image)(resources.GetObject("btndeletereport.Image")));
            this.btndeletereport.Location = new System.Drawing.Point(682, 35);
            this.btndeletereport.Name = "btndeletereport";
            this.btndeletereport.Size = new System.Drawing.Size(100, 49);
            this.btndeletereport.TabIndex = 26;
            this.btndeletereport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btndeletereport.UseVisualStyleBackColor = false;
            this.btndeletereport.Click += new System.EventHandler(this.btndeletereport_Click);
            // 
            // btnAddreport
            // 
            this.btnAddreport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(40)))), ((int)(((byte)(91)))));
            this.btnAddreport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddreport.FlatAppearance.BorderSize = 0;
            this.btnAddreport.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(80)))), ((int)(((byte)(36)))), ((int)(((byte)(95)))));
            this.btnAddreport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(143)))), ((int)(((byte)(241)))));
            this.btnAddreport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(80)))), ((int)(((byte)(36)))), ((int)(((byte)(95)))));
            this.btnAddreport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddreport.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddreport.ForeColor = System.Drawing.Color.White;
            this.btnAddreport.Image = ((System.Drawing.Image)(resources.GetObject("btnAddreport.Image")));
            this.btnAddreport.Location = new System.Drawing.Point(470, 35);
            this.btnAddreport.Name = "btnAddreport";
            this.btnAddreport.Size = new System.Drawing.Size(100, 49);
            this.btnAddreport.TabIndex = 28;
            this.btnAddreport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddreport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddreport.UseVisualStyleBackColor = false;
            this.btnAddreport.Click += new System.EventHandler(this.btnAddreport_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(16, 38);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(43, 36);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 22;
            this.pictureBox2.TabStop = false;
            // 
            // chart3
            // 
            this.chart3.BackColor = System.Drawing.Color.Gray;
            this.chart3.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.DiagonalRight;
            this.chart3.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss;
            chartArea1.Name = "ChartArea1";
            this.chart3.ChartAreas.Add(chartArea1);
            this.chart3.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart3.Legends.Add(legend1);
            this.chart3.Location = new System.Drawing.Point(3, 3);
            this.chart3.Name = "chart3";
            this.chart3.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart3.Series.Add(series1);
            this.chart3.Size = new System.Drawing.Size(1419, 408);
            this.chart3.TabIndex = 0;
            this.chart3.Text = "chart2";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.chart3, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.crimepanel, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.01205F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.98795F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1425, 781);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // crimepanel
            // 
            this.crimepanel.AutoScroll = true;
            this.crimepanel.AutoSize = true;
            this.crimepanel.BackColor = System.Drawing.Color.GhostWhite;
            this.crimepanel.Controls.Add(this.button1);
            this.crimepanel.Controls.Add(this.search);
            this.crimepanel.Controls.Add(this.select);
            this.crimepanel.Controls.Add(this.checkBox1);
            this.crimepanel.Controls.Add(this.btneditreport);
            this.crimepanel.Controls.Add(this.btndeletereport);
            this.crimepanel.Controls.Add(this.btnAddreport);
            this.crimepanel.Controls.Add(this.pictureBox2);
            this.crimepanel.Controls.Add(this.dg_programs);
            this.crimepanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crimepanel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.crimepanel.Location = new System.Drawing.Point(3, 417);
            this.crimepanel.Name = "crimepanel";
            this.crimepanel.Size = new System.Drawing.Size(1419, 361);
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
            this.button1.Location = new System.Drawing.Point(1360, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(46, 49);
            this.button1.TabIndex = 61;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dg_programs
            // 
            this.dg_programs.AllowUserToAddRows = false;
            this.dg_programs.AllowUserToDeleteRows = false;
            this.dg_programs.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.dg_programs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dg_programs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dg_programs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dg_programs.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dg_programs.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.dg_programs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dg_programs.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(165)))), ((int)(((byte)(165)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_programs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dg_programs.ColumnHeadersHeight = 29;
            this.dg_programs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn2,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn10,
            this.Column2,
            this.Column1});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_programs.DefaultCellStyle = dataGridViewCellStyle3;
            this.dg_programs.Location = new System.Drawing.Point(14, 90);
            this.dg_programs.Name = "dg_programs";
            this.dg_programs.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dg_programs.RowHeadersVisible = false;
            this.dg_programs.RowHeadersWidth = 51;
            this.dg_programs.RowTemplate.Height = 24;
            this.dg_programs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_programs.Size = new System.Drawing.Size(1392, 256);
            this.dg_programs.TabIndex = 12;
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
            this.dataGridViewTextBoxColumn7.HeaderText = "PROGRAM NAME";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 154;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn8.HeaderText = "FACILITATOR";
            this.dataGridViewTextBoxColumn8.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 121;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn9.HeaderText = "DATE";
            this.dataGridViewTextBoxColumn9.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 74;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn11.HeaderText = "OBJECTIVE";
            this.dataGridViewTextBoxColumn11.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn10.HeaderText = "BARANGAY";
            this.dataGridViewTextBoxColumn10.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
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
            // Programform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1425, 781);
            this.Controls.Add(this.tableLayoutPanel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Programform";
            this.Text = "Programform";
            this.Load += new System.EventHandler(this.Programform_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.crimepanel.ResumeLayout(false);
            this.crimepanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_programs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public MetroFramework.Controls.MetroTextBox search;
        public MetroFramework.Controls.MetroComboBox select;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btneditreport;
        private System.Windows.Forms.Button btndeletereport;
        private System.Windows.Forms.Button btnAddreport;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel crimepanel;
        private System.Windows.Forms.DataGridView dg_programs;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}