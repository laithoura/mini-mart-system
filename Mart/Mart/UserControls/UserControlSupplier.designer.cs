namespace Mart.UserControls
{
    partial class UserControlSupplier
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvSup = new System.Windows.Forms.DataGridView();
            this.SupplierID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Coloumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboSearchBy = new System.Windows.Forms.ComboBox();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.tblRowCount = new System.Windows.Forms.Label();
            this.btnKbach3 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbRecordCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSupDelete = new System.Windows.Forms.Button();
            this.btnSupAdd = new System.Windows.Forms.Button();
            this.btnSupUpate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSup)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSup
            // 
            this.dgvSup.AllowUserToAddRows = false;
            this.dgvSup.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.dgvSup.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSup.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSup.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvSup.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSup.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SupplierID,
            this.Coloumn2,
            this.Column6,
            this.Column5,
            this.Column3,
            this.Column2,
            this.Column4,
            this.Column1});
            this.dgvSup.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvSup.Location = new System.Drawing.Point(19, 75);
            this.dgvSup.Name = "dgvSup";
            this.dgvSup.ReadOnly = true;
            this.dgvSup.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvSup.RowHeadersVisible = false;
            this.dgvSup.RowHeadersWidth = 35;
            this.dgvSup.RowTemplate.Height = 30;
            this.dgvSup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSup.Size = new System.Drawing.Size(884, 439);
            this.dgvSup.TabIndex = 1;
            // 
            // SupplierID
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.SupplierID.DefaultCellStyle = dataGridViewCellStyle3;
            this.SupplierID.FillWeight = 62.85226F;
            this.SupplierID.HeaderText = "Supplier ID";
            this.SupplierID.MinimumWidth = 4;
            this.SupplierID.Name = "SupplierID";
            this.SupplierID.ReadOnly = true;
            // 
            // Coloumn2
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Coloumn2.DefaultCellStyle = dataGridViewCellStyle4;
            this.Coloumn2.FillWeight = 106.6779F;
            this.Coloumn2.HeaderText = "First Name";
            this.Coloumn2.Name = "Coloumn2";
            this.Coloumn2.ReadOnly = true;
            // 
            // Column6
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column6.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column6.FillWeight = 122.5397F;
            this.Column6.HeaderText = "Last Name";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column5
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column5.FillWeight = 81.21828F;
            this.Column5.HeaderText = "Supplier Gender";
            this.Column5.MinimumWidth = 4;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column3
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column3.FillWeight = 106.6779F;
            this.Column3.HeaderText = "Supplier  Birthdate";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column2
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle8;
            this.Column2.FillWeight = 106.6779F;
            this.Column2.HeaderText = "Supplier P_Number";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column4
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle9;
            this.Column4.FillWeight = 106.6779F;
            this.Column4.HeaderText = "Suppiler Email";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column1
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle10;
            this.Column1.FillWeight = 106.6779F;
            this.Column1.HeaderText = "Supplier Company";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // cboSearchBy
            // 
            this.cboSearchBy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSearchBy.FormattingEnabled = true;
            this.cboSearchBy.Items.AddRange(new object[] {
            "Supplier ID",
            "Supplier First Name",
            "Supplier Last Name"});
            this.cboSearchBy.Location = new System.Drawing.Point(617, 31);
            this.cboSearchBy.Name = "cboSearchBy";
            this.cboSearchBy.Size = new System.Drawing.Size(194, 21);
            this.cboSearchBy.TabIndex = 23;
            // 
            // txtKeyword
            // 
            this.txtKeyword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKeyword.Location = new System.Drawing.Point(617, 32);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(177, 20);
            this.txtKeyword.TabIndex = 26;
            // 
            // tblRowCount
            // 
            this.tblRowCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tblRowCount.AutoSize = true;
            this.tblRowCount.Font = new System.Drawing.Font("Monotype Corsiva", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tblRowCount.Location = new System.Drawing.Point(109, 534);
            this.tblRowCount.Name = "tblRowCount";
            this.tblRowCount.Size = new System.Drawing.Size(0, 22);
            this.tblRowCount.TabIndex = 27;
            // 
            // btnKbach3
            // 
            this.btnKbach3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnKbach3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(174)))), ((int)(((byte)(190)))));
            this.btnKbach3.BackgroundImage = global::Mart.Properties.Resources.Untitled_111copy_2;
            this.btnKbach3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnKbach3.FlatAppearance.BorderSize = 0;
            this.btnKbach3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnKbach3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKbach3.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKbach3.ForeColor = System.Drawing.Color.White;
            this.btnKbach3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnKbach3.Location = new System.Drawing.Point(372, 9);
            this.btnKbach3.Margin = new System.Windows.Forms.Padding(0);
            this.btnKbach3.Name = "btnKbach3";
            this.btnKbach3.Size = new System.Drawing.Size(152, 58);
            this.btnKbach3.TabIndex = 21;
            this.btnKbach3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnKbach3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnKbach3.UseCompatibleTextRendering = true;
            this.btnKbach3.UseVisualStyleBackColor = false;
            this.btnKbach3.Click += new System.EventHandler(this.btnKbach3_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lbRecordCount});
            this.statusStrip1.Location = new System.Drawing.Point(19, 514);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(884, 27);
            this.statusStrip1.TabIndex = 29;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(84, 22);
            this.toolStripStatusLabel1.Text = "Total Item  :  ";
            // 
            // lbRecordCount
            // 
            this.lbRecordCount.BackColor = System.Drawing.Color.Transparent;
            this.lbRecordCount.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecordCount.Name = "lbRecordCount";
            this.lbRecordCount.Size = new System.Drawing.Size(15, 22);
            this.lbRecordCount.Text = "0";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(174)))), ((int)(((byte)(190)))));
            this.btnSearch.BackgroundImage = global::Mart.Properties.Resources.Search_48;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.Black;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSearch.Location = new System.Drawing.Point(825, 5);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(78, 67);
            this.btnSearch.TabIndex = 24;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseCompatibleTextRendering = true;
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(174)))), ((int)(((byte)(190)))));
            this.btnRefresh.BackgroundImage = global::Mart.Properties.Resources.Refresh_32;
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.Black;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRefresh.Location = new System.Drawing.Point(536, 5);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(0);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(74, 67);
            this.btnRefresh.TabIndex = 22;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefresh.UseCompatibleTextRendering = true;
            this.btnRefresh.UseVisualStyleBackColor = false;
            // 
            // btnSupDelete
            // 
            this.btnSupDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(174)))), ((int)(((byte)(190)))));
            this.btnSupDelete.BackgroundImage = global::Mart.Properties.Resources.delete_32;
            this.btnSupDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSupDelete.FlatAppearance.BorderSize = 0;
            this.btnSupDelete.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSupDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupDelete.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupDelete.ForeColor = System.Drawing.Color.Black;
            this.btnSupDelete.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSupDelete.Location = new System.Drawing.Point(99, 5);
            this.btnSupDelete.Margin = new System.Windows.Forms.Padding(0);
            this.btnSupDelete.Name = "btnSupDelete";
            this.btnSupDelete.Size = new System.Drawing.Size(78, 67);
            this.btnSupDelete.TabIndex = 16;
            this.btnSupDelete.Text = "Delete";
            this.btnSupDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSupDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSupDelete.UseCompatibleTextRendering = true;
            this.btnSupDelete.UseVisualStyleBackColor = false;
            // 
            // btnSupAdd
            // 
            this.btnSupAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(174)))), ((int)(((byte)(190)))));
            this.btnSupAdd.BackgroundImage = global::Mart.Properties.Resources.AddNew_32;
            this.btnSupAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSupAdd.FlatAppearance.BorderSize = 0;
            this.btnSupAdd.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSupAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupAdd.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupAdd.ForeColor = System.Drawing.Color.Black;
            this.btnSupAdd.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSupAdd.Location = new System.Drawing.Point(19, 5);
            this.btnSupAdd.Margin = new System.Windows.Forms.Padding(0);
            this.btnSupAdd.Name = "btnSupAdd";
            this.btnSupAdd.Size = new System.Drawing.Size(78, 67);
            this.btnSupAdd.TabIndex = 7;
            this.btnSupAdd.Text = "Add";
            this.btnSupAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSupAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSupAdd.UseCompatibleTextRendering = true;
            this.btnSupAdd.UseVisualStyleBackColor = false;
            // 
            // btnSupUpate
            // 
            this.btnSupUpate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(174)))), ((int)(((byte)(190)))));
            this.btnSupUpate.BackgroundImage = global::Mart.Properties.Resources.Edit_32;
            this.btnSupUpate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSupUpate.FlatAppearance.BorderSize = 0;
            this.btnSupUpate.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSupUpate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupUpate.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupUpate.ForeColor = System.Drawing.Color.Black;
            this.btnSupUpate.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSupUpate.Location = new System.Drawing.Point(179, 5);
            this.btnSupUpate.Margin = new System.Windows.Forms.Padding(0);
            this.btnSupUpate.Name = "btnSupUpate";
            this.btnSupUpate.Size = new System.Drawing.Size(78, 67);
            this.btnSupUpate.TabIndex = 5;
            this.btnSupUpate.Text = "Update";
            this.btnSupUpate.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSupUpate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSupUpate.UseCompatibleTextRendering = true;
            this.btnSupUpate.UseVisualStyleBackColor = false;
            // 
            // UserControlSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(174)))), ((int)(((byte)(190)))));
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tblRowCount);
            this.Controls.Add(this.txtKeyword);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cboSearchBy);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnKbach3);
            this.Controls.Add(this.btnSupDelete);
            this.Controls.Add(this.btnSupAdd);
            this.Controls.Add(this.btnSupUpate);
            this.Controls.Add(this.dgvSup);
            this.Name = "UserControlSupplier";
            this.Size = new System.Drawing.Size(923, 556);
            this.Load += new System.EventHandler(this.USupplier_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSup)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSup;
        private System.Windows.Forms.Button btnSupAdd;
        public System.Windows.Forms.Button btnSupUpate;
        private System.Windows.Forms.Button btnSupDelete;
        private System.Windows.Forms.Button btnKbach3;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox cboSearchBy;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Label tblRowCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Coloumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lbRecordCount;
    }
}
