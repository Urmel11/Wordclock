using FluentAssertions;
using NUnit.Framework;
using System.Drawing;
using Wordclock.Core.Layout;

namespace Wordclock.Core.Tests.Layout
{
	class PixelTests
	{
		public class IsChangedProperty : PixelTests
		{
			[Test]
			public void Returns_True_If_PixelColor_Changed()
			{
				var pixel = new Pixel(0);

				pixel.AcceptChanges();

				pixel.PixelColor = Color.Black;

				pixel.IsChanged.Should().BeTrue();
			}

			[Test]
			public void Returns_True_After_Pixel_Was_Instantiated()
			{
				var pixel = new Pixel(0);

				pixel.IsChanged.Should().BeTrue();
			}

			[Test]
			public void Returns_False_If_PixelColor_Was_Set_To_Original_Color()
			{
				var pixel = new Pixel(0);

				pixel.PixelColor = Color.Yellow;

				pixel.AcceptChanges();

				pixel.PixelColor = Color.Yellow;

				pixel.IsChanged.Should().BeFalse();
			}
		}
	}
}
