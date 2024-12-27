using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScreenshotTagger.Plugin;

namespace ScreenshotTagger
{
	public partial class FormMain : Form
	{
		private const String DatabaseFilename = "data.json";
		/// <summary>
		/// The database, as stored completely in memory. This is brtually
		/// practical and should probably be given more structure very soon.
		/// The 3-tuple is (Unix timestamp (ms), automatically generated, tag string)
		/// and the key is the filename (absolute at the moment)
		/// </summary>
		private Dictionary<String, List<ScreenshotTag>> Database { get; set; } = [];
		private Boolean Dirty { get; set; } = false;
		private String ScreenshotDir { get; set; }
		private List<AutotagPlugin> Plugins { get; set; }

		public FormMain(List<AutotagPlugin> plugins, String dir)
		{
			Plugins = plugins;
			ScreenshotDir = dir;
			InitializeComponent();
			fswScreenshotDir.Path = dir;
			fswScreenshotDir.Filter = "*.*";
		}

		private async void FormMain_Load(object sender, EventArgs e)
		{
			await LoadDatabaseAsync();
		}

		private async Task LoadDatabaseAsync()
		{
			FileStream f = File.Open(DatabaseFilename, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read);
			// TODO: Error checking
			this.Database = (await JsonSerializer.DeserializeAsync<Dictionary<String, List<ScreenshotTag>>>(f))!;
			f.Close();
			UpdateUntaggedList();
			Dirty = false;
			btnSave.Enabled = false;
		}

		private async Task SaveDatabaseAsync(String text = "Saved")
		{
			FileStream f = File.Open(DatabaseFilename, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read);
			// TODO: Error checking
			await JsonSerializer.SerializeAsync(f, this.Database);
			f.Close();
			Dirty = false;
			UpdateLabel(text);
		}

		private void UpdateLabel(String text = "Saved")
		{
			DateTimeOffset now = DateTimeOffset.UtcNow;
			if (InvokeRequired)
			{
				Invoke(() => { lblStatus.Text = $"{text} at {now:g}"; });
			}
			else
			{
				lblStatus.Text = $"{text} at {now:g}";
			}
		}

		private void UpdateUntaggedList()
		{
			lbFiles.Items.Clear();
			foreach (String file in Directory.EnumerateFiles(ScreenshotDir))
			{
				if (File.GetCreationTimeUtc(file) < dtpFilterAfter.Value) continue;
				if (IsUserUntagged(file))
				{
					lbFiles.Items.Add(file.Replace(ScreenshotDir, ""));
				}
			}
		}

		private Boolean IsUserUntagged(String file)
		{
			// If it doesn't exist, it's user untagged
			if (!Database.TryGetValue(file, out List<ScreenshotTag>? value)) return true;
			// If all automatically generated, it's user untagged
			if (value.All(tag => tag.Auto)) return true;
			return false;
		}

		private void fswScreenshotDir_Changed(object sender, FileSystemEventArgs e)
		{
			if (e.ChangeType == WatcherChangeTypes.Deleted) return;
			// Okay at the time that this screenshot exists, capture the state
			// of the world so that we can add some auto-tags to it.
			List<String> tags = Plugins.SelectMany(p => p.OnNewFile(e.FullPath)).ToList();
			Int64 nowTimestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
			foreach (String tag in tags)
			{
				AddTag(e.FullPath, new ScreenshotTag()
				{
					UnixTimestampMs = nowTimestamp,
					Auto = true,
					Tag = tag
				});
			}
			UpdateUntaggedList();
		}

		private void AddTag(String filePath, ScreenshotTag tag)
		{
			if (Database.TryGetValue(filePath, out List<ScreenshotTag>? value))
			{
				value.Add(tag);
			}
			else
			{
				Database[filePath] = [tag];
			}
			Dirty = true;
			btnSave.Enabled = true;
		}

		private String? CurrentlySelectedFile
		{
			get
			{
				if (lbFiles.SelectedItem is null) return null;
				return ScreenshotDir + lbFiles.SelectedItem.ToString();
			}
		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			String file = CurrentlySelectedFile!;
			pbMain.Image = Image.FromFile(file);
			lbTags.Items.Clear();
			foreach (ScreenshotTag tag in Database.GetValueOrDefault(file, []))
			{
				String t = tag.Tag;
				if (tag.Auto) t = "[Auto] " + t;
				lbTags.Items.Add(t);
			}
		}

		private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
		{
			UpdateUntaggedList();
		}

		private void btnAddTag_Click(object sender, EventArgs e)
		{
			AddTag(CurrentlySelectedFile!, new ScreenshotTag()
			{
				UnixTimestampMs = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
				Auto = false,
				Tag = tbNewTag.Text
			});
			tbNewTag.Clear();
			listBox1_SelectedIndexChanged(sender, e);
		}

		private async void FormMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!Dirty) return;
			DialogResult result = MessageBox.Show(
				"You have unsaved changes to the database. Would you like to save your changes?",
				"Unsaved Changes",
				MessageBoxButtons.YesNoCancel,
				MessageBoxIcon.Warning
			);
			if (result == DialogResult.Yes) await SaveDatabaseAsync();
			if (result == DialogResult.Cancel) e.Cancel = true;
		}

		private async void SaveEventHandler(object sender, EventArgs e)
		{
			await SaveDatabaseAsync("Autosaved");
		}

		private void cbAutosave_CheckedChanged(object sender, EventArgs e)
		{
			tmrAutosave.Enabled = cbAutosave.Checked;
		}
	}
}
