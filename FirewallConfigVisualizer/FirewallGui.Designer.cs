namespace FirewallConfigVisualizer
{
    partial class FirewallGui
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.xmlStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bnLoad = new System.Windows.Forms.Button();
            this.listBoxPolicy = new System.Windows.Forms.ListBox();
            this.listBoxAliasFrom = new System.Windows.Forms.ListBox();
            this.listBoxAddressFrom = new System.Windows.Forms.ListBox();
            this.listBoxAliasTo = new System.Windows.Forms.ListBox();
            this.listBoxAddressTo = new System.Windows.Forms.ListBox();
            this.listViewService = new System.Windows.Forms.ListView();
            this.columnPort = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnApplication = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnProtocol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.richTextBoxDescription = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bnSearch = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.bnReset = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPolicyListCount = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.xmlStatus);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.bnLoad);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(214, 40);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // xmlStatus
            // 
            this.xmlStatus.AutoSize = true;
            this.xmlStatus.ForeColor = System.Drawing.Color.Red;
            this.xmlStatus.Location = new System.Drawing.Point(145, 16);
            this.xmlStatus.Name = "xmlStatus";
            this.xmlStatus.Size = new System.Drawing.Size(63, 13);
            this.xmlStatus.TabIndex = 2;
            this.xmlStatus.Text = "Not Loaded";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "XML File";
            // 
            // bnLoad
            // 
            this.bnLoad.Location = new System.Drawing.Point(64, 11);
            this.bnLoad.Name = "bnLoad";
            this.bnLoad.Size = new System.Drawing.Size(75, 23);
            this.bnLoad.TabIndex = 0;
            this.bnLoad.Text = "Load";
            this.bnLoad.UseVisualStyleBackColor = true;
            this.bnLoad.Click += new System.EventHandler(this.bnLoad_Click);
            // 
            // listBoxPolicy
            // 
            this.listBoxPolicy.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxPolicy.FormattingEnabled = true;
            this.listBoxPolicy.Location = new System.Drawing.Point(12, 62);
            this.listBoxPolicy.Name = "listBoxPolicy";
            this.listBoxPolicy.Size = new System.Drawing.Size(280, 381);
            this.listBoxPolicy.TabIndex = 13;
            this.listBoxPolicy.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBoxPolicy_DrawItem);
            this.listBoxPolicy.SelectedIndexChanged += new System.EventHandler(this.listBoxPolicy_SelectedIndexChanged);
            // 
            // listBoxAliasFrom
            // 
            this.listBoxAliasFrom.FormattingEnabled = true;
            this.listBoxAliasFrom.Location = new System.Drawing.Point(317, 62);
            this.listBoxAliasFrom.Name = "listBoxAliasFrom";
            this.listBoxAliasFrom.Size = new System.Drawing.Size(280, 225);
            this.listBoxAliasFrom.TabIndex = 14;
            this.listBoxAliasFrom.SelectedIndexChanged += new System.EventHandler(this.listBoxAliasFrom_SelectedIndexChanged);
            // 
            // listBoxAddressFrom
            // 
            this.listBoxAddressFrom.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxAddressFrom.FormattingEnabled = true;
            this.listBoxAddressFrom.Location = new System.Drawing.Point(317, 293);
            this.listBoxAddressFrom.Name = "listBoxAddressFrom";
            this.listBoxAddressFrom.Size = new System.Drawing.Size(280, 238);
            this.listBoxAddressFrom.TabIndex = 15;
            this.listBoxAddressFrom.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBoxAddressFrom_DrawItem);
            // 
            // listBoxAliasTo
            // 
            this.listBoxAliasTo.FormattingEnabled = true;
            this.listBoxAliasTo.Location = new System.Drawing.Point(622, 62);
            this.listBoxAliasTo.Name = "listBoxAliasTo";
            this.listBoxAliasTo.Size = new System.Drawing.Size(280, 225);
            this.listBoxAliasTo.TabIndex = 16;
            this.listBoxAliasTo.SelectedIndexChanged += new System.EventHandler(this.listBoxAliasTo_SelectedIndexChanged);
            // 
            // listBoxAddressTo
            // 
            this.listBoxAddressTo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxAddressTo.FormattingEnabled = true;
            this.listBoxAddressTo.Location = new System.Drawing.Point(622, 293);
            this.listBoxAddressTo.Name = "listBoxAddressTo";
            this.listBoxAddressTo.Size = new System.Drawing.Size(280, 238);
            this.listBoxAddressTo.TabIndex = 17;
            this.listBoxAddressTo.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBoxAddressTo_DrawItem);
            // 
            // listViewService
            // 
            this.listViewService.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnPort,
            this.columnApplication,
            this.columnProtocol});
            this.listViewService.Location = new System.Drawing.Point(12, 449);
            this.listViewService.Name = "listViewService";
            this.listViewService.Size = new System.Drawing.Size(280, 202);
            this.listViewService.TabIndex = 19;
            this.listViewService.UseCompatibleStateImageBehavior = false;
            this.listViewService.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewService_ColumnClick);
            // 
            // columnPort
            // 
            this.columnPort.Text = "Port";
            // 
            // columnApplication
            // 
            this.columnApplication.Text = "Application";
            this.columnApplication.Width = 140;
            // 
            // columnProtocol
            // 
            this.columnProtocol.Text = "Protocol";
            // 
            // richTextBoxDescription
            // 
            this.richTextBoxDescription.Location = new System.Drawing.Point(318, 538);
            this.richTextBoxDescription.Name = "richTextBoxDescription";
            this.richTextBoxDescription.Size = new System.Drawing.Size(279, 113);
            this.richTextBoxDescription.TabIndex = 20;
            this.richTextBoxDescription.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bnSearch);
            this.groupBox2.Controls.Add(this.tbSearch);
            this.groupBox2.Location = new System.Drawing.Point(564, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(257, 39);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            // 
            // bnSearch
            // 
            this.bnSearch.Location = new System.Drawing.Point(175, 11);
            this.bnSearch.Name = "bnSearch";
            this.bnSearch.Size = new System.Drawing.Size(75, 23);
            this.bnSearch.TabIndex = 4;
            this.bnSearch.Text = "Search";
            this.bnSearch.UseVisualStyleBackColor = true;
            this.bnSearch.Click += new System.EventHandler(this.bnSearch_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(6, 13);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(163, 20);
            this.tbSearch.TabIndex = 3;
            // 
            // bnReset
            // 
            this.bnReset.Location = new System.Drawing.Point(836, 15);
            this.bnReset.Name = "bnReset";
            this.bnReset.Size = new System.Drawing.Size(75, 23);
            this.bnReset.TabIndex = 22;
            this.bnReset.Text = "Reset";
            this.bnReset.UseVisualStyleBackColor = true;
            this.bnReset.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(437, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "FROM";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(749, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "TO";
            // 
            // tbPolicyListCount
            // 
            this.tbPolicyListCount.AutoSize = true;
            this.tbPolicyListCount.Location = new System.Drawing.Point(9, 46);
            this.tbPolicyListCount.Name = "tbPolicyListCount";
            this.tbPolicyListCount.Size = new System.Drawing.Size(0, 13);
            this.tbPolicyListCount.TabIndex = 25;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(622, 536);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(280, 113);
            this.richTextBox1.TabIndex = 26;
            this.richTextBox1.Text = "";
            // 
            // FirewallGui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 661);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.tbPolicyListCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bnReset);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.richTextBoxDescription);
            this.Controls.Add(this.listViewService);
            this.Controls.Add(this.listBoxAddressTo);
            this.Controls.Add(this.listBoxAliasTo);
            this.Controls.Add(this.listBoxAddressFrom);
            this.Controls.Add(this.listBoxAliasFrom);
            this.Controls.Add(this.listBoxPolicy);
            this.Controls.Add(this.groupBox1);
            this.Name = "FirewallGui";
            this.Text = "FirewallGui";
            this.Load += new System.EventHandler(this.FirewallGui_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label xmlStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bnLoad;
        private System.Windows.Forms.ListBox listBoxPolicy;
        private System.Windows.Forms.ListBox listBoxAliasFrom;
        private System.Windows.Forms.ListBox listBoxAddressFrom;
        private System.Windows.Forms.ListBox listBoxAliasTo;
        private System.Windows.Forms.ListBox listBoxAddressTo;
        private System.Windows.Forms.ListView listViewService;
        private System.Windows.Forms.ColumnHeader columnPort;
        private System.Windows.Forms.ColumnHeader columnApplication;
        private System.Windows.Forms.ColumnHeader columnProtocol;
        private System.Windows.Forms.RichTextBox richTextBoxDescription;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bnSearch;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Button bnReset;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label tbPolicyListCount;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

