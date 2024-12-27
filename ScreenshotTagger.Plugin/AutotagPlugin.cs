using System;
using System.Collections.Generic;

namespace ScreenshotTagger.Plugin
{
	// TODO: Split core plugin thing so that this doesn't depend on Windows
	/// <summary>
	/// Autotag plugins automatically tag things in predetermined ways.
	/// </summary>
	public abstract class AutotagPlugin
	{
		public abstract List<String> OnNewFile(String filePath);
	}
}