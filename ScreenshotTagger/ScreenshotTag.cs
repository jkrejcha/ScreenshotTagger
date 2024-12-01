using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenshotTagger
{
	public readonly struct ScreenshotTag
	{
		public Int64 UnixTimestampMs { get; init; }
		public Boolean Auto { get; init; }
		public String Tag { get; init; }
	}
}
