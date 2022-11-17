using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Commands.Use_Case;

namespace DiagramsElementsLibrary.Use_Case;

public class AddPrecedent : IFigure
{
    public double X { get; set; }
    public double Y { get; set; }
    public double W { get; set; }
    public double H { get; set; }
    public Panel Draw(IElement element, Panel panel)
    {
        var canvas = new Canvas();
        panel.Children.Add(canvas);
        #region Formatting

        stackPanel.VerticalAlignment = VerticalAlignment.Center;
        stackPanel.HorizontalAlignment = HorizontalAlignment.Center;

        #endregion

        #region Childrens
        var ellipse = new Ellipse()
        {
            Width = W,
            Height = H,
            Stroke = Brushes.Black

        };
        canvas.Children.Add(ellipse);

        canvas.Children.Add(new TextBlock()
        {
            Text = element.Name,
            TextAlignment = TextAlignment.Center
        });
        #endregion

        return canvas;
    }
}