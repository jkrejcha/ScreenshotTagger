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
			btnSave = new Button();
			fswScreenshotDir = new System.IO.FileSystemWatcher();
			pictureBox1 = new PictureBox();
			lbFiles = new ListBox();
			lblUserUntagged = new Label();
			tbNewTag = new TextBox();
			btnAddTag = new Button();
			lbTags = new ListBox();
			lblFilterAfter = new Label();
			dtpFilterAfter = new DateTimePicker();
			tmrAutosave = new Timer(components);
			cbAutosave = new CheckBox();
			((System.ComponentModel.ISupportInitialize)fswScreenshotDir).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			// 
			// btnSave
			// 
			btnSave.Location = new Point(12, 12);
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
			// pictureBox1
			// 
			pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			pictureBox1.Location = new Point(361, 12);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(690, 510);
			pictureBox1.TabIndex = 1;
			pictureBox1.TabStop = false;
			// 
			// lbFiles
			// 
			lbFiles.FormattingEnabled = true;
			lbFiles.ItemHeight = 20;
			lbFiles.Location = new Point(12, 69);
			lbFiles.Name = "lbFiles";
			lbFiles.Size = new Size(343, 164);
			lbFiles.TabIndex = 2;
			lbFiles.SelectedIndexChanged += listBox1_SelectedIndexChanged;
			// 
			// lblUserUntagged
			// 
			lblUserUntagged.AutoSize = true;
			lblUserUntagged.Location = new Point(12, 43);
			lblUserUntagged.Name = "lblUserUntagged";
			lblUserUntagged.Size = new Size(108, 20);
			lblUserUntagged.TabIndex = 3;
			lblUserUntagged.Text = "User Untagged";
			// 
			// tbNewTag
			// 
			tbNewTag.Location = new Point(12, 265);
			tbNewTag.Name = "tbNewTag";
			tbNewTag.PlaceholderText = "New Tag";
			tbNewTag.Size = new Size(216, 27);
			tbNewTag.TabIndex = 4;
			// 
			// btnAddTag
			// 
			btnAddTag.Location = new Point(234, 265);
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
			lbTags.Location = new Point(12, 298);
			lbTags.Name = "lbTags";
			lbTags.Size = new Size(343, 224);
			lbTags.TabIndex = 6;
			// 
			// lblFilterAfter
			// 
			lblFilterAfter.AutoSize = true;
			lblFilterAfter.Location = new Point(12, 239);
			lblFilterAfter.Name = "lblFilterAfter";
			lblFilterAfter.Size = new Size(79, 20);
			lblFilterAfter.TabIndex = 7;
			lblFilterAfter.Text = "Filter After";
			// 
			// dtpFilterAfter
			// 
			dtpFilterAfter.Location = new Point(97, 234);
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
			cbAutosave.Location = new Point(160, 12);
			cbAutosave.Name = "cbAutosave";
			cbAutosave.Size = new Size(138, 24);
			cbAutosave.TabIndex = 9;
			cbAutosave.Text = "Enable Autosave";
			cbAutosave.UseVisualStyleBackColor = true;
			cbAutosave.CheckedChanged += cbAutosave_CheckedChanged;
			// 
			// FormMain
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1059, 527);
			Controls.Add(cbAutosave);
			Controls.Add(dtpFilterAfter);
			Controls.Add(lblFilterAfter);
			Controls.Add(lbTags);
			Controls.Add(btnAddTag);
			Controls.Add(tbNewTag);
			Controls.Add(lblUserUntagged);
			Controls.Add(lbFiles);
			Controls.Add(pictureBox1);
			Controls.Add(btnSave);
			Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			Margin = new Padding(3, 4, 3, 4);
			Name = "FormMain";
			Text = "ScreenshotTagger";
			WindowState = FormWindowState.Maximized;
			FormClosing += FormMain_FormClosing;
			Load += FormMain_Load;
			((System.ComponentModel.ISupportInitialize)fswScreenshotDir).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button btnSave;
		private System.IO.FileSystemWatcher fswScreenshotDir;
		private PictureBox pictureBox1;
		private ListBox lbFiles;
		private Label lblUserUntagged;
		private Button btnAddTag;
		private TextBox tbNewTag;
		private ListBox lbTags;
		private DateTimePicker dtpFilterAfter;
		private Label lblFilterAfter;
		private Timer tmrAutosave;
		private CheckBox cbAutosave;
	}
}
