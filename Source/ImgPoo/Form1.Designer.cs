using System.Windows.Forms;

namespace ImgPoo {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.imgBox = new System.Windows.Forms.PictureBox();
            this.menuBar = new System.Windows.Forms.MenuStrip();
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetZoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeBGColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleStatusBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.statsFilePath = new System.Windows.Forms.ToolStripStatusLabel();
            this.statsSize = new System.Windows.Forms.ToolStripStatusLabel();
            this.statsZoom = new System.Windows.Forms.ToolStripStatusLabel();
            this.fileDialog = new System.Windows.Forms.OpenFileDialog();
            this.folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.imgPanel = new System.Windows.Forms.Panel();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox)).BeginInit();
            this.menuBar.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.imgPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgBox
            // 
            this.imgBox.Location = new System.Drawing.Point(0, 0);
            this.imgBox.Name = "imgBox";
            this.imgBox.Size = new System.Drawing.Size(32, 32);
            this.imgBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgBox.TabIndex = 0;
            this.imgBox.TabStop = false;
            this.imgBox.Paint += new System.Windows.Forms.PaintEventHandler(this.imgBox_Paint);
            // 
            // menuBar
            // 
            this.menuBar.BackColor = System.Drawing.SystemColors.Control;
            this.menuBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem,
            this.viewMenuItem});
            this.menuBar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuBar.Location = new System.Drawing.Point(0, 0);
            this.menuBar.Name = "menuBar";
            this.menuBar.Size = new System.Drawing.Size(626, 24);
            this.menuBar.TabIndex = 1;
            this.menuBar.Text = "menuStrip1";
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openImageToolStripMenuItem,
            this.openDirectoryToolStripMenuItem});
            this.fileMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.fileMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileMenuItem.Text = "&File";
            // 
            // openImageToolStripMenuItem
            // 
            this.openImageToolStripMenuItem.Name = "openImageToolStripMenuItem";
            this.openImageToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openImageToolStripMenuItem.Text = "Open Image";
            this.openImageToolStripMenuItem.Click += new System.EventHandler(this.openImageToolStripMenuItem_Click);
            // 
            // openDirectoryToolStripMenuItem
            // 
            this.openDirectoryToolStripMenuItem.Name = "openDirectoryToolStripMenuItem";
            this.openDirectoryToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openDirectoryToolStripMenuItem.Text = "Open Directory";
            this.openDirectoryToolStripMenuItem.Click += new System.EventHandler(this.openDirectoryToolStripMenuItem_Click);
            // 
            // viewMenuItem
            // 
            this.viewMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomInToolStripMenuItem,
            this.zoomOutToolStripMenuItem,
            this.resetZoomToolStripMenuItem,
            this.changeBGColorToolStripMenuItem,
            this.toggleStatusBarToolStripMenuItem});
            this.viewMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.viewMenuItem.Name = "viewMenuItem";
            this.viewMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.viewMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewMenuItem.Text = "&View";
            // 
            // zoomInToolStripMenuItem
            // 
            this.zoomInToolStripMenuItem.Name = "zoomInToolStripMenuItem";
            this.zoomInToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.zoomInToolStripMenuItem.Text = "Zoom In";
            this.zoomInToolStripMenuItem.Click += new System.EventHandler(this.zoomInToolStripMenuItem_Click);
            // 
            // zoomOutToolStripMenuItem
            // 
            this.zoomOutToolStripMenuItem.Name = "zoomOutToolStripMenuItem";
            this.zoomOutToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.zoomOutToolStripMenuItem.Text = "Zoom Out";
            this.zoomOutToolStripMenuItem.Click += new System.EventHandler(this.zoomOutToolStripMenuItem_Click);
            // 
            // resetZoomToolStripMenuItem
            // 
            this.resetZoomToolStripMenuItem.Name = "resetZoomToolStripMenuItem";
            this.resetZoomToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.resetZoomToolStripMenuItem.Text = "Reset Zoom";
            this.resetZoomToolStripMenuItem.Click += new System.EventHandler(this.resetZoomToolStripMenuItem_Click);
            // 
            // changeBGColorToolStripMenuItem
            // 
            this.changeBGColorToolStripMenuItem.Name = "changeBGColorToolStripMenuItem";
            this.changeBGColorToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.changeBGColorToolStripMenuItem.Text = "Change BG Color";
            this.changeBGColorToolStripMenuItem.Click += new System.EventHandler(this.changeBGColorToolStripMenuItem_Click);
            // 
            // toggleStatusBarToolStripMenuItem
            // 
            this.toggleStatusBarToolStripMenuItem.Name = "toggleStatusBarToolStripMenuItem";
            this.toggleStatusBarToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.toggleStatusBarToolStripMenuItem.Text = "Toggle Status Bar";
            this.toggleStatusBarToolStripMenuItem.Click += new System.EventHandler(this.toggleStatusBarToolStripMenuItem_Click);
            // 
            // statusBar
            // 
            this.statusBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.statusBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statsFilePath,
            this.statsSize,
            this.statsZoom});
            this.statusBar.Location = new System.Drawing.Point(0, 658);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(626, 24);
            this.statusBar.TabIndex = 2;
            this.statusBar.Text = "statusStrip1";
            // 
            // statsFilePath
            // 
            this.statsFilePath.BackColor = System.Drawing.SystemColors.Control;
            this.statsFilePath.ForeColor = System.Drawing.SystemColors.Control;
            this.statsFilePath.Name = "statsFilePath";
            this.statsFilePath.Size = new System.Drawing.Size(519, 19);
            this.statsFilePath.Spring = true;
            this.statsFilePath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statsSize
            // 
            this.statsSize.BackColor = System.Drawing.SystemColors.Control;
            this.statsSize.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.statsSize.ForeColor = System.Drawing.SystemColors.Control;
            this.statsSize.Name = "statsSize";
            this.statsSize.Size = new System.Drawing.Size(43, 19);
            this.statsSize.Text = "Size:   ";
            // 
            // statsZoom
            // 
            this.statsZoom.BackColor = System.Drawing.SystemColors.Control;
            this.statsZoom.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.statsZoom.ForeColor = System.Drawing.SystemColors.Control;
            this.statsZoom.Name = "statsZoom";
            this.statsZoom.Size = new System.Drawing.Size(49, 19);
            this.statsZoom.Text = "Zoom: ";
            this.statsZoom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // folderDialog
            // 
            this.folderDialog.ShowNewFolderButton = false;
            // 
            // imgPanel
            // 
            this.imgPanel.AutoScroll = true;
            this.imgPanel.BackColor = System.Drawing.Color.Black;
            this.imgPanel.Controls.Add(this.imgBox);
            this.imgPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgPanel.Location = new System.Drawing.Point(0, 24);
            this.imgPanel.Name = "imgPanel";
            this.imgPanel.Size = new System.Drawing.Size(626, 634);
            this.imgPanel.TabIndex = 3;
            // 
            // colorDialog
            // 
            this.colorDialog.FullOpen = true;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(626, 682);
            this.Controls.Add(this.imgPanel);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.menuBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuBar;
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ImgPoo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseWheel);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.imgBox)).EndInit();
            this.menuBar.ResumeLayout(false);
            this.menuBar.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.imgPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        /// <summary>
        /// For custom things the editor shouldn't overwrite in
        /// InitializeComponent().
        /// </summary>
        private void CustomizeComponent() {
            menuBar.BackColor = System.Drawing.Color.FromArgb(16, 16, 16);
            ToolStripManager.Renderer = new ToolStripProfessionalRenderer(new ToolStripColorTable());
            
            foreach (ToolStripMenuItem itm in menuBar.Items) {
                itm.ForeColor = System.Drawing.Color.FromArgb(248, 248, 248);
                ToolStripDropDownMenu dd = itm.DropDown as ToolStripDropDownMenu;
                dd.ShowImageMargin = false;
                dd.BackColor = System.Drawing.Color.FromArgb(16, 16, 16);
                dd.ForeColor = System.Drawing.Color.FromArgb(248, 248, 248);
            }
        }

        private System.Windows.Forms.PictureBox imgBox;
        private System.Windows.Forms.MenuStrip menuBar;
        private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toggleStatusBarToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.OpenFileDialog fileDialog;
        private System.Windows.Forms.FolderBrowserDialog folderDialog;
        private System.Windows.Forms.ToolStripStatusLabel statsFilePath;
        private System.Windows.Forms.ToolStripStatusLabel statsZoom;
        private System.Windows.Forms.ToolStripStatusLabel statsSize;
        private System.Windows.Forms.Panel imgPanel;
        private System.Windows.Forms.ToolStripMenuItem resetZoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeBGColorToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog;
    }
}

