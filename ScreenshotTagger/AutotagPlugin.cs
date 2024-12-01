using System;
using System.Collections.Generic;

namespace ScreenshotTagger
{
	/// <summary>
	/// Autotag plugins automatically tag things in predetermined ways.
	/// </summary>
	public abstract class AutotagPlugin
	{
		public abstract List<String> OnNewFile(String filePath);
	}
}
