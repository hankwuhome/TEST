namespace GenerateCode
{
    partial class GeneratePPPWebAPI
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.ControllerName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GenerateSearchList = new System.Windows.Forms.CheckBox();
            this.GenerateDetail = new System.Windows.Forms.CheckBox();
            this.GenerateTokenFilter = new System.Windows.Forms.CheckBox();
            this.GenerateDataPermission = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.MainTable = new System.Windows.Forms.TextBox();
            this.Generate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SubTables = new System.Windows.Forms.TextBox();
            this.Active_Add = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Active_Edit = new System.Windows.Forms.CheckBox();
            this.Active_View = new System.Windows.Forms.CheckBox();
            this.Active_Delete = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ControllerName
            // 
            this.ControllerName.Location = new System.Drawing.Point(85, 12);
            this.ControllerName.Name = "ControllerName";
            this.ControllerName.Size = new System.Drawing.Size(100, 22);
            this.ControllerName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "功能代碼";
            // 
            // GenerateSearchList
            // 
            this.GenerateSearchList.AutoSize = true;
            this.GenerateSearchList.Location = new System.Drawing.Point(12, 101);
            this.GenerateSearchList.Name = "GenerateSearchList";
            this.GenerateSearchList.Size = new System.Drawing.Size(136, 16);
            this.GenerateSearchList.TabIndex = 3;
            this.GenerateSearchList.Text = "產生功能項-SearchList";
            this.GenerateSearchList.UseVisualStyleBackColor = true;
            // 
            // GenerateDetail
            // 
            this.GenerateDetail.AutoSize = true;
            this.GenerateDetail.Location = new System.Drawing.Point(12, 157);
            this.GenerateDetail.Name = "GenerateDetail";
            this.GenerateDetail.Size = new System.Drawing.Size(115, 16);
            this.GenerateDetail.TabIndex = 8;
            this.GenerateDetail.Text = "產生功能項-Detail";
            this.GenerateDetail.UseVisualStyleBackColor = true;
            // 
            // GenerateTokenFilter
            // 
            this.GenerateTokenFilter.AutoSize = true;
            this.GenerateTokenFilter.Location = new System.Drawing.Point(12, 190);
            this.GenerateTokenFilter.Name = "GenerateTokenFilter";
            this.GenerateTokenFilter.Size = new System.Drawing.Size(121, 16);
            this.GenerateTokenFilter.TabIndex = 9;
            this.GenerateTokenFilter.Text = "Token與Action檢核";
            this.GenerateTokenFilter.UseVisualStyleBackColor = true;
            // 
            // GenerateDataPermission
            // 
            this.GenerateDataPermission.AutoSize = true;
            this.GenerateDataPermission.Location = new System.Drawing.Point(12, 223);
            this.GenerateDataPermission.Name = "GenerateDataPermission";
            this.GenerateDataPermission.Size = new System.Drawing.Size(96, 16);
            this.GenerateDataPermission.TabIndex = 10;
            this.GenerateDataPermission.Text = "資料權限檢核";
            this.GenerateDataPermission.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "對應主Table";
            // 
            // MainTable
            // 
            this.MainTable.Location = new System.Drawing.Point(85, 43);
            this.MainTable.Name = "MainTable";
            this.MainTable.Size = new System.Drawing.Size(100, 22);
            this.MainTable.TabIndex = 1;
            // 
            // Generate
            // 
            this.Generate.Location = new System.Drawing.Point(282, 257);
            this.Generate.Name = "Generate";
            this.Generate.Size = new System.Drawing.Size(75, 23);
            this.Generate.TabIndex = 11;
            this.Generate.Text = "Generate";
            this.Generate.UseVisualStyleBackColor = true;
            this.Generate.Click += new System.EventHandler(this.Generate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "其他Table";
            // 
            // SubTables
            // 
            this.SubTables.Location = new System.Drawing.Point(85, 71);
            this.SubTables.Name = "SubTables";
            this.SubTables.Size = new System.Drawing.Size(272, 22);
            this.SubTables.TabIndex = 2;
            // 
            // Active_Add
            // 
            this.Active_Add.AutoSize = true;
            this.Active_Add.Checked = true;
            this.Active_Add.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Active_Add.Location = new System.Drawing.Point(107, 123);
            this.Active_Add.Name = "Active_Add";
            this.Active_Add.Size = new System.Drawing.Size(48, 16);
            this.Active_Add.TabIndex = 4;
            this.Active_Add.Text = "新增";
            this.Active_Add.UseVisualStyleBackColor = true;
            this.Active_Add.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "SearchList包含";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // Active_Edit
            // 
            this.Active_Edit.AutoSize = true;
            this.Active_Edit.Checked = true;
            this.Active_Edit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Active_Edit.Location = new System.Drawing.Point(161, 124);
            this.Active_Edit.Name = "Active_Edit";
            this.Active_Edit.Size = new System.Drawing.Size(48, 16);
            this.Active_Edit.TabIndex = 5;
            this.Active_Edit.Text = "編輯";
            this.Active_Edit.UseVisualStyleBackColor = true;
            // 
            // Active_View
            // 
            this.Active_View.AutoSize = true;
            this.Active_View.Checked = true;
            this.Active_View.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Active_View.Location = new System.Drawing.Point(215, 124);
            this.Active_View.Name = "Active_View";
            this.Active_View.Size = new System.Drawing.Size(48, 16);
            this.Active_View.TabIndex = 6;
            this.Active_View.Text = "檢視";
            this.Active_View.UseVisualStyleBackColor = true;
            // 
            // Active_Delete
            // 
            this.Active_Delete.AutoSize = true;
            this.Active_Delete.Location = new System.Drawing.Point(269, 124);
            this.Active_Delete.Name = "Active_Delete";
            this.Active_Delete.Size = new System.Drawing.Size(48, 16);
            this.Active_Delete.TabIndex = 7;
            this.Active_Delete.Text = "刪除";
            this.Active_Delete.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(172, 333);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(494, 220);
            this.tabControl1.TabIndex = 18;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(486, 194);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(192, 74);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // GeneratePPPWebAPI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 609);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.Active_Delete);
            this.Controls.Add(this.Active_View);
            this.Controls.Add(this.Active_Edit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Active_Add);
            this.Controls.Add(this.SubTables);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Generate);
            this.Controls.Add(this.MainTable);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.GenerateDataPermission);
            this.Controls.Add(this.GenerateTokenFilter);
            this.Controls.Add(this.GenerateDetail);
            this.Controls.Add(this.GenerateSearchList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ControllerName);
            this.Name = "GeneratePPPWebAPI";
            this.Text = "PPPWebAPI自動產檔工具";
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ControllerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox GenerateSearchList;
        private System.Windows.Forms.CheckBox GenerateDetail;
        private System.Windows.Forms.CheckBox GenerateTokenFilter;
        private System.Windows.Forms.CheckBox GenerateDataPermission;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox MainTable;
        private System.Windows.Forms.Button Generate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SubTables;
        private System.Windows.Forms.CheckBox Active_Add;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox Active_Edit;
        private System.Windows.Forms.CheckBox Active_View;
        private System.Windows.Forms.CheckBox Active_Delete;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}

