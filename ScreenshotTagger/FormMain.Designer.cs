using System.Drawing;
using System.Windows.Forms;

namespace ScreenshotTagger
{
	partial class FormMain
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
			btnSave = new Button();
			fswScreenshotDir = new System.IO.FileSystemWatcher();
			pbMain = new PictureBox();
			lbFiles = new ListBox();
			lblUserUntagged = new Label();
			tbNewTag = new TextBox();
			btnAddTag = new Button();
			lbTags = new ListBox();
			lblFilterAfter = new Label();
			dtpFilterAfter = new DateTimePicker();
			tmrAutosave = new Timer(components);
			cbAutosave = new CheckBox();
			tcMain = new TabControl();
			tpUserUntagged = new TabPage();
			lblStatus = new Label();
			tpInfo = new TabPage();
			lblInfoText = new Label();
			((System.ComponentModel.ISupportInitialize)fswScreenshotDir).BeginInit();
			((System.ComponentModel.ISupportInitialize)pbMain).BeginInit();
			tcMain.SuspendLayout();
			tpUserUntagged.SuspendLayout();
			tpInfo.SuspendLayout();
			SuspendLayout();
			// 
			// btnSave
			// 
			btnSave.Location = new Point(6, 6);
			btnSave.Name = "btnSave";
			btnSave.Size = new Size(142, 28);
			btnSave.TabIndex = 0;
			btnSave.Text = "Save Database";
			btnSave.UseVisualStyleBackColor = true;
			btnSave.Click += SaveEventHandler;
			// 
			// fswScreenshotDir
			// 
			fswScreenshotDir.EnableRaisingEvents = true;
			fswScreenshotDir.SynchronizingObject = this;
			fswScreenshotDir.Changed += fswScreenshotDir_Changed;
			// 
			// pbMain
			// 
			pbMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			pbMain.Location = new Point(355, 6);
			pbMain.Name = "pbMain";
			pbMain.Size = new Size(658, 532);
			pbMain.TabIndex = 1;
			pbMain.TabStop = false;
			// 
			// lbFiles
			// 
			lbFiles.FormattingEnabled = true;
			lbFiles.ItemHeight = 20;
			lbFiles.Location = new Point(6, 86);
			lbFiles.Name = "lbFiles";
			lbFiles.Size = new Size(343, 164);
			lbFiles.TabIndex = 2;
			lbFiles.SelectedIndexChanged += listBox1_SelectedIndexChanged;
			// 
			// lblUserUntagged
			// 
			lblUserUntagged.AutoSize = true;
			lblUserUntagged.Location = new Point(6, 60);
			lblUserUntagged.Name = "lblUserUntagged";
			lblUserUntagged.Size = new Size(108, 20);
			lblUserUntagged.TabIndex = 3;
			lblUserUntagged.Text = "User Untagged";
			// 
			// tbNewTag
			// 
			tbNewTag.Location = new Point(6, 282);
			tbNewTag.Name = "tbNewTag";
			tbNewTag.PlaceholderText = "New Tag";
			tbNewTag.Size = new Size(216, 27);
			tbNewTag.TabIndex = 4;
			// 
			// btnAddTag
			// 
			btnAddTag.Location = new Point(228, 282);
			btnAddTag.Name = "btnAddTag";
			btnAddTag.Size = new Size(121, 27);
			btnAddTag.TabIndex = 5;
			btnAddTag.Text = "Add Tag";
			btnAddTag.UseVisualStyleBackColor = true;
			btnAddTag.Click += btnAddTag_Click;
			// 
			// lbTags
			// 
			lbTags.FormattingEnabled = true;
			lbTags.ItemHeight = 20;
			lbTags.Location = new Point(6, 315);
			lbTags.Name = "lbTags";
			lbTags.Size = new Size(343, 224);
			lbTags.TabIndex = 6;
			// 
			// lblFilterAfter
			// 
			lblFilterAfter.AutoSize = true;
			lblFilterAfter.Location = new Point(6, 256);
			lblFilterAfter.Name = "lblFilterAfter";
			lblFilterAfter.Size = new Size(79, 20);
			lblFilterAfter.TabIndex = 7;
			lblFilterAfter.Text = "Filter After";
			// 
			// dtpFilterAfter
			// 
			dtpFilterAfter.Location = new Point(91, 251);
			dtpFilterAfter.Name = "dtpFilterAfter";
			dtpFilterAfter.Size = new Size(258, 27);
			dtpFilterAfter.TabIndex = 8;
			dtpFilterAfter.ValueChanged += dateTimePicker1_ValueChanged;
			// 
			// tmrAutosave
			// 
			tmrAutosave.Enabled = true;
			tmrAutosave.Interval = 60000;
			tmrAutosave.Tick += SaveEventHandler;
			// 
			// cbAutosave
			// 
			cbAutosave.AutoSize = true;
			cbAutosave.Checked = true;
			cbAutosave.CheckState = CheckState.Checked;
			cbAutosave.Location = new Point(154, 6);
			cbAutosave.Name = "cbAutosave";
			cbAutosave.Size = new Size(138, 24);
			cbAutosave.TabIndex = 9;
			cbAutosave.Text = "Enable Autosave";
			cbAutosave.UseVisualStyleBackColor = true;
			cbAutosave.CheckedChanged += cbAutosave_CheckedChanged;
			// 
			// tcMain
			// 
			tcMain.Controls.Add(tpUserUntagged);
			tcMain.Controls.Add(tpInfo);
			tcMain.Dock = DockStyle.Fill;
			tcMain.Location = new Point(0, 0);
			tcMain.Name = "tcMain";
			tcMain.SelectedIndex = 0;
			tcMain.Size = new Size(1027, 577);
			tcMain.TabIndex = 10;
			// 
			// tpUserUntagged
			// 
			tpUserUntagged.Controls.Add(lblStatus);
			tpUserUntagged.Controls.Add(btnSave);
			tpUserUntagged.Controls.Add(cbAutosave);
			tpUserUntagged.Controls.Add(pbMain);
			tpUserUntagged.Controls.Add(dtpFilterAfter);
			tpUserUntagged.Controls.Add(lbFiles);
			tpUserUntagged.Controls.Add(lblFilterAfter);
			tpUserUntagged.Controls.Add(lblUserUntagged);
			tpUserUntagged.Controls.Add(lbTags);
			tpUserUntagged.Controls.Add(tbNewTag);
			tpUserUntagged.Controls.Add(btnAddTag);
			tpUserUntagged.Location = new Point(4, 29);
			tpUserUntagged.Name = "tpUserUntagged";
			tpUserUntagged.Padding = new Padding(3);
			tpUserUntagged.Size = new Size(1019, 544);
			tpUserUntagged.TabIndex = 0;
			tpUserUntagged.Text = "User Untagged";
			tpUserUntagged.UseVisualStyleBackColor = true;
			// 
			// lblStatus
			// 
			lblStatus.AutoSize = true;
			lblStatus.Location = new Point(6, 37);
			lblStatus.Name = "lblStatus";
			lblStatus.Size = new Size(0, 20);
			lblStatus.TabIndex = 10;
			// 
			// tpInfo
			// 
			tpInfo.Controls.Add(lblInfoText);
			tpInfo.Location = new Point(4, 29);
			tpInfo.Name = "tpInfo";
			tpInfo.Padding = new Padding(3);
			tpInfo.Size = new Size(1019, 544);
			tpInfo.TabIndex = 1;
			tpInfo.Text = "Info";
			tpInfo.ToolTipText = "Information on plugin status, selected folder, etc";
			tpInfo.UseVisualStyleBackColor = true;
			// 
			// lblInfoText
			// 
			lblInfoText.AutoSize = true;
			lblInfoText.Location = new Point(8, 13);
			lblInfoText.Name = "lblInfoText";
			lblInfoText.Size = new Size(154, 20);
			lblInfoText.TabIndex = 0;
			lblInfoText.Text = "Loading information...";
			// 
			// FormMain
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1027, 577);
			Controls.Add(tcMain);
			Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Margin = new Padding(3, 4, 3, 4);
			Name = "FormMain";
			Text = "ScreenshotTagger";
			WindowState = FormWindowState.Maximized;
			FormClosing += FormMain_FormClosing;
			Load += FormMain_Load;
			((System.ComponentModel.ISupportInitialize)fswScreenshotDir).EndInit();
			((System.ComponentModel.ISupportInitialize)pbMain).EndInit();
			tcMain.ResumeLayout(false);
			tpUserUntagged.ResumeLayout(false);
			tpUserUntagged.PerformLayout();
			tpInfo.ResumeLayout(false);
			tpInfo.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private Button btnSave;
		private System.IO.FileSystemWatcher fswScreenshotDir;
		private PictureBox pbMain;
		private ListBox lbFiles;
		private Label lblUserUntagged;
		private Button btnAddTag;
		private TextBox tbNewTag;
		private ListBox lbTags;
		private DateTimePicker dtpFilterAfter;
		private Label lblFilterAfter;
		private Timer tmrAutosave;
		private CheckBox cbAutosave;
		private TabControl tcMain;
		private TabPage tpUserUntagged;
		private Label lblStatus;
		private TabPage tpInfo;
		private Label lblInfoText;
	}
}
