using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Commands.Use_Case;

namespace DiagramsElementsLibrary.Use_Case;

public class AddRelation : IFigure
{
    public double X { get; set; }
    public double Y { get; set; }
    public double W { get; set; }
    public double H { get; set; }
    public double ActualFontSize { get; set; } = 12;
    public double ActualOffset { get; set; } = 20;
    public Panel Draw(IElement element, Panel panel, int numberOfElements)
    {
        var canvas = new Canvas();
        panel.Children.Add(canvas);
        #region Line
        var relation = new Line();
        relation.X1 = panel.ActualWidth / 20 + (W * 3) / 2;
        relation.Y1 = 0-(panel.ActualHeight * element.Id / 2 / numberOfElements + 2 * H);
        relation.X2 = panel.ActualWidth / 3;
        relation.Y2 = panel.ActualHeight * element.Id / numberOfElements;
        relation.Stroke = Brushes.Black;
        canvas.Children.Add(relation);
        var count = canvas.Children.Count;
      
        #endregion
        return canvas;
    }
}