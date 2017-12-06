namespace PyTimer
{
    partial class PyTimer
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PyTimer));
            this.pyList = new System.Windows.Forms.ListBox();
            this.pyMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.开始运行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.停止运行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开文件夹ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addPyButton = new System.Windows.Forms.Button();
            this.runPyButton = new System.Windows.Forms.Button();
            this.startRunButton = new System.Windows.Forms.Button();
            this.repeatTimeText = new System.Windows.Forms.TextBox();
            this.repeatTimeLabel = new System.Windows.Forms.Label();
            this.applyRepeatTimeButton = new System.Windows.Forms.Button();
            this.pauseRunButton = new System.Windows.Forms.Button();
            this.cancelRunButton = new System.Windows.Forms.Button();
            this.startAllButton = new System.Windows.Forms.Button();
            this.pauseAllButton = new System.Windows.Forms.Button();
            this.cancelAllButton = new System.Windows.Forms.Button();
            this.autoRunCheck = new System.Windows.Forms.CheckBox();
            this.pyMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pyList
            // 
            this.pyList.ContextMenuStrip = this.pyMenu;
            this.pyList.FormattingEnabled = true;
            this.pyList.ItemHeight = 12;
            this.pyList.Location = new System.Drawing.Point(12, 12);
            this.pyList.Name = "pyList";
            this.pyList.Size = new System.Drawing.Size(197, 76);
            this.pyList.TabIndex = 0;
            this.pyList.SelectedIndexChanged += new System.EventHandler(this.pyList_SelectedIndexChanged);
            // 
            // pyMenu
            // 
            this.pyMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开始运行ToolStripMenuItem,
            this.停止运行ToolStripMenuItem,
            this.打开ToolStripMenuItem,
            this.打开文件夹ToolStripMenuItem,
            this.删除ToolStripMenuItem});
            this.pyMenu.Name = "pyMenu";
            this.pyMenu.Size = new System.Drawing.Size(137, 114);
            this.pyMenu.Opening += new System.ComponentModel.CancelEventHandler(this.pyMenu_Opening);
            // 
            // 开始运行ToolStripMenuItem
            // 
            this.开始运行ToolStripMenuItem.Name = "开始运行ToolStripMenuItem";
            this.开始运行ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.开始运行ToolStripMenuItem.Text = "开始运行";
            this.开始运行ToolStripMenuItem.Click += new System.EventHandler(this.开始运行ToolStripMenuItem_Click);
            // 
            // 停止运行ToolStripMenuItem
            // 
            this.停止运行ToolStripMenuItem.Name = "停止运行ToolStripMenuItem";
            this.停止运行ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.停止运行ToolStripMenuItem.Text = "停止运行";
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.打开ToolStripMenuItem.Text = "打开";
            // 
            // 打开文件夹ToolStripMenuItem
            // 
            this.打开文件夹ToolStripMenuItem.Name = "打开文件夹ToolStripMenuItem";
            this.打开文件夹ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.打开文件夹ToolStripMenuItem.Text = "打开文件夹";
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // addPyButton
            // 
            this.addPyButton.Location = new System.Drawing.Point(12, 94);
            this.addPyButton.Name = "addPyButton";
            this.addPyButton.Size = new System.Drawing.Size(75, 23);
            this.addPyButton.TabIndex = 1;
            this.addPyButton.Text = "添加脚本";
            this.addPyButton.UseVisualStyleBackColor = true;
            this.addPyButton.Click += new System.EventHandler(this.addPyButton_Click);
            // 
            // runPyButton
            // 
            this.runPyButton.Location = new System.Drawing.Point(134, 94);
            this.runPyButton.Name = "runPyButton";
            this.runPyButton.Size = new System.Drawing.Size(75, 23);
            this.runPyButton.TabIndex = 2;
            this.runPyButton.Text = "运行一次";
            this.runPyButton.UseVisualStyleBackColor = true;
            this.runPyButton.Click += new System.EventHandler(this.runPyButton_Click);
            // 
            // startRunButton
            // 
            this.startRunButton.Location = new System.Drawing.Point(12, 205);
            this.startRunButton.Name = "startRunButton";
            this.startRunButton.Size = new System.Drawing.Size(75, 23);
            this.startRunButton.TabIndex = 3;
            this.startRunButton.Text = "开始运行";
            this.startRunButton.UseVisualStyleBackColor = true;
            this.startRunButton.Click += new System.EventHandler(this.startRunButton_Click);
            // 
            // repeatTimeText
            // 
            this.repeatTimeText.Location = new System.Drawing.Point(12, 153);
            this.repeatTimeText.Name = "repeatTimeText";
            this.repeatTimeText.Size = new System.Drawing.Size(89, 21);
            this.repeatTimeText.TabIndex = 4;
            // 
            // repeatTimeLabel
            // 
            this.repeatTimeLabel.AutoSize = true;
            this.repeatTimeLabel.Location = new System.Drawing.Point(12, 138);
            this.repeatTimeLabel.Name = "repeatTimeLabel";
            this.repeatTimeLabel.Size = new System.Drawing.Size(89, 12);
            this.repeatTimeLabel.TabIndex = 5;
            this.repeatTimeLabel.Text = "重复周期(毫秒)";
            // 
            // applyRepeatTimeButton
            // 
            this.applyRepeatTimeButton.Location = new System.Drawing.Point(134, 153);
            this.applyRepeatTimeButton.Name = "applyRepeatTimeButton";
            this.applyRepeatTimeButton.Size = new System.Drawing.Size(75, 23);
            this.applyRepeatTimeButton.TabIndex = 6;
            this.applyRepeatTimeButton.Text = "确定";
            this.applyRepeatTimeButton.UseVisualStyleBackColor = true;
            this.applyRepeatTimeButton.Click += new System.EventHandler(this.applyRepeatTimeButton_Click);
            // 
            // pauseRunButton
            // 
            this.pauseRunButton.Location = new System.Drawing.Point(12, 234);
            this.pauseRunButton.Name = "pauseRunButton";
            this.pauseRunButton.Size = new System.Drawing.Size(75, 23);
            this.pauseRunButton.TabIndex = 7;
            this.pauseRunButton.Text = "暂停运行";
            this.pauseRunButton.UseVisualStyleBackColor = true;
            this.pauseRunButton.Click += new System.EventHandler(this.pauseRunButton_Click);
            // 
            // cancelRunButton
            // 
            this.cancelRunButton.Location = new System.Drawing.Point(12, 263);
            this.cancelRunButton.Name = "cancelRunButton";
            this.cancelRunButton.Size = new System.Drawing.Size(75, 23);
            this.cancelRunButton.TabIndex = 8;
            this.cancelRunButton.Text = "取消运行";
            this.cancelRunButton.UseVisualStyleBackColor = true;
            this.cancelRunButton.Click += new System.EventHandler(this.cancelRunButton_Click);
            // 
            // startAllButton
            // 
            this.startAllButton.Location = new System.Drawing.Point(134, 205);
            this.startAllButton.Name = "startAllButton";
            this.startAllButton.Size = new System.Drawing.Size(75, 23);
            this.startAllButton.TabIndex = 9;
            this.startAllButton.Text = "全部开始";
            this.startAllButton.UseVisualStyleBackColor = true;
            this.startAllButton.Click += new System.EventHandler(this.startAllButton_Click);
            // 
            // pauseAllButton
            // 
            this.pauseAllButton.Location = new System.Drawing.Point(134, 233);
            this.pauseAllButton.Name = "pauseAllButton";
            this.pauseAllButton.Size = new System.Drawing.Size(75, 23);
            this.pauseAllButton.TabIndex = 10;
            this.pauseAllButton.Text = "全部暂停";
            this.pauseAllButton.UseVisualStyleBackColor = true;
            this.pauseAllButton.Click += new System.EventHandler(this.pauseAllButton_Click);
            // 
            // cancelAllButton
            // 
            this.cancelAllButton.Location = new System.Drawing.Point(134, 262);
            this.cancelAllButton.Name = "cancelAllButton";
            this.cancelAllButton.Size = new System.Drawing.Size(75, 23);
            this.cancelAllButton.TabIndex = 11;
            this.cancelAllButton.Text = "全部取消";
            this.cancelAllButton.UseVisualStyleBackColor = true;
            this.cancelAllButton.Click += new System.EventHandler(this.cancelAllButton_Click);
            // 
            // autoRunCheck
            // 
            this.autoRunCheck.AutoSize = true;
            this.autoRunCheck.Location = new System.Drawing.Point(12, 180);
            this.autoRunCheck.Name = "autoRunCheck";
            this.autoRunCheck.Size = new System.Drawing.Size(108, 16);
            this.autoRunCheck.TabIndex = 12;
            this.autoRunCheck.Text = "启动后自动运行";
            this.autoRunCheck.UseVisualStyleBackColor = true;
            this.autoRunCheck.CheckedChanged += new System.EventHandler(this.autoRunCheck_CheckedChanged);
            // 
            // PyTimer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 297);
            this.Controls.Add(this.autoRunCheck);
            this.Controls.Add(this.cancelAllButton);
            this.Controls.Add(this.pauseAllButton);
            this.Controls.Add(this.startAllButton);
            this.Controls.Add(this.cancelRunButton);
            this.Controls.Add(this.pauseRunButton);
            this.Controls.Add(this.applyRepeatTimeButton);
            this.Controls.Add(this.repeatTimeLabel);
            this.Controls.Add(this.repeatTimeText);
            this.Controls.Add(this.startRunButton);
            this.Controls.Add(this.runPyButton);
            this.Controls.Add(this.addPyButton);
            this.Controls.Add(this.pyList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PyTimer";
            this.Text = "PyTimer";
            this.Load += new System.EventHandler(this.PyTimer_Load);
            this.pyMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox pyList;
        private System.Windows.Forms.Button addPyButton;
        private System.Windows.Forms.ContextMenuStrip pyMenu;
        private System.Windows.Forms.ToolStripMenuItem 开始运行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 停止运行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.Button runPyButton;
        private System.Windows.Forms.Button startRunButton;
        private System.Windows.Forms.TextBox repeatTimeText;
        private System.Windows.Forms.Label repeatTimeLabel;
        private System.Windows.Forms.Button applyRepeatTimeButton;
        private System.Windows.Forms.Button pauseRunButton;
        private System.Windows.Forms.Button cancelRunButton;
        private System.Windows.Forms.Button startAllButton;
        private System.Windows.Forms.Button pauseAllButton;
        private System.Windows.Forms.Button cancelAllButton;
        private System.Windows.Forms.CheckBox autoRunCheck;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开文件夹ToolStripMenuItem;
    }
}

