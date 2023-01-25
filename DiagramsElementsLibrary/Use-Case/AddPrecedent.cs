using Commands.Use_Case;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;
using System;

namespace DiagramsElementsLibrary.Use_Case;

/// <summary>
/// Class AddPrecedent.
/// Implements the <see cref="DiagramsElementsLibrary.IFigure" />
/// </summary>
/// <seealso cref="DiagramsElementsLibrary.IFigure" />
public class AddPrecedent : IFigure
{
    /// <summary>
    /// Gets or sets the x.
    /// </summary>
    /// <value>The x.</value>
    public double X { get; set; }
    /// <summary>
    /// Gets or sets the y.
    /// </summary>
    /// <value>The y.</value>
    public double Y { get; set; }

    /// <summary>
    /// Gets or sets the w.
    /// </summary>
    /// <value>The w.</value>
    public double W { get; set; } = 100;

    /// <summary>
    /// Gets or sets the h.
    /// </summary>
    /// <value>The h.</value>
    public double H { get; set; } = 50;

    /// <summary>Gets or sets the actual size of the font.</summary>
    /// <value>The actual size of the font.</value>
    public double ActualFontSize { get; set; } = 12;

    /// <summary>Gets or sets the actual offset.</summary>
    /// <value>The actual offset.</value>
    public double ActualOffset { get; set; } = 20;
    /// <summary>
    /// Draws this instance.
    /// </summary>
    /// <param name="element">The element.</param>
    /// <param name="panel">The panel.</param>
    /// <param name="numberOfElements">The number of elements.</param>
    /// <returns>StackPanel.</returns>
    public Panel Draw(IElement element, Panel panel, int numberOfElements)
    {
        SizeAdaptation(panel, numberOfElements);

        var canvas = new Canvas();
        panel.Children.Add(canvas);

        #region Ellipse

        var ellipse = new Ellipse()
        {
            Width = W,
            Height = H,
            Stroke = Brushes.Black
        };
        canvas.Children.Add(ellipse);

        var count = canvas.Children.Count;
        Canvas.SetLeft(canvas.Children[count - 1], panel.ActualWidth * 2 / 3);
        Canvas.SetTop(canvas.Children[count - 1], panel.ActualHeight * element.Id / numberOfElements);

        #endregion

        #region TextBlock

        var textBlock = new TextBlock()
        {
            Name = "textBlock" + element.Id,
            Text = element.Name,
            TextAlignment = TextAlignment.Center,
            Width = W - ActualOffset,
            Height = H - ActualOffset,
            FontSize = ActualFontSize
        };
        canvas.Children.Add(textBlock);

        Canvas.SetLeft(canvas.Children[count], panel.ActualWidth * 2 / 3 + ellipse.Width / 2 - textBlock.Width / 2);
        Canvas.SetTop(canvas.Children[count], panel.ActualHeight * element.Id / numberOfElements + ellipse.Height / 2 - textBlock.Height / 2);

        #endregion

        return canvas;
    }

    /// <summary>Sizes the adaptation.</summary>
    /// <param name="panel">The panel.</param>
    /// <param name="numberOfElements">The number of elements.</param>
    private void SizeAdaptation(FrameworkElement panel, int numberOfElements)
    {
        while (numberOfElements > (Convert.ToInt32(panel.ActualHeight / H) - 1))
        {
            this.W *= 0.75;
            this.H *= 0.75;
            this.ActualFontSize *= 0.75;
            this.ActualOffset *= 0.75;
        }
    }
}