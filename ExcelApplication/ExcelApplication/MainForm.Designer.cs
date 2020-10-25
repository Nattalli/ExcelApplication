namespace ExcelApplication
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileTool = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Calculating = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.RowAdding = new System.Windows.Forms.Button();
            this.ColumnAdding = new System.Windows.Forms.Button();
            this.RowDeleting = new System.Windows.Forms.Button();
            this.ColumnDeleting = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileTool});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(955, 36);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileTool
            // 
            this.FileTool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem1,
            this.saveToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.FileTool.Name = "FileTool";
            this.FileTool.Size = new System.Drawing.Size(54, 30);
            this.FileTool.Text = "File";
            this.FileTool.Click += new System.EventHandler(this.FileTool_Click);
            // 
            // openToolStripMenuItem1
            // 
            this.openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            this.openToolStripMenuItem1.Size = new System.Drawing.Size(158, 34);
            this.openToolStripMenuItem1.Text = "Open";
            this.openToolStripMenuItem1.Click += new System.EventHandler(this.saveToolStripMenuItem1_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(158, 34);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(158, 34);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(158, 34);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Calculating
            // 
            this.Calculating.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Calculating.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Calculating.Font = new System.Drawing.Font("PMingLiU-ExtB", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Calculating.Location = new System.Drawing.Point(139, 67);
            this.Calculating.Name = "Calculating";
            this.Calculating.Size = new System.Drawing.Size(309, 43);
            this.Calculating.TabIndex = 0;
            this.Calculating.Text = "Calculate";
            this.Calculating.UseVisualStyleBackColor = false;
            this.Calculating.Click += new System.EventHandler(this.Calculating_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(139, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(308, 44);
            this.textBox1.TabIndex = 1;
            // 
            // RowAdding
            // 
            this.RowAdding.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.RowAdding.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RowAdding.Font = new System.Drawing.Font("PMingLiU-ExtB", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RowAdding.Location = new System.Drawing.Point(31, 10);
            this.RowAdding.Name = "RowAdding";
            this.RowAdding.Size = new System.Drawing.Size(137, 48);
            this.RowAdding.TabIndex = 0;
            this.RowAdding.Text = "Add row";
            this.RowAdding.UseVisualStyleBackColor = false;
            this.RowAdding.Click += new System.EventHandler(this.RowAdding_Click);
            // 
            // ColumnAdding
            // 
            this.ColumnAdding.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ColumnAdding.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ColumnAdding.Font = new System.Drawing.Font("PMingLiU-ExtB", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnAdding.Location = new System.Drawing.Point(31, 64);
            this.ColumnAdding.Name = "ColumnAdding";
            this.ColumnAdding.Size = new System.Drawing.Size(137, 48);
            this.ColumnAdding.TabIndex = 1;
            this.ColumnAdding.Text = "Add column";
            this.ColumnAdding.UseVisualStyleBackColor = false;
            this.ColumnAdding.Click += new System.EventHandler(this.ColumnAdding_Click);
            // 
            // RowDeleting
            // 
            this.RowDeleting.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.RowDeleting.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.RowDeleting.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.RowDeleting.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua;
            this.RowDeleting.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RowDeleting.Font = new System.Drawing.Font("PMingLiU-ExtB", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RowDeleting.Location = new System.Drawing.Point(210, 10);
            this.RowDeleting.Name = "RowDeleting";
            this.RowDeleting.Size = new System.Drawing.Size(139, 48);
            this.RowDeleting.TabIndex = 2;
            this.RowDeleting.Text = "Delete row";
            this.RowDeleting.UseVisualStyleBackColor = false;
            this.RowDeleting.Click += new System.EventHandler(this.RowDeleting_Click);
            // 
            // ColumnDeleting
            // 
            this.ColumnDeleting.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ColumnDeleting.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ColumnDeleting.Font = new System.Drawing.Font("PMingLiU-ExtB", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnDeleting.Location = new System.Drawing.Point(210, 64);
            this.ColumnDeleting.Name = "ColumnDeleting";
            this.ColumnDeleting.Size = new System.Drawing.Size(139, 48);
            this.ColumnDeleting.TabIndex = 3;
            this.ColumnDeleting.Text = "Delete column";
            this.ColumnDeleting.UseVisualStyleBackColor = false;
            this.ColumnDeleting.Click += new System.EventHandler(this.ColumnDeleting_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(1, 34);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ColumnDeleting);
            this.splitContainer1.Panel1.Controls.Add(this.RowDeleting);
            this.splitContainer1.Panel1.Controls.Add(this.ColumnAdding);
            this.splitContainer1.Panel1.Controls.Add(this.RowAdding);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textBox1);
            this.splitContainer1.Panel2.Controls.Add(this.Calculating);
            this.splitContainer1.Size = new System.Drawing.Size(953, 124);
            this.splitContainer1.SplitterDistance = 373;
            this.splitContainer1.TabIndex = 2;
            // 
            // dataGridView
            // 
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(1, 152);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 62;
            this.dataGridView.RowTemplate.Height = 28;
            this.dataGridView.Size = new System.Drawing.Size(955, 477);
            this.dataGridView.TabIndex = 3;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick_1);
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(955, 630);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileTool;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button Calculating;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button RowAdding;
        private System.Windows.Forms.Button ColumnAdding;
        private System.Windows.Forms.Button RowDeleting;
        private System.Windows.Forms.Button ColumnDeleting;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

