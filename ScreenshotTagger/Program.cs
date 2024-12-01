using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace ScreenshotTagger
{
	internal static class Program
	{
		private const String PluginsDir = "plugins";
		
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		internal static void Main(String[] args)
		{
			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			ApplicationConfiguration.Initialize();

			// Configure autotag plugins
			List<AutotagPlugin> plugins = [];
			foreach (String file in Directory.GetFiles(PluginsDir, "*.dll", SearchOption.TopDirectoryOnly))
			{
				Assembly pluginAssembly = Assembly.LoadFile(file);
				foreach (Type t in pluginAssembly.GetTypes().Where(t => t.IsSubclassOf(typeof(AutotagPlugin))))
				{
					// TODO: Error checking
					// TODO: Maybe C compat?
					plugins.Add((AutotagPlugin)t.GetConstructor([])!.Invoke([]));
				}
			}

			// Run the app
			Application.Run(new FormMain(plugins, args[0])); // TODO: Error checking
		}
	}
}