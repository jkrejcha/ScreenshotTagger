using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using ScreenshotTagger.Plugin;

namespace ScreenshotTagger
{
	internal static class Program
	{
		private const String PluginsDir = "plugins";
		
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		internal static void Main(String[] args)
		{
			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			ApplicationConfiguration.Initialize();

			// Configure autotag plugins
			List<AutotagPlugin> plugins = [];
			List<LogEntry> entries = [];
			foreach (String file in Directory.GetFiles(PluginsDir, "*.dll", SearchOption.TopDirectoryOnly))
			{
				Assembly pluginAssembly = Assembly.LoadFrom(Path.GetFullPath(file));
				try
				{
					foreach (Type t in pluginAssembly.GetTypes().Where(t => t.IsSubclassOf(typeof(AutotagPlugin))))
					{
						// TODO: Error checking
						// TODO: Maybe C compat?
						// TODO: Maybe Python compat?
						plugins.Add((AutotagPlugin)t.GetConstructor([])!.Invoke([]));
					}
				}
				catch (Exception e)
				{
					entries.Add(new LogEntry() { Text = $"Failed to load plugin file ({file}): {e.Message}" });
					// TODO: Handle this
				}
			}

			String dirName;
			if (args.Length >= 1)
			{
				dirName = args[0];
			}
			else
			{
				FolderBrowserDialog fbd = new FolderBrowserDialog()
				{
					Description = "Choose a directory to monitor..."
				};
				if (fbd.ShowDialog() == DialogResult.OK)
				{
					dirName = fbd.SelectedPath;
				}
				else
				{
					return;
				}
			}

			// Run the app
			Application.Run(new FormMain(plugins, entries, dirName));
		}
	}
}