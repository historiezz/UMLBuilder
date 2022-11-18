using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Commands.Use_Case;

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
    public double W { get; set; }
    /// <summary>
    /// Gets or sets the h.
    /// </summary>
    /// <value>The h.</value>
    public double H { get; set; }
    /// <summary>
    /// Draws this instance.
    /// </summary>
    /// <param name="element">The element.</param>
    /// <param name="panel">The panel.</param>
    /// <param name="numberOfElements">The number of elements.</param>
    /// <returns>StackPanel.</returns>
    public Panel Draw(IElement element, Panel panel, int numberOfElements)
    {
        this.W = 100;
        this.H = 50;
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
        Canvas.SetLeft(canvas.Children[count - 1], panel.ActualWidth / 3);
        Canvas.SetTop(canvas.Children[count - 1], panel.ActualHeight * element.Id / numberOfElements);

        #endregion

        #region TextBlock

        var textBlock = new TextBlock()
        {
            Name = "textBlock" + element.Id,
            Text = element.Name,
            TextAlignment = TextAlignment.Center,
            Width = 80,
            Height = 20
        };
        canvas.Children.Add(textBlock);

        Canvas.SetLeft(canvas.Children[count], panel.ActualWidth / 3 + ellipse.Width / 2 - textBlock.Width / 2);
        Canvas.SetTop(canvas.Children[count], panel.ActualHeight * element.Id / numberOfElements + ellipse.Height / 2 - textBlock.Height / 2);

        #endregion

        return canvas;
    }
}