namespace Wordclock.Ui.Win
{
	public class UiPixel : Label
	{
		public UiPixel(int size, string character, int id)
		{
			Text = character;
			ForeColor = Color.Gray;
			BackColor = Color.Black;
			TextAlign = ContentAlignment.MiddleCenter;
			Size = new Size(size, size);
			Font = new Font(Font.FontFamily, 16, FontStyle.Bold);

			PixelId = id;
		}

		public int PixelId { get; }
	}
}
