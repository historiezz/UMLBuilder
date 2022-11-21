using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DiagramsElementsLibrary.Save;

/// <summary>
/// Class SaveImage.
/// </summary>
public class SaveImage
{
    /// <summary>
    /// Converts to imagesource.
    /// </summary>
    /// <param name="canvas">The canvas.</param>
    /// <param name="filename">The filename.</param>
    public static void ToImageSource(Canvas canvas, string filename)
    {
        var bmp = new System.Windows.Media.Imaging.RenderTargetBitmap((int)canvas.ActualWidth, (int)canvas.ActualHeight,
            96d, 96d, PixelFormats.Pbgra32);
        canvas.Measure(new Size((int)canvas.ActualWidth, (int)canvas.ActualHeight));
        canvas.Arrange(new Rect(new Size((int)canvas.ActualWidth, (int)canvas.ActualHeight)));
        bmp.Render(canvas);
        var encoder = new PngBitmapEncoder();
        encoder.Frames.Add(BitmapFrame.Create(bmp));
        using (var file = File.Create(filename))
        {
            encoder.Save(file);
        }
    }
}